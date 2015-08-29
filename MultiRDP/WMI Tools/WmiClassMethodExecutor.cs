using System;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MultiRDP.WMI_Tools
{
    /*
     * Some notes here
     * 
     * ManagementBaseObject is more of a container than anything. It is used to hold values from user input as well as
     * input from a WMI process, be that a query, or method execution. Think of it as a collection of information, 
     * specifically tailored for only WMI.
     * 
     * This class isn't meant to be informational, however, for sake of sanity and ease of use, a couple of informational
     * methods have been included here, in order to better assist the operator with executing the methods of a particular
     * WMI class. This class should not be used for gathering information from WMI. Instead, utilize WmiInformationGatherer
     * 
     * Written by Christopher Albert v0.1 Saturday, 22 November, 2014
     */


    //TODO: Clean up results display. Return an object containing information regarding execution or errors. ****PERFORM CHECKING ON INFORMATION INPUT, WITH EXCEPTION HANDLING****
    //TODO: Finish implementing the ability to target multiple computers at once
    //TODO: Try to find a way to cleanly allow multiple method execution (highly doubtful that it will be clean)
    class WmiClassMethodExecutor
    {
        private ManagementPath mRemoteWmiPath; //will be c'tord with user input for the system name, and the root of the WMI repository
        private ManagementPath[] mRemoteWmiPaths; //
        private ManagementClass mTargetWmiClass; //use to target a specific WMI class for method execution, by supplying a ManagementPath as well as the namespace and class name
        private ManagementClass[] mTargetWmiClasses;
        private ManagementBaseObject mTargetWmiClassMethodInputParameters; //use to gather and inject parameters of mTargetWmiClass' chosen method (also used to choose that method)
        private ManagementBaseObject[] mMultipleTargetWmiClassMethodInputParameters;
        private ManagementBaseObject mTargetWmiClassMethodOutput; //use to store results of executing the method in mTargetWmiClass
        private Form mResultsForm; //ghost form used for optionally displaying the results of a query against a specific WMI class
        
        
        #region C'tors

        /// <summary>
        /// This constructor requires the target system name, the target namespace, and the target WMI class to be worked with. Allows fine grain control over the WMI experience
        /// : is already appended automatically, so only input the namespace. 
        /// </summary>
        /// <param name="pComputerName"></param>
        /// <param name="pWmiNameSpace"></param>
        /// <param name="pTargetWmiClass"></param>
        public WmiClassMethodExecutor(string pComputerName, string pWmiNameSpace, string pTargetWmiClass)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pComputerName + @"\root"); //targets the root of WBEM
            mTargetWmiClass = new ManagementClass(mRemoteWmiPath + @"\" + pWmiNameSpace + ":" + pTargetWmiClass);
        }

        /// <summary>
        /// Defaults to the WMI namespace \root\cimv2: for operation. Requires a computer name and target class
        /// </summary>
        /// <param name="pComputerName"></param>
        /// <param name="pTargetWmiClass"></param>
        public WmiClassMethodExecutor(string pComputerName, string pTargetWmiClass)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pComputerName + @"\root");
            mTargetWmiClass = new ManagementClass(mRemoteWmiPath + @"\cimv2:" + pTargetWmiClass);
        }

        /// <summary>
        /// Creates a collection of target WMI classes for each computer and targets \root\cimv2: on each system
        /// </summary>
        /// <param name="pComputerNames"></param>
        /// <param name="pTargetWmiClass"></param>
        public WmiClassMethodExecutor(string[] pComputerNames, string pTargetWmiClass)
        {
            mRemoteWmiPaths = new ManagementPath[pComputerNames.Length];
            mTargetWmiClasses = new ManagementClass[pComputerNames.Length];

            for (int i = 0; i < mRemoteWmiPaths.Length; i++)
            {
                mRemoteWmiPaths[i] = new ManagementPath(@"\\" + pComputerNames[i] + @"\root");
                mTargetWmiClasses[i] = new ManagementClass(mRemoteWmiPaths[i] + @"\cimv2:" + pTargetWmiClass);
            }
        }
        #endregion

        #region Execution Setup

        

        /// <summary>
        /// Selects a single method from the chosen WMI Class this object was instantiated with
        /// </summary>
        /// <param name="pTargetMethod"></param>
        public void SelectTargetMethodFromWmiClass(string pTargetMethod)
        {
            try
            {
                mTargetWmiClassMethodInputParameters = mTargetWmiClass.GetMethodParameters(@pTargetMethod);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                MessageBox.Show(e.Message.ToString() + "\r\nIt is likely that the targeted system is offline or having network issues.\r\nCheck the remote system");
                return;
            }
            
        }

        /// <summary>
        /// Selects multiple methods from the chosen WMI Class this object was instantiated with
        /// </summary>
        /// <param name="pTargetMethods"></param>
        public void SelectTargetMethodsFromWmiClass(string[] pTargetMethods)
        {
            mMultipleTargetWmiClassMethodInputParameters = new ManagementBaseObject[pTargetMethods.Length];
            for (int i = 0; i < mMultipleTargetWmiClassMethodInputParameters.Length; i++)
            {
                mMultipleTargetWmiClassMethodInputParameters[i] = mTargetWmiClass.GetMethodParameters(pTargetMethods[i]);
            }
        }

        #region verbose methods

        /// <summary>
        /// This method allows multiple parameters to be selected for the chosen WMI Class method, and their arguments to be set using CIM_STRING as the value
        /// </summary>
        /// <param name="pTargetMethodParameter"></param>
        /// <param name="pValues"></param>
        public void SetTargetMethodMultipleParametersString(string[] pTargetMethodParameter, string[] pValues) 
        {
            for (int i = 0; i < pTargetMethodParameter.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameter[i]] = pValues[i];            
            }            
        }

        public void SetTargetMethodMultipleParametersSingleValueString(string[] pTargetMethodParameters, string pValue)
        {
            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValue;
            }
        }

        /// <summary>
        /// This method will set a parameter for the chosen WMI Class method, using CIM_SINT32 as the value
        /// </summary>
        /// <param name="pTargetMethodParameter"></param>
        /// <param name="pValues"></param>
        public void SetTargetMethodParameterString(string pTargetMethodParameter, string pValues)
        {
            try
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameter] = pValues;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message + "\r\nA WMI Class wasn't properly initalized. This can be caused by the remote host not being available, or by instantiating this WMIClassMethodExecutor class improperly. Please check your code");
                throw;
            }            
        }

        /// <summary>
        /// This method allows multiple parameters to be selected for the chosen WMI Class method, and their arguments to be set using CIM_SINT32 as the value
        /// </summary>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pParameters"></param>
        public void SetTargetMethodMultipleParametersInt(string[] pTargetMethodParameters, int[] pValues) 
        {
            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValues[i];
            }
        }

        /// <summary>
        /// This method will set a parameter for the chosen WMI Class method, using CIM_SINT32 as the value
        /// </summary>
        /// <param name="pTargetMethodParameter"></param>
        /// <param name="pValue"></param>
        public void SetTargetMethodParameterInt(string pTargetMethodParameter, int pValue)
        {
            mTargetWmiClass[pTargetMethodParameter] = pValue;
        }

        /// <summary>
        /// This method allows multiple parameters to be selected from the chosen WMI Class method, and a single argument to be set for all of them, using CIM_SINT32 as the value
        /// </summary>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pValue"></param>
        public void SetTargetMethodMultipleParametersSingleValueInt(string[] pTargetMethodParameters, int pValue)
        {
            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValue;
            }            
        }

        #endregion

        #region Generic Methods

        /// <summary>
        /// This method allows a single parameter to be selected from the chosen WMI Class, and allows a generic type to be chosen for it's value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethodParameter"></param>
        /// <param name="pValue"></param>
        public void SetTargetMethodParameterSingleGen<T>(string pTargetMethodParameter, T pValue)
        {
            mTargetWmiClassMethodInputParameters[pTargetMethodParameter] = pValue;
        }

        /// <summary>
        /// This method allows multiple paramaters to be selected from the chosen WMI class, and allows a generic type to be assigned to all of them
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pValue"></param>
        public void SetTargetMethodParameterMultipleGen<T>(string[] pTargetMethodParameters, T pValue)
        {
            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValue;
            }
        }

        /// <summary>
        /// This method allows multiple parameters to be selected from the chosen WMI class, and allows each of them to be assigned a unique generic value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pValue"></param>
        public void SetTargetMethodParameterMultipleGen<T>(string[] pTargetMethodParameters, T[] pValues)
        {
            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValues[i];
            }
        }

        /// <summary>
        /// This method allows for the selection and value setting of multiple parameters from a manually chosen method, and will execute after setting the parameters. Option of displaying method exectution results
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pValues"></param>
        public void SetThenExecuteTargetMethodGen<T>(string pMethod, string[] pTargetMethodParameters, T[] pValues, bool pDisplayMethodOperationResults)
        {
            mTargetWmiClassMethodInputParameters = mTargetWmiClass.GetMethodParameters(@pMethod);

            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {                
                mTargetWmiClassMethodInputParameters[pTargetMethodParameters[i]] = pValues[i];
            }

            mTargetWmiClassMethodOutput = mTargetWmiClass.InvokeMethod(pMethod, mTargetWmiClassMethodInputParameters, null);

            if (pDisplayMethodOperationResults)
            {
                List<string> methodExecutionResults = new List<string>();
                foreach (PropertyData methodResult in mTargetWmiClassMethodOutput.Properties)
                {
                    methodExecutionResults.Add(methodResult.Name);
                }
                GenerateResultsWindow(methodExecutionResults, null, "Execution results of method: " + pMethod, true);
            }
        }

        #endregion

        #endregion

        #region Method Execution
        //TODO: Clean this shit up. I should be returning formatted objects with accessable properties, as opposed to forms


        /// <summary>
        /// This method is used for executing the specified method
        /// </summary>
        /// <param name="pMethod"></param>
        /// <param name="pDisplayTargetMethodResults"></param>
        public void ExecuteTargetMethod(string pMethod, bool pDisplayTargetMethodResults)
        {
            mTargetWmiClassMethodOutput = mTargetWmiClass.InvokeMethod(pMethod, mTargetWmiClassMethodInputParameters, null);

            if (pDisplayTargetMethodResults)
            {
                List<string> methodExecutionResults = new List<string>();
                foreach (PropertyData methodResult in mTargetWmiClassMethodOutput.Properties)
                {
                    methodExecutionResults.Add(methodResult.Name);
                }
                GenerateResultsWindow(methodExecutionResults, null, "Execution results of method: " + pMethod, true);
            }
        }

        

        #endregion


        #region Information

        public void GetTargetClassMethods()//calling this method will display all of the available methods of the WMI class that this class was instantiated with
        {
            List<string> classMethodResults = new List<string>();
            foreach (MethodData methodName in mTargetWmiClass.Methods)
            {
                classMethodResults.Add(methodName.Name);
            }

            GenerateResultsWindow(classMethodResults, null, mTargetWmiClass.ClassPath.ToString() + " Method Query Results", false);
        }

        public void GetTargetMethodParameters(string pTargetMethod)//calling this method will display all of the available methods within the WMI Class this object was instantiated with
        {
            mTargetWmiClassMethodInputParameters = mTargetWmiClass.GetMethodParameters(@pTargetMethod);

            List<string> classPropertyResults = new List<string>();
            foreach (PropertyData item in mTargetWmiClassMethodInputParameters.Properties)
            {
                classPropertyResults.Add(item.Name + "::" + item.Type);
            }

            GenerateResultsWindow(classPropertyResults, null, mTargetWmiClass.ClassPath.ToString() + " Param results for method: " + pTargetMethod, false);
        }

        private void GenerateResultsWindow(List<string> pResultStrings, int[] pResultInts, string pFormTitle, bool pMethodExecuted)
        {
            TextBox resultsTextBox = new TextBox();
            mResultsForm = new Form();
            mResultsForm.Width = 601;
            mResultsForm.Height = 400;
            mResultsForm.Controls.Add(resultsTextBox);
            mResultsForm.Text = pFormTitle;
            resultsTextBox.Location = new Point(0, 0);
            resultsTextBox.Size = new Size(600, 399);
            resultsTextBox.Multiline = true;
            resultsTextBox.Visible = true;
            resultsTextBox.Enabled = true;

            if (pMethodExecuted)
            {
                foreach (string result in pResultStrings)
                {
                    resultsTextBox.AppendText(result + ": " + mTargetWmiClassMethodOutput[result]);
                    resultsTextBox.AppendText(Environment.NewLine);
                }
                mResultsForm.Show();
            }
            else
            {
                foreach (string result in pResultStrings)
                {
                    resultsTextBox.AppendText(result);
                    resultsTextBox.AppendText(Environment.NewLine);
                }
                mResultsForm.Show();
            }
        }
        #endregion
    }
}

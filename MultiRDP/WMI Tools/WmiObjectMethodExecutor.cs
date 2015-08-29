using System;
using System.Management;
using System.Collections.Generic;


namespace MultiRDP.WMI_Tools
{
    /*
     *NOTES: This was just a quick hash out of the ability to execute methods on Instances of WMI classes.
     *There is enough here to execute methods, but nothing else. Bare bones as I could possibly make it.
     *Allows someone who knows the WMI structure to access the specific instance they want, and to execute
     *whatever method(s) it contains with multiple parameter options. Has not yet been fleshed out with
     *Planned features. No information returned from this class yet.
     * 
     */


    internal class ExecutionResults
    {

    }


    class WmiObjectMethodExecutor
    {
        private ManagementObject mTargetWmiClassInstance;
        private ManagementPath mRemoteWmiPath;
        private ManagementBaseObject mTargetClassInstanceMethodInputParameters;
        private ManagementBaseObject mTargetClassInstanceMethodOutput;
                
        //TODO: Implement results return.
        //TODO: Extend class ability. Multiple systems, multiple methods, maybe multiple classes (that one is kind of pipe dreamish without a decent interface)
        //TODO: Flesh out the methods with normal types? There is a chance a beginner programmer may know about WMI and not understand how generics work.
        //Talk to shane, see what he thinks about trying to layout simple methods to include all skill levels.

        /// <summary>
        /// This constructor is used to set a new WMI Path and WMI class with custom chosen parameters. Root is automatically targeted, and : is already
        /// appended to the namespace. Only input a namespace, such as CIMV2
        /// </summary>
        /// <param name="pComputerName"></param>
        /// <param name="pNameSpace"></param>
        /// <param name="pTargetClassInstance"></param>
        public WmiObjectMethodExecutor(string pComputerName, string pNameSpace, string pTargetClassInstance)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pComputerName + @"\root");
            mTargetWmiClassInstance = new ManagementObject(mRemoteWmiPath + @"\" + pNameSpace + ":" + pTargetClassInstance);
        }

        /// <summary>
        /// 1:1 selection of a method parameter and it's value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethod"></param>
        /// <param name="pValue"></param>
        public void SetParamThenExecuteTargetMethodGen<T>(string pTargetMethod, string pTargetMethodParameter, T pValue)
        {
            mTargetClassInstanceMethodInputParameters = mTargetWmiClassInstance.GetMethodParameters(pTargetMethod);

            mTargetClassInstanceMethodInputParameters[pTargetMethodParameter] = pValue;

            mTargetClassInstanceMethodOutput = mTargetWmiClassInstance.InvokeMethod(pTargetMethod, mTargetClassInstanceMethodInputParameters, null);
        }

        /// <summary>
        /// Many:1 selection of method parameters and setting them all with one value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethod"></param>
        /// <param name="pTargetmethodParameters"></param>
        /// <param name="pValue"></param>
        public void SetParamsThenExecuteTargetMethodGen<T>(string pTargetMethod, string[] pTargetmethodParameters, T pValue)
        {
            mTargetClassInstanceMethodInputParameters = mTargetWmiClassInstance.GetMethodParameters(pTargetMethod);

            for (int i = 0; i < pTargetmethodParameters.Length; i++)
            {
                mTargetClassInstanceMethodInputParameters[pTargetmethodParameters[i]] = pValue;
            }

            mTargetClassInstanceMethodOutput = mTargetWmiClassInstance.InvokeMethod(pTargetMethod, mTargetClassInstanceMethodInputParameters, null);
        }

        /// <summary>
        /// Many:Many selection of method parameters and setting them all with individual values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pTargetMethod"></param>
        /// <param name="pTargetMethodParameters"></param>
        /// <param name="pValues"></param>
        public void SetParamsThenExecuteTargetMethodGen<T>(string pTargetMethod, string[] pTargetMethodParameters, T[] pValues)
        {
            mTargetClassInstanceMethodInputParameters = mTargetWmiClassInstance.GetMethodParameters(pTargetMethod);

            for (int i = 0; i < pTargetMethodParameters.Length; i++)
            {
                mTargetClassInstanceMethodInputParameters[pTargetMethodParameters[i]] = pValues[i];
            }

            mTargetClassInstanceMethodOutput = mTargetWmiClassInstance.InvokeMethod(pTargetMethod, mTargetClassInstanceMethodInputParameters, null);
        }
    }
}

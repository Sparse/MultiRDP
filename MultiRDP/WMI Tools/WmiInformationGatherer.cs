using System;
using System.Management;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MultiRDP.WMI_Tools
{
    class WmiInformationGatherer
    {
        private List<ManagementClass> mTargetWmiClasses; //FUTURE USE: Plan for multi-class targeting
        private ManagementObject mTargetWmiClassInstance;
        private ManagementObjectSearcher mObjectSearcher;
        private ManagementPath mRemoteWmiPath;
        private ManagementPath mLocalManagementPath = new ManagementPath(@"\\localhost\root");        
        private ObjectQuery mObjectQuery;

        public List<string> AvailableWMINamespaces = new List<string>();
        public string ConnectedHost;
        public Exception RemoteHostError;

        #region C'tor

        /// <summary>
        /// Targets a WMI class instance in the WBEM Namespace of root\cimv2: of the specified computer. 
        /// </summary>
        /// <param name="pTargetWmiClass"></param>
        /// <param name="pHostName"></param>
        /// 
        public WmiInformationGatherer(string pTargetWmiClassInstance, string pHostName)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pHostName + @"\root");
            mTargetWmiClassInstance = new ManagementObject(mRemoteWmiPath + @"\" + "cimv2" + ":" + pTargetWmiClassInstance);
        }


        public WmiInformationGatherer(string pNamespace, string pHostName)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pHostName + @"\root\" + pNamespace + ":");

        }

        /// <summary>
        /// This C'tor will query a specified system for all available namespaces under WBEM\Root. A singular remote host can be specified.
        /// If any errors occur, they will be placed in the public variable RemoteHostError. Please use that variable for error handling.
        /// </summary>
        public WmiInformationGatherer(string pRemoteHost)
        {
            if (pRemoteHost == "" || pRemoteHost == "127.0.0.1" || pRemoteHost == "localhost" || pRemoteHost == "::1")
            {
                pRemoteHost = "localhost";             
            }

            try
            {
                ConnectedHost = pRemoteHost;
                mObjectQuery = new ObjectQuery("select * from __Namespace");
                mObjectSearcher = new ManagementObjectSearcher(new ManagementScope(new ManagementPath(@"\\" + pRemoteHost + @"\root")), mObjectQuery);
                ManagementObjectCollection gatheredNamespaces = mObjectSearcher.Get();
                ManagementObjectCollection.ManagementObjectEnumerator namespaceEnumerator = gatheredNamespaces.GetEnumerator();
                while (namespaceEnumerator.MoveNext())
                {
                    foreach (PropertyData WmiNamespace in namespaceEnumerator.Current.Properties)
                    {
                        AvailableWMINamespaces.Add(WmiNamespace.Value.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                RemoteHostError = e;
            }                       
        }

        #endregion

        public void WmiClassScavenge(string pWmiNamespace)
        {

        }


        public string GetPropertyValue(string pProperty)
        {
            return mTargetWmiClassInstance[pProperty].ToString();
        }
    }
}

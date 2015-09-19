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

        
        public WmiResult WmiResults;

        #region C'tor

        /// <summary>
        /// This C'tor will query a specified system for all available namespaces under WBEM\Root. A singular remote host can be specified.
        /// If any errors occur, they will be placed in the public variable WmiResult.WmiError object, which is publically accessable here. Please use that obect for error handling.
        /// </summary>
        public WmiInformationGatherer(string pRemoteHost)
        {
            if (pRemoteHost == "" || pRemoteHost == "127.0.0.1" || pRemoteHost == "localhost" || pRemoteHost == "::1")
            {
                pRemoteHost = "localhost";
            }

            try
            {
                WmiResults = new WmiResult(pRemoteHost);
                mObjectQuery = new ObjectQuery("select * from __Namespace");
                mObjectSearcher = new ManagementObjectSearcher(new ManagementScope(new ManagementPath(@"\\" + pRemoteHost + @"\root")), mObjectQuery);
                ManagementObjectCollection gatheredNamespaces = mObjectSearcher.Get();
                ManagementObjectCollection.ManagementObjectEnumerator namespaceEnumerator = gatheredNamespaces.GetEnumerator();
                WmiResults.PopulateNamespaceList(gatheredNamespaces);
            }
            catch (Exception e)
            {
                WmiResults.WmiError = e;
            }
        }

        /// <summary>
        /// Targets the specified namespace on a specified computer, and scavenges it for all classes, if the bool is set to true. If false, it is used to setup the ManagementPath which
        /// consists of the specified system and specified namespace
        /// </summary>
        /// <param name="pNamespace"></param>
        /// <param name="pHostName"></param>
        public WmiInformationGatherer(string pNamespace, string pHostName, bool pScavenge)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pHostName + @"\root\" + pNamespace);

            if (pScavenge)
            {
                try
                {
                    ManagementClass managementClass = new ManagementClass(mRemoteWmiPath);
                    EnumerationOptions scavengeOptions = new EnumerationOptions();
                    scavengeOptions.EnumerateDeep = false;
                    WmiResults = new WmiResult(pHostName);
                    WmiResults.PopulateClassesList(managementClass.GetSubclasses());
                }
                catch (Exception e)
                {
                    WmiResults.WmiError = e;
                }
            }
        }

        /// <summary>
        /// Targets a WMI class in the specified Namespace of WBEM, on the specified remote computer
        /// </summary>
        /// <param name="pTargetWmiClass"></param>
        /// <param name="pHostName"></param>
        /// 
        public WmiInformationGatherer(string pTargetWmiClassInstance, string pNamespace, string pHostName)
        {
            mRemoteWmiPath = new ManagementPath(@"\\" + pHostName + @"\root");
            mTargetWmiClassInstance = new ManagementObject(mRemoteWmiPath + @"\" + pNamespace + ":" + pTargetWmiClassInstance);
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

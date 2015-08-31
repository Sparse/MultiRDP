using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace MultiRDP.WMI_Tools
{
    class WmiResult
    {
        public List<string> Namespaces;
        public List<string> Classes;
        public List<string> Methods;
        public List<string> Properties;
        public string ConnectedHost;
        public ManagementObjectCollection CollectedNamespaces;
        public ManagementObjectCollection CollectedClasses;
        public ManagementObjectCollection CollectedMethods;
        public ManagementObjectCollection CollectedProperties;
        public Exception WmiError;


        public WmiResult PopulateNamespaceList(ManagementObjectCollection pGatheredNamespaces)
        {
            Namespaces = new List<string>();
            CollectedNamespaces = pGatheredNamespaces;
            ManagementObjectCollection.ManagementObjectEnumerator namespaceEnumerator = pGatheredNamespaces.GetEnumerator();

            while (namespaceEnumerator.MoveNext())
            {
                foreach (PropertyData item in namespaceEnumerator.Current.Properties)
                {
                    Namespaces.Add(item.Value.ToString());
                }   
            }                     
            return this;
        }

        public WmiResult PopulateClassesList(ManagementObjectCollection pManagementClasses)
        {
            Classes = new List<string>();
            CollectedClasses = pManagementClasses;

            foreach (ManagementObject WmiClass in pManagementClasses)
            {
                Classes.Add(WmiClass["__Class"].ToString());
            }
            return this;
        }
    }
}

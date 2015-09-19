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
        public List<string> Namespaces { get; private set; }
        public List<string> Classes { get; private set; }
        public List<string> Methods { get; private set; }
        public List<string> Properties { get; private set; }
        public string ConnectedHost { get; private set; }        
        public ManagementObjectCollection CollectedNamespaces { get; private set; }
        public ManagementObjectCollection CollectedClasses { get; private set; }
        public ManagementObjectCollection CollectedMethods { get; private set; }
        public ManagementObjectCollection CollectedProperties { get; private set; }
        public Exception WmiError { get; set; }

        public WmiResult(string pRemoteHost)
        {

        }

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

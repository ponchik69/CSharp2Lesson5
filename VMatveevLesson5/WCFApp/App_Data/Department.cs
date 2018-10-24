using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFApp
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public int UUID { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
    }
}

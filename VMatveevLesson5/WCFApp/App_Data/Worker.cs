using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFApp
{
    [DataContract]
    public struct Worker
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int DepartamentId { get; set; }

        //        public Employee Employee { get; set; }
        //        public Department Department { get; set; }

    }
}

using System;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public int PhoneNumber { get; set; }
    }
}

using System;
using System.Runtime.Serialization;

namespace Serialization
{
    [Serializable]
    [DataContract]
    public class Student
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string SecondName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public Contact Contact { get; set; }
    }
}

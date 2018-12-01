using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace SaveClassLibrary
{
    [DataContract]
    public enum Sex
    {
        Male,
        Female
    }

    [DataContract]
    public class Client
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public Sex Sex { get; set; }

        public Client()
        {

        }

        public Client(string name, string phoneNumber, Sex sex)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Sex = sex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baiThi.Entity
{
    class Student
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;

        public string firstName { get => _firstName; set => _firstName = value; }
        public string lastName { get => _lastName; set => _lastName = value; }
        public string phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string email { get => _email; set => _email = value; }
    }
}

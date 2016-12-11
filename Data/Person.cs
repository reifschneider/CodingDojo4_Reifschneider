using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Person
    {
        private string firstname;
        private string lastname;
        private long ssn;
        private string birthdate;

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        public long Ssn
        {
            get
            {
                return ssn;
            }

            set
            {
                ssn = value;
            }
        }

        public string Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
            }
        }

        public Person(string firstname, string lastname, long ssn, string birthdate)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Ssn = ssn;
            this.Birthdate = birthdate;
        }
    }
}

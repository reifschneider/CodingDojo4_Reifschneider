using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace CodingDojo4_Reifschneider.ViewModel
{
    public class PersonVM : ViewModelBase
    {
        private Person p;

        public String Firstname
        {
            get
            {
                return p.Firstname;
            }
            set
            {
                p.Firstname = value;
                RaisePropertyChanged();
            }
        }

        public String Lastname
        {
            get
            {
                return p.Lastname;
            }
            set
            {
                p.Lastname = value;
                RaisePropertyChanged();
            }
        }

        public long Ssn
        {
            get
            {
                return p.Ssn;
            }
            set
            {
                p.Ssn = value;
                RaisePropertyChanged();
            }
        }

        public String Birthdate
        {
            get
            {
                return p.Birthdate;
            }
            set
            {
                p.Birthdate = value;
                RaisePropertyChanged();
            }
        }

        public PersonVM(string firstname, string lastname, long ssn, string birthdate)
        {
            this.p = new Person(firstname, lastname, ssn, birthdate);
        }
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Data;
using System.Collections.Generic;

namespace CodingDojo4_Reifschneider.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private string firstname ="";
        private string lastname ="";
        private long ssn;
        private DateTime birthdate = DateTime.Today;
        private Methods m;


        private ObservableCollection<PersonVM> persons = new ObservableCollection<PersonVM>();
        private RelayCommand addBtnClickedCommand;
        private RelayCommand saveBtnClickedCommand;
        private RelayCommand loadBtnClickedCommand;

        private bool checkLastname;


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

        public DateTime Birthdate
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

        public ObservableCollection<PersonVM> Persons
        {
            get
            {
                return persons;
            }

            set
            {
                persons = value;
            }
        }

        public RelayCommand AddBtnClickedCommand
        {
            get
            {
                return addBtnClickedCommand;
            }

            set
            {
                addBtnClickedCommand = value;
            }
        }

        public RelayCommand SaveBtnClickedCommand
        {
            get
            {
                return saveBtnClickedCommand;
            }

            set
            {
                saveBtnClickedCommand = value;
            }
        }

        public RelayCommand LoadBtnClickedCommand
        {
            get
            {
                return loadBtnClickedCommand;
            }

            set
            {
                loadBtnClickedCommand = value;
            }
        }

        public bool CheckLastname
        {
            get
            {
                return checkLastname;
            }

            set
            {
                checkLastname = value;
            }
        }

        public MainViewModel()
        {
            m = new Methods();
            //AddBtnClickedCommand = new RelayCommand(new Action(Add), new Func<bool>(CheckLN));
            AddBtnClickedCommand = new RelayCommand(Add, CheckLN);
            SaveBtnClickedCommand = new RelayCommand(SavePersons, () => { return Persons.Count > 0; });
            LoadBtnClickedCommand = new RelayCommand(LoadPersons, () => { return File.Exists(@"C:\Users\Nadja\Documents\Dojo4.txt"); });
        }


        private void LoadPersons()
        {
            Persons.Clear();
            foreach(Person p in m.Load())
            {
                Persons.Add(new PersonVM(p.Firstname,p.Lastname,p.Ssn, p.Birthdate));
            }
        }

        private void SavePersons()
        {
            List<Person> personList = new List<Person>();
            foreach (PersonVM p in Persons)
            {
                personList.Add(new Person(p.Firstname, p.Lastname, p.Ssn, p.Birthdate));
            }
            m.Save(personList);
        }

        private void Add()
        {
            persons.Add(new PersonVM(firstname, lastname, ssn, birthdate.ToString("dd.MM.yyyy")));
        }


        public bool CheckLN()
        {
            return Lastname.Length >= 2;
        }

        /*
        private void Load()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Nadja\Documents\Input.txt", Encoding.UTF8);

            
            foreach (string line in lines)
            {
                var values = line.Split(';');
                int number = int.Parse(values[2]);
                persons.Add(new PersonVM(values[0], values[1],  number, values[3]));
            }

        }

        private void Save()
        {
            StreamWriter file = new StreamWriter(@"C:\Users\Nadja\Documents\Output.txt");
            {
                foreach (PersonVM p in persons)
                {
                    file.WriteLine(p.Firstname + ";" + p.Lastname + ";" + p.Ssn + ";" + p.Birthdate);
                }
            }
            file.Close();
        }
        */
    }
}
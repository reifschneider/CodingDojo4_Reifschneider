using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        string firstname ="";
        string lastname ="";
        long ssn;
        DateTime birthdate = DateTime.Today;
        Methods m;


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


        ObservableCollection<PersonVM> persons = new ObservableCollection<PersonVM>();
        private RelayCommand addBtnClickedCommand;
        private RelayCommand saveBtnClickedCommand;
        private RelayCommand loadBtnClickedCommand;

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


        public MainViewModel()
        {
            m = new Methods();
            AddBtnClickedCommand = new RelayCommand(Add, CheckLN);
            SaveBtnClickedCommand = new RelayCommand(SavePersons, () => { return persons.Count > 0; });
            LoadBtnClickedCommand = new RelayCommand(LoadPersons);
        }


        private void LoadPersons()
        {
            persons.Clear();
            foreach(PersonVM p in m.Load())
            {
                persons.Add(p);
            }
        }

        private void SavePersons()
        {
            List<PersonVM> personList = new List<PersonVM>();
            foreach (PersonVM p in persons)
            {
                personList.Add(p);
            }
            m.Save(personList);
        }

        private void Add()
        {
            persons.Add(new PersonVM(firstname, lastname, ssn, birthdate.ToString("dd.MM.yyyy")));
        }


        public bool CheckLN()
        {
            if (lastname.Length >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }

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
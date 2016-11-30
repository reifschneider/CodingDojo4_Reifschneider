using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CodingDojo4_Reifschneider.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        string firstname;
        string lastname;
        long ssn;
        DateTime birthdate = DateTime.Today;


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
            AddBtnClickedCommand = new RelayCommand(new Action(Add));
            SaveBtnClickedCommand = new RelayCommand(new Action(Save));
            LoadBtnClickedCommand = new RelayCommand(new Action(Load));
        }

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
                    file.WriteLine(p.Firstname+";"+p.Lastname + ";" +p.Ssn + ";" +p.Birthdate);
                }
            }
            file.Close();
        }

        private void Add()
        {
            persons.Add(new PersonVM(firstname, lastname, ssn, birthdate.ToString("dd.MM.yyyy")));
        }


    }
}
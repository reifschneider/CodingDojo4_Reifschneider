using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Methods
    {

        string path = @"C:\Users\Nadja\Documents\Dojo4.txt";

        public Methods()
        {

        }

        public List<PersonVM> Load()
        {

            List<PersonVM> list = new List<PersonVM>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                foreach (string line in lines)
                {
                    var values = line.Split(';');
                    int number = int.Parse(values[2]);
                    list.Add(new PersonVM(values[0], values[1], number, values[3]));
                }
            }

            return list;

        }
        public void Save(List<PersonVM> list)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            
            StreamWriter file = new StreamWriter(path);
            {
                foreach (PersonVM p in list)
                {
                    file.WriteLine(p.Firstname + ";" + p.Lastname + ";" + p.Ssn + ";" + p.Birthdate);
                }
            }
            file.Close();
        }
    }
}

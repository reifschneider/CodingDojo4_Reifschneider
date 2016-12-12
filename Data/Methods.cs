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
        string path = @"Dojo4.csv";

        public Methods()
        {

        }

        public List<Person> Load()
        {
            List<Person> list = new List<Person>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                foreach (string line in lines)
                {
                    var values = line.Split(';');
                    long number = long.Parse(values[2]);
                    list.Add(new Person(values[0], values[1], number, values[3]));
                }
            }

            return list;

        }
        public void Save(List<Person> list)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
            
            StreamWriter file = new StreamWriter(path);
            {
                foreach (Person p in list)
                {
                    file.WriteLine(p.Firstname + ";" + p.Lastname + ";" + p.Ssn + ";" + p.Birthdate);
                }
            }
            file.Close();
        }
    }
}

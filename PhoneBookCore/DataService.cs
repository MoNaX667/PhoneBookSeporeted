using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookCore
{
    public class DataService
    {
        /// <summary>
        /// Add some person to table
        /// </summary>
        /// <param name="targetPerson">New person</param>
        public void Add(Person targetPerson)
        {
            MyDataModel db=new MyDataModel();
            db.Persons.Add(targetPerson);
            db.SaveChanges();
        }

        /// <summary>
        /// Get current persons collection
        /// </summary>
        /// <returns>Collection of person</returns>
        public IEnumerable<Person> GetPersonList()
        {
            MyDataModel db = new MyDataModel();
            return db.Persons.ToList();
        }

        /// <summary>
        /// Remove some person from teble
        /// </summary>
        /// <param name="targetId">Id of target person</param>
        public void Remove(int targetId)
        {
            MyDataModel db = new MyDataModel();
            var tempList = db.Persons.ToList();
            Person targetPerson;

            foreach (var person in tempList)
            {
                if (person.Id == targetId)
                {
                    targetPerson = person;
                    db.Persons.Remove(targetPerson);
                }
            }
            
            db.SaveChanges();
        }

        /// <summary>
        /// Clear table
        /// </summary>
        public void Clear()
        {
            MyDataModel db = new MyDataModel();
            var tempList = db.Persons.ToList();
            db.Persons.RemoveRange(tempList);
            db.SaveChanges();
        }

        /// <summary>
        /// Return count of the collection
        /// </summary>
        /// <returns>Count of persons</returns>
        public int GetLenght()
        {
            MyDataModel db = new MyDataModel();
            return db.Persons.ToList().Count;
        }
    }
}

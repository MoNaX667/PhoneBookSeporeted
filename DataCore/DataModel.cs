using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DataCore
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {

        public DataModel()
            : base("name=DataModel")
        {
        }


        public virtual DbSet<Person> MyEntities { get; set; }

        public void Add(Person newPerson)
        {
            MyEntities.Add(newPerson);
        }

        public void Remove(Person targetPerson)
        {
            MyEntities.Remove(targetPerson);
        }

        public void Clear()
        {
            List<Person> temp = MyEntities.ToList();
            MyEntities.RemoveRange(temp);
        }

    }

}
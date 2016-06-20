namespace PhoneBookCore
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDataModel : DbContext
    {
        public MyDataModel()
            : base("name=MyDataModel")
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
    }

}
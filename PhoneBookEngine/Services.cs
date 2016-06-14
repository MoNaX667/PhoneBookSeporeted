namespace  PhoneBookEngine
{
    using System.Collections.Generic;
    using System.Linq;
    using DataCore;

    public static class Services
    {
        private static PhoneBook currentPhoneBook ;
        private static  DataModel dataBase;

        public static PhoneBook GetPhoneBook
        {
            get
            {
                return currentPhoneBook;
            }
        }

        public static void LoadBaseConfig()
        {
            dataBase = new DataModel();
            currentPhoneBook =new PhoneBook(dataBase.MyEntities.ToList<Person>());
        }

        public static void Add(string surName, string foreName, string middleName, string phoneNumber)
        {
            dataBase.MyEntities.Add(new Person(surName, foreName, middleName, phoneNumber));
            currentPhoneBook.Add(surName, foreName, middleName, phoneNumber);
        }

        public static void Remove()
        {

        }

        public static void Clear()
        {
            dataBase.MyEntities.RemoveRange(currentPhoneBook.GetPersonList());
            currentPhoneBook=new PhoneBook();
        }

        public static void Sort()
        {

        }

        public static void Search()
        {

        }

        public static IEnumerable<Person> CreateTestList(int count)
        {
            RandomContactListCreator randomList=new RandomContactListCreator();
            List<Person> temp = randomList.CreateContactList(count);
            dataBase.MyEntities.AddRange(temp);

            return temp;
        }

        /// <summary>
        /// Check phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        /// <returns>Return flag</returns>
        private static bool CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Any(temp => (!char.IsDigit(temp) && (temp != '-'))))
            {
                return false;
            }

            string[] blocksOfPhoneNumber = phoneNumber.Split('-');

            if (blocksOfPhoneNumber.Length < 4)
            {
                return false;
            }

            if ((blocksOfPhoneNumber[0].Length != 1) &&
                (blocksOfPhoneNumber[1].Length != 3) &&
                (blocksOfPhoneNumber[2].Length != 3) &&
                 (blocksOfPhoneNumber[3].Length != 4))
            {
                return false;
            }

            return true;
        }
    }
}

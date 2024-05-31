using System;
using System.Data;
using BankDatatAccess;


namespace BankBusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }

        public clsPerson()
        {
            this.Id = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.PhoneNumber = "";
            this.Address = "";
            this.Gender = 'N';

            Mode = enMode.AddNew;
        }

        public clsPerson(int Id, string FirstName, string LastName, string Email, string PhoneNumber
            , string Address,char Gender)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Gender = Gender;
            Mode = enMode.Update;
        }

        public static clsPerson FindPerson(int Id)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            char Gender = 'N';

            if (clsBankDataAccess.FindPerson(Id, ref FirstName, ref LastName, ref Email
                , ref Phone, ref Address, ref Gender))
            {
                return new clsPerson(Id, FirstName, LastName, Email, Phone, Address,Gender);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewPerson()
        {

            this.Id = clsBankDataAccess.AddNewPerson(this.FirstName, this.LastName, this.Email, this.PhoneNumber
                , this.Address, this.Gender);

            return (Id != -1);

        }

        private bool _UpdatePerson()
        {

            return clsBankDataAccess.UpdatePerson(this.Id, this.FirstName, this.LastName, this.Email, this.PhoneNumber
                 , this.Address, this.Gender);



        }

        public bool SavePerson()

        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }
            return false;
        }

        static public bool DeletePerson(int Id)
        {
            return clsBankDataAccess.DeletePerson(Id);
        }
    }
}

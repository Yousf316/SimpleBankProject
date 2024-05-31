using System;
using System.Data;
using System.Net;
using System.Security.Policy;
using BankDatatAccess;

namespace BankBusinessLayer
{
    public class clsUser : clsPerson
    {
        public enum enModeUser { AddNew = 0, Update = 1 };
        public enModeUser ModeUser = enModeUser.AddNew;


        public int UserID { get; set; }

        public string Password { get; set; }
        public int Permission { get; set; }


        public string UserName { get; set; }


        public clsUser() : base()
        {
            this.UserID = -1;

            this.Password = "";
            this.Permission = -1;
            this.UserName = "";
            this.PhoneNumber = "";
            ModeUser = enModeUser.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName, int Permission, string FirstName,
        string LastName, string Email, string Phone,string Password, string Address, char Gender)
            : base(PersonID, FirstName, LastName, Email, Phone, Address, Gender)

        {


            this.UserID = UserID;
            this.Password = Password;


            this.Permission = Permission;
            this.UserName = UserName;


            ModeUser = enModeUser.Update;
        }

        public static clsUser FindUser(int Id)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            char Gender = 'N';

            string UserName = "";
            string Password = "";
            int Permission = -1;
            int PersonID = -1;
            if (clsBankDataAccess.FindUser(Id, ref UserName, ref PersonID,ref Password, ref Permission))
            {

                if (clsBankDataAccess.FindPerson(PersonID, ref FirstName, ref LastName, ref Email
                , ref Phone, ref Address, ref Gender))
                {
                    return new clsUser(Id, PersonID, UserName, Permission,
                        FirstName, LastName, Email, Phone, Password, Address, Gender);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {

            if (this.Id == -1)
            {
                return false;
            }
            this.UserID = clsBankDataAccess.AddNewUser(this.Id, this.UserName, this.Password, this.Permission);

            return (UserID != -1);



        }

        private bool _UpdateUser()
        {

            return clsBankDataAccess.UpdateUser(this.UserID, this.UserName, this.Password, this.Permission);




        }

        public bool SaveUser()

        {

            SavePerson();

            switch (ModeUser)
            {
                case enModeUser.AddNew:
                    if (_AddNewUser())
                    {

                        ModeUser = enModeUser.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enModeUser.Update:

                    return _UpdateUser();

            }
            return false;
        }

        static public bool DeleteUser(int Id)
        {
            return clsBankDataAccess.DeleteUser(Id);
        }



        public static DataTable GetAllUser()
        {
            return clsBankDataAccess.GetAllUsers();
        }

        static public bool IsUserExist(int UserID)
        {
            return clsBankDataAccess.IsUserExist(UserID);
        }

        static public bool FindUserByIDAndPassword(int ID, string Password)
        {
            return clsBankDataAccess.FindUserByIDAndPassword(ID, Password);



        }
        static public int GetUserPermission(int ID)
        {
            return clsBankDataAccess.GetUserPermission(ID);
        }



        static public int FindUserByUserNameAndPassword(string ID, string Password)
        {
            return clsBankDataAccess.FindUserByUserNameAndPassword(ID, Password);



        }


    }
}


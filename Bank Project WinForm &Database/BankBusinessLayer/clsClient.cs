using System;
using System.Data;
using BankDatatAccess;

namespace BankBusinessLayer
{
    public class clsClient : clsPerson
    {
        public enum enModeClient { AddNew = 0, Update = 1 };
        public enModeClient ModeClient = enModeClient.AddNew;


        public int ClientID { get; set; }
        
        public string Password { get; set; }
        public float Balance { get; set; }
        public string FullName { get; set; }


        public clsClient():base()
        {
            this.ClientID = -1;
            
            this.Password = "";
            this.Balance = -1;
            this.FullName = "";


            ModeClient = enModeClient.AddNew;
        }

        private clsClient(int ClientID, string Password, float Balance,
            int PersonID, string FirstName, string LastName, string Email, string Phone, string Address, char Gender)
            : base(PersonID, FirstName, LastName, Email, Phone, Address,Gender)
        {
            this.ClientID = ClientID;
            
            this.Password = Password;
            this.Balance = Balance;
            


            ModeClient = enModeClient.Update;
        }

        public static clsClient FindClient(int ClientID)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            char Gender = 'N';

            string Password = "";
          int  PersonID = -1;
           float Balance = -1;

            if(clsBankDataAccess.FindClient(ClientID,ref PersonID, ref Password,ref Balance))
            {
                if (clsBankDataAccess.FindPerson(PersonID, ref FirstName, ref LastName, ref Email
                , ref Phone, ref Address, ref Gender))
                {
                    return new clsClient(ClientID, Password, Balance, PersonID,FirstName,
                        LastName,Email,Phone,Address,Gender);
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

        private bool _AddNewClient()
        {
            if(this.Id == -1)
            {
                return false;
            }
            this.ClientID = clsBankDataAccess.AddNewClient(this.Id, this.Password, this.Balance);

            return (ClientID != -1);

            

        }

        private bool _UpdateClient()
        {

            return clsBankDataAccess.UpdateClient(this.ClientID,this.Id, this.Password, this.Balance);




        }

        public bool SaveClient()

        {

            SavePerson();

            switch (ModeClient)
            {
                case enModeClient.AddNew:
                    if (_AddNewClient())
                    {

                        ModeClient = enModeClient.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enModeClient.Update:

                    return _UpdateClient();

            }
            return false;
        }

       static public bool Deposit (int ID,float Balance)
        {
            float NewBalance = 0;

            clsBankDataAccess.GetClientBalance(ID, ref NewBalance);

            NewBalance += Balance;
            return clsBankDataAccess.UpdateClientBalance(ID, NewBalance);
        }

        static public bool Withdraw(int ID, float Balance)
        {
            if(Balance >0)
            {
                Balance *= -1;
            }
            float NewBalance = 0;

            clsBankDataAccess.GetClientBalance(ID, ref NewBalance);

            NewBalance += Balance;
            return clsBankDataAccess.UpdateClientBalance(ID, NewBalance);
        }



        //static public bool Withdraw(int ID, float Balance)
        //{
        //    float NewBalance = 0;

        //    clsBankDataAccess.GetClientBalance(ID, ref NewBalance);
        //    if (NewBalance >= Balance)
        //    {
        //        NewBalance -= Balance;
        //        return clsBankDataAccess.UpdateClientBalance(ID, NewBalance);
        //    }
        //    else
        //        return false;

        //}
        static public bool DeleteClient(int Id)
        {
            return clsBankDataAccess.DeleteClient(Id);
        }

        static public bool IsClientExist(int Id)
        {
            return clsBankDataAccess.IsClientExist(Id);
        }

        public static DataTable GetAllClients ()
        {
            return clsBankDataAccess.GetAllClients();
        }

        public static bool FindClientByIDAndPassword(int ID,string Password)
        {
            return clsBankDataAccess.FindClientByIDAndPassword(ID,Password);
        }

        //dont forget Implment this
        static public bool Transaction(int FromClientID,int ToClientID, float Balance)
        {
           if(IsClientExist(ToClientID))
                {
                Withdraw(FromClientID, Balance);

               return Deposit(ToClientID, Balance);
                
            }
            return false;
        }
    }
}

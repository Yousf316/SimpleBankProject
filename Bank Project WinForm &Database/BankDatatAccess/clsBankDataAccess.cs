using System;
using System.Data;
using System.Data.SqlClient;


namespace BankDatatAccess
{
    public class clsBankDataAccess
    {

        //Person`s Founctions

        static public bool FindPerson(int PersonID,ref string FirstName,ref string LastName,ref string Email, ref string Phone,
                                         ref string Address,ref char Gender)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Persons
                    WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    Gender = Convert.ToChar(reader["Gender"]);


                    isFound = true;
                }

                reader.Close(); 
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public int AddNewPerson(string FirstName, string LastName, string Email, string phone,
                                         string Address,char Gender)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Persons]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Phone]
           ,[Address]
            ,[Gender])
     VALUES
           (@FirstName
           ,@LastName
           ,@Email
           ,@Phone
           ,@Address
            ,@Gender);
            Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Gender", Gender);

            try
            Delete
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int PersonID))
                _Delete
                    ID = PersonID;
                }



            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return ID;
        }
        static public bool UpdatePerson(int PersonID,string FirstName, string LastName, string Email, string phone,
                                        string Address ,char Gender)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Persons]
     SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Email] = @Email
      ,[Phone] = @Phone 
      ,[Address] = @Address 
       ,[Gender] = @Gender
            WHERE PersonID =@PersonID
            ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();

                
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected >0);
        }


        static public bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Persons]
                    WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        static public bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Found =1  FROM [dbo].[Persons]
                    WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader= cmd.ExecuteReader();
                
                if(reader.HasRows == true)
                {
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        //Client`s Founctions
        static public int AddNewClient(int PersonID,string Password,float Balance)
        {
           
            int ID = -1;    

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Clients]
           ([PersonID]
           ,[Password]
           ,[Balance])
     VALUES
           (@PersonID
           ,@Password
           ,@Balance);
            Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Balance", Balance);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(),out int ClientID))
                {
                    ID =ClientID;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close(); 
            }
            return ID;
        }

        static public bool IsClientExist(int ClientID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Found =1  FROM [dbo].[Clients]
                    WHERE ClientID = @ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public bool FindClientByIDAndPassword(int ClientID,string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Found =1  FROM [dbo].[Clients]
                    WHERE ClientID = @ClientID and Password = @Password";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static private int _GetPersonIDFromClient(int ClientID)
        {
           int ID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select PersonID  FROM [dbo].[Clients]
                    WHERE ClientID = @ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if(result != null&&int.TryParse(result.ToString(),out int PersonID))
                    {
                    ID = PersonID;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return ID;
        }
        static public bool GetClientBalance(int ClientID,ref float  Balance)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Balance  FROM [dbo].[Clients]
                    WHERE ClientID = @ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();

                Object result = cmd.ExecuteScalar();

                if (result !=null && float.TryParse(result.ToString(),out float cBalance))
                {
                    Balance = cBalance;
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool FindClient(int ID, ref int PersonID,ref string Password, ref float Balance)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM  Clients
                                                      where ClientID =@ClientID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ClientID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = Convert.ToInt16(reader["PersonID"]);
                    Password = (string)reader["Password"];
                    Balance = Convert.ToInt32(reader["Balance"]);

                    isFound = true;
                }

                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool UpdateClient(int ClientID, int PersonID, string Password, float Balance)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Clients]
   SET [PersonID] = @PersonID
      ,[Password] = @Password
      ,[Balance] = @Balance
 WHERE ClientID =@ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

                
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        static public bool UpdateClient(int ClientID, string Password, float Balance)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Clients]
   SET 
      [Password] = @Password
      ,[Balance] = @Balance
 WHERE ClientID =@ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);
          
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        static public bool UpdateClientBalance(int ClientID, float Balance)
        {

           if(Balance < 0)
                return false;

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Clients]
   SET 
      
      [Balance] = @Balance
 WHERE ClientID =@ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);

            
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        static public bool DeleteClient(int ClientID)
        {
            int PersonID = _GetPersonIDFromClient(ClientID);
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Clients]
             WHERE ClientID = @ClientID";

            SqlCommand cmd = new SqlCommand(query, connection);

           
            cmd.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            DeletePerson(PersonID);
            return (rowsAffected > 0);
        }

        static public DataTable GetAllClients()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"SELECT ClientInfo.*
                FROM     ClientInfo";

            SqlCommand cmd = new SqlCommand(query, connection);



            try
            {
                connection.Open();
               SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        //User`s Founctions

        static private int _GetPersonIDFromUser(int UserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select PersonID  FROM [dbo].[Users]
                    WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int PersonID))
                {
                    ID = PersonID;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return ID;
        }
        static public bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Found =1  FROM [dbo].[Users]
                    WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        static public bool FindUser(int UserID,ref string UserName,ref int PersonID
           , ref string Password,ref int Permission)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                        FROM     Users WHERE UserID =@UserID";

            SqlCommand cmd = new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    
                    Permission = (int)reader["Permission"];

                    isFound = true;
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        static public int AddNewUser(int PersonID,string UserName,string Password,int Permission)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Users]
           ([PersonID]
           ,[UserName]
           ,[Password]
           ,[Permission])
     VALUES
           (@PersonID
           ,@UserName
           ,@Password
           ,@Permission);
            Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Permission", Permission);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(),out int UserID))
                {
                    ID = UserID;    
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        static public bool UpdateUser(int UserID, string UserName, string Password, int Permission)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Users]
                   
                    SET 
      [UserName] = @UserName
      ,[Password] = @Password
      ,[Permission] = @Permission
 WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Permission", Permission);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        static public bool DeleteUser(int UserID)
        {
            int PersonID = _GetPersonIDFromUser(UserID);
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Users]
             WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, connection);


            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            DeletePerson(PersonID);
            return (rowsAffected > 0);
        }

        static public DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"
            SELECT UserInfo.*
                FROM     UserInfo";

            SqlCommand cmd = new SqlCommand(query, connection);



            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
            
        }

        static public bool FindUserByIDAndPassword(int User, string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Found =1  FROM [dbo].[Users]
                    WHERE UserID = @UserID and Password = @Password";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserID", User);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    isFound = true;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        static public int FindUserByUserNameAndPassword(string UserName, string Password)
        {
          int UserID = -1;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select UserID  FROM [dbo].[Users]
                    WHERE UserName = @UserName and Password = @Password";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    UserID = ID;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        static public int GetUserPermission(int UserID)
        {
            int Permission = 0;

            SqlConnection connection = new SqlConnection(clsBankDataAccessSettings.ConnectionString);

            string query = @"Select Permission  FROM [dbo].[Users]
                    WHERE UserID = @UserID" ;

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);
            

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result !=null && int.TryParse(result.ToString(),out int PermissionNum))
                {
                   Permission = PermissionNum;
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return Permission;
        }
    }
}

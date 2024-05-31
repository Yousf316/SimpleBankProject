using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Controls : Form
    {

        enum enMode
        {

            AddNew,
            Update
        }

        enMode Mode =enMode.AddNew;
       public enum enType
        {

            Client,
            User
        }

       public enType Type =enType.Client; 
        public int ID { get; set; }
        public Controls(int iD, enType Type )
        {
            InitializeComponent();

            rdFemale.Checked = true;

            ID = iD;
            this.Type = Type;

            CheckType();

            CheckMode();
        }
        
        private void CheckType()
        {

            

          if(this.Type == enType.Client)
            {
                lbPermission.Visible = false;
                plPermission.Visible = false;
               // txtPermission.Visible = false;

                lbUserName.Visible = false;
                txtUserName.Visible = false;
            }
            else
            {
                lbBalance.Visible = false;
                txtBalance.Visible = false;

            }
        }

        private void CheckMode()
        {

            if (this.ID == -1)
            {
                this.Mode = enMode.AddNew;

            }
            else
            {
                this.Mode = enMode.Update;
               
            }

            if (this.Type == enType.Client)
            {
                switch(this.Mode)

                {
                    case enMode.AddNew:

                        lbAddS.Text = "ADD NEW CLIENT";
                      
                        break;

                    default:
                        GetClientData(this.ID);
                        lbAddS.Text = "UPDATE CLIENT ID = "+this.ID;
                        break;

                }
            }
            else
            {
                switch (this.Mode)

                {
                    case enMode.AddNew:

                        lbAddS.Text = "ADD NEW USER";

                        break;

                    default:
                        GetUserData(this.ID);
                        lbAddS.Text = "UPDATE USER ID = " + this.ID;

                        break;

                }

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private int SetPermission()
        {
            int Permission = 0;



            if (cbAll.Checked)
            {
                Permission = Convert.ToInt16(cbAll.Tag.ToString());

                return -1;
            }


            if (ckDelete.Checked)
            {
                Permission += Convert.ToInt16(ckDelete.Tag.ToString());
            }


            if(ckUpdate.Checked)
            {
                Permission += Convert.ToInt16(ckUpdate.Tag.ToString());  
            }



            if (cbAdd.Checked)
            {
                Permission += Convert.ToInt16(cbAdd.Tag.ToString());
            }


            if (cbTransations.Checked)
            {
                Permission += Convert.ToInt16(cbTransations.Tag.ToString());
            }


            return Permission;

        }


        private void GetPermission(int Permission)
        {
            int Key = 0;

           
            if (Permission == -1)
            {
                cbAll.Checked = true;
                return;
            }

            Key = Convert.ToInt16(cbAdd.Tag.ToString());

            if((Permission & Key ) == Key)
            {
                cbAdd.Checked = true ;
            }

            Key = Convert.ToInt16(ckDelete.Tag.ToString());

            if ((Permission & Key) == Key)
            {
                ckDelete.Checked = true;
            }

            Key = Convert.ToInt16(ckUpdate.Tag.ToString());

            if ((Permission & Key) == Key)
            {
                ckUpdate.Checked = true;
            }


            Key = Convert.ToInt16(cbTransations.Tag.ToString());

            if ((Permission & Key) == Key)
            {
                cbTransations.Checked = true;
            }

        }
        private bool GetClientData (int ID)
        {

            if(!clsClient.IsClientExist(ID))
            {
                return false;
            }

            clsClient client = clsClient.FindClient(ID);

            if(client.Gender == 'M')
            {
                rbMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            lbID.Text = client.ClientID.ToString();
           txtFirstName.Text = client.FirstName;
            txtLastName.Text = client.LastName;
            txtAddress.Text = client.Address;
            txtEmail.Text = client.Email;
            txtBalance.Text = client.Balance.ToString();
            txtPassword.Text = client.Password;
            txtPhone.Text = client.PhoneNumber;

            return true;
        }

        private bool GetUserData(int ID)
        {

            if (!clsUser.IsUserExist(ID))
            {
                return false;
            }

            clsUser User = clsUser.FindUser(ID);

            if (User.Gender == 'M')
            {
                rbMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }

            lbID.Text = User.UserID.ToString();
            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            txtAddress.Text = User.Address;
            txtEmail.Text = User.Email;

             txtUserName.Text = User.UserName;
            //txtPermission.Text = User.Permission.ToString();


            GetPermission(User.Permission);
            txtPassword.Text = User.Password;
            txtPhone.Text = User.PhoneNumber;

            return true;
        }


        private bool SaveClientData()
        {
            clsClient client;
           if (this.ID == -1)
            {
                client = new clsClient();
            }else
            {
                 client =  clsClient.FindClient(this.ID);
            }
            

            client.FirstName = txtFirstName.Text;
            client.LastName = txtLastName.Text;
            client.Email = txtEmail.Text;
            client.PhoneNumber = txtPhone.Text;
            client.Address = txtAddress.Text;
            client.Password = txtPassword.Text;

            if (rdFemale.Checked)
                client.Gender = 'F';
            else
                client.Gender = 'M';

            client.Balance = Convert.ToInt32(txtBalance.Text);

            client.SaveClient();

            this.ID =  client.ClientID;

            this.Mode = enMode.Update;

            return true;
        }

        private bool SaveUsertData()
        {
            clsUser User;

            if (this.ID == -1)
            {
                User = new clsUser();
            }
            else
            {
                User = clsUser.FindUser(this.ID);
            }
            

            User.FirstName = txtFirstName.Text;
            User.LastName = txtLastName.Text;
            User.Email = txtEmail.Text;
            User.PhoneNumber = txtPhone.Text;
            User.Address = txtAddress.Text;
            User.Password = txtPassword.Text;
            User.UserName = txtUserName.Text;
            if (rdFemale.Checked)
                User.Gender = 'F';
            else
                User.Gender = 'M';

            User.Permission = SetPermission();

            User.SaveUser();

            this.ID = User.UserID;

            this.Mode = enMode.Update;

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Type == enType.User)
            {
                if(SaveUsertData())
                {
                    MessageBox.Show("Successed");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                if(SaveClientData())
                {
                    MessageBox.Show("Successed");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }

            CheckMode();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Controls_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

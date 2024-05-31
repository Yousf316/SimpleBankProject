using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Windows.Forms;

namespace Bank
{
    public partial class FindByPassword : Form
    {

        
        public FindByPassword(enType type,enMode mode)
        {
            InitializeComponent();

            this.type = type;
            this.mode = mode;

            if(this.mode ==enMode.User)
            {
                lbID.Text = "User Name";
            }
        }
        public enum enType
        {
            Deposit,
            Withdraw,
            Update,
            Delete,
            Login
            
        }
        public enType type = enType.Login;
        public enum enMode
        {
            client,
            User
        }

        public enMode mode = enMode.User;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FindByPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string UserName =null;

            int ID =-1;

            if (this.mode == enMode.User)
            {
                UserName = txtID.Text;
            }else
            {
                int.TryParse(txtID.Text, out int CID);

                ID = CID;
            }
          
            
            string Password = txtPassword.Text;
            
            
            if (this.mode == enMode.client)
            {
                if(clsClient.FindClientByIDAndPassword(ID,Password))
                {
                    switch (this.type)
                    {
                        case enType.Deposit:
                            Deposite dfrm = new Deposite(ID,Deposite.enType.Deposit);

                            dfrm.ShowDialog();
                            break;


                            case enType.Withdraw:
                            Deposite dfrm1 = new Deposite(ID, Deposite.enType.Withdraw);

                            dfrm1.ShowDialog();
                            break;


                        case enType.Update:
                            Controls frm = new Controls(ID, Bank.Controls.enType.Client) ;

                            frm.ShowDialog();

                            break;
                        case enType.Delete:
                            clsClient.DeleteClient(ID);
                            MessageBox.Show("Deleted Successfully");
                            break;
                    }
                    
                    this.Close();
                }
                
            }
            else
            {
                if((ID =clsUser.FindUserByUserNameAndPassword(UserName,Password)) != -1)
                    {
                    MessageBox.Show("Correct");
                    switch(type)
                    {
                        case enType.Update:
                            Controls frm = new Controls(ID, Bank.Controls.enType.User);

                            frm.ShowDialog();
                            break;

                            case enType.Login:

                            Form1 fr = new Form1(clsUser.GetUserPermission(ID));
                            fr.ShowDialog();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Incourrect");
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

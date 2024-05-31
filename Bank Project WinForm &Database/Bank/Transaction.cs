using BankBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Deposite : Form
    {
        public enum enType
        {
            Deposit,
            Withdraw
        }

        public enType Type = enType.Deposit;

        public int ID { get; set; }
        public string Password { get; set; }
        public Deposite(int ID,enType Type)
        {
            InitializeComponent();

            this.Type = Type; 
            this.ID = ID;
        }
        private bool OpertionTreans(int ID,float Amount)
        {
            if(Type == enType.Deposit)
            {
               return clsClient.Deposit(ID, Amount);
            }
            else
            {
               return clsClient.Withdraw(ID, Amount); 
            }
        }
      

        private void btnSendAmount_Click(object sender, EventArgs e)
        {
            float.TryParse(txtAmont.Text,out float Amount);
            if(OpertionTreans(this.ID, Amount))
            {
                MessageBox.Show("Sended Successfully");
            }
            else
            {
                MessageBox.Show("Send Faild");
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Deposite_Load(object sender, EventArgs e)
        {

        }
    }
}

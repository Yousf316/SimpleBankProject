using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankBusinessLayer;

namespace Bank
{
    public partial class Form1 : Form
    {

        public int Permission { get; set; }
        public Form1(int Permission)
        {
            InitializeComponent();
            this.Permission = Permission;
        }
        

       private Bank.Controls.enType ctype = Bank.Controls.enType.Client;

        private bool GetPermission(int Key)
        {

            if ((this.Permission & Key) == Key)
                return true;
            else
            return false;
        }

        
        private void RefreshClientsList()
        {
            dgAllClients.DataSource = clsClient.GetAllClients();
        }

        private void RefreshUsersList()
        {
            dgAllClients.DataSource = clsUser.GetAllUser();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshClientsList();
        }
       
        private void _AddNewData()
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(1))
                {
                    MessageBoxPermission();
                    return;
                }

            }

            Controls frm = new Controls(-1, ctype);



            frm.ShowDialog();
            RefreshClientsList();
        }

        private void _UpdateData()
        {

            if (this.Permission != -1)
            {
                if(!GetPermission(2))
                {
                    MessageBoxPermission();
                    return;
                }
                
            }
            Controls frm = new Controls((int)dgAllClients.CurrentRow.Cells[0].Value, ctype);
            
           

            
            frm.ShowDialog();

            if(ctype == Bank.Controls.enType.User)
            RefreshUsersList();
            else
               RefreshClientsList();
        }

        private void MessageBoxPermission()
        {
            MessageBox.Show("User Need Permisson","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        private void clientsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ctype = Bank.Controls.enType.Client;
            RefreshClientsList();
            
        }

        private void usersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ctype = Bank.Controls.enType.User;
            RefreshUsersList();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _UpdateData();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            if (this.Permission != -1)
            {
                if (!GetPermission(4))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            switch (this.ctype)
            {
                case Bank.Controls.enType.Client:
                    clsClient.DeleteClient((int)dgAllClients.CurrentRow.Cells[0].Value);
                    RefreshClientsList();
                    break;

                    case Bank.Controls.enType.User:
                    clsUser.DeleteUser((int)dgAllClients.CurrentRow.Cells[0].Value);

                    RefreshUsersList();
                    break;
            }
           

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ctype = Bank.Controls.enType.Client;
            _AddNewData();
            RefreshClientsList();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Permission != -1)
            {
                if (!GetPermission(16))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Deposit, FindByPassword.enMode.client);
            frm.ShowDialog();
            RefreshClientsList();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(16))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Withdraw, FindByPassword.enMode.client);
            frm.ShowDialog();
            RefreshClientsList();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ctype = Bank.Controls.enType.User;
            _AddNewData();
            RefreshClientsList();
        }

        private void clientToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(2))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Update, FindByPassword.enMode.client);
            frm.ShowDialog();
            RefreshClientsList();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(2))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Update, FindByPassword.enMode.User);
            frm.ShowDialog();
            RefreshUsersList(); 
        }

        private void clientToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(4))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Delete, FindByPassword.enMode.client);
            frm.ShowDialog();
            RefreshClientsList();
        }

        private void userToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (this.Permission != -1)
            {
                if (!GetPermission(4))
                {
                    MessageBoxPermission();
                    return;
                }

            }
            FindByPassword frm = new FindByPassword(FindByPassword.enType.Delete, FindByPassword.enMode.User);
            frm.ShowDialog();

            RefreshUsersList();
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           this.Close();
            
        }

        private void dgAllClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}

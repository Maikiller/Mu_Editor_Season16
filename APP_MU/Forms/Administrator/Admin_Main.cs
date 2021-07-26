using APP_MU.DataBase;
using APP_MU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_MU.Forms.Administrator
{
    public partial class Admin_main : Form
    {
        public Admin_main()
        {
            InitializeComponent();
        }

        private void Admin_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Main main = new();
            main.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Accounts admin_Accounts = new();
            admin_Accounts.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Characters admin_Characters = new();
            admin_Characters.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NPC_Shop_Editor npc_show = new();
            npc_show.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working"); ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working"); ;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In Working");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Shop_Create shop_Create = new();
            shop_Create.ShowDialog();
        }
    }
}
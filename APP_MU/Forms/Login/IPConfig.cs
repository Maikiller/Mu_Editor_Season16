using APP_MU.Database;
using APP_MU.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_MU.Forms.Login
{
    public partial class IPConfig : Form
    {
        public IPConfig()
        {
            InitializeComponent();
        }

        public void LoadText()
        {
            string[] lines = File.ReadAllLines("Saved.txt");
            if (lines.Length > 0)
            {
                textBox1.Text = lines[3];
                textBox4.Text = lines[4];
                textBox3.Text = lines[5];
                textBox2.Text = lines[6];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.server = textBox1.Text;
            config.user = textBox4.Text;
            config.password = textBox3.Text;
            config.port = textBox2.Text;

            this.Close();
        }

        private void IPConfig_Load(object sender, EventArgs e)
        {
            LoadText();
        }
    }
}
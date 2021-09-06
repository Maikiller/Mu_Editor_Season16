using APP_MU.Database;
using APP_MU.DataBase;
using APP_MU.Models;
using APP_MU.Models.DatabaseQuerys;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_MU.Forms.Administrator
{
    public partial class ServerCreator : Form
    {
        public ServerCreator()
        {
            InitializeComponent();
        }

        private void loadDates()
        {
            comboBox2.SelectedIndex = 0;
            Sql_Querys sql_Querys = new();
            config.database = "mu_online_login";
            dataGridView2.DataSource = Connect.loadData(sql_Querys.loadAllServerList);
        }

        private void addServer()
        {
            CreaterServer.server = CreaterServer.code = int.Parse(textBox1.Text);
            CreaterServer.name = textBox2.Text;
            CreaterServer.port = int.Parse(textBox3.Text);
            CreaterServer.ip = textBox4.Text;
            CreaterServer.default_world = int.Parse(textBox5.Text);
            CreaterServer.default_x = Convert.ToInt32(numericUpDown1.Value);
            CreaterServer.default_y = Convert.ToInt32(numericUpDown2.Value);
            CreaterServer.flag = 1;
            if (checkBox1.Checked == false)
                CreaterServer.flag = 0;

            Sql_Querys sql_Querys = new();
            Querys querys = new();
            config.database = "mu_online_login";
            Connect.update(sql_Querys.addServer);
            Connect.update(querys.world_server);
            config.database = "mu_game";
            Connect.update(querys.settings);

            MessageBox.Show("Server " + CreaterServer.name + " Created");
            config.database = "mu_online_login";
            dataGridView2.DataSource = Connect.loadData(sql_Querys.loadAllServerList);
        }

        private void ServerCreator_Load(object sender, EventArgs e)
        {
            loadDates();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            addServer();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreaterServer.type = 0;
            if (comboBox2.SelectedIndex == 1)
            {
                CreaterServer.type = 1;
            }
        }




       /* private void ExecuteCommand()
        {

            var proc1 = new ProcessStartInfo();
            string anyCommand="";
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
        }


      /*  private void OpenFileDialog()
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string path = choofdlog.FileName;
                //ExecuteCommand(path);
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }

        }*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}

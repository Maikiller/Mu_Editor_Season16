using APP_MU.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_MU.DataBase
{
    internal class Connect
    {
        private static MySqlConnection con;

        public static MySqlConnection Connecting()
        {
            con = new(
            "" +
            "Server=" + config.server + ";" +
            "Port=" + config.port + ";" +
            "Database=" + config.database + ";" +
            "Uid=" + config.user + ";" +
            "Pwd=" + config.password + ";" +
            "Connection Timeout=5;"
            );
            return con;
        }

        public static void update(string sql)
        {
            var cmd = Connecting().CreateCommand();
            cmd.CommandText = sql;
            con.Open();
            try
            {
                cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        public static DataTable loadData(string sql)
        {
            DataTable data = new();
            MySqlDataAdapter da;
            var cmd = Connecting().CreateCommand();
            cmd.CommandText = sql;
            da = new MySqlDataAdapter(cmd.CommandText, Connecting());
            try
            {
                da.Fill(data);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace MovieDB
{
    public partial class Form3 : Form
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=MovieDb.db;Version=3;");
        DataTable dt = new DataTable();
        SQLiteDataAdapter da = new SQLiteDataAdapter();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                conn.Open();
                //cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
    public partial class Form2 : Form
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=MovieDb.db;Version=3;");
        DataTable dt = new DataTable();
        SQLiteDataAdapter da = new SQLiteDataAdapter();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                da.SelectCommand = new SQLiteCommand("SELECT * from Movies;", conn);

                dt.Clear();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

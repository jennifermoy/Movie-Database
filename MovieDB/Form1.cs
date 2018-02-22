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
    public partial class Form1 : Form
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=MovieDb.db;Version=3;");
        DataTable dt = new DataTable();
        SQLiteDataAdapter da = new SQLiteDataAdapter();

        public Form1()
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
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT into Movies(MovieTitle, Category, Genre, CheckoutDate, ReturnDate, IsRented) VALUES(@title, @category, @genre, @checkout, @return, @rented)", conn);
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@title", textBox1.Text);
                cmd.Parameters.AddWithValue("@category", textBox2.Text);
                cmd.Parameters.AddWithValue("@genre", textBox3.Text);
                cmd.Parameters.AddWithValue("@checkout", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@return", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@rented", cbRented.CheckState);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rentedMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
        }
    }
}

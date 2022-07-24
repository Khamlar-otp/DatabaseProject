using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectDatabase
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            int age = int.Parse(textBox2.Text);
            string address = textBox3.Text;
            string email = textBox4.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4T433V8\SQLEXPRESS;Initial Catalog=StudentInformation;Integrated Security=True");
                con.Open();
                string query = "insert into tbl_employee (Name,Age,Address,Email) values ('" + fname + "','" + age + "','" + address + "','" + email + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record insert succesfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Record insert failed", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4T433V8\SQLEXPRESS;Initial Catalog=StudentInformation;Integrated Security=True");
                con.Open();
                string query = "Select *from tbl_employee";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data successfuly loaded in datagridview");
            }
            catch (SqlException exl)
            {
                MessageBox.Show("data loading faild", exl.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            int age = int.Parse(textBox2.Text);
            string address = textBox3.Text;
            string email = textBox4.Text;
            int e_id = int.Parse(textBox5.Text);
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4T433V8\SQLEXPRESS;Initial Catalog=StudentInformation;Integrated Security=True");
                con.Open();
                string query = "update tbl_employee set Name='" + fname + "',Age='" + age + "',Address='" + address + "',Email='" + email + "'where Id='" + e_id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update Sccessflly");
            }
            catch (SqlException ex3)
            {
                MessageBox.Show("Error record update", ex3.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int e_id = int.Parse(textBox5.Text);
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4T433V8\SQLEXPRESS;Initial Catalog=StudentInformation;Integrated Security=True");
                con.Open();
                string query = " Delete from tbl_employee where Id='" + e_id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record  deleted successfully");

            }
            catch (SqlException ex2)
            {
                MessageBox.Show("Record deletion failed", ex2.Message);
            }
        }
    }
}

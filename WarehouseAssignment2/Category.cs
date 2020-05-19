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

namespace WarehouseAssignment2
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter dr;
        SqlCommand cmd, cmd2;
        DataTable dt;
        SqlCommandBuilder cmdb;

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("insert into Category Values (@Category)", con);
            cmd.Parameters.AddWithValue("@Category", textBox1.Text);
            cmd.ExecuteNonQuery();
            cmd2 = new SqlCommand("Select * from [Category]", con);
            dr = new SqlDataAdapter(cmd2);
            dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("Successfull Add");



        }

        private void Category_Load(object sender, EventArgs e)
        {
            if(Myglob.admin!=1)
            {
                button1.Hide();
                button2.Hide();
                label1.Hide();
                textBox1.Hide();
            }
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
            con.Open();
             cmd = new SqlCommand("Select * from [Category]", con);
             dr = new SqlDataAdapter(cmd);
             dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmdb = new SqlCommandBuilder(dr);
            dr.Update(dt);
            MessageBox.Show("Upadte Successfull");
        }
    }
}

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
    public partial class Registration : Form
    {
        public Registration()
        {

            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {


            if (PasswordtextBox.Text != CPasswordtextBox.Text)
                MessageBox.Show("Password Dont match");
            else

            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
                con.Open();
                string Email = EmailtextBox.Text;
                string password = PasswordtextBox.Text;
                Myglob.email = Email;
                if (comboBox2.SelectedIndex == 0)
                    Myglob.admin = 0;
                else
                    Myglob.admin = 1;
                SqlCommand cmd2 = new SqlCommand("Select * from Login", con);
                SqlDataReader rd = cmd2.ExecuteReader();
                int flag = 0;
                while (rd.Read())
                {
                    if (EmailtextBox.Text == rd["Email"].ToString())
                        flag = 1;
                }
                if (flag == 1)
                {
                    MessageBox.Show("Username Or Email already exsist");
                    con.Close();
                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
                    con1.Open();
                    SqlCommand cmd = new SqlCommand("insert into Login(Email,Password,Admin) VALUES('" + Email + "', '" + password + "', '" + comboBox2.SelectedIndex.ToString() + "')", con1);
                    cmd.ExecuteNonQuery();
                    SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
                    con2.Open();
                    string name = textBox1.Text;
                    string number = textBox3.Text;
                    string city = comboBox1.SelectedItem.ToString();
                    string gender;
                    if (radioButton1.Checked)
                        gender = radioButton1.Text;
                    else
                        gender = radioButton2.Text;

                    SqlCommand cmd1 = new SqlCommand("insert into UserDetails (Name,Email,Password,Number,City,Gander) VALUES('" + name + "','" + Email + "', '" + password + "', '" + number + "',  '" + city + "', '" + gender + "')", con2);
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Successfull Registration");
                    this.Hide();
                    MainForm m = new MainForm();
                    m.ShowDialog();


                }

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                Register.Enabled = true;
            else
                Register.Enabled = false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
                label9.Visible = true;
            else
                label9.Visible = false;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CPasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form1 : Form
    {
        static int  i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (EmailtextBox.Text =="" || PasswordtextBox.Text == "")
                MessageBox.Show("Please Enter valid Email or Password");
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aa\source\repos\WarehouseAssignment2\WarehouseAssignment2\Database1.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Login", con);
                SqlDataReader rd = cmd.ExecuteReader();
                int flag = 0;

                while (rd.Read())
                {
                    
                    if (EmailtextBox.Text == rd["Email"].ToString() & PasswordtextBox.Text == rd["Password"].ToString())
                    {
                        if (Convert.ToInt32(rd["Admin"]) == 1)
                            Myglob.admin = 1;
                        MessageBox.Show("successfull");
                        Myglob.email = rd["Email"].ToString();
                        this.Hide();
                        MainForm m = new MainForm();





                                                m.ShowDialog();
                        con.Close();
                        flag = 1;
                    }
                }
                if (flag == 0)
                    MessageBox.Show("Please Enter valid Email or Password");
            }    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration r = new Registration();
            r.ShowDialog();   
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                PasswordtextBox.UseSystemPasswordChar = false;
            else
                PasswordtextBox.UseSystemPasswordChar = true;

        }
    }
    public static class Myglob
    {
        public static  int  admin = 0;
        public static string email = "";
        
    }
}

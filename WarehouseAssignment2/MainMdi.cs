using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseAssignment2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            xToolStripMenuItem.Text = "Welcome" + " " + Myglob.email;
            if (Myglob.admin == 1)
            {
                menuStrip1.Items.Remove(buyToolStripMenuItem);
                menuStrip1.Items.Remove(orderToolStripMenuItem);

            }
            else
            {
                menuStrip1.Items.Remove(updateProductToolStripMenuItem);
                menuStrip1.Items.Remove(addNewProductToolStripMenuItem);

            }





        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNew n1 = new AddNew();
            n1.MdiParent = this;
            n1.Show();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayItem n2 = new DisplayItem();
            n2.MdiParent = this;
            n2.Show();
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category n3 = new Category();
            n3.MdiParent = this;
            n3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetails n4 = new UserDetails();
            n4.MdiParent = this;
            n4.Show();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order n5 = new Order();
            n5.MdiParent = this;
            n5.Show();
        }

        private void updateProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateProduct n6 = new UpdateProduct();
            n6.MdiParent = this;
            n6.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult d = MessageBox.Show("Are You Sure", "Exit", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
                Application.Exit();  
        }

        private void buyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buy n7 = new Buy();
            n7.MdiParent = this;
            n7.Show();
        }
    }
}

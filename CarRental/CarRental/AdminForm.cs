using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            lbl1.Text = "Welcome, " + LoginHelper.UserName;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogForm lf = new LogForm();
            lf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarRegForm cr = new CarRegForm();
            cr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInfoForm ui = new UserInfoForm();
            ui.Show();
            
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfoForm ui = new UserInfoForm();
            ui.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(ui);
            ui.Show();
            
        }

        private void carRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarRegForm cr = new CarRegForm();
            cr.Dock = DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(cr);
            cr.Show();
        }

        private void rentalListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalListForm rlf = new RentalListForm();
            rlf.Dock =DockStyle.Fill;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(rlf);
            rlf.Show();
        }

       
    }
}

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

namespace CarRental
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void RegForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogForm lf = new LogForm();
            lf.Show();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = txtPass.Text != txtCp.Text;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (lblError.Visible)
            {
                MessageBox.Show("Invalid Data");
                return;
            }

            string un = txtUn.Text;
            string pass = txtPass.Text;
            string em = txtEm.Text;
            string mb = txtMb.Text;
            string ut = "";
            if (cmbUt.SelectedItem != null)
            {
                ut = cmbUt.SelectedItem.ToString();
            }
            string ad = txtAddress.Text;

            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-2JBTPEL\SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
                sql.Open();
                string query = "insert into UserInfo (UserName,[Password],Email,Mobile,UserType,[Address]) "+
                            "values ('" + un + "','" + pass + "','" + em + "','" + mb + "','" + ut + "','" + ad + "')";
                SqlCommand cmd = new SqlCommand(query,sql);
                cmd.ExecuteNonQuery();
                lblReC.Visible = true;
                
                sql.Close();

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void btCl_Click(object sender, EventArgs e)
        {
            LogForm lf = new LogForm();
            lf.Show();
            this.Hide();

        }

    }
}

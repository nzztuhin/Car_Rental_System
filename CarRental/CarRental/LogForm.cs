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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
             
        }

        private void login_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-2JBTPEL\SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
            string un = txtUn.Text;
            string pass = txtPass.Text;
            

            try
            {
                string query = "select * from UserInfo Where UserName='" + un + "' and Password='" + pass + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query,sql);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    lblError.Visible = true;
                }
                else
                {
                    string userType = dt.Rows[0]["UserType"].ToString();
                    if (userType == "Admin")
                    {
                        LoginHelper.UserName = un;
                        
                        AdminForm af = new AdminForm();
                        af.Show();
                        this.Hide();

                    }
                    else
                    {
                        LoginHelper.UserName = un;
                        LoginHelper.ID = dt.Rows[0]["ID"].ToString();
                        CustomerForm cf = new CustomerForm();
                        cf.Show();
                        this.Hide();
                    }

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    } 
}

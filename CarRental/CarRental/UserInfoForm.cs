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
    public partial class UserInfoForm : UserControl
    {
        public UserInfoForm()
        {
            InitializeComponent();
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }
        private void Init()
        {
            txtSearch.Text = txtId.Text = txtPass.Text = txtEm.Text =txtMb.Text=txtUn.Text=txtAddress.Text= "";
            cmbUt.SelectedItem = cmbUt.SelectedItem = null;
            this.LoadUserInfo();

        }
        private void LoadUserInfo()
        {
            try
            {
                string query = "select * from UserInfo";
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    query = query + " where UserName like'%" + txtSearch.Text + "%'";
                }
                DataTable dt = DataAccess.GetDataTable(query);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void blbSearch_Click(object sender, EventArgs e)
        {
            this.LoadUserInfo();
        }

        private void blbRef_Click(object sender, EventArgs e)
        {
            this.Init();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["dgvId"].Value.ToString();
                this.LoadCarDetails(id);

            }
        }
        private void LoadCarDetails(string id)
        {
            try
            {
                string query = "select * from UserInfo where ID =" + id;

                DataTable dt = DataAccess.GetDataTable(query);

                if (dt.Rows.Count != 1)
                    return;
                txtId.Text = dt.Rows[0]["ID"].ToString();
                txtUn.Text = dt.Rows[0]["UserName"].ToString();
                txtPass.Text = dt.Rows[0]["Password"].ToString();
                txtEm.Text = dt.Rows[0]["Email"].ToString();
                txtMb.Text = dt.Rows[0]["Mobile"].ToString();
                cmbUt.SelectedItem = dt.Rows[0]["UserType"].ToString();
                txtAddress.Text=dt.Rows[0]["Address"].ToString();


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void blbNew_Click(object sender, EventArgs e)
        {
            this.NewUserInfo();
        }
        private void NewUserInfo()
        {
            txtId.Text = "";
            txtPass.Text = "";
            txtEm.Text = "";
            txtMb.Text = "";
            cmbUt.SelectedItem = null;
            txtAddress.Text = "";
            dataGridView1.ClearSelection();
        }

        private void blbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                    this.Insert();
                else
                {
                    this.Updateq();
                }
                this.LoadUserInfo();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string id = dataGridView1.Rows[i].Cells["dgvId"].Value.ToString();
                    if (id == txtId.Text)
                    {
                        dataGridView1.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void Updateq()
        {
            string query = "update UserInfo set UserName='" + txtUn.Text + "', [Password]='"+txtPass.Text+"', "+ 
                " Email='" + txtEm.Text + "',Mobile='" + txtMb.Text + "',UserType='" + cmbUt.SelectedItem + "',Address='"+txtAddress.Text+"' " +
                " where ID = " + txtId.Text + " ";
            DataAccess.ExecuteQuery(query);
            MessageBox.Show("Updated");
        }
        private void Insert()
        {
             string query = "insert into UserInfo (UserName,[Password],Email,Mobile,UserType,[Address]) "+
                            "values ('" + txtUn.Text + "','" + txtPass.Text + "','" + txtEm.Text + "','" + txtMb.Text + "','" + cmbUt.SelectedItem + "','" + txtAddress.Text + "')";
            DataAccess.InsertQuery(query);

        }


        private void blbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Please select a row");
                }
                else
                {
                    string query = "delete from UserInfo where ID =" + txtId.Text;

                    DataAccess.ExecuteQuery(query);
                    this.LoadUserInfo();
                    this.NewUserInfo();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogForm lf = new LogForm();
            lf.Show();
            this.Hide();
        }

    }
}

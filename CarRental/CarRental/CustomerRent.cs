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
    public partial class CustomerRent :  UserControl
    {
        public CustomerRent()
        {
            InitializeComponent();
            txtCustomerid.Text= LoginHelper.ID ;
            txtUser.Text = LoginHelper.UserName;
           
        }

        private void CarRegForm_Load(object sender, EventArgs e)
        {
            this.Init();
        }
        private void Init()
        {
            txtSearch.Text =txtCarId.Text =txtModel.Text=txtCost.Text = "";
            cmbserv.Text = cmbAvl.Text = "";
            this.LoadCarReg();
            
        }
        private void LoadCarReg()
        {
            try
            {
                string query = "select * from CarReg";
                if(!string.IsNullOrEmpty(txtSearch.Text))
                {
                    query=query +" where Service like'%"+txtSearch.Text+"%'";
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
            this.LoadCarReg();
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
                string query = "select * from  CarReg where CarID ="+id;
               
                DataTable dt = DataAccess.GetDataTable(query);

                if (dt.Rows.Count != 1)
                    return;
                txtCarId.Text = dt.Rows[0]["CarID"].ToString();
                txtModel.Text = dt.Rows[0]["Model"].ToString();
                txtCost.Text = dt.Rows[0]["Cost"].ToString();
                cmbserv.Text = dt.Rows[0]["Service"].ToString();
                cmbAvl.Text = dt.Rows[0]["Available"].ToString();

                

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void blbNew_Click(object sender, EventArgs e)
        {
            this.NewCarReg();
        }
        private void NewCarReg()
        {
            txtCarId.Text = "";
            txtModel.Text = "";
            txtCost.Text = "";
            cmbserv.Text = "";
            cmbAvl.Text = "";
            dataGridView1.ClearSelection();
        }

        private void blbSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                    this.Insert();
                
                    this.Updateq();
                
                this.LoadCarReg();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string id = dataGridView1.Rows[i].Cells["dgvId"].Value.ToString();
                    if (id == txtCarId.Text)
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
            string query = "update CarReg set Available='No' " +
                " where CarID = "+txtCarId.Text+" ";
            DataAccess.ExecuteQuery(query);
            MessageBox.Show("Successful");
        }
        private void Insert()
        {
            string query = "insert into RentalInfo ([CustomerID],[User_Name],[CarID],[Service],[Model],[Cost]) "+
                " values ('" + txtCustomerid.Text + "','" + txtUser.Text + "','" + txtCarId.Text + "','" + cmbserv.Text + "','" + txtModel.Text + "','" + txtCost.Text + "')";
                  DataAccess.InsertQuery(query);
           
        }


        private void blbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCarId.Text == "")
                {
                    MessageBox.Show("Please select a row");
                }
                else
                {
                    string query = "delete from CarReg where CarID =" +txtCarId.Text;

                    DataAccess.ExecuteQuery(query);
                    this.LoadCarReg();
                    this.NewCarReg();
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

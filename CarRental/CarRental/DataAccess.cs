using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CarRental
{
   static class DataAccess
    {
       public static DataTable GetDataTable(string query)
       {
           SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-2JBTPEL\SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
           sql.Open();
           SqlCommand cmd = new SqlCommand(query,sql);
           DataSet ds =new DataSet();
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           sda.Fill(ds);
           DataTable dt = ds.Tables[0];
           sql.Close();
           return dt;
           
       }
       public static void ExecuteQuery(string query)
       {
           SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-2JBTPEL\SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
           sql.Open();
           SqlCommand cmd = new SqlCommand(query, sql);
           cmd.ExecuteNonQuery();
           sql.Close();
       }
       public static void InsertQuery(string query)
       {
           SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-2JBTPEL\SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
           sql.Open();
           SqlCommand cmd = new SqlCommand(query, sql);
           cmd.ExecuteNonQuery();
           sql.Close();


       }

    }
}

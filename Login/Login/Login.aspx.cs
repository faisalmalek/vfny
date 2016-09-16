using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            String connstring="Data Source=CELAB5;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            String sql="Select * from Login";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter=new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Login");

            foreach (Datarow row in ds.Tables["Login"].Rows)
            { 
                ListItem newitem =new ListItem;
                newItem.Text = row["Username"]+","+row["Password"];
                newitem.Value=row["Username"].ToString();
                lstTable.Items.Add(newitem)
            }

        }
    }
}
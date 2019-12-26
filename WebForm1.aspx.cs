using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test2._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CONNECT TO DB
            string connStr = "Server=mysql-2017;Database=test;UID=sa;PWD=admin12345678";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //CREATE A COMMAND
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[StateCity]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            string temp = "";
            //READ FROM DB
            SqlDataReader reader = cmd.ExecuteReader();
            temp += "<table id=samptab><tr><th>SerialNo</th><th>City</th><th>State</th><th>Zip</th><th>Country</th></tr>";

            while (reader.Read())

            {
                temp += "<tr>";
                temp += "<td>";

                temp += reader["SerialNo"].ToString();
                temp += "</td><td>";

                temp += reader["City"].ToString();
                temp += "</td><td>";

                temp += reader["State"].ToString();
                temp += "</td><td>";

                temp += reader["Zip"].ToString();
                temp += "</td><td>";

                temp += reader["Country"].ToString();
                temp += "</td></tr>";

            }
            temp += "</table>";
            conn.Close();
            lbl_test.Text = temp;

        }
    }
}
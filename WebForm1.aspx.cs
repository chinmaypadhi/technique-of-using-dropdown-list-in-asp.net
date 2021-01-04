using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dropdownlist_todatabse
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
if(!IsPostBack)
            {
                ListItem li = new ListItem();
                ListItem li1 = new ListItem();
                ListItem li2 = new ListItem();
                li.Text = "chinmay";
                li1.Text = "sonu";
                li2.Text = "mota";

                DropDownList1.Items.Add(li);
                DropDownList1.Items.Add(li1);
                DropDownList1.Items.Add(li2);
            }
        }

       static string str = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
        SqlConnection con = new SqlConnection(str);
        SqlCommand cmd;
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "dropview";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dropShow("id", "name", dt);
                selectdrop(dt);
                con.Close();
            }

        }

        protected void dropShow(string id,string name,DataTable dt)
        {
            //for (int x=0;x<=dt.Rows.Count-1; x++)
            //{
                DropDownList1.DataTextField =name;
                DropDownList1.DataValueField =id;

                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
            //}
        }

        protected void selectdrop(DataTable dt)
        {
            for(int x=0;x<=dt.Columns.Count;x++)
            {
                DropDownList2.Items.Add(new ListItem(dt.Rows[x][1].ToString()));
            }
        }
    }
}
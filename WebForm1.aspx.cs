using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace sample_inv
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string sql;
        OdbcConnection CON = new OdbcConnection("Driver={MySQL ODBC 8.0 ANSI Driver};Server=localhost;Port=3306;Database=swm;uid=swmuser;pwd=swmuser@123");
        OdbcCommand CMD;
        OdbcDataAdapter ADAP;
        String SQL;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        public void bind()
        {
            SQL = "SELECT * FROM CUSTOMER WHERE LIVE_FLAG=1 and customer_name<>'--Select--'";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            GridView1.DataSource = DS.Tables["RESULT"];
            GridView1.DataBind();

            for (int i = 0; i <= DS.Tables["RESULT"].Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            SQL = "SELECT IFNULL(MAX(CUSTOMER_ID),0)CUSTOMER_ID FROM CUSTOMER";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            Int32 CID = 0;
            if (Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["CUSTOMER_ID"]) > 0)
            {
                CID = Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["CUSTOMER_ID"]) + 1;

            }
            else
            {
                CID = 1;
            }


            SQL = "INSERT INTO CUSTOMER (CUSTOMER_ID,CUSTOMER_NAME,ADDRESS1,ADDRESS2,ADDRESS3,STATE,STATE_CODE,PIN_CODE,PHONE,GST,CREATION_DATE,LIVE_FLAG)VALUES('" + CID + "','" + txtcustomer.Text + "','" + txtadd1.Text + "','" + txtadd2.Text + "','" + txtadd3.Text + "','" + txtstate.Text + "','" + txtstatecode.Text + "','" + txtpincode.Text + "','" + txtphno.Text + "','" + txtgst.Text + "',CURDATE(),1)";
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            CMD = new OdbcCommand(SQL, CON);
            CMD.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Customer Saved !! ');</script>");
            clean();
            bind();
        }
        public void clean()
        {
            txtcustomer.Text = "";
            txtadd1.Text = "";
            txtadd2.Text = "";
            txtadd3.Text = "";
            txtstate.Text = "";
            txtstatecode.Text = "";
            txtpincode.Text = "";
            txtphno.Text = "";
            txtgst.Text = "";
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((GridViewRow)((ImageButton)sender).NamingContainer);

            TextBox txtcust = new TextBox();
            txtcust = (TextBox)(row.FindControl("txtcust"));
            TextBox txtad1 = new TextBox();
            txtad1 = (TextBox)(row.FindControl("txtad1"));
            TextBox txtad2 = new TextBox();
            txtad2 = (TextBox)(row.FindControl("txtad2"));
            TextBox txtad3 = new TextBox();
            txtad3 = (TextBox)(row.FindControl("txtad3"));
            TextBox txtst = new TextBox();
            txtst = (TextBox)(row.FindControl("txtst"));
            TextBox txtstcode = new TextBox();
            txtstcode = (TextBox)(row.FindControl("txtstcode"));
            TextBox txtpin = new TextBox();
            txtpin = (TextBox)(row.FindControl("txtpin"));
            TextBox txtph = new TextBox();
            txtph = (TextBox)(row.FindControl("txtph"));
            TextBox txtgst1 = new TextBox();
            txtgst1 = (TextBox)(row.FindControl("txtgst1"));

            SQL = "UPDATE CUSTOMER SET CUSTOMER_NAME='" + txtcust.Text + "',ADDRESS1='" + txtad1.Text + "',ADDRESS2='" + txtad2.Text + "',ADDRESS3='" + txtad3.Text + "',STATE='" + txtst.Text + "',STATE_CODE='" + txtstcode.Text + "',PIN_CODE='" + txtpin.Text + "',PHONE='" + txtph.Text + "',GST='" + txtgst1.Text + "',UPDATED_DATE=CURDATE() where customer_id='" + row.Cells[1].Text + "'";
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            CMD = new OdbcCommand(SQL, CON);
            CMD.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Customer details updated!! ');</script>");

            bind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((GridViewRow)((ImageButton)sender).NamingContainer);

            SQL = "UPDATE CUSTOMER SET LIVE_FLAG=0,UPDATED_DATE=CURDATE() where customer_id='" + row.Cells[1].Text + "'";
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            CMD = new OdbcCommand(SQL, CON);
            CMD.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Customer details Deleted!! ');</script>");

            bind();
        }


    }
}
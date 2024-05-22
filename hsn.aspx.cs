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
    public partial class hsn : System.Web.UI.Page
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
            SQL = "SELECT * FROM ITEM_MASTER WHERE LIVE_FLAG=1";
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
            if (txtitemno.Text != "" && txtdesc.Text != "" && txthsn.Text != "" && txtprice.Text != "")
            {
                SQL = "SELECT * FROM item_master WHERE ITEM_NAME='" + txtitemno.Text + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DS = new DataSet();
                ADAP.Fill(DS, "RESULT");
                if (DS.Tables["RESULT"].Rows.Count == 0)
                {
                    SQL = "SELECT IFNULL(MAX(item_ID),0)item_ID FROM item_master";
                    ADAP = new OdbcDataAdapter(SQL, CON);
                    DS = new DataSet();
                    ADAP.Fill(DS, "RESULT");
                    Int32 iID = 0;
                    if (Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["item_ID"]) > 0)
                    {
                        iID = Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["item_ID"]) + 1;
                    }
                    else
                    {
                        iID = 1;
                    }
                    SQL = "INSERT INTO item_master (ITEM_ID,ITEM_NAME,DESCRIPTION,HSN_NO,PRICE,creation_date,live_flag)VALUES('" + iID + "','" + txtitemno.Text + "','" + txtdesc.Text + "','" + txthsn.Text + "','" + txtprice.Text + "',CURDATE(),1)";
                    if (CON.State == ConnectionState.Closed)
                    {
                        CON.Open();
                    }
                    CMD = new OdbcCommand(SQL, CON);
                    CMD.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>alert('Item Saved !! ');</script>");
                    clean();
                    bind();
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('Please enter all the values');</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Item already available, please enter different item');</script>");
            }
        }
        public void clean()
        {
            txtitemno.Text = "";
            txtdesc.Text = "";
            txthsn.Text = "";
            txtprice.Text = "";
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((GridViewRow)((ImageButton)sender).NamingContainer);

            TextBox txtiname = new TextBox();
            txtiname = (TextBox)(row.FindControl("txtiname"));
            TextBox txtdes = new TextBox();
            txtdes = (TextBox)(row.FindControl("txtdes"));
            TextBox txthsn1 = new TextBox();
            txthsn1 = (TextBox)(row.FindControl("txthsn1"));
            TextBox txtprice1 = new TextBox();
            txtprice1 = (TextBox)(row.FindControl("txtprice1"));

            SQL = "UPDATE item_master SET item_NAME='" + txtiname.Text + "',description='" + txtdes.Text + "',hsn_no='" + txthsn1.Text + "',price='" + txtprice1.Text + "',UPDATED_DATE=CURDATE() where item_id='" + row.Cells[1].Text + "'";
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            CMD = new OdbcCommand(SQL, CON);
            CMD.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Item details updated!! ');</script>");

            bind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((GridViewRow)((ImageButton)sender).NamingContainer);

            SQL = "UPDATE item_master SET LIVE_FLAG=0,UPDATED_DATE=CURDATE() where item_id='" + row.Cells[1].Text + "'";
            if (CON.State == ConnectionState.Closed)
            {
                CON.Open();
            }
            CMD = new OdbcCommand(SQL, CON);
            CMD.ExecuteNonQuery();
            Response.Write("<script language='javascript'>alert('Item details Deleted!! ');</script>");

            bind();
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            clean();
        }
    }
}
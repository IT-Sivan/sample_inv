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
    public partial class order : System.Web.UI.Page
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
                SQL = "select * from CUSTOMER WHERE LIVE_FLAG=1";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DS = new DataSet();
                ADAP.Fill(DS, "result");
                ddlbillcustomer.DataSource = DS;
                ddlbillcustomer.DataTextField = "CUSTOMER_NAME";
                ddlbillcustomer.DataValueField = "CUSTOMER_ID";
                ddlbillcustomer.DataBind();

                ddlship.DataSource = DS;
                ddlship.DataTextField = "CUSTOMER_NAME";
                ddlship.DataValueField = "CUSTOMER_ID";
                ddlship.DataBind();

                BIND();


            }
        }


        public void BIND()
        {
            SQL = "SELECT YEAR(curdate()) year FROM dual";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            string yr;
            yr = Convert.ToString(DS.Tables["RESULT"].Rows[0]["YEAR"]);

            SQL = "SELECT IFNULL(MAX(ORDER_NO),0)ORDER_NO FROM OA_HEADER";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            String CID = "0";
            if (Convert.ToString(DS.Tables["RESULT"].Rows[0]["ORDER_NO"]) != "0")
            {
                CID = Convert.ToString(Convert.ToInt64(DS.Tables["RESULT"].Rows[0]["ORDER_NO"]) + 1);
            }
            else
            {
                CID = Convert.ToString(yr + "10001");
            }
            txtorderno.Text = Convert.ToString(CID);
            txtdate.Text = Convert.ToString(DateTime.Now);

            SQL = "select * from sno_t where sno<=10";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "result");
            GridView1.DataSource = DS;
            GridView1.DataBind();


            SQL = "select '--Select--' DESCRIPTION from dual union all SELECT DESCRIPTION FROM ITEM_MASTER WHERE LIVE_FLAG=1 ";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DataSet DSHSN = new DataSet();
            ADAP.Fill(DSHSN, "result");

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                DropDownList txtdesc = new DropDownList();
                txtdesc = (DropDownList)(GridView1.Rows[i].FindControl("txtdesc"));
                txtdesc.DataSource = DSHSN;
                txtdesc.DataTextField = "DESCRIPTION";
                txtdesc.DataValueField = "DESCRIPTION";
                txtdesc.DataBind();

            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string bcust, scust, msg, no, qty, wt, line;
            msg = "";
            bcust = "";
            scust = "";
            no = "";
            qty = "";
            wt = "";
            line = "";



            for (int I = 0; I <= GridView1.Rows.Count - 1; I++)
            {
                DropDownList txtdesc = new DropDownList();
                txtdesc = (DropDownList)(GridView1.Rows[I].FindControl("txtdesc"));
                TextBox txtkind = new TextBox();
                txtkind = (TextBox)(GridView1.Rows[I].FindControl("txtkind"));
                TextBox txtqty = new TextBox();
                txtqty = (TextBox)(GridView1.Rows[I].FindControl("txtqty"));
                TextBox txtweight = new TextBox();
                txtweight = (TextBox)(GridView1.Rows[I].FindControl("txtweight"));

                if (Convert.ToString(txtdesc.SelectedItem.Text) != "--Select--")
                {
                    line = "1";
                    if (txtkind.Text == "")
                    {
                        no = "No & Kind of Packages";
                    }
                    if (txtqty.Text == "")
                    {
                        qty = "quantity";
                    }
                    if (txtweight.Text == "")
                    {
                        wt = "weight";
                    }
                }
            }

            if (ddlbillcustomer.SelectedItem.Text == "--Select--")
            {
                bcust = "Bill to Customer name";
            }
            if (ddlship.SelectedItem.Text == "--Select--")
            {
                scust = "Ship to Customer name";
            }

            if (Convert.ToString(bcust) != "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += "," + bcust;
                }
                else
                {
                    msg += bcust;
                }
            }

            if (Convert.ToString(scust) != "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += "," + scust;
                }
                else
                {
                    msg += scust;
                }
            }

            if (line == "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += ", items";
                }
                else
                {
                    msg += " items";
                }
            }


            if (Convert.ToString(no) != "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += "," + no;
                }
                else
                {
                    msg += no;
                }
            }
            if (Convert.ToString(qty) != "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += "," + qty;
                }
                else
                {
                    msg += qty;
                }
            }
            if (Convert.ToString(wt) != "")
            {
                if (Convert.ToString(msg) != "")
                {
                    msg += "," + wt;
                }
                else
                {
                    msg += wt;
                }
            }




            if (Convert.ToString(msg) == "")
            {
                SQL = "SELECT IFNULL(MAX(header_id),0)header_id FROM oa_header";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DS = new DataSet();
                ADAP.Fill(DS, "RESULT");
                Int32 hID = 0;
                if (Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["header_id"]) > 0)
                {
                    hID = Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["header_id"]) + 1;
                }
                else
                {
                    hID = 1;
                }

                SQL = "INSERT INTO oa_header (HEADER_ID,ORDER_NO,ORDER_DATE ,B_CUST_ID , S_CUST_ID ,B_CUST_NAME ,S_CUST_NAME ,CREATION_DATE , LIVE_FLAG )VALUES('" + hID + "','" + txtorderno.Text + "',CURDATE(),'" + ddlbillcustomer.SelectedItem.Value + "','" + ddlship.SelectedItem.Value + "','" + ddlbillcustomer.SelectedItem.Text + "','" + ddlship.SelectedItem.Text + "',CURDATE(),1)";
                if (CON.State == ConnectionState.Closed)
                {
                    CON.Open();
                }
                CMD = new OdbcCommand(SQL, CON);
                CMD.ExecuteNonQuery();

                for (int I = 0; I <= GridView1.Rows.Count - 1; I++)
                {
                    TextBox txtitem = new TextBox();
                    txtitem = (TextBox)(GridView1.Rows[I].FindControl("txtitem"));
                    DropDownList txtdesc = new DropDownList();
                    txtdesc = (DropDownList)(GridView1.Rows[I].FindControl("txtdesc"));
                    TextBox txtkind = new TextBox();
                    txtkind = (TextBox)(GridView1.Rows[I].FindControl("txtkind"));
                    TextBox txthsnno = new TextBox();
                    txthsnno = (TextBox)(GridView1.Rows[I].FindControl("txthsnno"));
                    TextBox txtqty = new TextBox();
                    txtqty = (TextBox)(GridView1.Rows[I].FindControl("txtqty"));
                    TextBox txtrate = new TextBox();
                    txtrate = (TextBox)(GridView1.Rows[I].FindControl("txtrate"));
                    TextBox txtweight = new TextBox();
                    txtweight = (TextBox)(GridView1.Rows[I].FindControl("txtweight"));
                    TextBox txtamount = new TextBox();
                    txtamount = (TextBox)(GridView1.Rows[I].FindControl("txtamount"));

                    if (txtitem.Text != "" && txtdesc.Text != "")
                    {
                        SQL = "SELECT IFNULL(MAX(LINE_id),0)LINE_id FROM oa_LINES";
                        ADAP = new OdbcDataAdapter(SQL, CON);
                        DS = new DataSet();
                        ADAP.Fill(DS, "RESULT");
                        Int32 LID = 0;
                        if (Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["LINE_id"]) > 0)
                        {
                            LID = Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["LINE_id"]) + 1;
                        }
                        else
                        {
                            LID = 1;
                        }

                        SQL = "INSERT INTO oa_lines (HEADER_ID,LINE_ID, ITEM_ID,ITEM_NAME ,PACK_TYPE ,HSN_NO ,QUANTITY ,RATE  , WEIGHT ,AMOUNT ,TAX_AMOUNT ,TAX_PERCENTAGE,TOTAL_AMOUNT , CREATION_DATE , LIVE_FLAG )VALUES('" + hID + "','" + LID + "',(SELECT ITEM_ID FROM ITEM_MASTER WHERE ITEM_NAME='" + txtitem.Text + "' and live_flag=1),'" + txtitem.Text + "','" + txtkind.Text + "','" + txthsnno.Text + "','" + txtqty.Text + "','" + txtrate.Text + "','" + txtweight.Text + "','" + txtamount.Text + "',0,0,0,CURDATE(),1)";
                        if (CON.State == ConnectionState.Closed)
                        {
                            CON.Open();
                        }
                        CMD = new OdbcCommand(SQL, CON);
                        CMD.ExecuteNonQuery();
                    }
                }
                Response.Write("<script language='javascript'>alert('Order Saved !! ');</script>");
                BIND();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Please enter " + msg + "');</script>");
            }
        }

        protected void txtitem_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtitem = new TextBox();
            txtitem = (TextBox)(row.FindControl("txtitem"));
            TextBox txtdesc = new TextBox();
            txtdesc = (TextBox)(row.FindControl("txtdesc"));
            TextBox txtkind = new TextBox();
            txtkind = (TextBox)(row.FindControl("txtkind"));
            TextBox txthsnno = new TextBox();
            txthsnno = (TextBox)(row.FindControl("txthsnno"));
            TextBox txtqty = new TextBox();
            txtqty = (TextBox)(row.FindControl("txtqty"));
            TextBox txtrate = new TextBox();
            txtrate = (TextBox)(row.FindControl("txtrate"));
            TextBox txtweight = new TextBox();
            txtweight = (TextBox)(row.FindControl("txtweight"));
            TextBox txtamount = new TextBox();
            txtamount = (TextBox)(row.FindControl("txtamount"));


            SQL = "SELECT * FROM item_master where item_name='" + txtitem.Text + "'";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            Int32 CID = 0;
            if (DS.Tables["RESULT"].Rows.Count > 0)
            {
                txtdesc.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["description"]);
                txthsnno.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["hsn_no"]);
                txtrate.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["price"]);
            }
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtqty = new TextBox();
            txtqty = (TextBox)(row.FindControl("txtqty"));
            TextBox txtrate = new TextBox();
            txtrate = (TextBox)(row.FindControl("txtrate"));
            TextBox txtamount = new TextBox();
            txtamount = (TextBox)(row.FindControl("txtamount"));
            txtamount.Text = Convert.ToString(Convert.ToDouble(txtrate.Text) * Convert.ToDouble(txtqty.Text));

        }

        protected void txtdesc_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);

            TextBox txtitem = new TextBox();
            txtitem = (TextBox)(row.FindControl("txtitem"));
            TextBox txtdesc = new TextBox();
            txtdesc = (TextBox)(row.FindControl("txtdesc"));
            TextBox txtkind = new TextBox();
            txtkind = (TextBox)(row.FindControl("txtkind"));
            TextBox txthsnno = new TextBox();
            txthsnno = (TextBox)(row.FindControl("txthsnno"));
            TextBox txtqty = new TextBox();
            txtqty = (TextBox)(row.FindControl("txtqty"));
            TextBox txtrate = new TextBox();
            txtrate = (TextBox)(row.FindControl("txtrate"));
            TextBox txtweight = new TextBox();
            txtweight = (TextBox)(row.FindControl("txtweight"));
            TextBox txtamount = new TextBox();
            txtamount = (TextBox)(row.FindControl("txtamount"));


            SQL = "SELECT * FROM item_master where item_name='" + txtitem.Text + "'";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            Int32 CID = 0;
            if (DS.Tables["RESULT"].Rows.Count > 0)
            {
                txtdesc.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["description"]);
                txthsnno.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["hsn_no"]);
                txtrate.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["price"]);
            }
        }

        protected void txtdesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);

            TextBox txtitem = new TextBox();
            txtitem = (TextBox)(row.FindControl("txtitem"));

            DropDownList txtdesc = new DropDownList();
            txtdesc = (DropDownList)(row.FindControl("txtdesc"));
            TextBox txthsnno = new TextBox();
            txthsnno = (TextBox)(row.FindControl("txthsnno"));
            TextBox txtrate = new TextBox();
            txtrate = (TextBox)(row.FindControl("txtrate"));

            SQL = "SELECT * FROM item_master where description='" + txtdesc.SelectedItem.Text + "'";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            Int32 CID = 0;
            if (DS.Tables["RESULT"].Rows.Count > 0)
            {
                txtitem.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["ITEM_NAME"]);
                txthsnno.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["hsn_no"]);
                txtrate.Text = Convert.ToString(DS.Tables["RESULT"].Rows[0]["price"]);
            }
        }
    }
}
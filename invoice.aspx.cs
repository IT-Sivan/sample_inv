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
    public partial class invoice : System.Web.UI.Page
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


                ddlfromcus.DataSource = DS;
                ddlfromcus.DataTextField = "CUSTOMER_NAME";
                ddlfromcus.DataValueField = "CUSTOMER_ID";
                ddlfromcus.DataBind();
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


            SQL = "SELECT IFNULL(MAX(invoice_no),0)invoice_no FROM invoice_HEADER where 1=1";
            if (RadioButton1.Checked == true)
            {
                SQL += " and inv_challan_flag=1";
            }
            if (RadioButton2.Checked == true)
            {
                SQL += " and inv_challan_flag=2";
            }
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            String CID = "";
            if (Convert.ToInt32(DS.Tables["RESULT"].Rows.Count) > 0)
            {
                CID = Convert.ToString(Convert.ToInt64(DS.Tables["RESULT"].Rows[0]["invoice_no"]) + 1);
            }
            else
            {
                if (RadioButton1.Checked == true)
                {
                    CID = Convert.ToString(yr + "10001");
                }
                if (RadioButton2.Checked == true)
                {
                    CID = Convert.ToString(yr + "20001");
                }
            }
            txtorderno.Text = Convert.ToString(CID);
            txtdate.Text = Convert.ToString(DateTime.Now);
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (ddlbillcustomer.SelectedItem.Text != "--Select--" && ddlship.SelectedItem.Text != "--Select--")
            {
                SQL = "SELECT (select order_no from oa_header where header_id=a.header_id)order_no,(select order_date from oa_header where header_id=a.header_id)order_date,(select description from item_master where item_name=a.item_name and live_flag=1)description,a.* FROM OA_lines a where header_id in (select header_id from oa_header where b_cust_id='" + ddlbillcustomer.SelectedItem.Value + "') and (Select count(*) from invoice_lines where oa_line_id=a.line_id)=0";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DS = new DataSet();
                ADAP.Fill(DS, "RESULT");
                GridView1.DataSource = DS;
                GridView1.DataBind();
                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    GridView1.Rows[i].Cells[1].Text = Convert.ToString(i + 1);
                }
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Select the bill/ship to customer name !! ');</script>");
            }


        }

        protected void btnsave0_Click(object sender, EventArgs e)
        {

            Int32 n;
            n = 0;
            for (int I = 0; I <= GridView1.Rows.Count - 1; I++)
            {
                CheckBox chk1 = new CheckBox();
                chk1 = (CheckBox)(GridView1.Rows[I].FindControl("chk1"));
                if (chk1.Checked == true)
                {
                    n = 1;
                }
            }


            if (n == 1)
            {
                SQL = "SELECT IFNULL(MAX(inv_header_id),0)header_id FROM invoice_header";
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

                SQL = "INSERT INTO invoice_header (INV_HEADER_ID,INVOICE_NO ,INVOICE_DATE ,B_CUST_ID ,S_CUST_ID ,B_CUST_NAME ,S_CUST_NAME ,UPDATED_DAT , LIVE_FLAG,inv_challan_flag )VALUES('" + hID + "','" + txtorderno.Text + "',CURDATE(),'" + ddlbillcustomer.SelectedItem.Value + "','" + ddlship.SelectedItem.Value + "','" + ddlbillcustomer.SelectedItem.Text + "','" + ddlship.SelectedItem.Text + "',CURDATE(),1";
                if (RadioButton1.Checked == true)
                {
                    SQL += ",1";
                }
                if (RadioButton2.Checked == true)
                {
                    SQL += ",2";
                }
                SQL += ")";
                if (CON.State == ConnectionState.Closed)
                {
                    CON.Open();
                }
                CMD = new OdbcCommand(SQL, CON);
                CMD.ExecuteNonQuery();

                for (int I = 0; I <= GridView1.Rows.Count - 1; I++)
                {
                    CheckBox chk1 = new CheckBox();
                    chk1 = (CheckBox)(GridView1.Rows[I].FindControl("chk1"));

                    TextBox txtoano = new TextBox();
                    txtoano = (TextBox)(GridView1.Rows[I].FindControl("txtoano"));
                    TextBox txtoadt = new TextBox();
                    txtoadt = (TextBox)(GridView1.Rows[I].FindControl("txtoadt"));
                    TextBox txtitem = new TextBox();
                    txtitem = (TextBox)(GridView1.Rows[I].FindControl("txtitem"));
                    TextBox txtdesc = new TextBox();
                    txtdesc = (TextBox)(GridView1.Rows[I].FindControl("txtdesc"));
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
                    Label Lheader_id = new Label();
                    Lheader_id = (Label)(GridView1.Rows[I].FindControl("Lheader_id"));
                    Label Lline_id = new Label();
                    Lline_id = (Label)(GridView1.Rows[I].FindControl("Lline_id"));

                    if (chk1.Checked == true)
                    {

                        SQL = "SELECT IFNULL(MAX(inv_LINE_id),0)LINE_id FROM invoice_LINES";
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

                        SQL = "INSERT INTO invoice_lines (INV_HEADER_ID,INV_LINE_ID,INVOICE_NO,INVOICE_DATE, OA_HEADER_ID,OA_LINE_ID, ITEM_ID,ITEM_NAME,INVOICE_QTY ,RATE , WEIGHT ,AMOUNT  ,TAX_PERCENTAGE,UPDATED_DAT , LIVE_FLAG  )VALUES('" + hID + "','" + LID + "', '" + txtorderno.Text + "' ,curdate(), '" + Lheader_id.Text + "' ,'" + Lline_id.Text + "',(SELECT ITEM_ID FROM ITEM_MASTER WHERE ITEM_NAME='" + txtitem.Text + "'  and live_flag=1),'" + txtitem.Text + "', '" + txtqty.Text + "','" + txtrate.Text + "','" + txtweight.Text + "','" + txtamount.Text + "',0,CURDATE(),1)";
                        if (CON.State == ConnectionState.Closed)
                        {
                            CON.Open();
                        }
                        CMD = new OdbcCommand(SQL, CON);
                        CMD.ExecuteNonQuery();
                    }
                }


                Response.Write("<script language='javascript'>alert('Invoice Created !! ');</script>");
                btnsave_Click(sender, e);
                BIND();
            }

        }

        protected void btnsave1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = true;
            SQL = "SELECT (select order_no from oa_header where header_id=a.OA_header_id)order_no,(select order_date from oa_header where header_id=a.OA_header_id)order_date, (select INVOICE_no from INVOICE_header where INV_header_id=a.INV_header_id)order_no,(select INVOICE_date from INVOICE_header where INV_header_id=a.INV_header_id)order_date,(select b_cust_name from INVOICE_header where INV_header_id=a.INV_header_id)b_cust_name,(select PACK_TYPE from oa_LINES where LINE_id=a.OA_LINE_id)PACK_TYPE,(select HSN_NO from oa_LINES where LINE_id=a.OA_LINE_id)HSN_NO,(select description from item_master where item_name=a.item_name  and live_flag=1)description,a.* FROM INVOICE_lines a where 1=1";

            if (RadioButton1.Checked == true)
            {
                SQL += " and (select inv_challan_flag from INVOICE_header where INV_header_id=a.INV_header_id)=1";
            }
            if (RadioButton2.Checked == true)
            {
                SQL += " and (select inv_challan_flag from INVOICE_header where INV_header_id=a.INV_header_id)=2";
            }
            if (ddlbillcustomer.SelectedItem.Text != "--Select--")
            {
                SQL += " and (select b_cust_id from INVOICE_header where INV_header_id=a.INV_header_id) = '" + ddlbillcustomer.SelectedItem.Value + "'";
            }




            //--where INV_header_id in (select header_id from oa_header where b_cust_id='" + ddlbillcustomer.SelectedItem.Value + "')";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            GridView2.DataSource = DS;
            GridView2.DataBind();

            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                GridView2.Rows[i].Cells[1].Text = Convert.ToString(i + 1);
            }

            if (RadioButton1.Checked == true)
            {
                GridView2.Columns[2].HeaderText = "Invoice No";
                GridView2.Columns[3].HeaderText = "Invoice Date";
            }
            if (RadioButton2.Checked == true)
            {
                GridView2.Columns[2].HeaderText = "Challan No";
                GridView2.Columns[3].HeaderText = "Challan Date";
            }

        }

        protected void btnsave2_Click(object sender, EventArgs e)
        {
            GridView3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
            SQL = " select * from INVOICE_header a where 1=1";
            if (RadioButton1.Checked == true)
            {
                SQL += " and inv_challan_flag=1";
            }
            if (RadioButton2.Checked == true)
            {
                SQL += " and inv_challan_flag=2";
            }
            if (ddlbillcustomer.SelectedItem.Text != "--Select--")
            {
                SQL += " and  b_cust_id  = '" + ddlbillcustomer.SelectedItem.Value + "'";
            }
            //--where INV_header_id in (select header_id from oa_header where b_cust_id='" + ddlbillcustomer.SelectedItem.Value + "')";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");
            GridView3.DataSource = DS;
            GridView3.DataBind();
            for (int i = 0; i <= GridView3.Rows.Count - 1; i++)
            {
                GridView3.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
            }
            if (RadioButton1.Checked == true)
            {
                GridView3.Columns[1].HeaderText = "Invoice No";
                GridView3.Columns[2].HeaderText = "Invoice Date";
            }
            if (RadioButton2.Checked == true)
            {
                GridView3.Columns[1].HeaderText = "Challan No";
                GridView3.Columns[2].HeaderText = "Challan Date";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);

            Label lblinvno = new Label();
            lblinvno = (Label)(row.FindControl("LInvoice_No0"));


            SQL = " select B.invoice_no, B.invoice_date,B.B_CUST_ID,B.S_CUST_ID,(select description from item_master where item_name=a.item_name and live_flag=1)description,(select hsn_no from item_master where item_name=a.item_name  and live_flag=1)hsn_no,(select pack_type from oa_lines where line_id=a.oa_line_id)pack_type,b.inv_challan_flag,a.* from INVOICE_lines a,INVOICE_HEADER B WHERE A.INV_HEADER_ID=B.INV_HEADER_ID AND B.INVOICE_NO='" + lblinvno.Text + "' ";
            if (RadioButton1.Checked == true)
            {
                SQL += " and inv_challan_flag=1";
            }
            if (RadioButton2.Checked == true)
            {
                SQL += " and inv_challan_flag=2";
            }
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");

            if (DS.Tables["RESULT"].Rows.Count > 0)
            {
                SQL = "SELECT * FROM CUSTOMER WHERE CUSTOMER_ID='" + DS.Tables["RESULT"].Rows[0]["B_CUST_ID"] + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DataSet CDS = new DataSet();
                ADAP.Fill(CDS, "RESULT");

                SQL = "SELECT * FROM CUSTOMER WHERE CUSTOMER_ID='" + DS.Tables["RESULT"].Rows[0]["S_CUST_ID"] + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DataSet SCDS = new DataSet();
                ADAP.Fill(SCDS, "RESULT");

                string s;
                s = "<HTML>";
                s += "<head>";
                s += "<style>";
                s += "table, th, td {";
                s += "border: 1px solid black;";
                s += "border-collapse: collapse;";
                s += "}";
                s += "</style>";
                s += "</head>";
                s += "<BODY>";
                if (Convert.ToString(DS.Tables["RESULT"].Rows[0]["inv_challan_flag"]) == "1")
                {
                    s += "<H3 align='center'>TAX INVOICE</H3>";
                }
                if (Convert.ToString(DS.Tables["RESULT"].Rows[0]["inv_challan_flag"]) == "2")
                {
                    s += "<H3 align='center'>Delivery Challan</H3>";
                }

                SQL = "SELECT * FROM CUSTOMER WHERE CUSTOMER_name='" + ddlfromcus.SelectedItem.Text + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DataSet fCDS = new DataSet();
                ADAP.Fill(fCDS, "RESULT");


                s += "<TABLE width='100%'>";
                if (fCDS.Tables["RESULT"].Rows.Count>0)
                {
                    s += "<TR><TD ROWSPAN=3 colspan=3>" + fCDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"] + "<br>" + fCDS.Tables["RESULT"].Rows[0]["ADDRESS1"] + ",<BR>" + fCDS.Tables["RESULT"].Rows[0]["ADDRESS2"] + ",<br>" + fCDS.Tables["RESULT"].Rows[0]["ADDRESS3"] + ",<br>TIRUPUR<BR>GSTIN/UIN : " + fCDS.Tables["RESULT"].Rows[0]["GST"] + ",<BR>State Name : Tamil Nadu Code : 33</TD><TD colspan=2> <div style='float:left; width: 50 %;'>";
                }
                else
                {
                    s += "<TR><TD ROWSPAN=3 colspan=3>PANDIYAN TEX<br>8/2793-H1,<BR>Vidhyapathy Kovil Street,<br>Pandiyan Nagar,<br>TIRUPUR<BR>GSTIN/UIN : 33CHQPP5583A1Z5<BR>State Name : Tamil Nadu Code : 33</TD><TD colspan=2> <div style='float:left; width: 50 %;'>";
                }
                //



                if (Convert.ToString(DS.Tables["RESULT"].Rows[0]["inv_challan_flag"]) == "1")
                {
                    s += "Invoice No.";
                }
                if (Convert.ToString(DS.Tables["RESULT"].Rows[0]["inv_challan_flag"]) == "2")
                {

                    s += "Challan No.";
                }
                s += "<BR><B>" + lblinvno.Text + "</B></div>";

                s += "  <div style='float:right; width: 50 %;'>e-Way Bill No.</div></TD><TD colspan=2>Dated<BR><B>" + row.Cells[1].Text + "</B></TD></TR>";
                s += "<TR><TD colspan=3>Delivery Note</TD><TD colspan=2>Mode/Terms of Payment</TD></TR>";
                s += "<TR><TD colspan=3>Reference No. & Date</TD><TD colspan=2>Other References</TD></TR>";

                s += "<TR><TD ROWSPAN=3 colspan=3>Consignee (Ship to)";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"] + "";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["ADDRESS1"] + "";
                s += " ," + CDS.Tables["RESULT"].Rows[0]["ADDRESS2"] + "";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["ADDRESS3"] + "";
                s += "  <BR>GSTIN/UIN : " + CDS.Tables["RESULT"].Rows[0]["GST"] + "";
                s += " <BR>State : " + CDS.Tables["RESULT"].Rows[0]["STATE"] + "";
                s += " Code : " + CDS.Tables["RESULT"].Rows[0]["STATE_CODE"] + "";
                s += "</TD>";


                s += "<TD colspan=2>Buyer's Order No</TD><TD colspan=2>Dated</TD></TR>";
                s += "<tr><TD colspan=3>Despatch Doc No</TD><TD colspan=2>Delivery Note Date</TD></TR>";
                s += "<TR><TD colspan=3>Despatched through</TD><TD colspan=2>Destination</TD></TR>";


                s += "<TR><TD colspan=3>Buyer (Bill to)";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"] + "";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["ADDRESS1"] + "";
                s += " ," + SCDS.Tables["RESULT"].Rows[0]["ADDRESS2"] + "";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["ADDRESS3"] + "";
                s += " <BR>GSTIN/UIN : " + SCDS.Tables["RESULT"].Rows[0]["GST"] + "";
                s += " <BR>State : " + SCDS.Tables["RESULT"].Rows[0]["STATE"] + "";
                s += " Code : " + SCDS.Tables["RESULT"].Rows[0]["STATE_CODE"] + "";
                s += "</TD>";
                s += "<TD colspan=2></TD><TD  colspan=2></TD> </TR>";

                s += "<tr><td width='10px'>SI No.</td><td>Description of Goods</td><td>HSN/SAC</td><td >Quantity</td><td>Rate</td><td>Per</td><td>Amount</td></tr>";

                Double totamt = 0;
                s += "<tr height=180px>";
                string sno, item, hsn, qty, rate, paketype, amount;

                sno = "";
                item = "";
                hsn = "";
                qty = "";
                rate = "";
                paketype = "";
                amount = "";

                for (int k = 0; k <= DS.Tables["RESULT"].Rows.Count - 1; k++)
                {
                    sno += k + 1 + "<br>";
                    item += Convert.ToString(DS.Tables["RESULT"].Rows[k]["description"]) + "<br>";
                    hsn += Convert.ToString(DS.Tables["RESULT"].Rows[k]["hsn_no"]) + "<br>";
                    qty += Convert.ToString(DS.Tables["RESULT"].Rows[k]["invoice_qty"]) + "<br>";
                    rate += Convert.ToString(DS.Tables["RESULT"].Rows[k]["rate"]) + "<br>";
                    paketype += Convert.ToString(DS.Tables["RESULT"].Rows[k]["pack_type"]) + "<br>";
                    amount += Convert.ToString(DS.Tables["RESULT"].Rows[k]["Amount"]) + "<br>";

                    totamt = Convert.ToDouble(totamt + Convert.ToDouble(DS.Tables["RESULT"].Rows[k]["Amount"]));

                }


                s += " <td valign='top'>" + sno + "</td><td valign='top'>" + item + "</td><td valign='top'>" + hsn + "</td><td align='right' valign='top'>" + qty + "</td><td align='right' valign='top'>" + rate + "</td><td valign='top'>" + paketype + "</td><td align='right' valign='top'>" + amount + "</td> ";

                s += " </tr>";

                s += "<tr height='30px' align='Right'><td>Total</td><td></td><td></td><td></td><td></td><td></td><td align='right'>" + totamt + "";
                if (Convert.ToString(SCDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"]) == "SRI BALAJI GARMENTS")
                {
                    s += "<br>3% Discount " + (totamt * 3) / 100 + "";
                }


                s += "</td></tr>";


                // Console.WriteLine("Enter a Number to convert to words");
                string number = Convert.ToString(totamt);
                number = NumberToWords.ConvertAmount(double.Parse(number));

                s += " <tr><td colspan=7>Amount Chargeable (in words) : " + number + "</td></tr>";

                double t1 = 0;
                double t2 = 0;
                double tt = 0;

                if (Convert.ToString(SCDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"]) == "SRI BALAJI GARMENTS")
                {
                    t1 = (Convert.ToDouble(((totamt * 3) / 100)) * 2.5) / 100;
                    t2 = (Convert.ToDouble(((totamt * 3) / 100)) * 2.5) / 100;
                }
                else
                {
                    t1 = (Convert.ToDouble(totamt) * 2.5) / 100;
                    t2 = (Convert.ToDouble(totamt) * 2.5) / 100;
                }
                tt = t1 + t2;

                s += "<tr><td>HSN/SAC</td><td>Taxable Value</td><td colspan=2>Central Tax</td><td colspan=2>State Tax</td><td rowspan=2>Toal Tax Amount</td></tr>";
                s += "<tr><td rowspan=2>HSN/SAC value</td><td rowspan=2 align='Right'>" + totamt + "</td><td>Rate</td><td>Amount</td><td>Rate</td><td>Amount</td> </tr>";
                s += "<tr><td align='Right'>2.50%</td><td align='Right'>" + t1 + "</td><td align='Right'>2.50%</td><td align='Right'>" + t2 + "</td><td align='Right'>" + tt + "</td></tr>";

                s += "<tr><td align='Right'><b>Total</b></td><td align='Right'><b>" + totamt + "</b></td><td align='Right'><b></b></td><td align='Right'><b>" + t1 + "</b></td><td align='Right'><b></b></td><td align='Right'><b>" + t2 + "</b></td><td align='Right'><b>" + tt + "</b></td></tr>";


                string number1 = Convert.ToString(tt);
                number1 = NumberToWords.ConvertAmount(double.Parse(number1));

                //  s += " <tr><td colspan=7>Amount Chargeable (in words) : " + number1 + "</td></tr>";


                s += " <tr><td colspan=7><div>Tax Amount (in words) : " + number1 + "<BR>PAN NO : CHQPP5583A</div><br><div style='float:right; width: 50 %;'> Company's Bank Details<br>Bank Name : ICICI BANK<br>A/c No : 253805001415<br>Branch / IFS Code : PN Road,TIRUPUR / ICIC0002538</div></td></tr>";

                s += " <tr><td colspan=6> <u>Declaration</u><br>We declare that this invoice shows the actual price of the <br>goods described and that all particulars are true and correct.</td>";
                s += "  <td align='center' height='100px'>For PANDIYAN TEX <br><br> <br></td></tr>";

                s += "</TABLE>";
                s += "</BODY>";
                s += "</HTML>";
                Session["s"] = s;
                string url = "inv_print.aspx";
                string s1 = "window.open('" + url + "', 'popup_window', 'width=600,height=600,left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s1, true);
            }
        }



        protected void btnprintbill_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((Button)sender).NamingContainer);
            SQL = " select B.invoice_no, B.invoice_date,B.B_CUST_ID,B.S_CUST_ID,(select description from item_master where item_name=a.item_name and live_flag=1)description,(select hsn_no from item_master where item_name=a.item_name  and live_flag=1)hsn_no,(select pack_type from oa_lines where line_id=a.oa_line_id)pack_type,b.inv_challan_type,a.* from INVOICE_lines a,INVOICE_HEADER B WHERE A.INV_HEADER_ID=B.INV_HEADER_ID AND B.INVOICE_NO='" + row.Cells[0].Text + "' ";
            ADAP = new OdbcDataAdapter(SQL, CON);
            DS = new DataSet();
            ADAP.Fill(DS, "RESULT");

            if (DS.Tables["RESULT"].Rows.Count > 0)
            {
                SQL = "SELECT * FROM CUSTOMER WHERE CUSTOMER_ID='" + DS.Tables["RESULT"].Rows[0]["B_CUST_ID"] + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DataSet CDS = new DataSet();
                ADAP.Fill(CDS, "RESULT");

                SQL = "SELECT * FROM CUSTOMER WHERE CUSTOMER_ID='" + DS.Tables["RESULT"].Rows[0]["S_CUST_ID"] + "'";
                ADAP = new OdbcDataAdapter(SQL, CON);
                DataSet SCDS = new DataSet();
                ADAP.Fill(SCDS, "RESULT");

                string s;
                s = "<HTML>";
                s += "<head>";
                s += "<style>";
                s += "table, th, td {";
                s += "border: 1px solid black;";
                s += "border-collapse: collapse;";
                s += "}";
                s += "</style>";
                s += "</head>";
                s += "<BODY>";
                if (Convert.ToInt32(DS.Tables["RESULT"].Rows[0]["inv_challan_type"]) == 1)
                {
                    s += "<H3 align='center'>TAX INVOICE</H3>";
                }
                else
                {
                    s += "<H3 align='center'>Delivery Challan</H3>";
                }


                s += "<TABLE width='100%'>";
                s += "<TR><TD ROWSPAN=3 colspan=3>PANDIYAN TEX<br>8/2793-H1,<BR>Vidhyapathy Kovil Street,<br>Pandiyan Nagar,<br>TIRUPUR<BR>GSTIN/UIN : 33CHQPP5583A1Z5<BR>State Name : Tamil Nadu Code : 33</TD><TD colspan=2> <div style='float:left; width: 50 %;'>Invoice No.<BR><B>" + row.Cells[0].Text + "</B></div>";
                s += "  <div style='float:right; width: 50 %;'>e-Way Bill No.</div></TD><TD colspan=2>Dated<BR><B>" + row.Cells[1].Text + "</B></TD></TR>";
                s += "<TR><TD colspan=3>Delivery Note</TD><TD colspan=2>Mode/Terms of Payment</TD></TR>";
                s += "<TR><TD colspan=3>Reference No. & Date</TD><TD colspan=2>Other References</TD></TR>";

                s += "<TR><TD ROWSPAN=3 colspan=3>Consignee (Ship to)";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"] + "";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["ADDRESS1"] + "";
                s += " ," + CDS.Tables["RESULT"].Rows[0]["ADDRESS2"] + "";
                s += " <BR>" + CDS.Tables["RESULT"].Rows[0]["ADDRESS3"] + "";
                s += "  <BR>GSTIN/UIN : " + CDS.Tables["RESULT"].Rows[0]["GST"] + "";
                s += " <BR>State : " + CDS.Tables["RESULT"].Rows[0]["STATE"] + "";
                s += " Code : " + CDS.Tables["RESULT"].Rows[0]["STATE_CODE"] + "";
                s += "</TD>";


                s += "<TD colspan=2>Buyer's Order No</TD><TD colspan=2>Dated</TD></TR>";
                s += "<tr><TD colspan=3>Despatch Doc No</TD><TD colspan=2>Delivery Note Date</TD></TR>";
                s += "<TR><TD colspan=3>Despatched through</TD><TD colspan=2>Destination</TD></TR>";


                s += "<TR><TD colspan=3>Buyer (Bill to)";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["CUSTOMER_NAME"] + "";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["ADDRESS1"] + "";
                s += " ," + SCDS.Tables["RESULT"].Rows[0]["ADDRESS2"] + "";
                s += " <BR>" + SCDS.Tables["RESULT"].Rows[0]["ADDRESS3"] + "";
                s += " <BR>GSTIN/UIN : " + SCDS.Tables["RESULT"].Rows[0]["GST"] + "";
                s += " <BR>State : " + SCDS.Tables["RESULT"].Rows[0]["STATE"] + "";
                s += " Code : " + SCDS.Tables["RESULT"].Rows[0]["STATE_CODE"] + "";
                s += "</TD>";
                s += "<TD colspan=2></TD><TD  colspan=2></TD> </TR>";

                s += "<tr><td width='10px'>SI No.</td><td>Description of Goods</td><td>HSN/SAC</td><td >Quantity</td><td>Rate</td><td>Per</td><td>Amount</td></tr>";

                Double totamt = 0;
                s += "<tr>";
                string sno, item, hsn, qty, rate, paketype, amount;

                sno = "";
                item = "";
                hsn = "";
                qty = "";
                rate = "";
                paketype = "";
                amount = "";

                for (int k = 0; k <= DS.Tables["RESULT"].Rows.Count - 1; k++)
                {
                    sno += k + 1 + "<br>";
                    item += Convert.ToString(DS.Tables["RESULT"].Rows[k]["description"]) + "<br>";
                    hsn += Convert.ToString(DS.Tables["RESULT"].Rows[k]["hsn_no"]) + "<br>";
                    qty += Convert.ToString(DS.Tables["RESULT"].Rows[k]["invoice_qty"]) + "<br>";
                    rate += Convert.ToString(DS.Tables["RESULT"].Rows[k]["rate"]) + "<br>";
                    paketype += Convert.ToString(DS.Tables["RESULT"].Rows[k]["pack_type"]) + "<br>";
                    amount += Convert.ToString(DS.Tables["RESULT"].Rows[k]["Amount"]) + "<br>";

                    totamt = Convert.ToDouble(totamt + Convert.ToDouble(DS.Tables["RESULT"].Rows[k]["Amount"]));

                }
                s += " <td>" + sno + "</td><td>" + item + "</td><td>" + hsn + "</td><td align='right'>" + qty + "</td><td align='right'>" + rate + "</td><td>" + paketype + "</td><td align='right'>" + amount + "</td> ";





                s += " </tr>";



                s += "<tr height='30px' align='Right'><td>Total</td><td></td><td></td><td></td><td></td><td></td><td align='right'>" + totamt + "</td></tr>";


                // Console.WriteLine("Enter a Number to convert to words");
                string number = Convert.ToString(totamt);
                number = NumberToWords.ConvertAmount(double.Parse(number));

                s += " <tr><td colspan=7>Amount Chargeable (in words) : " + number + "</td></tr>";

                double t1 = 0;
                double t2 = 0;
                double tt = 0;
                t1 = (Convert.ToDouble(totamt) * 2.5) / 100;
                t2 = (Convert.ToDouble(totamt) * 2.5) / 100;
                tt = t1 + t2;

                s += "<tr><td>HSN/SAC</td><td>Taxable Value</td><td colspan=2>Central Tax</td><td colspan=2>State Tax</td><td rowspan=2>Toal Tax Amount</td></tr>";
                s += "<tr><td rowspan=2>HSN/SAC value</td><td rowspan=2 align='Right'>" + totamt + "</td><td>Rate</td><td>Amount</td><td>Rate</td><td>Amount</td> </tr>";
                s += "<tr><td align='Right'>2.50%</td><td align='Right'>" + t1 + "</td><td align='Right'>2.50%</td><td align='Right'>" + t2 + "</td><td align='Right'>" + tt + "</td></tr>";

                s += "<tr><td align='Right'><b>Total</b></td><td align='Right'><b>" + totamt + "</b></td><td align='Right'><b></b></td><td align='Right'><b>" + t1 + "</b></td><td align='Right'><b></b></td><td align='Right'><b>" + t2 + "</b></td><td align='Right'><b>" + tt + "</b></td></tr>";


                string number1 = Convert.ToString(tt);
                number1 = NumberToWords.ConvertAmount(double.Parse(number1));

                //  s += " <tr><td colspan=7>Amount Chargeable (in words) : " + number1 + "</td></tr>";


                s += " <tr><td colspan=7><div>Tax Amount (in words) : " + number1 + "<BR>PAN NO : CHQPP5583A</div><br><div style='float:right; width: 50 %;'> Company's Bank Details<br>Bank Name : ICICI BANK<br>A/c No : 253805001415<br>Branch / IFS Code : PN Road,TIRUPUR / ICIC0002538</div></td></tr>";

                s += " <tr><td colspan=6> <u>Declaration</u><br>We declare that this invoice shows the actual price of the <br>goods described and that all particulars are true and correct.</td>";
                s += "  <td align='center' height='100px'>For PANDIYAN TEX <br><br> <br></td></tr>";

                s += "</TABLE>";
                s += "</BODY>";
                s += "</HTML>";
                Session["s"] = s;
                string url = "inv_print.aspx";
                string s1 = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s1, true);


            }
        }

        protected void btnsave3_Click(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                Label4.Text = "Invoice No";
                btnsave0.Text = "Create Invoice";
                btnsave1.Text = "View Invoice";
                btnsave2.Text = "Print Invoice";
            }

            if (RadioButton2.Checked == true)
            {
                Label4.Text = "Challan No";
                btnsave0.Text = "Create Challan";
                btnsave1.Text = "View Challan";
                btnsave2.Text = "Print Challan";
            }
            BIND();
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                Label4.Text = "Invoice No";
                btnsave0.Text = "Create Invoice";
                btnsave1.Text = "View Invoice";
                btnsave2.Text = "Print Invoice";
            }

            if (RadioButton2.Checked == true)
            {
                Label4.Text = "Challan No";
                btnsave0.Text = "Create Challan";
                btnsave1.Text = "View Challan";
                btnsave2.Text = "Print Challan";
            }
            BIND();
        }
    }
}
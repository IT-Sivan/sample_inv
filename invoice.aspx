<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="sample_inv.invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    
     <link href="Bootstrap/css/bootstrap.rtl.min.css" rel="stylesheet" />
    <script src="Bootstrap/js/bootstrap.min.js"></script>

    
 <style>
        
        .active a
        {
            color: #4cff00 !important;
        }
        .title
        {
            color: #fff;
            font-weight: 700;
            font-size: 23px;
            margin-left: 275px;
           
            text-shadow: 2px 3px #000;
        }
        .image
        {
            border-radius: 29px;
            background-color: #fff;
            height: 41px;
            margin-left: 14px;
            width:19%;
            margin-top: -3px;
        }
        .style
        {    
            width: 76%;
            margin-left: 14px;
            height: 33px;
            margin-top: 6px;
            background-color: #fff;

        }
        .card 
        {
            box-shadow: 0 0 12px 0px #dedede;
            flex-basis: 20%;
            padding: 2% 3%;
            margin: 2% 0;
            border-radius: 18px;
            cursor: pointer;
            transition: 0.3s;
            width: 18%;
            height: 148px;
            margin-left: 40px;

        }
        .panel
        {
            box-sizing: border-box;
            margin-left: 170px;
            width: 75%;
            height: 300px;
            margin-top: 63px;
            border: 1px solid;
            box-shadow: 6px 9px 11px -1px #9d9d9d;
        }
        .textbox
        {
            border-radius: 35px;
            height: 33px;
            width: 100%;
        }
        .label
        {
            margin-left: 5px;
            line-height: 34px;
            color: #c70d0d;
            font-weight: 500;
        }
         .form-control1
        {
            display: block;
            padding: 0.375rem 0.75rem;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: 0.375rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
     
         <nav class="navbar navbar-expand-lg navbar-dark bd-navbar sticky-top" style="background-color: #712cf9;margin-bottom: 14px;">
        
            <div class="navbar-collapse" id="navbarText">
         
                <div class="card-header">
                   
                    <div class="title">  PANDIYAN TEX </div>
         
                </div>
      
                <ul class="navbar-nav" style="margin-left: 120px;font-weight: 600;font-family: sans-serif;font-size: 15px;">
        
                    <li class="nav-item ">
          
                        <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="WebForm1.aspx">Customer</a>
                        
        
                    </li>

        
                    <li class="nav-item ">
          
                        <a class="nav-link" style="color: #fff;margin-left: 26px;" href="hsn.aspx">HSN</a>
        
                    </li>

                     <li class="nav-item ">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="order.aspx">Order</a>

                  </li>

                    <li class="nav-item active">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="invoice.aspx">Invoice</a>

                  </li>
           
                    <li class="nav-item" style="color: #ffeb3b;font-weight: 300;margin-left: 121PX;margin-top: 8px;"></li>
      
                </ul>
    
            </div>
 
        </nav>

        <div class="container-fluid">

                     <div class="row" style="margin-top: 20px;" >
                		
		                 <div class="col-md-12" >                        
            
                             <div class="row" style="display: -webkit-box !important;" >
                                  <div class="col-md-2"  style="MARGIN-TOP: 2REM;">
                                      <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Style="color: #fd6f0a;
    font-weight: 700;margin-left: 26px;" Checked="True" GroupName="1" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Invoice" />
                                      <asp:RadioButton ID="RadioButton2" runat="server" Style="color: #fd0ac9;
    font-weight: 700;margin-left: 26px;" AutoPostBack="True" GroupName="1" OnCheckedChanged="RadioButton2_CheckedChanged" Text="Challan" />
                                  </div>
                                    <div class="col-md-2" >
                                          <asp:Label ID="Label4" class="label" runat="server">Invoice No</asp:Label>
                                        <asp:TextBox ID="txtorderno" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                  <div class="col-md-2" >
                                          <asp:Label ID="Label1" class="label" runat="server">Date</asp:Label>
                                        <asp:TextBox ID="txtdate" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                   <div class="col-md-2" >
                                          <asp:Label ID="Label3" class="label" runat="server">From Customer Name</asp:Label>
                                          <%-- <asp:TextBox ID="txtpartno" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlfromcus" class="form-control textbox"  runat="server"></asp:DropDownList>
                                    </div>

                                 <div class="col-md-2" >
                                          <asp:Label ID="Label5" class="label" runat="server">Bill Customer Name</asp:Label>
                                          <%-- <asp:TextBox ID="txtpartno" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlbillcustomer" class="form-control textbox"  runat="server"></asp:DropDownList>
                                    </div>

                                  <div class="col-md-2" >
                                          <asp:Label ID="Label2" class="label" runat="server">Ship to</asp:Label>
                                          <%-- <asp:TextBox ID="txtpartno" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlship" class="form-control textbox"  runat="server"></asp:DropDownList>
                                    </div>
                         </div>

                    </div>

              </div>

             <div class="row" style="margin-top: 28px;" >

                  <div class="col-md-12" >                        
            
                             <div class="row" style="display: -webkit-box !important;" >
                                  <div class="col-md-2" ></div>
                                      <div class="col-md-2"  >
                                    <asp:Button ID="btnsave" class="btn btn-warning" runat="server" Text="View Pending Orders" OnClick="btnsave_Click"  />
                                      </div>
                                  <div class="col-md-2" style="margin-left: -2rem;" >
          <asp:Button ID="btnsave0" class="btn btn-primary " runat="server" Text="Create Invoice" OnClick="btnsave0_Click"  />
                                      &nbsp;</div>
                                  <div class="col-md-2" style="margin-left: -5rem;" >

           <asp:Button ID="btnsave1" class="btn btn-success" runat="server" Text="View Invoice" OnClick="btnsave1_Click" style="height: 37px"  />
                                      </div>
                                  <div class="col-md-2"  style="margin-left: -6rem;">
          <asp:Button ID="btnsave2" class="btn btn-info" runat="server" Text="Print Invoice" OnClick="btnsave2_Click"  />
                                      </div>
                                  <div class="col-md-2" style="margin-left: -6rem;">
                                      </div>

         
                 </div>
           </div>
      </div>
                 <%--  <div class="row" style="margin-top: 80px;" >

                         <div class="col-md-12">

                             <div class="row" style="display: -webkit-box !important;" >

                                 <div class="col-md-4"></div>

                                  <div class="col-md-1">

                                    <asp:Button ID="btnsave" class="btn btn-success" runat="server" Text="Save"  />

                                 </div>

                                 <div class="col-md-1">

                                         <asp:Button ID="btnedit" class="btn btn-warning" runat="server" Text="Edit"  />

                                  </div>

                                 <div class="col-md-1">

                                        <asp:Button ID="btndelete" class="btn btn-danger"  runat="server" Text="Delete" />
                                </div>

                                 <div class="col-md-1">

                                    <asp:Button ID="btnview" class="btn btn-primary"  runat="server" Text="View" />

                                 </div>

                                 <div class="col-md-1">

                                     <asp:Button ID="btnreset" class="btn btn-info"  runat="server" Text="Reset"  />
                                 </div>

                                  <div class="col-md-3"></div>
                           
                       </div>

                   </div>

           </div>--%>
            <br />
                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:CheckBox ID="chk1" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>

                      <asp:BoundField HeaderText="S.No" />
                      <asp:TemplateField HeaderText="Order No">
                          <ItemTemplate>
                              <asp:TextBox ID="txtoano" runat="server" Width="120px" Text='<%# Bind("order_no") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Order Date">
                          <ItemTemplate>
                              <asp:TextBox ID="txtoadt" runat="server" class="form-control1"  Width="90px"  Text='<%# Bind("order_date") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                     <asp:TemplateField HeaderText="Item">
                         <ItemTemplate>
                             <asp:TextBox ID="txtitem" class="form-control1" runat="server" Width="119px" AutoPostBack="True" Text='<%# Bind("item_name") %>'></asp:TextBox>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                     

                      <asp:TemplateField HeaderText="Description">
                         <ItemTemplate>
                             <asp:TextBox ID="txtdesc" class="form-control1" Width="150px" runat="server"  Text='<%# Bind("description") %>'></asp:TextBox>
                         </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:TemplateField  HeaderText="No & Kind of Packages">
                        <ItemTemplate >
                            <asp:TextBox ID="txtkind" class="form-control1" AutoPostBack="true"  runat="server" 
                                  Width="82px"  Text='<%# Bind("pack_type") %>'></asp:TextBox>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                     
                    
                    <asp:TemplateField  HeaderText="HSN No">
                        <ItemTemplate >
                            <asp:TextBox ID="txthsnno" class="form-control1"  runat="server" Width="90px"  Text='<%# Bind("hsn_no") %>' ></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                                    

                    <asp:TemplateField HeaderText="Rate" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtrate" class="form-control1" Width="90px" runat="server" Text='<%# Bind("rate") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Weight" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtweight" class="form-control1" Width="90px"   runat="server"  Text='<%# Bind("weight") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                        
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqty" class="form-control1"  runat="server" Width="80px"   Text='<%# Bind("quantity") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                                           
                     <asp:TemplateField HeaderText="Amount" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtamount" class="form-control1"  Width="90px"  runat="server"  Text='<%# Bind("amount") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
 
                      <asp:TemplateField HeaderText="Order Header Id">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("header_id") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Lheader_id" runat="server" Text='<%# Bind("header_id") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Order Line Id">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("line_id") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Lline_id" runat="server" Text='<%# Bind("line_id") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
 
                </Columns>
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <FooterStyle BackColor="#28e7ff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#28e7ff"  Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                
            </asp:GridView>

      </div>

                        <asp:GridView ID="GridView2" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None" Visible="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:CheckBox ID="chk2" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>

                      <asp:BoundField HeaderText="S.No" />
                      <asp:TemplateField HeaderText="Invoice No">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Invoice_No") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="LInvoice_No" runat="server" Text='<%# Bind("Invoice_No") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Invoice Date">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("invioce_date") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Linvioce_date" runat="server" Text='<%# Bind("invOIce_date") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Order No">
                          <ItemTemplate>
                              <asp:TextBox ID="txtoano0" runat="server" Width="90px" Text='<%# Bind("order_no") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Order Date">
                          <ItemTemplate>
                              <asp:TextBox ID="txtoadt0" runat="server" class="form-control1"  Width="90px"  Text='<%# Bind("order_date") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                     <asp:TemplateField HeaderText="Item">
                         <ItemTemplate>
                             <asp:TextBox ID="txtitem0" class="form-control1" runat="server" Width="119px" AutoPostBack="True" Text='<%# Bind("item_name") %>'></asp:TextBox>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                     

                      <asp:TemplateField HeaderText="Description">
                         <ItemTemplate>
                             <asp:TextBox ID="txtdesc0" class="form-control1" Width="60px" runat="server"  Text='<%# Bind("description") %>'></asp:TextBox>
                         </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:TemplateField  HeaderText="No & Kind of Packages">
                        <ItemTemplate >
                            <asp:TextBox ID="txtkind0" class="form-control1" AutoPostBack="true"  runat="server" 
                                  Width="82px"  Text='<%# Bind("pack_type") %>'></asp:TextBox>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                     
                    
                    <asp:TemplateField  HeaderText="HSN No">
                        <ItemTemplate >
                            <asp:TextBox ID="txthsnno0" class="form-control1"  runat="server" Width="90px"  Text='<%# Bind("hsn_no") %>' ></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                                    

                    <asp:TemplateField HeaderText="Rate" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtrate0" class="form-control1" Width="90px" runat="server" Text='<%# Bind("rate") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Weight" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtweight0" class="form-control1" Width="90px"   runat="server"  Text='<%# Bind("weight") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                        
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqty0" class="form-control1"  runat="server" Width="80px"   Text='<%# Bind("INVOICE_QTY") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                                           
                     <asp:TemplateField HeaderText="Amount" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtamount0" class="form-control1"  Width="90px"  runat="server"  Text='<%# Bind("amount") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
 
                      
 
                </Columns>
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <FooterStyle BackColor="#28e7ff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#28e7ff"  Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             
            </asp:GridView>

                        <asp:GridView ID="GridView3" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:BoundField HeaderText="S.No" />
                      <asp:TemplateField HeaderText="Invoice No">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Invoice_No") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="LInvoice_No0" runat="server" Text='<%# Bind("Invoice_No") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Invoice Date">
                          <EditItemTemplate>
                              <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("invioce_date") %>'></asp:TextBox>
                          </EditItemTemplate>
                          <ItemTemplate>
                              <asp:Label ID="Linvioce_date0" runat="server" Text='<%# Bind("invOIce_date") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Generate e-way Bill" Visible="False">
                          <ItemTemplate>
                              <asp:Button ID="btneway" runat="server" OnClick="Button1_Click" Text="Generate e-way Bill" Width="178px" />
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Print">
                          <ItemTemplate>
                              <asp:Button ID="btnprint" runat="server" OnClick="Button1_Click" Text="Print" Width="64px" />
                          </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
 
                      
 
                      <asp:BoundField DataField="b_cust_name" HeaderText="Bill to Customer" />
                      <asp:BoundField DataField="s_cust_name" HeaderText="Ship to Customer" />
 
                      
 
                </Columns>
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <FooterStyle BackColor="#28e7ff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#28e7ff"  Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               
            </asp:GridView>


    </form>
</body>
</html>

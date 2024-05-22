<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="sample_inv.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Bootstrap/css/bootstrap.rtl.min.css" rel="stylesheet" />
    <script src="Bootstrap/js/bootstrap.min.js"></script>

    

    <style>
        .form-width
        {
            width: 15%;
        }
        .col-width
        {
            width: 100%;
        }
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
        .textbox
        {
            /*border-radius: 35px;
            height: 33px;
            width: 100%;*/
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
                   
                    <div class="title"> PANDIYAN TEX </div>
         
                </div>
      
                <ul class="navbar-nav" style="margin-left: 120px;font-weight: 600;font-family: sans-serif;font-size: 15px;">
        
                    <li class="nav-item active">
          
                        <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="WebForm1.aspx">Customer</a>
                        
        
                    </li>

        
                    <li class="nav-item">
          
                        <a class="nav-link" style="color: #fff;margin-left: 26px;" href="hsn.aspx">HSN</a>
        
                    </li>

                     <li class="nav-item">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="order.aspx">Order</a>

                  </li>

                    <li class="nav-item">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="invoice.aspx">Invoice</a>

                  </li>
           
                    <li class="nav-item" style="color: #ffeb3b;font-weight: 300;margin-left: 121PX;margin-top: 8px;"></li>
      
                </ul>
    
            </div>
 
        </nav>

          
        <div class="container-fluid">
            
            <div class="row" >
                		
		        <div class="col-md-12" >                        
            
                    <div class="row" style="display: -webkit-box !important;" >
                       
		
		                <div class="col-md-6" >
			
			                <asp:Label ID="Label1" class="label" runat="server">Customer Name</asp:Label>
			
			                <asp:TextBox ID="txtcustomer" class="form-control textbox" runat= "server"  ></asp:TextBox>
		
						</div>
   
						<div class="col-md-6" >
		
							<asp:Label ID="Label5" class="label" runat="server">Address1</asp:Label>
		
							<asp:TextBox ID="txtadd1" class="form-control textbox" runat= "server"></asp:TextBox>
	
						</div>
  
						<div class="col-md-6" >
	  
							<asp:Label ID="Label6" class="label" runat="server">Address2</asp:Label>
		
							<asp:TextBox ID="txtadd2" class="form-control textbox" runat= "server"></asp:TextBox>
	
						</div>
 
						<div class="col-md-6" >
	 
							<asp:Label ID="Label2" class="label" runat="server">Address3</asp:Label>
	
							<asp:TextBox ID="txtadd3" class="form-control textbox" runat= "server"></asp:TextBox>
   
						</div>
  
						<div class="col-md-6" >
	
							<asp:Label ID="Label7" class="label" runat="server">State</asp:Label>
	
							<asp:TextBox ID="txtstate" class="form-control textbox" runat= "server"></asp:TextBox>
  
						</div>
  
						<div class="col-md-6" >

							<asp:Label ID="Label3" class="label" runat="server">State Code</asp:Label>
	
							<asp:TextBox ID="txtstatecode" class="form-control textbox" runat= "server"></asp:TextBox>

						</div>
	
						<div class="col-md-6" >

							<asp:Label ID="Label4" class="label" runat="server">Pin Code</asp:Label>
		
							<asp:TextBox ID="txtpincode" class="form-control textbox" runat= "server"></asp:TextBox>
  
						</div>

                        <div class="col-md-6" >

							<asp:Label ID="Label8" class="label" runat="server">Phone No</asp:Label>
		
							<asp:TextBox ID="txtphno" class="form-control textbox" runat= "server"></asp:TextBox>
  
						</div>


                        <div class="col-md-6" >

							<asp:Label ID="Label9" class="label" runat="server">GSTIN/UIN</asp:Label>
		
							<asp:TextBox ID="txtgst" class="form-control textbox" runat= "server"></asp:TextBox>
  
						</div>

                          <div class="col-md-1">
                                      <asp:Label ID="Label10" runat="server" style="visibility:hidden"  Text="Label"></asp:Label>
                                         <asp:Button ID="btnsave"  class="btn btn-success btn-md " runat="server" style="color: #fff;" Text="Save" OnClick="btnsave_Click"  />
                                 </div>
	
	                    <asp:Label ID="lblap_id" runat="server" Visible="false" Text="Label"></asp:Label>
	
                        <br />
                        <br />
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">

                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:BoundField HeaderText="S.No" >
                      <ItemStyle Width="50px" />
                      </asp:BoundField>
                      <asp:BoundField DataField="customer_id" HeaderText="Customer ID" >
                      <ItemStyle Width="50px" />
                      </asp:BoundField>
                     <asp:TemplateField HeaderText="Customer">
                         <ItemTemplate>
                             <asp:TextBox ID="txtcust" class="form-control1" runat="server" Width="200px" Text='<%# Bind("customer_name") %>'></asp:TextBox>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                     <%--<asp:TemplateField HeaderText="Product Group">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlproduct" class="form-control1" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason of failure">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlreasonfail" AutoPostBack="true" class="form-control1" runat="server" OnSelectedIndexChanged="ddlreasonfail_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                      <asp:TemplateField HeaderText="Address1">
                         <ItemTemplate>
                             <asp:TextBox ID="txtad1" class="form-control1" Width="60px" runat="server" Text='<%# Bind("address1") %>'></asp:TextBox>
                         </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:TemplateField  HeaderText="Address2">
                        <ItemTemplate >
                            <asp:TextBox ID="txtad2" class="form-control1" AutoPostBack="true"  runat="server" 
                                  Width="82px"  Text='<%# Bind("address2") %>'></asp:TextBox>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     
                    
                    <asp:TemplateField  HeaderText="Address3">
                        <ItemTemplate >
                            <asp:TextBox ID="txtad3" class="form-control1"  runat="server" Width="150px"  Text='<%# Bind("address3") %>' ></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="Root Cause">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlrootcause" class="form-control1"  runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                    <%-- <asp:TemplateField HeaderText="Rework Time">
                        <ItemTemplate>
                           <asp:TextBox ID="txtrewrktime" class="form-control1 " runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                   <%--  <asp:TemplateField HeaderText="Rework Cost">
                        <ItemTemplate>
                           <asp:TextBox ID="txtrewrkcost" class="form-control1"  runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                            <asp:TextBox ID="txtst" class="form-control1"  runat="server" Width="80px" Text='<%# Bind("state") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="Cleaned/Replaced">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkclean" runat="server" Text="C" />
                            <asp:CheckBox ID="chkreplace"  runat="server" Text="R" />
                            <asp:CheckBox ID="chkreassemble"  runat="server" Text="Re-Ass" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>

                    <%--<asp:TemplateField HeaderText="Supplier Name" >
                        <ItemTemplate>
                            <asp:TextBox ID="txtremarks" class="form-control1"   runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlsupplier" class="form-control1" runat="server">
                                <asp:ListItem Value="0">--choose--</asp:ListItem>
                                 <asp:ListItem Value="1">EXCEL PLAST</asp:ListItem>
                                <asp:ListItem Value="2">SRI MAHALAKSHMI INDUSTRIAL</asp:ListItem>
                                <asp:ListItem Value="3">INHOUSE</asp:ListItem>
                                <asp:ListItem Value="4">GREEN VISION ENGINEERING</asp:ListItem>
                                <asp:ListItem Value="5">M.K.INDUSTRIES</asp:ListItem>
                                <asp:ListItem Value="6">VASANTHA FINE WORKS</asp:ListItem>
                                 <asp:ListItem Value="7">SRP SYNTHETIC RUBBER PRODUCTS PVT LTD</asp:ListItem>
                                <asp:ListItem Value="8">VARRMAS ELASSTO SEALS</asp:ListItem>
                                <asp:ListItem Value="9">PRASEE RUBBER TECHNOLOGY</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    
                    <asp:TemplateField HeaderText="State Code" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtstcode" class="form-control1"  Width="80px"   runat="server" Text='<%# Bind("state_code") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Pin Code" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtpin" class="form-control1"   runat="server"  Width="80px"  Text='<%# Bind("pin_code") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    
                     <asp:TemplateField HeaderText="Phone" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtph" class="form-control1"   runat="server"  Width="90px"  Text='<%# Bind("phone") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>


                  <%--  <asp:TemplateField HeaderText="Weight">
                        <ItemTemplate>
                            <asp:Button ID="btnsave"  class="custom-btn btn-6 btn-sm" ForeColor="#000000" runat="server" Text="Save" OnClick="btnsave_Click" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   --%>
                      <asp:TemplateField HeaderText="GST">
                          <ItemTemplate>
                              <asp:TextBox ID="txtgst1" runat="server" class="form-control1" Width="119px" Text='<%# Bind("gst") %>'></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="40px" ImageUrl="~/IMAGES/SAVE1.png" Width="40px" />
                              &nbsp;
                              <asp:ImageButton ID="ImageButton2" runat="server" Height="40px" ImageUrl="~/IMAGES/DELETE.png" OnClick="ImageButton2_Click" Width="40px" OnClientClick=" return confirm('You are about to delete the Customer! Are you sure you want to delete?');"/>
                          </ItemTemplate>
                          <ItemStyle Wrap="False" />
                      </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" Wrap="True" />
                <FooterStyle BackColor="#28e7ff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#28e7ff"  Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                
            </asp:GridView>

                                </td>
                            </tr>
                        </table>
	
                    </div>

                </div>

            </div>

              </div>



    </form>
</body>
</html>

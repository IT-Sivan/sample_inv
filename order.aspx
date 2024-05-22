<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="sample_inv.order" %>

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


     .auto-style1 {
         margin-left: 81px;
         margin-top: 8px;
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
        
                    <li class="nav-item ">
          
                        <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="WebForm1.aspx">Customer</a>
                        
        
                    </li>

        
                    <li class="nav-item ">
          
                        <a class="nav-link" style="color: #fff;margin-left: 26px;" href="hsn.aspx">HSN</a>
        
                    </li>

                     <li class="nav-item active">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="order.aspx">Order</a>

                  </li>

                    <li class="nav-item">

                     <a class="nav-link"  style="margin-left: 26px;color: #fff;" href="invoice.aspx">Invoice</a>

                  </li>
           
                    <li class="auto-style1" style="color: #ffeb3b;font-weight: 300;"></li>
      
                </ul>
    
            </div>
 
        </nav>

        <div class="container-fluid">

                     <div class="row" style="margin-top: 37px;" >
                		
		                 <div class="col-md-12" >                        
            
                             <div class="row" style="display: -webkit-box !important;" >
                                  <div class="col-md-1" ></div>
                                    <div class="col-md-2">
                                          <asp:Label ID="Label4" class="label" runat="server">Order No</asp:Label>
                                        <asp:TextBox ID="txtorderno" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                  <div class="col-md-2">
                                          <asp:Label ID="Label1" class="label" runat="server">Date</asp:Label>
                                        <asp:TextBox ID="txtdate" class="form-control textbox" runat="server" ></asp:TextBox>
                                    </div>

                                 <div class="col-md-3">
                                          <asp:Label ID="Label5" class="label" runat="server">Bill Customer Name</asp:Label>
                                          <%-- <asp:TextBox ID="txtpartno" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlbillcustomer" class="form-control textbox"  runat="server"></asp:DropDownList>
                                    </div>

                                  <div class="col-md-3" >
                                          <asp:Label ID="Label2" class="label" runat="server">Ship to</asp:Label>
                                          <%-- <asp:TextBox ID="txtpartno" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>--%>
                                     <asp:DropDownList ID="ddlship" class="form-control textbox"  runat="server"></asp:DropDownList>
                                    </div>
                                 <div class="col-md-1" >
                                      <asp:Button ID="btnsave" class="btn btn-warning" style="margin-top: 27px;" runat="server" Text="Save" OnClick="btnsave_Click"  />
                                 </div>
                         </div>

                    </div>

              </div>

                                   

           <br />
           
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

                        <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:BoundField HeaderText="S.No" />
                     <asp:TemplateField HeaderText="Item">
                         <ItemTemplate>
                             <asp:TextBox ID="txtitem" class="form-control1" runat="server" Width="119px" AutoPostBack="True" OnTextChanged="txtitem_TextChanged"></asp:TextBox>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                     

                      <asp:TemplateField HeaderText="Description">
                          <ItemTemplate>
                              <asp:DropDownList ID="txtdesc" class="form-control1" runat="server" OnSelectedIndexChanged="txtdesc_SelectedIndexChanged" Width="328px" AutoPostBack="True">
                              </asp:DropDownList>
                          </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:TemplateField  HeaderText="No & Kind of Packages">
                        <ItemTemplate >
                            <asp:TextBox ID="txtkind" class="form-control1" AutoPostBack="true"  runat="server" 
                                  Width="82px" ></asp:TextBox>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                     
                    
                    <asp:TemplateField  HeaderText="HSN No">
                        <ItemTemplate >
                            <asp:TextBox ID="txthsnno" class="form-control1"  runat="server" Width="100px" ></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>                                    

                    <asp:TemplateField HeaderText="Rate" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtrate" class="form-control1"   Width="100px" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Weight" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtweight" class="form-control1"  Width="100px"  runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                        
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtqty" class="form-control1"  runat="server" Width="80px" AutoPostBack="True" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                                           
                     <asp:TemplateField HeaderText="Amount" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtamount" class="form-control1"  Width="100px"  runat="server"></asp:TextBox>
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

      </div>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hsn.aspx.cs" Inherits="sample_inv.hsn" %>

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
            height: 206px;
            margin-top: 17px;
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

        
                    <li class="nav-item active">
          
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

         <div class="panel">
            
               <div class="container">

                     <div class="row" style="margin-top: 37px;" >
                		
		                 <div class="col-md-12" >                        
            
                             <div class="row" style="display: -webkit-box !important;" >

                                    <div class="col-md-2" >
                                          <asp:Label ID="Label4" class="label" runat="server">Item No</asp:Label>
                                        <asp:TextBox ID="txtitemno" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                  <div class="col-md-4" >
                                          <asp:Label ID="Label1" class="label" runat="server">Description</asp:Label>
                                        <asp:TextBox ID="txtdesc" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                 <div class="col-md-3" >
                                          <asp:Label ID="Label5" class="label" runat="server">HSN No</asp:Label>
                                        <asp:TextBox ID="txthsn" class="form-control textbox" AutoPostBack="true" runat="server" ></asp:TextBox>
                                    </div>

                                  <div class="col-md-3" >
                                          <asp:Label ID="Label6" class="label" runat="server">Price</asp:Label>
                                        <asp:TextBox ID="txtprice" class="form-control textbox" runat="server"></asp:TextBox>
                                    </div>

                                


                         </div>

                    </div>

              </div>

                   <div class="row" style="margin-top: 80px;" >

                         <div class="col-md-12">

                             <div class="row" style="display: -webkit-box !important;margin-top: -48px;" >

                                 <div class="col-md-4"></div>

                                  <div class="col-md-1">

                                    <asp:Button ID="btnsave" class="btn btn-success" runat="server" Text="Save" OnClick="btnsave_Click"  />

                                 </div>

                                <%-- <div class="col-md-1">

                                         <asp:Button ID="btnedit" class="btn btn-warning" runat="server" Text="Edit"  />

                                  </div>

                                 <div class="col-md-1">

                                        <asp:Button ID="btndelete" class="btn btn-danger"  runat="server" Text="Delete" />
                                </div>--%>

                                 <div class="col-md-1">

                                    <asp:Button ID="btnview" class="btn btn-primary"  runat="server" Text="View" />

                                 </div>

                                 <div class="col-md-1">

                                     <asp:Button ID="btnreset" class="btn btn-warning"  runat="server" Text="Reset" OnClick="btnreset_Click"  />
                                 </div>

                        

                                  <div class="col-md-3">

                                 </div>
                           
                       </div>

                   </div>

           </div>

                  
      </div>

            </div>
        <br />

        <div >
            
             
                                          <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-striped table-condensed table-responsive thead-dark" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"  ForeColor="#333333"  GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                      <asp:BoundField HeaderText="S.No" >
                      <ItemStyle Width="50px" />
                      </asp:BoundField>
                      <asp:BoundField DataField="item_id" HeaderText="Item ID" >
                      <ItemStyle Width="50px" />
                      </asp:BoundField>
                     <asp:TemplateField HeaderText="Item Name">
                         <ItemTemplate>
                             <asp:TextBox ID="txtiname" class="form-control1" runat="server" Width="200px" Text='<%# Bind("item_name") %>'></asp:TextBox>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>
 

                      <asp:TemplateField HeaderText="Description">
                         <ItemTemplate>
                             <asp:TextBox ID="txtdes" class="form-control1" Width="500px" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                         </ItemTemplate>
                           <HeaderStyle HorizontalAlign="Center" />
                     </asp:TemplateField>

                    <asp:TemplateField  HeaderText="HSN">
                        <ItemTemplate >
                            <asp:TextBox ID="txthsn1" class="form-control1" AutoPostBack="true"  runat="server" 
                                  Width="82px"  Text='<%# Bind("hsn_no") %>'></asp:TextBox>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     
                    
                    <asp:TemplateField  HeaderText="Price">
                        <ItemTemplate >
                            <asp:TextBox ID="txtprice1" class="form-control1"  runat="server" Width="150px"  Text='<%# Bind("price") %>' ></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
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
                     
            </div>

    </form>
</body>
</html>

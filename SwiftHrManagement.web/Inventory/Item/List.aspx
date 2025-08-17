<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Item.List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                           Inventory Group/Product Setup     
                </header>

                <div class="panel-body">
                     <div class="row">
                        <div class="col-md-10">
                            <div class="form-group">
                               <asp:TextBox ID="txtNodeSearch" runat="server" CssClass="form-control"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass ="btn btn-primary" 
                                        onclick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">           
                        <div>
                            <div id="rpt" runat="server" >
                                <asp:UpdatePanel ID ="updtpnl" runat = "server">
                                    <ContentTemplate>
                                        <asp:TreeView ID="TvItem" runat="server" OnTreeNodePopulate="TvItem_TreeNodePopulate" ExpandDepth="0" 
                                                ShowLines="True" onselectednodechanged="TvItem_SelectedNodeChanged">
                                                <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="DarkBlue" HorizontalPadding="5"/>
                                                <RootNodeStyle Font-Bold="True" Font-Size="10pt"/>
                                                <HoverNodeStyle Font-UnderLine="True" />
                                                <Nodes>
                                                </Nodes>
                                                
                                    </asp:TreeView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                        
                                        
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <input  type="button" value="Add Product Group" onclick="AddProductGroup()" class="btn btn-primary"  />
                        <input  type="button" value="Add Product" onclick="AddProduct()" class="btn btn-primary"  />                                  
                        <input  type="button" value="View Detail" onclick="EditProductGroup()" class="btn btn-primary"  />
                        <input  type="button" value="Branch Detail" onclick="ProductBranch()" class="btn btn-primary" />       
                    </div>
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdProductMSG" runat="server">
                               <ContentTemplate>
                              
                            <table style="width: 100%;" runat="server">
                                <tr>
                                    <td class="style3"> Group Code: </td>
                                    <td> <div ID="lblProductCode" runat="server" ></div></td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style3"> Group Name: </td>
                                    <td>  <div ID="lblProductName" runat="server" ></div> </td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style3"> Group/Product: </td>
                                    <td> <div ID="lblIsProduct" runat="server" ></div> </td>
                                    
                                </tr>
                                </tr>
                                  <tr>
                                    <td class="style3"> Product ID: </td>
                                    <td> <div ID="lblProductID" runat="server" ></div> </td>
                                    
                                </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel> 
                    </div>
                </div>
            </section>
        </div>
    </div>






    <%--<%--<table width="100%">
                        <tr>
                            <td align="left" class="style1" valign="bottom">
                                <img src="/Images/big_bullit.gif" />&nbsp;&nbsp; Inventory Group/Product Setup
                                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>--%>
    <%-- </td>
                        </tr>
                        
                        <tr>
                            <td bgcolor="#999999" valign="top">
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style2" >
                            <asp:TextBox ID="txtNodeSearch" runat="server" Width="391px"></asp:TextBox> 
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass ="button" 
                                        onclick="btnSearch_Click" />
                                        
                                 <div>
                                    <div id="rpt" runat="server" 
                                         style="height:350px; width:573px; overflow:auto; background-color:ButtonFace; " 
                                         align="left">
                                    <asp:UpdatePanel ID ="updtpnl" runat = "server">
                                        <ContentTemplate>
                                            <asp:TreeView ID="TvItem" runat="server" 
                                                OnTreeNodePopulate="TvItem_TreeNodePopulate" ExpandDepth="0" 
                                                 ShowLines="True" onselectednodechanged="TvItem_SelectedNodeChanged">
                                                 <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="DarkBlue" HorizontalPadding="5"/>
                                                  <RootNodeStyle Font-Bold="True" Font-Size="10pt"/>
                                                  <HoverNodeStyle Font-UnderLine="True" />
                                                  <Nodes>
                                                  </Nodes>
                                                

                                        </asp:TreeView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                        
                                        
                                     </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td> 
                            
                                <input  type="button" value="Add Product Group" onclick="AddProductGroup()" class="button" style="width:150px;" />
                                <input  type="button" value="Add Product" onclick="AddProduct()" class="button" style="width:150px;" />                                  
                                <input  type="button" value="View Detail" onclick="EditProductGroup()" class="button" style="width:150px;" />
                                <input  type="button" value="Branch Detail" onclick="ProductBranch()" class="button" style="width:110px;" />                                                                    
                                &nbsp;</td>
                        </tr>
                        <tr> <td>
                        
                           
                            <asp:UpdatePanel ID="UpdProductMSG" runat="server">
                               <ContentTemplate>
                              
                            <table style="width: 100%;" runat="server">
                                <tr>
                                    <td class="style3"> Group Code: </td>
                                    <td> <div ID="lblProductCode" runat="server" ></div></td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style3"> Group Name: </td>
                                    <td>  <div ID="lblProductName" runat="server" ></div> </td>
                                    
                                </tr>
                                  <tr>
                                    <td class="style3"> Group/Product: </td>
                                    <td> <div ID="lblIsProduct" runat="server" ></div> </td>
                                    
                                </tr>
                                </tr>
                                  <tr>
                                    <td class="style3"> Product ID: </td>
                                    <td> <div ID="lblProductID" runat="server" ></div> </td>
                                    
                                </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel> 
                         
                               
                         </td>
                        </tr>
                    </table>--%>


    <script type="text/javascript">

        function AddProductGroup() {
            var IsProduct = document.getElementById("lblIsProduct").innerHTML;

            if (IsProduct == "") {
                alert('Please select the node first.');
                return false;
            }


            if (IsProduct == "Product") {
                alert("Sorry, Product Can not have further node !");
                return false;
            }

            var URL = "../Manage.aspx?grpid=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
            GB_show("Add Prodcut Group ", URL, 400, 700);
        }

        function ProductBranch() {

            var IsProduct = document.getElementById("lblIsProduct").innerHTML;

            if (IsProduct == "") {
                alert('Please select the node first.');
                return false;
            }


            if (IsProduct != "Product") {
                alert("Sorry, Product Need to Select !");
                return false;
            }

            var URL = "../EditBranchProduct.aspx?ProductId=" + document.getElementById("lblProductID").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
            GB_show("Branch Product Information", URL, 500, 750);

        }


        function AddProduct() {

            var IsProduct = document.getElementById("lblIsProduct").innerHTML;

            if (IsProduct == "") {
                alert('Please select the node first.');
                return false;
            }

            if (IsProduct == "Product") {
                alert("Sorry, Product Can not have further node !");
                return false;
            }

            var URL = "../ProductSetup.aspx?ItemId=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
            GB_show("Add Prodcut Group ", URL, 700, 500);
        }

        function EditProductGroup() {
            var IsProduct = document.getElementById("lblIsProduct").innerHTML;

            if (IsProduct == "") {
                alert('Please select the node first.');
                return false;
            }

            if (IsProduct == "Product") {
                var URL = "../ProductSetup.aspx?ItemId=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML + "&productId=" + document.getElementById("lblProductID").innerHTML;
                GB_show("Add Prodcut Group ", URL, 650, 600);
            }
            else {

                var URL = "../Manage.aspx?id=" + document.getElementById("lblProductCode").innerHTML + "&product=" + document.getElementById("lblProductName").innerHTML;
                GB_show("Add Prodcut Group ", URL, 700, 500);
            }

        }

        function doHighlight(searchTerm, highlightStartTag, highlightEndTag) {

            if (searchTerm == "") {
                return false;
            }

            var bodyText = document.body.innerHTML;

            // the highlightStartTag and highlightEndTag parameters are optional
            if ((!highlightStartTag) || (!highlightEndTag)) {
                highlightStartTag = "<font style='color:blue; background-color:#FFCC00;'>";
                highlightEndTag = "</font>";
            }

            var newText = "";
            var i = -1;
            var lcSearchTerm = searchTerm.toLowerCase();
            var lcBodyText = bodyText.toLowerCase();

            while (bodyText.length > 0) {
                i = lcBodyText.indexOf(lcSearchTerm, i + 1);
                if (i < 0) {
                    newText += bodyText;
                    bodyText = "";
                } else {
                    // skip anything inside an HTML tag
                    if (bodyText.lastIndexOf(">", i) >= bodyText.lastIndexOf("<", i)) {
                        // skip anything inside a <script> block
                        if (lcBodyText.lastIndexOf("/script>", i) >= lcBodyText.lastIndexOf("<script", i)) {
                            newText += bodyText.substring(0, i) + highlightStartTag + bodyText.substr(i, searchTerm.length) + highlightEndTag;
                            bodyText = bodyText.substr(i + searchTerm.length);
                            lcBodyText = bodyText.toLowerCase();
                            i = -1;
                        }
                    }
                }
            }
            document.body.innerHTML = newText;
            return true;
        }



        doHighlight(document.getElementById("txtNodeSearch").value);


    </script>
</asp:Content>

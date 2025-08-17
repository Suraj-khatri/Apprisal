<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewChart.aspx.cs" Inherits="SwiftHrManagement.web.OrganoChart.ViewChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/";
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    Organization Chart Setup
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="form-group">
                                <asp:TextBox ID="txtNodeSearch" runat="server" CssClass="form-control"></asp:TextBox> 
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass ="btn btn-primary" 
                                    onclick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" id="rpt" runat="server" style="width:100%; height:400px;">
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
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <input  type="button" value="Add Group" onclick="AddGroup()" class="btn btn-primary" style="width:150px;" />&nbsp; 
                                <input  type="button" value="View Detail" onclick="EditProductGroup()" class="btn btn-primary" style="width:150px;" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdProductMSG" runat="server">
                                   <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Group Code:</label>
                                                </div>
                                            </div>
                                            <div class="col-md-9">
                                                <div class="form-group">
                                                    <div ID="lblProductCode" runat="server" >
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Group Name:</label>
                                                </div>
                                            </div>
                                            <div class="col-md-9">
                                                <div class="form-group">
                                                    <div ID="lblProductName" runat="server" ></div>
                                                </div>
                                            </div>
                                        </div>
                                       <div class="row">
                                           <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Group/Product:</label> 
                                                </div>
                                            </div>
                                           <div class="col-md-9">
                                                <div class="form-group">
                                                    <div ID="lblIsProduct" runat="server" >
                                                        <asp:Label ID="Label1" runat="server" Text="12"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                       <div class="row">
                                           <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>Product ID:</label> 
                                                </div>
                                            </div>
                                           <div class="col-md-9">
                                                <div class="form-group">
                                                     <div ID="lblProductID" runat="server" ></div>
                                                </div>
                                            </div>
                                        </div>  
                                </ContentTemplate>
                                </asp:UpdatePanel> 
                            </div>
                        </div>
                        </div>
                    </div>
                </section>
        </div>
    </div>
    <script type="text/javascript">
        function AddGroup() {
            var Product = document.getElementById("<%= lblProductCode.ClientID %>").innerHTML;
            if (Product == "") {
                alert('Please select the node first.');
                return false;
            }
            var URL = "/OrganoChart/Manage.aspx?flag=a&Grpid=" + document.getElementById("<%= lblProductCode.ClientID %>").innerHTML + "&product=" + document.getElementById("<%= lblProductName.ClientID%>").innerHTML;
            GB_show("Add New Group ", URL, 300, 500);
            }

            function EditProductGroup() {

                var URL = "/OrganoChart/Manage.aspx?flag=a&id=" + document.getElementById("<%= lblProductCode.ClientID %>").innerHTML + "&product=" + document.getElementById("<%= lblProductName.ClientID %>").innerHTML;
                GB_show("Modify Group", URL, 300, 500);
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
            doHighlight(document.getElementById("<%= txtNodeSearch.ClientID %>").value);  
    </script>
</asp:Content>

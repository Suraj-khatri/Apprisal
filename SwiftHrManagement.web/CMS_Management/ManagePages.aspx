<%@ Page Language="C#" validateRequest="false"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManagePages.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.ManagePages" Title="Swift HR Management System 1.0" %>
<%@ Import Namespace="System.Data"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="docs/style.css" type="text/css">
		
		<!-- 
			Include the WYSIWYG javascript files
		-->
 
		<script type="text/javascript" src="scripts/wysiwyg.js"></script>
		<script type="text/javascript" src="scripts/wysiwyg-settings.js"></script>
		<!-- 
			Attach the editor on the textareas
		-->
		<script type="text/javascript">
			// Use it to attach the editor to all textareas with full featured setup
			//WYSIWYG.attach('all', full);
			
			// Use it to attach the editor directly to a defined textarea
			//WYSIWYG.attach('textarea1'); // default setup
			WYSIWYG.attach('textarea2', full);
		    WYSIWYG.attach('textarea3', small);
			
			// Use it to display an iframes instead of a textareas
			//WYSIWYG.display('all', full);  

		</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="UPDPANEL" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel"> 
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Add CMS Pages Details
                        </header>
                        <div class="panel-body">
                                <%                                  
                                DataSet ds = PopulateCMSPage(this.Id);
                                DataTable dt = new DataTable();
                                DataTable cms = ds.Tables[0];
                           
                                %> 
                            <div class="col-md-12 form-group">
                                Please enter valid data! <span class="required">(* are required fields!)</span>  
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                <asp:Label ID="lblHead" runat="server" Visible="False"></asp:Label>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Page Type :<span class="errormsg">*</span></label>
                                    <select class="form-control" name="pageType" id ="pageType" >
                                        <%  if (cms.Rows[0]["func_type"].ToString() == "Query")
                                            {%>
                                                <option selected>Query</option>
			                                    <option>Content</option>
			                                    <option>Notice</option>
			                                    <%}
                                            else if (cms.Rows[0]["func_type"].ToString() == "Content")
                                            {%>
                                            <option>Query</option>
			                                    <option selected>Content</option>
			                                    <option>Notice</option>
			                                    <%}

                                            else if (cms.Rows[0]["func_type"].ToString() == "Notice")
                                            {%>
                                                <option>Query</option>
			                                    <option >Content</option>
			                                    <option selected>Notice</option>          
			                                <%} %>
			                        </select>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Page Name :<span class="errormsg">*</span><br /></label>
                                    <input class="form-control" type="text" id="txtPageName" name="txtPageName" value="<%=cms.Rows[0]["func_name"].ToString()%>"/>
                                </div>
                            <div class="col-md-12 form-group">
                                <label>Page Head :<span class="errormsg">*</span></label>
                                <textarea class="form-control" id="textarea3" name="textarea3"><%=cms.Rows[0]["func_head"].ToString()%></textarea>
                            </div>
                            <div class="col-md-12 form-group">
                                <label>Page Content :<span class="errormsg">*</span></label>
                                <textarea class="form-control" id="textarea2" name="textarea2" style="height:200px;"><%=cms.Rows[0]["func_detail"].ToString()%></textarea>
                            </div>
                            <div class="col-md-12 form-group">
                                <asp:Button ID="BtnSave" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="page" onclick="BtnSave_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure to Save?" Enabled="True" 
                                    TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" onclick="BtnDelete_Click"/>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="&lt;&lt; Back"  onclick="BtnBack_Click"/>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

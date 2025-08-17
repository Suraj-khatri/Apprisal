<%@ Page Language="C#" validateRequest="false" EnableEventValidation="false"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AddCmsPage.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.AddCmsPage" Title="Swift HR Management System 1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="docs/style.css" type="text/css"/>
		<script type="text/javascript" src="scripts/wysiwyg.js"></script>
		<script type="text/javascript" src="scripts/wysiwyg-settings.js"></script>
		<script type="text/javascript">
			WYSIWYG.attach('textarea2', full);
		    WYSIWYG.attach('textarea3', small);
		</script>
        <style type="text/css">
            .style10
            {
                height: 50px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<form name="form1" id="form1" method="post">
     <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Add CMS Pages Details
                    </header>
                    <div class="panel-body">
                        <div id="formArea" runat="server">
                            <div class="form-group">                            
                                <span class="txtlbl">Please Enter Valid Data!</span>
                                <span class="required" >(* Required fields)</span>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                <asp:Label ID="lblHead" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">                            
                                    <label>Page Type:<span class="errormsg">*</span></label>
                                    <select name="pageType" id ="pageType" class="form-control">
			                          <option>Content</option>
			                          <option>Query</option>
			                          <option>Notice</option>
			                        </select>
                                </div>
                                <div class="col-md-6 form-group">                            
                                    <label>Page Name:<span class="errormsg">*</span></label>
                                    <input type="text" id="txtPageName" name="txtPageName" class="form-control"></input>
                                </div>
                            </div>
                            <div class="form-group">                            
                                <label>Page Head:<span class="errormsg">*</span></label>
                                <textarea id="textarea3" name="textarea3" class="form-control"></textarea>
                            </div>
                            <div class="form-group">                            
                                <label>Page Content:<span class="errormsg">*</span></label>
                                <textarea id="textarea2" name="textarea2" class="form-control" ></textarea>
                            </div>
                            <div class="form-group">                            
                              <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="page" 
                                    onclick="BtnSave_Click" />
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                    Text="Back"  onclick="BtnBack_Click"/>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
         </div>
    </form>
</asp:Content>


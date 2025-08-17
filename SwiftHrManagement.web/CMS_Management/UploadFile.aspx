<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.UploadFile" Title="Swift HR Management System 1.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script language="javascript">

        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;

            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = boolChecked;
            }
        }
        function DeleteUploadFile(upload_Id) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =HdnUploadId.ClientID %>").value = upload_Id;
                document.getElementById("<% =Delete.ClientID %>").click();
            }
        }

    </script>

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel"> 
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Upload File for CMS 
                </header>
                <div class="panel-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row col-md-12">
                                Please enter valid data! <span class="required">(* are required fields!)</span>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                <asp:HiddenField ID="HdnUploadId" runat="server" />
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group">
                                <label>Page Name:<span class="errormsg">*</span></label>
                                <div id="lblPName" runat="server" visible="true">
                                    <asp:Label ID="lblPageName"  runat="server"></asp:Label>
                                </div>
                                <div id="ddlPName" runat="server" visible="false">
                                    <asp:DropDownList ID="ddlPageName" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary" onclick="BtnSearch_Click" />
                                </div>
                            </div>
                            </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>File Description:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="Required" runat="server" ControlToValidate="TxtFileDescription" Display="None" ErrorMessage="*" 
                                SetFocusOnError="True" ValidationGroup="uploader"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>File Date:</label>
                                <asp:TextBox ID="txtFileDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtFileDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtFileDate">
                            </cc1:CalendarExtender>
                        </div>
                    </div> 
                    <div class="row">
                        <div class="co-md-12 form-group">
                            <label>Select File:<span class="errormsg">*</span></label>
                            <input id="fileUpload" runat="server" name="fileUpload" type="file" class="form-control" />       
                        </div>
                    </div>  
                    <div class="row">           
                        <div class="col-md-12 form-group">                       
                            <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" onclick="BtnUpload_Click" ValidationGroup="uploader"/>  
                        </div>
                    </div>
                    <div class="row">           
                        <div class="col-md-12 form-group">                                           
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                     <div id="fileDesc" runat="server"></div>
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back" Visible="true" />
                            <asp:Button ID="Delete" runat="server" CssClass="button" onclick="Delete_Click" Text="Delete" style ="display:none" />
                        </div>
                    </div>
            </div>
        </section>
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="EmpFileUploader.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.EmpFileUploader" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function DeleteUploadFile(upload_Id) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =upload_Id.ClientID %>").value = upload_Id;
                document.getElementById("<% =Delete.ClientID %>").click();
            }
        }
    </script>
    <script language="javascript">
            function checkAll(me) {
                var checkBoxes = document.forms[0].chkTran;
                var boolChecked = me.checked;

                for (i = 0; i < checkBoxes.length; i++) {
                    checkBoxes[i].checked = boolChecked;
                }
            }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
           <i class="fa fa-caret-right"></i>    	 Manage Documents
        </header>
        <div class="panel-body">
             <asp:Label ID="lblMessage" runat="server" CssClass="txtlbl"></asp:Label>
                <asp:Label ID="lblEmpNo" runat="server"></asp:Label>
               <asp:HiddenField ID="upload_Id" runat="server" Value = "" />
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Type:<span class="required">*</span>
                    </label>
                     <asp:DropDownList id="ddlDocType" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Medical">Medical</asp:ListItem>
                    <asp:ListItem Value="Education">Education</asp:ListItem>
                    <asp:ListItem Value="Training">Training</asp:ListItem>
                    <asp:ListItem Value="ID Card">ID Card</asp:ListItem>
                    <asp:ListItem Value="Past Experience">Past Experience</asp:ListItem>
                    <asp:ListItem Value="Others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ControlToValidate="ddlDocType" Display="Dynamic" 
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="uploader">
                </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    
                    <label>
Description:   <span class="errormsg">*</span>
                    </label>
                    <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control" ></asp:TextBox>
                 
                    <asp:RequiredFieldValidator ID="rfv3" 
                        runat="server" ControlToValidate="TxtFileDescription" Display="Dynamic" 
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="uploader">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Location:<span class="errormsg">*</span>
                    </label>
                    <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" CssClass="form-control" /> 
                        
                
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                        ValidationGroup="uploader" ControlToValidate="fileUpload" Display="Dynamic" 
                        SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                </div>
            </div>
             <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" 
                    onclick="BtnUpload_Click" ValidationGroup="uploader"/>
                    
                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                </cc1:ConfirmButtonExtender>
            <div class="row">
                <div class="col-md-12">
                    <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
                </div>
            </div>
            <asp:Button ID="btnSetProfile" runat="server" CssClass="btn btn-primary"
                    Text="Set Profile" onclick="btnSetProfile_Click" />
                    
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                    ConfirmText="Confirm to make Profile picture?" Enabled="True" TargetControlID="btnSetProfile">
                </cc1:ConfirmButtonExtender>&nbsp; 
                
                 <asp:Button ID="btnResetProfile" runat="server" CssClass="btn btn-primary"
                    Text="Reset Profile" onclick="btnResetProfile_Click"/>
                 
                 <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                    ConfirmText="Confirm to reset profile picture?" Enabled="True" TargetControlID="btnResetProfile">
                </cc1:ConfirmButtonExtender>&nbsp; 
                     
                <asp:Button ID="Delete" runat="server" CssClass="btn btn-primary" 
                    Text="Delete" OnClick="Delete_Click" style = "display:none"/>
        
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" 
                    Text="Back" OnClick="btnBack_Click"/>
        </div>
    </div>


</asp:Content>


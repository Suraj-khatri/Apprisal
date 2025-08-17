<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.AddGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                     document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
                 }
             }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Manage Shift
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server"></asp:Label> 
                        <label>Shift Name:</label>
                         <asp:Label ID="lblShiftName" runat="server"></asp:Label>     
                    </div>
                    <div class="form-group">
                        <label>Group Name:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlGroupName" runat="server" CssClass="form-control"></asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="ddlGroupName" ErrorMessage="Required!" SetFocusOnError="True" 
                            ValidationGroup="add"></asp:RequiredFieldValidator>      
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                        <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="form-control" >
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        </asp:DropDownList> 
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" ValidationGroup="add"  runat="server" CssClass="btn btn-primary" Text=" Save "
                            onclick="btnSave_Click"  />&nbsp;
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" ConfirmText="Confirm to Save?"
                             Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " onclick="btnDelete_Click"  />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="btnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" />                    
                    </div>
                    <br/>
                    <div class="row">
                    <div class="col-md-12">
                    <div id="rpt" runat="server"></div>
                        </div>
                        </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

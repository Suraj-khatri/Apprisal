<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="GlobalLeaveSetup.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveFacility.GlobalLeaveSetup" %>
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
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Global Leave Update
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" onclick="btnDeleteRecord_Click" style="display:none;"/>
                        <asp:HiddenField ID="hdnEmpType" runat="server" /> 
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Employee Type:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="ddlEmpType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="global">
                        </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlEmpType" runat="server" CssClass="form-control" AutoPostBack="True" 
                            onselectedindexchanged="ddlEmpType_SelectedIndexChanged">
                        </asp:DropDownList>                        
                    </div>
                    <div class="form-group">
                        <label>Leave Type:<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="ddlLeaveType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="global">
                        </asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="form-control" AutoPostBack="True" 
                            onselectedindexchanged="ddlLeaveType_SelectedIndexChanged">
                        </asp:DropDownList>                       
                    </div>
                    <div class="form-group">
                        <label>Default Days:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="txtDefaultDays" Display="Dynamic" SetFocusOnError="True" ValidationGroup="global">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDefaultDays" runat="server" CssClass="form-control"></asp:TextBox>                        
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="global" 
                            onclick="btnSave_Click"/>
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back"/>
                    </div>
                    <div class="form-group">
                        <div id="rptGlobal" runat="server"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
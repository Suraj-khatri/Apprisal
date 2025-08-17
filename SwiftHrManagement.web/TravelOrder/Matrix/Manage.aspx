<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.Matrix.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
        }
        function showReport() {
            if (!Page_ClientValidate('comm'))
                return false;


            var url = "../../../SwiftSystem/Reports/Reports.aspx?reportName=enrol" +
                "&fromDate=" + fromDate +
                "&AgentId=" + AId +
                "&toDate=" + toDate;

            OpenInNewWindow(url);

            return false;

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Manage Travel Order Matrix
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 form-group">
                    Please enter valid data!
                      <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </div>
                <div class="col-md-4 form-group">
                    <label>Category:<span class="required">*</span></label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlCategory" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="matrix">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>Zone:<span class="required">*</span></label>
                    <asp:DropDownList ID="ddlZone" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="ddlZone" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="matrix"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>Head:<span class="required">*</span></label>
                    <asp:DropDownList ID="ddlHead" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="ddlHead" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="matrix"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>Currency:<span class="required">*</span></label>
                    <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="ddlCurrency" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="matrix"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>Amount:<span class="required">*</span></label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="matrix"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-12 form-group">
                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnSave_Click" Text="Add New" ValidationGroup="matrix" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Add New?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                </div>
                <div class="col-md-12 form-group">
                    <div id="rpt" runat="server"></div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

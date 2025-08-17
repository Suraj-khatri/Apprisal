<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="WriteMessage.aspx.cs" Inherits="SwiftHrManagement.web.MessagingPortal.WriteMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../js/listBoxMovement.js" type="text/javascript"></script>
    <script type="text/javascript">
        function add() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Send Message
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Select Group:</label>
                        <asp:DropDownList ID="mesageGroupDDL" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group autocomplete-form">
                        <label>Employee Name:</label>
                        <asp:TextBox ID="empName" runat="server" CssClass="form-control" AutoPostBack="true" ValidationGroup="emp"/>
                        <cc1:AutoCompleteExtender ID="aceEmpName" runat="server"
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="empName" />
                        <cc1:TextBoxWatermarkExtender ID="wmeEmpName"
                            runat="server" Enabled="True" TargetControlID="empName"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                        <asp:RequiredFieldValidator ID="empRFV" runat="server" SetFocusOnError="true" 
                            ControlToValidate="empName" ValidationGroup="emp"
                            ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Message:</label>
                        <asp:TextBox ID="message" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="msgRFV" runat="server" SetFocusOnError="true" ErrorMessage="Required!"
                            ForeColor="Red" ControlToValidate="message" ValidationGroup="msg"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="sendMessage" runat="server" Text="Send Message" CssClass="btn btn-primary" OnClick="sendMessage_Click" ValidationGroup="msg" />
                        <asp:Button ID="clear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="clear_Click" />
                    </div>
                </div>
        </section>
        </div>
    </div>
</asp:Content>

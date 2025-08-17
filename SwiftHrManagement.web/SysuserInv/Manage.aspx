<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.SysuserInv.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
             <div class="row">
                 <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            User Add Details
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>
                            <div class="form-group autocomplete-form" >
                                <label>Full Name:<span class="errormsg">*</span></label>
                                <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label>
                                <asp:HiddenField ID="hdnEmpName" runat="server" />
                                <br />
                                <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                                    OnTextChanged="txtEmployee_TextChanged" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                    CompletionInterval="10" CompletionListCssClass="form-control"
                                    DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                                    OnClientItemSelected="GetEmpName">
                                </cc1:AutoCompleteExtender>
                                <cc1:TextBoxWatermarkExtender ID="txtEmployee_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtEmployee"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                            <div class="form-group">
                                <label>User Name:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="TxtUsername" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="user" BorderColor="#FFFF66"
                                    SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Password:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" TextMode="Password" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Type:</label>
                                <asp:DropDownList ID="DdlUserType" runat="server" CssClass="form-control" Width="100%">
                                    <asp:ListItem Value="N">Normal </asp:ListItem>
                                    <asp:ListItem Value="B">Branch </asp:ListItem>
                                    <asp:ListItem Value="A">All</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                 <label>Is Active :</label>&nbsp;<asp:CheckBox ID="Chkstatus" runat="server"/>
                            </div>
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="user"
                                    Width="75px" />
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                    OnClick="BtnDelete_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete ?" Enabled="True"
                                    TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_Click" Text=" Back" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

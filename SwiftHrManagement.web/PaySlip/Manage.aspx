<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.PaySlip.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-8 col-md-offset-2">
            <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                Monthly PaySlip Search
            </header>
            <div class="panel-body">
                <div class="form-group">
                    <label>Year:  <span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlYear"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control"></asp:DropDownList>                    
                </div>
                <div class="form-group">
                    <label>Month:  <span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlMonth"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control"></asp:DropDownList>                    
                </div>
                <div class="form-group autocomplete-form">
                    <label>Employee:  <span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmployee"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                        CssClass="form-control" ></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                        CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true"
                        Enabled="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee">
                    </cc1:AutoCompleteExtender>    
                    <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender" 
                          runat="server" Enabled="True" TargetControlID="txtEmployee" 
                          WatermarkCssClass="form-control" WatermarkText="Auto Complete">
            </cc1:TextBoxWatermarkExtender>                
                </div>
                <asp:Button ID="BtnSalary" runat="server" CssClass="btn btn-primary" Text="Salary Slip" ValidationGroup="payroll"
                    OnClick="BtnSalary_Click" />
            </div>
        </section>
    </div>
</div>
</asp:Content>

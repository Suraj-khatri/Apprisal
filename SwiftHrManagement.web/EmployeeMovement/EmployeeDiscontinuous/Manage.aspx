<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeDiscontinuous.Manage" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<head>
<script type="text/javascript" src="../../Jsfunc.js" ></script>
</head>
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
    
     <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  Discontinuation Detail Entry 
        </header>
        <div class="panel-body">
            <span class="txtlbl" >Please enter valid  data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                         Employee Name : 
                    </label>
                     <asp:Label ID="lblEmpName" runat="server" CssClass="form-control" Width="100%" ></asp:Label>
                    </div>
                <div class="col-md-6 autocomplete-form">
                    <label>&nbsp;</label><br />
                    <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" 
                ontextchanged="txtEmpName_TextChanged"  AutoPostBack="true"></asp:TextBox> 
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName">
            </cc1:AutoCompleteExtender> 
            <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender" 
                          runat="server" Enabled="True" TargetControlID="txtEmpName" 
                          WatermarkCssClass="form-control" WatermarkText="Auto Complete">
            </cc1:TextBoxWatermarkExtender>
                </div>
               
            </div>
            <div class="row">
                 <div class="col-md-4 form-group">
                    <label>
                         Discontinuation Mode: <span class="errormsg">*</span>
                    </label>
                    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="DdlDiscontReason" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="discont"></asp:RequiredFieldValidator>
               
                <asp:DropDownList ID="DdlDiscontReason" runat="server" CssClass="form-control">                              
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Effective Date:  <span class="errormsg">*</span>
                    </label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="txtEffectiveDate" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="discont"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="form-control"></asp:TextBox>   
                <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtEffectiveDate">
                </cc1:CalendarExtender>
                </div>
                <div class="col-md-6">
                   <label> Description: <span class="errormsg">*</span></label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="txtDesc" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="discont"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" 
                    TextMode="MultiLine" ></asp:TextBox>   
                </div>
                 </div>
            <br />
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="discont" />

                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>

                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnDelete_Click" Text="Delete" />

                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                    ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>

                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnBack_Click" Text="Back" />
           
        </div>
    </div>
             </div>
    </div>
</asp:Content>

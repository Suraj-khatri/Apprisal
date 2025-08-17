<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Substitute.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Assign Substitute Leave
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span>Please enter valid  data!</span><span class="required" > (* Required fields)</span>             
                        <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label> 
                    </div>
                    <div class="form-group autocomplete-form">
                        <label>Employee Name:</label>
                        <div id="divHR" runat="server" visible="false">
                            <asp:Label ID="LblEmpName" runat="server" CssClass="txtlbl"></asp:Label>                
                            <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" AutoPostBack="true" CssClass="form-control" 
                                ontextchanged="txtEmpName_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10" 
                                CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                                TargetControlID="txtEmpName">
                            </cc1:AutoCompleteExtender>                        
                            <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                TargetControlID="txtEmpName" WatermarkCssClass="form-control" WatermarkText="All Employee">
                            </cc1:TextBoxWatermarkExtender>  
                        </div> 
                        <div id="divSup" runat="server" visible="false"> 
                            <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>                    
                    <div class="form-group">
                        <label>Working Date:<span class="errormsg">*</span></label>
                         <asp:TextBox ID="txtWorkingDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWorkingDate" 
                            Display="Dynamic" ErrorMessage="Required!" ValidationGroup="doctor" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="txtWorkingDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txtWorkingDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" onclick="BtnSave_Click" Text="Save" 
                            ValidationGroup="doctor" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?" 
                            Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
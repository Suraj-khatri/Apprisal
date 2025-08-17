<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ApprovedLeaveSearch.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveCallBack.ApprovedLeaveSearch" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Search Employee For Call Back
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span> <span class="required" >&nbsp;(* Required fields)</span>       
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        </div>
                        <div class="form-group autocomplete-form">
                             <label>Employee Name:</label>
                            <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                            <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" AutoPostBack="true" 
                                ontextchanged="txtEmpName_TextChanged">
                            </asp:TextBox>
                            <cc1:AutoCompleteExtender ID="aceEmpName" runat="server" CompletionInterval="10" 
                                CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" ServicePath="~/Autocomplete.asmx" 
                                TargetControlID="txtEmpName">
                            </cc1:AutoCompleteExtender>
                            <cc1:TextBoxWatermarkExtender ID="wmeEmpName" runat="server" Enabled="True" TargetControlID="txtEmpName" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                        </div>
                        <div class="form-group">
                            <label>Leave Type:<span class="errormsg">*</span></label>
                            <asp:DropDownList ID="DdlLeaveType" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlLeaveType" 
                                Display="Dynamic" ErrorMessage="Required!" ValidationGroup="call" SetFocusOnError="True">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnGo" runat="server" CssClass="btn btn-primary" onclick="BtnGo_Click" Text=" Search" 
                                ValidationGroup="call" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
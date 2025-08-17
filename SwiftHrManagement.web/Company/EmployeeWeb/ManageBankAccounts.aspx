<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageBankAccounts.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageBankAccounts" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
            	   <i class="fa fa-caret-right"></i><a href="ListBankAccounts.aspx?Id=<%=GetEmpId().ToString()%>">List Bank Account  </a> &raquo; Manage Bank Account 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label><asp:HiddenField ID="hdnempid" runat="server"/>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Account Number <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                              runat="server" ControlToValidate="TxtAccountNumber" Display="None" 
                              ErrorMessage="RequiredFieldValidator" ValidationGroup="account" 
                              SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtAccountNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Account Provider <span class="errormsg">*</span>
                    </label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                              runat="server" ControlToValidate="DdlBankName" Display="None" 
                              ErrorMessage="RequiredFieldValidator" ValidationGroup="account" 
                              SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                          <asp:DropDownList ID="DdlBankName" runat="server" CssClass="form-control">
                          </asp:DropDownList>
                </div>
                </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                        AccountDetails
                    </label>
               
                <asp:TextBox ID="TxtAccountDetails" runat="server" CssClass="form-control" 
                               TextMode="MultiLine" ></asp:TextBox>
                </div>
                </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>Is Default?&nbsp; </label>
                  <asp:CheckBox ID="ChkIsDefault" runat="server" />
                </div>
            </div>
      
         
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="account" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete ?" Enabled="True" 
                    TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
    </div>
           </div>

</asp:Content>

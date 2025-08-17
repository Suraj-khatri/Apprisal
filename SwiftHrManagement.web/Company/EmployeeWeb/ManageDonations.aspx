<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageDonations.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageDonations" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListDonations.aspx?Id=<%=GetEmpId().ToString()%>">List Donation  </a> &raquo; Manage Donation
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
             <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnempid" runat="server" /> 
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
    Donation Date : <span class="errormsg">*</span>
                    </label>
                
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                              runat="server" ControlToValidate="TxtDonationDate" 
                              ErrorMessage="" ValidationGroup="donation"></asp:RequiredFieldValidator>
                          <br />
                        <asp:TextBox ID="TxtDonationDate" runat="server" CssClass="form-control"></asp:TextBox>
                          <cc1:CalendarExtender ID="TxtDonationDate_CalendarExtender" runat="server" 
                              Enabled="True" TargetControlID="TxtDonationDate">
                          </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Amount : <span class="errormsg">*</span>
                    </label>
                   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtDonationAmount" 
                    ErrorMessage="RequiredFieldValidator" Display="None" ValidationGroup="donation"></asp:RequiredFieldValidator>
                <br />              
                <asp:TextBox ID="TxtDonationAmount" runat="server" CssClass="form-control"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtDonationAmount_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtDonationAmount">
                </cc1:FilteredTextBoxExtender>
                </div>
                </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
  Tax Free Percentage : <span class="errormsg">(Special Government Declared Rate Only)</span>
                    </label>
                <asp:TextBox ID="TxtTaxpct" runat="server" CssClass="form-control">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtTaxpct_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtTaxpct">
                </cc1:FilteredTextBoxExtender>
                </div>
                </div>
             <div class="row">
                <div class="col-md-6 form-group">
                     <label>Narration:</label>
                          <asp:TextBox ID="TxtDetailedDescription" runat="server" 
                              TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
           
                
                </div>
            </div>
            <br/>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="donation" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
        </div>
    </div>

</asp:Content>


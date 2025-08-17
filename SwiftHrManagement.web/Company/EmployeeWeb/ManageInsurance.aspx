<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageInsurance.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageInsurance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  <a href="ListInsurance.aspx?Id=<%=GetEmpId().ToString()%>">List Insurance  </a> &raquo; Manage Insurance
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <asp:HiddenField ID="hdnempid" runat="server" />Please enter valid data
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Insurer <span class="errormsg">*</span>
                    </label>
                       <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="DdlInsurer" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlInsurer" runat="server"  CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Insurance For <span class="errormsg">*</span>
                    </label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="DdlInsuranceFor" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlInsuranceFor" runat="server" 
               CssClass="form-control"
                onselectedindexchanged="DdlInsuranceFor_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Insured Date 
            <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                runat="server" ControlToValidate="TxtInsuredDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="TxtInsuredDate" runat="server"  CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtInsuredDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtInsuredDate">
            </cc1:CalendarExtender>      
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                            Expiry Date
            <span class="errormsg">*</span>
                    </label>
                <asp:RequiredFieldValidator ID="R1" 
                runat="server" ControlToValidate="TxtExpDate" Display="None" 
                ErrorMessage="*" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="TxtInsuredDate" ControlToValidate="TxtExpDate" 
                ErrorMessage="Expiry date can't be less than insured date!" Operator="GreaterThanEqual" 
                SetFocusOnError="True" ValidationGroup="Insurance" Display="Dynamic" 
                Type="Date"></asp:CompareValidator><br />
            <asp:TextBox ID="TxtExpDate" runat="server"  CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtExpDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtExpDate">
            </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Insured Amount <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                runat="server" ControlToValidate="TxtAmount" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><%--<asp:CompareValidator ID="CompareValidator3" runat="server" 
                ControlToValidate="TxtAmount" Display="Dynamic" ErrorMessage="Invalid Amount!" 
                Type="Double" ValidationGroup="Insurance" SetFocusOnError="True"></asp:CompareValidator>--%><br />
            <asp:TextBox ID="TxtAmount" runat="server"  CssClass="form-control" 
                 ontextchanged="TxtAmount_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Policy Number <span class="errormsg">*</span>
                    </label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                runat="server" ControlToValidate="TxtInsurancePolicyNumber" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="TxtInsurancePolicyNumber" runat="server" 
                CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Payment Frequency<span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                runat="server" ControlToValidate="ddlPay_frequency" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                InitialValue="0"></asp:RequiredFieldValidator><br />
             <asp:DropDownList ID="ddlPay_frequency" runat="server" 
                 CssClass="form-control" >
                 <asp:ListItem Value="A" Text="Annual" />
                 <asp:ListItem Value="M" Text="Monthly" />
             </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Premium Amount<span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                runat="server" ControlToValidate="txtA_Premium_Amt" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                InitialValue="0"></asp:RequiredFieldValidator><br />
            <asp:textbox ID="txtA_Premium_Amt" runat="server"  CssClass="form-control"> </asp:textbox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Paid By <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                runat="server" ControlToValidate="ddlPremiumPayer" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                InitialValue="0"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="ddlPremiumPayer" runat="server" 
              CssClass="form-control"
                onselectedindexchanged="ddlPremiumPayer_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
                </div>
                 <div id="showHide" runat="server" visible="false">
                <div class="col-md-4">
            <td class="txtlbl" >
                Deduction from Salary<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                runat="server" ControlToValidate="ddlsalaryDeduction" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Insurance" 
                InitialValue="0"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="ddlsalaryDeduction" runat="server"  CssClass="form-control">
                    <asp:ListItem Value="Y" Text="Yes" />
                    <asp:ListItem Value="N" Text="No" />
                </asp:DropDownList> 
            </td>
        </div>
                </div>
            </div>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                onclick="BtnSave_Click" />
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                onclick="BtnDelete_Click" Text="Delete" Visible="False" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Delete?" Enabled="True" 
                TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
        </div>
    </div>
 
</asp:Content>




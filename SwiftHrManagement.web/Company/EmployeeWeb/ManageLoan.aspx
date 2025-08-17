<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageLoan.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageLoan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <div class="panel">
        <header class="panel-heading">
             <i class="fa fa-caret-right"></i>  <a href="ListLoan.aspx?Id=<%=GetEmpId().ToString()%>">List Loan  </a> &raquo; Manage Loan 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!
            <span class="required" >(* Required fields)</span><br />       
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="hdnempid" runat="server"/>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Loan Type:<span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                runat="server" ControlToValidate="DdlLoanType" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Loan" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlLoanType" runat="server" CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Ledger Code:<span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtLedgerCode" 
                Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="TxtLedgerCode" runat="server" CssClass="form-control" 
               ></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Applied Date:
            <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                runat="server" ControlToValidate="TxtAppliedDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Loan" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="TxtAppliedDate" runat="server"  CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtAppliedDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TxtAppliedDate">
            </cc1:CalendarExtender>    
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Applied Amount: <span class="errormsg">*</span>
                    </label>
                   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                runat="server" ControlToValidate="txtAppliedAmount" Display="None" 
                ErrorMessage="*" ValidationGroup="Loan" SetFocusOnError="True"></asp:RequiredFieldValidator><%--<asp:CompareValidator 
                ID="CompareValidator2" runat="server" ControlToValidate="txtAppliedAmount" Display="Dynamic" 
                ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                ValidationGroup="Loan"></asp:CompareValidator>--%><asp:TextBox ID="txtAppliedAmount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Sanctioned Date<span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                runat="server" ControlToValidate="txtSanctionedDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Loan" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="txtSanctionedDate" runat="server" CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                Enabled="True" TargetControlID="txtSanctionedDate">
            </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Sanctioned Amount: <span class="errormsg">*</span>
                    </label>
                   
            <asp:RequiredFieldValidator ID="RvAmount" 
                runat="server" ControlToValidate="txtSanctionedAmt" Display="None" 
                ErrorMessage="*" ValidationGroup="Loan" SetFocusOnError="True"></asp:RequiredFieldValidator><%--<asp:CompareValidator 
                ID="cv2" runat="server" ControlToValidate="txtSanctionedAmt" Display="Dynamic" 
                ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                ValidationGroup="Loan"></asp:CompareValidator>--%><asp:TextBox ID="txtSanctionedAmt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Interest Type:<span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                runat="server" ControlToValidate="DdlInterestType" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Loan" 
                SetFocusOnError="True"></asp:RequiredFieldValidator><br />
            <asp:DropDownList ID="DdlInterestType" runat="server" CssClass="form-control">
            <asp:ListItem Value="">Select...</asp:ListItem>
            <asp:ListItem Value="P">Percent</asp:ListItem>
            <asp:ListItem Value="A">Flat</asp:ListItem>
            <asp:ListItem Value="E">EMI</asp:ListItem>
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Interest Rate (%): <span class="errormsg">*<%--<asp:CompareValidator ID="CompareValidator3" 
                    runat="server" ControlToValidate="txtInterestRate" Display="Dynamic" 
                    ErrorMessage="Invalid Rate!" SetFocusOnError="True" Type="Double" 
                    ValidationGroup="Loan"></asp:CompareValidator>--%></span>
                    </label>
                   <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtInterestRate" 
                Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="txtInterestRate" runat="server" CssClass="form-control" 
                MaxLength="10"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Installment Amount: <span class="errormsg">*</span>
                    </label>
                  
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtInstallmentAmt" 
                Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator><%--<asp:CompareValidator 
                ID="CompareValidator1" runat="server" ControlToValidate="txtInstallmentAmt" 
                ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                ValidationGroup="Loan" Display="Dynamic" Type="Double"></asp:CompareValidator>--%>
                <asp:CompareValidator ID="cv4" runat="server" 
                ControlToCompare="txtSanctionedAmt" ControlToValidate="txtInstallmentAmt" 
                Display="Dynamic" ErrorMessage="Invalid Amount!" Operator="LessThanEqual" 
                SetFocusOnError="True" Type="Double" ValidationGroup="Loan"></asp:CompareValidator>
                <br />
            <asp:TextBox ID="txtInstallmentAmt" runat="server" CssClass="form-control" 
               ></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Installment Start Date:<span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                runat="server" ControlToValidate="txtInstallmentStartDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CVDate" 
                runat="server" ControlToCompare="txtSanctionedDate" 
                ControlToValidate="txtInstallmentStartDate" ErrorMessage="Invalid Date!" Operator="GreaterThanEqual" 
                SetFocusOnError="True" ValidationGroup="Loan" Display="Dynamic" 
                Type="Date"></asp:CompareValidator><br />
            <asp:TextBox ID="txtInstallmentStartDate" runat="server" CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="txtInstallmentStartDate_CalendarExtender" 
                runat="server" Enabled="True" TargetControlID="txtInstallmentStartDate">
            </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         No. Of Installments: <span class="errormsg">*</span>
                    </label>
                   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                runat="server" ControlToValidate="TxtNoOfInstallments" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="TxtNoOfInstallments" runat="server" CssClass="form-control" 
                AutoPostBack="True" 
                ontextchanged="TxtNoOfInstallments_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="TxtNoOfInstallments_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterType="Numbers" 
                TargetControlID="TxtNoOfInstallments">
            </cc1:FilteredTextBoxExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Remaining Installments: <span class="errormsg">*</span>
                    </label>
                    
            <asp:RequiredFieldValidator 
                ID="rfv" runat="server" ControlToValidate="txtRemainingInstallment" 
                Display="None" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Loan"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtRemainingInstallment" runat="server" CssClass="form-control"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtRemainingInstallment_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterType="Numbers" 
                TargetControlID="txtRemainingInstallment">
            </cc1:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Repayment Frequency: <span class="errormsg">*</span>
                    </label>
                   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="ddlRepaymentFrequency" Display="None" ErrorMessage="*" 
                ValidationGroup="Loan" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlRepaymentFrequency" runat="server" CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Next Run Month: <span class="errormsg">*</span>
                    </label>
                   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="DdlNextRunMonth" Display="None" ErrorMessage="*" 
                ValidationGroup="Loan" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlNextRunMonth" runat="server" CssClass="form-control">
            </asp:DropDownList>
                </div>
                <div class="col-md-6 form-group">
                    <label>
Naration: 
                    </label>
                    
            <asp:TextBox ID="txtNaration" runat="server" CssClass="form-control" 
                TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <br/>
             <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                onclick="BtnSave_Click" ValidationGroup="Loan" />
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                Text="Delete" onclick="BtnDelete_Click" ValidationGroup="Loan" 
                Visible="False" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
                &nbsp;
            <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" 
                ValidationGroup="Loan" />
        </div>
    </div>

</asp:Content>

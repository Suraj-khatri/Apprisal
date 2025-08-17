<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageAdvance.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageAdvance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
          <i class="fa fa-caret-right"></i>     <a href="ListAdvance.aspx?Id=<%=GetEmpId().ToString()%>">List Advance  </a> &raquo; Manage Advance 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!              
                    <span class="required">(* Required fields)</span><br />
                    <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hdnempid" runat="server" />
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Advance Type: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlAdvanceType" 
                       ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="Advance"></asp:RequiredFieldValidator><br />
                    <asp:DropDownList ID="DdlAdvanceType" runat="server" CssClass="form-control" ValidationGroup="Advance">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Date Taken: <span class="errormsg">*<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDateTaken" 
                         ErrorMessage="Required!" ValidationGroup="Advance"></asp:RequiredFieldValidator></span>
                    </label>
                   
                    <asp:TextBox ID="TxtDateTaken" runat="server" CssClass="form-control" ValidationGroup="Advance"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtDateTaken_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="TxtDateTaken">
                    </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Advance Amount: <span class="errormsg">*<asp:RequiredFieldValidator 
                        ID="rfv" runat="server" ControlToValidate="TxtAmount" 
                         ErrorMessage="Required!" 
                        ValidationGroup="Advance"></asp:RequiredFieldValidator></span>
                    </label>
                     <asp:CompareValidator ID="cv" runat="server" ControlToValidate="TxtAmount" 
                        Display="Dynamic" ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                        ValidationGroup="Advance" Type="Double"></asp:CompareValidator><br />
                    <asp:TextBox ID="TxtAmount" runat="server" CssClass="form-control" ValidationGroup="Advance"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Deduction Amount: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                        ID="rfv1" runat="server" ControlToValidate="TxtDeductionAmt" 
                       ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="Advance"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cv2" runat="server" 
                        ControlToValidate="TxtDeductionAmt" Display="Dynamic" 
                        ErrorMessage="Invalid Amount!" 
                        onservervalidate="CustomValidator1_ServerValidate" SetFocusOnError="True" 
                        ValidationGroup="Advance" Type="Double"></asp:CompareValidator>&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TxtAmount" ControlToValidate="TxtDeductionAmt" 
                        Display="Dynamic" ErrorMessage="Not higher than advance amount!" 
                        Operator="LessThanEqual" SetFocusOnError="True" Type="Double" 
                        ValidationGroup="Advance"></asp:CompareValidator><br />
                    <asp:TextBox ID="TxtDeductionAmt" runat="server" CssClass="form-control" ValidationGroup="Advance"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Deduction Start Date: <span class = "errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server" ControlToValidate="TxtDeductionStartdate" 
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="Advance">
                    </asp:RequiredFieldValidator>
                    
                    <br />
                    <asp:TextBox ID="TxtDeductionStartdate" runat="server" ValidationGroup="Advance"
                        CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="TxtDeductionStartdate_CalendarExtender" 
                        runat="server" Enabled="True" TargetControlID="TxtDeductionStartdate">
                    </cc1:CalendarExtender>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Deduction Frequency: <span class = "errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="DdlDeductionFrequency"  
                        ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="Advance"></asp:RequiredFieldValidator>
                <br />
                    <asp:DropDownList ID="DdlDeductionFrequency" runat="server" ValidationGroup="Advance" 
                        AppendDataBoundItems="True" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                          Next Run Month: <span class = "errormsg">*</span>
                    </label>
                  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="DdlNextRunMonth" 
                        ErrorMessage="Required!" SetFocusOnError="True" 
                        ValidationGroup="Advance"></asp:RequiredFieldValidator>
                <br />
                    <asp:DropDownList ID="DdlNextRunMonth" runat="server" ValidationGroup="Advance"
                        AppendDataBoundItems="True" CssClass="form-control" >
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Ledger Code:
                    </label> 
                    
                <asp:TextBox ID="txtLedgerCode" runat="server" CssClass="form-control" 
                        TextMode="SingleLine"></asp:TextBox>
                </div>
                </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        Is Fully Paid:
                    </label> 
                    <asp:CheckBox ID="Chkfullypaid" runat="server" Enabled="False" 
                        AutoPostBack="True" oncheckedchanged="Chkfullypaid_CheckedChanged" />
                </div>
                </div>
             <div class="row">
                <div class="col-md-6 form-group">
                   <label> Narration: </label>
                <asp:TextBox ID="txtNarration" runat="server" CssClass="form-control"
                        TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <br/>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                        onclick="BtnSave_Click" Text="Save" ValidationGroup="Advance" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                        onclick="BtnDelete_Click" Text="Delete" Visible="False" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                    &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary"  OnClick="BtnBack_OnClick"
                        Text="Back" />        
        </div>
    </div>
  
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Projectmaster.Master"  AutoEventWireup="true" CodeBehind="ManageFuturePayable.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageFuturePayable1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="../../Jsfunc.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
              <i class="fa fa-caret-right"></i> <a href="ListFuturePayable.aspx?Id=<%=GetEmpId().ToString()%>">List Payable Future  </a> &raquo; Manage Future Payable 
 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!   
            <br /><span class="required" >(* Required fields)</span><br />
             <asp:HiddenField ID="hdnEmployeeId" runat="server" />             
                <asp:Label ID="lblTransactionMessage" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Benefit Name: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="ddlBenefitName" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Payable" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="ddlBenefitName" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
Payable Amount: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtAmount" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Payable" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                
            </div>
       
        <br/>
        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="Payable" />
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


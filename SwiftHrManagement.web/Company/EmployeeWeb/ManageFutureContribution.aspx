<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageFutureContribution.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageFutureContribution" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />

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
            <span class="required" >(* Required fields)</span><br />
             <asp:HiddenField ID="hdnEmployeeId" runat="server" />             
                <asp:Label ID="lblTransactionMessage" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Contribution Date: <span class="errormsg">*</span>
                    </label>
                   
       
            <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control"></asp:TextBox>
            <cc1:CalendarExtender ID="ce1" runat="server" EnabledOnClient="true" TargetControlID="TxtDate"></cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtDate" Display="None" 
                    ErrorMessage="Required!" ValidationGroup="Contribution" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
        
                </div>
                <div class="col-md-4 form-group">
                    <label>
  Amount: <span class="errormsg">*</span>
                    </label>
                 
            <asp:TextBox ID="TxtAmount" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="TxtAmount" Display="None" 
                ErrorMessage="Required!" ValidationGroup="Contribution" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                </div>
              <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                        Remarks:
                    </label>
                     <asp:TextBox ID="TxtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>Is Active </label>
                    <asp:CheckBox ID="ChkInactive" runat="server" />
                </div>
            </div>
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="Contribution" />
                <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:confirmbuttonextender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" visible ="false"
                    Text="Delete" />
                <cc1:confirmbuttonextender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" 
                    TargetControlID="BtnDelete">
                </cc1:confirmbuttonextender>
<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
        </div>
    </div>
    
</asp:Content>

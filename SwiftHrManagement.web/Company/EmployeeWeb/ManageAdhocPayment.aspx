<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageAdhocPayment.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageAdhocPayment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID = "pnladhoc" runat=server>
    <ContentTemplate>
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>   <a href="ListAdhocPayment.aspx?Id=<%=GetEmpId().ToString()%>">List Adhoc Payments </a> &raquo; Manage Adhoc Payments
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
             Plese enter valid data
                <span class="required">(* Required fields)</span><br />
                <div style="text-align: left; height: 13px; width: 275px">
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </div>
                  <asp:HiddenField ID="hdnempid" runat="server" />
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Add/ Deduct: <span class="errormsg">*
                </span>
                    </label>
                    
                <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlAddDeduct" 
                    Display="None" SetFocusOnError="True" ValidationGroup="adhoc"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="DdlAddDeduct" runat="server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="DdlAddDeduct_SelectedIndexChanged">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="A">Add</asp:ListItem>
                    <asp:ListItem Value="D">Deduct</asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Head: <span class="errormsg"> *<asp:RequiredFieldValidator 
                    ID="rfv" runat="server" ControlToValidate="DdlAdhocHead" 
                    Display="None" ErrorMessage="*" SetFocusOnError="True" 
                    ValidationGroup="adhoc"></asp:RequiredFieldValidator></span>
                    </label>
                   
                <asp:DropDownList ID="DdlAdhocHead" runat="server" CssClass="form-control">
                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Amount:<span class="errormsg"> *<asp:RequiredFieldValidator 
                    ID="rfv1" runat="server" 
                    ControlToValidate="TxtPayableAmount" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="adhoc" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator></span>
                    </label>
                   <asp:CompareValidator ID="cv" runat="server" 
                    ControlToValidate="TxtPayableAmount" Display="Dynamic" 
                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                    ValidationGroup="adhoc"></asp:CompareValidator><br />
                <asp:TextBox ID="TxtPayableAmount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Tax Deducted Amount:
                    </label>
                   
                            <asp:CompareValidator ID="cv3" runat="server" ControlToValidate="TxtTax" 
                                Display="Dynamic" ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                                Type="Double" ValidationGroup="adhoc"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxtTax" runat="server" CssClass="form-control">0</asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                           Applied For year:
                    </label>
                 
               <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" >
                </asp:DropDownList><br />
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Applied For Month:
                    </label>
                    
                <asp:DropDownList ID="Ddlmonth" runat="server" CssClass="form-control" >
                </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Is Applied?
                    </label>
                  
                <asp:CheckBox ID="ChkPaid" runat="server" 
                    oncheckedchanged="ChkPaid_CheckedChanged" AutoPostBack="True" />
                </div>
                </div>
                 <div class="row">
                <div class="col-md-4 form-group">
                    <label>
Applied Date: <span class ="errormsg">(Already Applied Date)</span>
                    </label>
                <asp:TextBox ID="TxtPayableDate" runat="server" CssClass="form-control"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtPayableDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtPayableDate">
                </cc1:CalendarExtender>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-6 form-group">
                    <label>
                         Narration:
                    </label>
                <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control" 
                     TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <asp:CheckBox ID="ChkIstaxed" runat="server" Visible="false" />
            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="adhoc" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete ?" Enabled="True" 
                    TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary"
                    onclick="BtnCancel_Click" Text="Back" />
        </div>
    </div> 
    
     </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>


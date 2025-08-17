<%@ Page Title="" Language="C#" MasterPageFile="~/Projectmaster.Master" AutoEventWireup="true" CodeBehind="ManagePayable.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManagePayable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UPDATE1" runat="server">
        <ContentTemplate>
            <div class="panel">
                <header class="panel-heading">
             <i class="fa fa-caret-right"></i> <a href="ListPayable.aspx?Id=<%=GetEmpId().ToString()%>">List Payable  </a> &raquo; Manage Payable 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label> 
        </header>
                <div class="panel-body">
                    Please enter valid data!   
                    
                    <span class="required">(* Required fields)</span><br />
                    <asp:HiddenField ID="hdnEmployeeId" runat="server" />
                    <asp:Label ID="lblTransactionMessage" runat="server" Text="" />

                    <div class="row">
                        <div id="DivMsg" runat="server"></div>
                        <div class="col-md-12 form-group">
                            <asp:Label ID="lblBenefit" runat="server" />
                            <asp:TextBox ID="txtBenefit" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-4 form-group">
                            <div id="AddSingleBenefit" runat="server">
                                <label><asp:Label ID="lbloption" runat="server" Text="Add New Benefit Head:" /></label>
                                <asp:CheckBox runat="server" ID="chkAddBenefit" OnCheckedChanged="chkAddBenefit_CheckedChanged" AutoPostBack="true" />
                            </div>
                        </div>
                        <div class="col-md-4 form-group">
                            <label><asp:Label ID="lblChooseSet" runat="server" Text="Choose Set:"></asp:Label></label>
                            <span class="errormsg" id="asterisk" runat="server">*</span>
                            <asp:RequiredFieldValidator ID="rft"
                                runat="server" ControlToValidate="ddlChooseSet" 
                                ErrorMessage="Required!" ValidationGroup="Payable"
                                SetFocusOnError="True" />
                            <asp:DropDownList ID="ddlChooseSet" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="ddlChooseSet_SelectedIndexChanged" AutoPostBack="true" />
                            
                        </div>

                    </div>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary"
                        OnClick="BtnSearch_Click" />
                    <br/>
                    <div runat="server" id="head">
                        <%--<div class="panel-body">--%>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label><asp:Label ID="Benefithead" runat="server" Text="Benefit Head:" /></label>
                                <asp:DropDownList ID="DdlBenefitHead" runat="server" CssClass="form-control" />

                            </div>
                            <div class="col-md-4 form-group">
                                <label><asp:Label ID="Amount" runat="server" Text="Benefit Amount:" /></label>
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />

                            </div>

                        </div>
                        <%--</div>--%>
                    </div>
                    <%--<div class="panel-body">--%>
                    <div class="row">
                        <div class="col-md-4 form-group">
                             <label><asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date:" /></label>
                             <asp:TextBox ID="txtEffecctiveDate" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="ceEffectiveDate" runat="server" TargetControlID="txtEffecctiveDate" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label><asp:Label ID="lblAppliedDate" runat="server" Text="Applied Date:" /></label>
                            <asp:TextBox ID="txtAppliedDate" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="ceAppliedDate" runat="server" TargetControlID="txtAppliedDate" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label><asp:Label ID="lblEffectiveUpto" runat="server" Text="Effective Upto:" /></label>
                            <asp:TextBox ID="txtEffectiveUpto" runat="server" CssClass="form-control" />
                            <cc1:CalendarExtender ID="ceEffectiveUpto" runat="server" TargetControlID="txtEffectiveUpto" />
                        </div>
                    </div>
                    <%--</div>--%>
                    <div id="rpt" runat="server"></div>

                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                        OnClick="BtnSave_Click" ValidationGroup="Payable" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave" />
                    &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Visible="false"
                        Text="Delete" OnClick="BtnDelete_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete" />
                    <input id="btnBack" type="button" value="Back" class="btn btn-primary" onclick="Javascript: history.back()" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


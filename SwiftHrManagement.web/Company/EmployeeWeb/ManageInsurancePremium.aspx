<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageInsurancePremium.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageInsurancePremium" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            width: 178px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


<asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>    
        <div class="row">
            <div class="col-md-12">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                       <a href="ListInsurance.aspx?Id=<%=GetEmpId().ToString()%>">List Insurance  </a> &raquo;
						<a href="ListInsurancePremium.aspx?EmpId=<%=GetEmpId().ToString()%>&Insurance_Id=<%=GetInsuranceId().ToString()%> ">Manage Insurance Premium  </a> &raquo; Insurance Premium Details Entry
                        <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                            <asp:Label ID="lblTransactionMessage" runat="server" ></asp:Label>
                            <asp:HiddenField ID="hdnInsuranceId" runat="server" />
                            <asp:HiddenField ID="hdnempid" runat="server" />
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6 ">
                                <div class="form-group">
                                    <label>Category For:</label>
                                    <asp:TextBox ID="txtInsurancePolicy" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 ">
                                <div class="form-group">
                                   <label>&nbsp;</label>
                                    <asp:TextBox ID="txtUnpaidAmt" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 ">
                                <div class="form-group">
                                    <label>Paid Amount: <span class="errormsg">*</span></label>
                                    <asp:CompareValidator ID="CV1" 
                                        runat="server" ControlToValidate="TxtPaidAmount" Display="Dynamic" 
                                        ErrorMessage="Invalid Amount!" SetFocusOnError="True" Type="Double" 
                                        ValidationGroup="insurancepremium">
                                    </asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                        runat="server" ControlToValidate="TxtPaidAmount" Display="None" 
                                        ErrorMessage="Required!" ValidationGroup="insurancepremium" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtPaidAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6 ">
                                <div class="form-group">
                                   <label> Paid Date: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                        runat="server" ControlToValidate="TxtPaidDate" Display="None" 
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                                        ValidationGroup="insurancepremium">
                                    </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtPaidDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtPaidDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="TxtPaidDate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6 ">
                                <div class="form-group">
                                    <label>Receipt Number(Premium Payment):</label>
                                    <asp:TextBox ID="TxtPaidReceiptNumber" runat="server" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                            onclick="BtnSave_Click" ValidationGroup="insurancepremium" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete" Visible="False" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to Delete ?" Enabled="True" TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" />
                        </div>

                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<%--
   <table border="0" cellspacing="5" cellpadding="5" class="container"> 

        
        <tr>
            <td colspan="3">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="insurancepremium" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" Visible="False" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete ?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="&lt;&lt;Back" />
                </td>
        </tr>
--%>
</asp:Content>
   

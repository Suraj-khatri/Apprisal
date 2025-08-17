<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageAdvanceCollection.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageAdvanceCollection" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style10
        {
            font-weight: bold;
            text-decoration: underline;
            font-size:12px;
            color: #004D20;
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
                            <a href="ListAdvance.aspx?Id=<%=GetEmpId().ToString()%>">List Advance </a> &raquo;
						    <a href="ListAdvanceCollection.aspx?EmpId=<%=GetEmpId().ToString()%>&Id=<%=GetAdvanceId().ToString()%>">List Advance Deduction  </a> &raquo;Manage Advance Deduction 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
				                <u><b>Advance Collection Entry</b></u>
                            </div>
                               
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <label>Advance Type:</label>
                                </div>
                                <div class="col-md-3">
                                     <asp:Label ID="lblAdvanceType" runat="server" ></asp:Label>
                                </div>
                                <div class="col-md-3 text-right">
                                    <label>Date Taken:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lblDateTaken" runat="server" CssClass="lblText"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <label>Advance Amount:</label>
                                </div>
                                <div class="col-md-3">
                                     <asp:Label ID="lblAdvanceAmt" runat="server" ></asp:Label>
                                </div>
                                <div class="col-md-3 text-right">
                                    <label>Deduction Amount:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lblDeductionAmt" runat="server" ></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <label>Deduction Start Date:</label>
                                </div>
                                <div class="col-md-3">
                                     <asp:Label ID="lblDeducationStartDate" runat="server" ></asp:Label>
                                </div>
                                <div class="col-md-3 text-right">
                                    <label>Is Fully Paid:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lblIsFullyPaid" runat="server" ></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <label>Remaining Balance:</label>
                                </div>
                                <div class="col-md-3">
                                     <strong><asp:Label ID="lblRemainBalance" runat="server" ></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <label>Deduction Frequency:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lblDeductionFrequency" runat="server" ></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
				                <u><b>Advance Deduction Entry Details</b></u><br/>
                                <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdnempid" runat="server" />
                            </div>
                            
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Paid Amount:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPaidAmount"  
                                    SetFocusOnError="True" ValidationGroup="advanceCollection" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="txtPaidAmount" 
                                    ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                                    Type="Double" ValidationGroup="advanceCollection"></asp:CompareValidator><br />
                                    <asp:TextBox ID="txtPaidAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label>Paid Date:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                    ControlToValidate="txtPaidDate"  SetFocusOnError="True" 
                                    ValidationGroup="advanceCollection" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtPaidDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtPaidDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtPaidDate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-11 ">
                                    <label>Narration:</label>
                                    <asp:TextBox ID="txtNarration" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <br/>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="advanceCollection" />
                                <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" 
                                        Text="Back" onclick="BtnCancel_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>  

                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

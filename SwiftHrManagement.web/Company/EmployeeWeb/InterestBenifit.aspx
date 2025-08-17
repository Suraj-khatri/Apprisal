<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="InterestBenifit.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.InterestBenifit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Interest Benefit
                        </header>
                        <div class="panel-body">
                            <label>Upload CSV file for payable</label>
                                <a target='_blank' href="../../doc/InterestBenefit/interest_benefit.csv" alt='Sample File'>Get Sample Upload File</a>
                                <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />
                            <div class="form-group">
                                <label>Benefit Head:</label>
                                <asp:DropDownList ID="Ddlinterest" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                 <label>Fiscal Year:</label>
                                <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                             <div class="form-group">
                                <label> Select File: <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                                    ValidationGroup="adhoc" ControlToValidate="fileUpload" Display="Dynamic" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:FileUpload ID = "fileUpload" runat = "server" />    
                            </div>
                            <div class="form-group">
                                <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="btn btn-primary" 
                                    onclick="BtnUpload_Click" ValidationGroup="adhoc"/>
                                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                </section>
            </div>
        </div>
</asp:Content>

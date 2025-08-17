<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadPayment.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.UploadPayment" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Adhoc Payment Upload CSV File
                </header>
                <div class="panel-body">
                    <label>Upload CSV file for adhoc Payment</label>
                    <a target='_blank' href="../../doc/Adhoc_upload/adhoc_upload.csv" alt='Sample File'>Get Sample Upload File</a>
                    <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label> Add/ Deduct <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                    ErrorMessage="Required!" ControlToValidate="DdlAddDeduct" 
                                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="adhoc"></asp:RequiredFieldValidator>

                                <asp:DropDownList ID="DdlAddDeduct" runat="server" CssClass="form-control" 
                                    AutoPostBack="True" onselectedindexchanged="DdlAddDeduct_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="A">Add</asp:ListItem>
                                    <asp:ListItem Value="D">Deduct</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label> Deduction Head <span class="errormsg">*
                                <asp:RequiredFieldValidator 
                                    ID="rfv" runat="server" ControlToValidate="DdlAdhocHead" 
                                    Display="Dynamic" ErrorMessage="Reqired!" SetFocusOnError="True" 
                                    ValidationGroup="adhoc"></asp:RequiredFieldValidator></span></label>
                                <asp:DropDownList ID="DdlAdhocHead" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Applied For year</label>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label> Applied For Month</label>
                                    <asp:DropDownList ID="Ddlmonth" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group" align="left">
                                <label>Is Applied?</label>
                                <asp:CheckBox ID="ChkPaid" runat="server" oncheckedchanged="ChkPaid_CheckedChanged" AutoPostBack="True" />
                            </div>
                        </div>                               
                        <div class="col-md-6">
                            <div class="form-group"> 
                                <label>Applied Date</label>
                                <asp:TextBox ID="TxtPayableDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtPayableDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtPayableDate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>  Apply On</label>
                                <asp:TextBox ID="TxtAppliedOn" runat="server" CssClass="form-control" 
                                        ontextchanged="TxtAppliedOn_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtAppliedOn_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtAppliedOn">
                                </cc1:CalendarExtender>                                         
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Select File <span class="errormsg">*</span> </label>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                                    ValidationGroup="adhoc" ControlToValidate="fileUpload" Display="Dynamic" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <br />           
                                <asp:FileUpload ID = "fileUpload" runat = "server" CssClass = "" />    
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>&nbsp;</label>
                                <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="btn btn-primary" 
                                    onclick="BtnUpload_Click" ValidationGroup="adhoc"/>
                                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                                </cc1:ConfirmButtonExtender>
                            </div>    
                        </div>                           
                    </div>
                </section>
            </div>
        </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadPayable.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.UploadPayable" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Payable Upload CSV File
                </header>
            <div class="panel-body">
                        <label>Upload CSV file for payable</label>
                        <a target='_blank' href="../../doc/payroll_upload/payable/excel_upload.csv" alt="Sample File">Get Sample Upload File</a>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-6">
                                <label> Benefit Head : <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                                ErrorMessage="Required!" ControlToValidate="DdlBenefitHead" 
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="payable"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="DdlBenefitHead" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>  Previous Effective Upto :</label>
                                <asp:Textbox ID="txtEff_upto" runat="server" CssClass="form-control"></asp:Textbox>
                                <cc1:CalendarExtender ID="txtEff_upto_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtEff_upto">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="col-md-6">
                                <label>Effective From : <span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Required!" ControlToValidate="txtEff_From" 
                                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="payable"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Textbox ID="txtEff_From" runat="server" CssClass="form-control"></asp:Textbox>
                                    <cc1:CalendarExtender ID="txtEff_From_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtEff_From">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="col-md-6">
                                <label>  Apply From :<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Required!" ControlToValidate="txtApply_From" 
                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="payable"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Textbox ID="txtApply_From" runat="server" CssClass="form-control"></asp:Textbox>
                                <cc1:CalendarExtender ID="txtApply_From_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtApply_From">
                                </cc1:CalendarExtender>
                            </div>   
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Select File:</label><span class="errormsg">*</span> 
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                            ValidationGroup="payable" ControlToValidate="fileUpload" Display="Dynamic" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" size="22" class="form-group" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="btn btn-primary" 
                            onclick="BtnUpload_Click" ValidationGroup="payable"/>
                        <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                        </cc1:ConfirmButtonExtender>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

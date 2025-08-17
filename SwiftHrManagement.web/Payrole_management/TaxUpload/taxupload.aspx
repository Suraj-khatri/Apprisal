<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="taxupload.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.TaxUpload.taxupload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Tax Upload CSV File
                        </header>
                        <div class="panel-body">
                            <label>Upload TAX</label>
                            <a target='_blank' href="../../doc/payroll_upload/tax/tax_upload.csv" alt='Sample File'>Get Sample Upload File</a>
                            <div class="form-group">
                                <label> Year :<span class="errormsg">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Required"  ValidationGroup="taxupload" ControlToValidate="DdlYear"></asp:RequiredFieldValidator></span></label>
                                 <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>Month<span class="errormsg"> *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="Required"  ValidationGroup="taxupload" ControlToValidate="DdlMonth"></asp:RequiredFieldValidator></span></label>
                                <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>  Select File :<span class="errormsg">*<asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="Required" ValidationGroup="taxupload" ControlToValidate="fileUpload"></asp:RequiredFieldValidator></span></label>
                                <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" />
                            </div>
                            <div class="form-group">         
                                <asp:Button ID="BtnUpload" runat="server" Text="Live Upload" 
                                    CssClass="btn btn-primary" onclick="BtnUpload_Click" ValidationGroup="taxupload"/>
                                <asp:Button ID="BtnUploadTrial" runat="server" Text="Trial Upload" 
                                    CssClass="btn btn-primary" ValidationGroup="taxupload" 
                                    onclick="BtnUploadTrial_Click"/>
                            </div> 
                            <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />	
                        </div>
               </section>
            </div>
        </div>
</asp:Content>


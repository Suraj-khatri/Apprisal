<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="upload_asset.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.upload_asset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                    Upload Asset Booking
                    </header>
            <div class="panel-body">
                <h4>Upload Asset Of Diminishing Method</h4>
                <div class="form-group">
                <asp:Label ID="LblMessageText" runat="server" Text="Label" CssClass="wellcome"></asp:Label>
                    </div>
                <div class="form-group">
                    <a target='_blank' href="../doc/upload.csv" alt='Sample File'>Get Sample Upload File</a>
                    <br />
                    <asp:Label ID="lblmsg1" runat="server" CssClass="errormsg"></asp:Label>
                </div>
                <div class="row form-inline">
                <div class="col-md-4 form-group">
                    <label>Select File:</label>
                    <span class="txtlbl"> <span class="errormsg">*</span> </span>
                        <input id="fileDM" runat="server" name="fileDM" type="file"
                        class="inputTextBoxLP"/> 
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Required!"
                ValidationGroup="DM" ControlToValidate="fileDM" Display="Dynamic" 
                    SetFocusOnError="True" class="form-control"></asp:RequiredFieldValidator> 
                </div>
                <div class="col-md-2 form-group">
                    <label>&nbsp;</label><br />
                    <asp:Button ID="BtnUploadDM" runat="server" Text="Upload To Server" CssClass="btn btn-primary"
                        ValidationGroup="DM" OnClick="BtnUploadDM_Click" />

                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                        ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUploadDM">
                    </cc1:ConfirmButtonExtender>
                </div>
                    </div>
            </div>
            </section>
        </div>
    </div>



</asp:Content>


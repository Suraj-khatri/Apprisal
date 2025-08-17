<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="UploadBill.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.BillDetail.UploadBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

 <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                     Upload File</header>
                <div class="panel-body">
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                    <br />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                    <fieldset>
                        <legend >Upload Bill  As A File: </legend>
                    </fieldset>
                  <div class="row form-inline">
                 <div class="col-md-3 form-group">
                    <label>Select File:</label><span class="required">*</span>
                    <input id="fileUpload" runat="server" class="" name="fileUpload" 
                    type="file"/>
                     <asp:RequiredFieldValidator ID="rfv2" 
                    runat="server" ControlToValidate="fileUpload" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="upload">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-6 form-group">
                    <label>File Description:</label><span class="required">*</span>
                    <asp:TextBox ID="TxtFileDesc" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!" ControlToValidate="TxtFileDesc" Display="Dynamic" SetFocusOnError="True" 
                                            ValidationGroup="upload"></asp:RequiredFieldValidator>
                </div>
                       
              <div class="col-md-3">
                  <label>&nbsp;</label><br />
                    <asp:Button ID="BtnUpload" runat="server" CssClass="btn btn-primary" onclick="BtnUpload_Click" Text="Upload" ValidationGroup="upload" />
                </div>
                       </div>
                <div class="form-group">
                    <asp:Table ID="tblResult" runat="server" Width="100%">
                </asp:Table>
                </div>
            </div>
            </section>
        </div>
    </div>    
   
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CustomerFileUploader.aspx.cs" Inherits="SwiftAssetManagement.web.Customer.CustomerFileUploader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <%--<asp:scriptmanager runat="server"></asp:scriptmanager>--%>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-user"></i>  Uploaded File Informationp;  Customer Name:-<asp:Label id="lblcustName" runat="server"></asp:Label>
                </header>
                    <div class="panel-body">
                                        <span class="txtlbl" >Please enter valid data!</span><br />
                                        <span class="required" >(* Required fields)</span><br /><br />
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label> File Description:<span class="errormsg">*</span></label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFileDescription" Display="None" 
                                                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="uploader"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>Select File:<span class="errormsg">*</span></label>
                                                <input id="fileUpload" runat="server" name="fileUpload" type="file" class="form-group" />
                                            </div>
                                            </div>
                                         <div class="col-md-2">
                                            <div class="form-group">
                                                <label>&nbsp;</label><br />
                                            <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" onclick="BtnUpload_Click" ValidationGroup="uploader"/>
                                        </div>
                                            </div>

                                    </div>
                                    <div class="form-group">
                                        <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
                                    </div>
                                    <div class="form-group">
                                        
                                        <asp:Button ID="Delete" runat="server" CssClass="btn btn-primary" onclick="Delete_Click" Text="Delete" />
                                        <asp:Button ID="Btn_Back" runat="server" CssClass="btn btn-primary" 
                                         OnClick="Btn_Back_Click" Text="Back" />
                                    </div>

                                </div>
                            
            </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CMSMenuManage.aspx.cs" Inherits="SwiftHrManagement.web.CMS_Management.CMSMenuManage" Title="Swift HR Management System 1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Create Sub Menu Details
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Page Name:<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="DdlPageName" Display="Dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" 
                            ValidationGroup="sub"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DdlPageName" runat="server" CssClass="form-control" 
                            onselectedindexchanged="DdlPageName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Parent Menu:</label>
                        <asp:DropDownList ID="DdlMainMenu" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Menu Name:<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtSubMenu" Display="Dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" 
                            ValidationGroup="sub"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSubMenu" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Display:</label>
                        <asp:DropDownList ID="ddlDisplayFlag" runat="server" CssClass="form-control">
                            <asp:ListItem Value="o">Outside/All Side</asp:ListItem> 
                            <asp:ListItem Value="i">Inside Only</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Menu Description:<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtMenuDesc" Display="Dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" 
                            ValidationGroup="sub"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtMenuDesc" runat="server" CssClass="form-control" 
                            TextMode="MultiLine"></asp:TextBox>
                        
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" 
                            onclick="Btn_Save_Click" ValidationGroup="sub" />

                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete" />

                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnBack_Click" Text="Back" />
                    </div>
                    <div class="form-group">

                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

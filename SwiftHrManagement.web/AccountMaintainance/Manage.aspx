<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.AccountMaintainance.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<asp:UpdatePanel ID="updatep" runat=server>
<ContentTemplate>
    <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                             Account Maintainance
                        </header>
                        <div class="panel-body">
                                <div class="form-group">
                                    <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>

                                <div class="form-group">
                                    <label>Account Number:<span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ErrorMessage="Required!" ControlToValidate="TxtAccountNumber" AutoComplete="Off"
                                        Display="Dynamic" ValidationGroup="account" BorderColor="#FFFF66"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="TxtAccountNumber" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                                        
                                </div>
                                  <div class="form-group">
                                    <label>Account Name:<span class="errormsg">*</span></label>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ErrorMessage="Required!" ControlToValidate="TxtAccountName" AutoComplete="Off"
                                        Display="Dynamic" ValidationGroup="account" BorderColor="#FFFF66"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="TxtAccountName" runat="server" CssClass="form-control" Width="100%" ></asp:TextBox>
                                        
                                </div>
                                 
                                 <div class="form-group">
                                    <label>Account Currency:<span class="errormsg">*</span></label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ErrorMessage="Required!" ControlToValidate="TxtAccountCurrency" AutoComplete="Off"
                                        Display="Dynamic" ValidationGroup="account" BorderColor="#FFFF66"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="TxtAccountCurrency" runat="server" CssClass="form-control" Width="100%" ></asp:TextBox>
                                        
                                </div>
                                 
                                 <div class="form-group">
                                    <label>Select Branch:<span class="errormsg">*</span></label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Required!" ControlToValidate="CmbAccountBranch" AutoComplete="Off"
                                        Display="Dynamic" ValidationGroup="account" BorderColor="#FFFF66"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="CmbAccountBranch" runat="server" CssClass="form-control" Width="100%"> 
                                    </asp:DropDownList>
                                        
                                </div>   
                                 <div class="form-group">
                                    <label>Account Type:<span class="errormsg">*</span></label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="Required!" ControlToValidate="TxtAccountType" AutoComplete="Off"
                                        Display="Dynamic" ValidationGroup="account" BorderColor="#FFFF66"
                                        SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                        <asp:TextBox ID="TxtAccountType" runat="server" CssClass="form-control" Width="100%" ></asp:TextBox>
                                        
                                </div>
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="Btn_Save_Click" Font-Strikeout="False" ValidationGroup="account"
                                    Width="75px" />
                                
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"  Text="Back"  onclick="BtnBack_Click" />
                            </div>
                        </div>
                        </div>
                    </section>
                </div>
            </div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

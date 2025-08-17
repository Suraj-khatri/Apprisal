<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.SalaryLeaderMapping.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Salary Ledger Creation & Mapping
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Branch Name:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="DdlBranchName" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="acc" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>
                                         
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Salary Ledger Head Name:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="DdlHeadName" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="acc" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="DdlHeadName" runat="server" CssClass="form-control" Width="100%"> 
                                        </asp:DropDownList>
                                         
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Account Name:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtAccName" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="acc" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                       <asp:textbox ID="txtAccName" runat="server" CssClass="form-control" Width="100%"></asp:textbox>
                                         
                                    </div>
                                </div>
                                
                                <div class="col-md-6 form-group">
                                    <div class="form-group">
                                        <label>Account Number:<span class="errormsg">*</span></label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ErrorMessage="Required!" ControlToValidate="txtAccNumber" AutoComplete="Off"
                                            Display="Dynamic" ValidationGroup="acc" BorderColor="#FFFF66"
                                            SetFocusOnError="True">
                                        </asp:RequiredFieldValidator>
                                       <asp:textbox ID="txtAccNumber" runat="server" CssClass="form-control" Width="100%"></asp:textbox>
                                         
                                    </div>
                                </div>
                            </div>
                           
                        <%-- <button type="submit" class="btn btn-primary">Submit</button>--%>
                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="acc" />
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_Click" Text=" Back" />
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

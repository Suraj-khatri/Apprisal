<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.Manage" Title="Swift HR Management System 1.0" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                          SALARY GENERATION DETAILS
                        </header>
                        <div class="panel-body">
                            
     <asp:UpdatePanel ID = "updtpnl" runat ="server">
        <ContentTemplate>
                   <div>
                     <asp:Label ID="lblMes" runat="server"></asp:Label>  
                   </div> 

                          <div class="form-group">
                                <label>Fiscal Year :</label>
                               <asp:DropDownList ID="DdlFY" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                            </div>
                          <div class="form-group">
                                <label> Run Month :</label>
                    <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>
                              
                            </div>
                          <div class="form-group">
                                <label>Branch Name :</label>
                  <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" 
                         AutoPostBack="True" 
                        onselectedindexchanged="DdlBranch_SelectedIndexChanged">
                    </asp:DropDownList>
                           </div>
                           <div class="form-group">
                                <label>Employee Name :</label>
                               <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                   </div>
                            <div class="form-group">
                                   <asp:Button ID="btnGenerate" runat="server" Text="Generate Salary" onclick="btnGenerate_Click" CssClass="btn btn-primary" /> 
                    <cc1:ConfirmButtonExtender ID="btnGenerate_ConfirmButtonExtender" 
                        runat="server" ConfirmText="Confirm To Generate Live Salary?" Enabled="True" 
                        TargetControlID="btnGenerate">
                    </cc1:ConfirmButtonExtender>
                                
                            </div>
             </ContentTemplate>
    </asp:UpdatePanel>
                            </div>
                </section>
        </div>
    </div>

</asp:Content>

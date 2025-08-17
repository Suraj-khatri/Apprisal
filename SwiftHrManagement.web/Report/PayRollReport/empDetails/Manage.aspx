<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.empDetails.Manage" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UP" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-lg-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Get Employee Id
                        </header>
                        <div class="panel-body">
                             Please enter valid data!<span class="required"> (* Required fields!)</span>
                            <div class="form-group">
                                <label>Branch Name :</label>
                               <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DdlBranchName_SelectedIndexChanged"></asp:DropDownList>     
                               </div>
                            <div class="form-group">
                                <label>Department Name :</label>
                                 <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" 
                          AutoPostBack="True" 
                          onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList> 
                            </div> 
                             <div class="form-group">
                                <label>Employee Name :</label>
                                  <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control">
                </asp:DropDownList>  
                                 </div>
                            <div class="form-group">
                                  <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" 
                    onclick="Btn_Search_Click" ValidationGroup="yearly" />
                &nbsp;<asp:Button ID="BtnExport" runat="server" CssClass="btn btn-primary" 
                    onclick="BtnExport_Click" Text="Export To Excel" /> 
                            </div>
                            </div>
                        </section>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

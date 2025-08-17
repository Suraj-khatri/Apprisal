<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="ManageContributionReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Contribution_Report.ManageContributionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6 col-md-offset-3">
                    <section class="panel">
                    <header class="panel-heading">
                         <i class="fa fa-caret-right" aria-hidden="true"></i> 
                         Contribution Report
                        </header>
                    <div class="panel-body">
                        <div class="form-group">
                           
                            <label>Fiscal Year : <span class="errormsg">*</span> </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlFiscalYear"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contributionProjection"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control">
                            </asp:DropDownList>

                            
                        </div>
                        <div class="form-group">
                           
                            <label>Month : <span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlMonth"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contributionProjection"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control"
                                AutoPostBack="True">
                            </asp:DropDownList>

                            
                            <span class="errormsg">
                                <asp:Label ID="Lblmonth" Text="" runat="server"></asp:Label></span>
                        </div>
                        <div class="form-group">
                            <label>Branch :</label>
                            <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="DdlBranchType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Department :</label>
                            <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="form-control"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="DdlDepartment_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Employee :</label>
                            <asp:DropDownList ID="DdlEmployee" runat="server" CssClass="form-control"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <span class="errormsg">
                                <asp:Label ID="lblemp" Text="" runat="server"></asp:Label></span>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnsummery" runat="server" CssClass="btn btn-primary" Text="Summery"
                                ValidationGroup="contributionProjection" OnClick="btnsummery_Click" />

                            <asp:Button ID="BtnViewDetails" runat="server" Text="View Details" CssClass="btn btn-primary"
                                ValidationGroup="contributionProjection" OnClick="BtnViewDetails_Click" />

                        </div>
                    </div>
                      </section>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

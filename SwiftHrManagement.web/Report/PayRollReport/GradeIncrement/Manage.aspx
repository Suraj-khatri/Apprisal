<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.GradeIncrement.Manage" %>

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
                        Grade Increment Report
                        </header>
                    <div class="panel-body">
                        <label>Grade Increment Report</label>
                        <div class="form-group">
                            <label>Fiscal Year : <span class="errormsg">*</span></label>
                            <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="DdlFiscalYear"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Text="Search"
                                ValidationGroup="contribution" OnClick="BtnSearch_Click" />
                        </div>
                    </div>
                         </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

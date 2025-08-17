<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.HeadWise.Manage" %>
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
                         Report
                        </header>
                    <div class="panel-body">
                        <label>Deposit Report</label>
                        <div class="form-group">
                            <label>Fiscal Year:<span class="errormsg">*</span> </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ControlToValidate="DdlFiscalYear"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control" >
                            </asp:DropDownList>

                            
                        </div>
                        <div class="form-group">
                            <label>Month:</label>
                            <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Branch:</label>
                            <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="DdlBranchType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Department:</label>
                            <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Report:<span class="errormsg">*</span> </label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                ControlToValidate="ddlReport"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlReport" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="cit">CIT</asp:ListItem>
                                <asp:ListItem Value="epf">EPF</asp:ListItem>
                                <asp:ListItem Value="tax">TAX</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Text="Search"
                                ValidationGroup="contribution" OnClick="BtnSearch_Click" />

                            <asp:Button ID="BtnDeposit" runat="server" CssClass="btn btn-primary" Text="Deposits"
                                ValidationGroup="contribution" OnClick="BtnDeposit_Click" />
                        </div>
                        <br/>
                        <label>Yearly Payable Report</label>
                        <div class="form-group">
                            <label>Fiscal Year:<span class="errormsg">*</span> </label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                ControlToValidate="DdlFY_ID"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="head"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlFY_ID" runat="server" CssClass="form-control" >
                            </asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <label>Branch:</label>
                            <asp:DropDownList ID="Ddl_Branch" runat="server" CssClass="form-control"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="Ddl_Branch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Department:</label>
                            <asp:DropDownList ID="Ddl_Department" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Head:<span class="errormsg">*</span> </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                ControlToValidate="Ddl_Head"
                                SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="head"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="Ddl_Head" runat="server" CssClass="form-control">
                            </asp:DropDownList>            
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSearch_Report" runat="server" CssClass="btn btn-primary" Text="Search"
                                ValidationGroup="head" OnClick="BtnSearch_Report_Click" />
                        </div>
                    </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

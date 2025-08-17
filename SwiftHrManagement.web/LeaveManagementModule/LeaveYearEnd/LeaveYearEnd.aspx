<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="LeaveYearEnd.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveYearEnd.LeaveYearEnd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10 {
            width: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <asp:UpdatePanel ID="updatepanel1" runat="server">
      <ContentTemplate>
    <div class="form-group autocomplete-form">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    End Leave Year
                 </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                           <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>B.S. Year:</label>
                            <asp:TextBox ID="txtDefaultYear" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnEndYear" runat="server" Text="End Year" CssClass="btn btn-primary"
                            ValidationGroup="End" OnClick="BtnEndYear_Click" OnClientClick=" return confirm('Do you want to end year ?');" />
                        <asp:Button ID="BtnEndYearContract" runat="server" Text="End Year Contract" CssClass="btn btn-primary"
                            ValidationGroup="End" OnClick="BtnEndYearContract_Click" OnClientClick=" return confirm('Do you want to end year ?');" />
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnEndYearOther" runat="server" Text="End Year Other" CssClass="btn btn-primary"
                           ValidationGroup="End" OnClick="BtnEndYearOther_Click" OnClientClick=" return confirm('Do you want to end year ?');" />
                       <asp:Button ID="BtnChangeBSYear" runat="server" Text="Change B.S. Year" CssClass="btn btn-primary"
                           ValidationGroup="End" OnClick="BtnChangeBSYear_Click" OnClientClick=" return confirm('Do you want to change year ?');" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
      </ContentTemplate>
  </asp:UpdatePanel>                                                       
</asp:Content>

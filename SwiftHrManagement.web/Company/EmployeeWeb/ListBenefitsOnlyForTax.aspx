<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListBenefitsOnlyForTax.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListBenefitsOnlyForTax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:GridView ID="GdvBenefitList" runat="server" AutoGenerateColumns = "False" 
        Width="636px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name of Benefit" 
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField DataField="GlCode" HeaderText="Ledger Code"  
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>

            <asp:HyperLinkField 
                DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/Company/EmployeeWeb/ManageBenefitsForTax.aspx?ID={0}" 
                NavigateUrl="~/Company/EmployeeWeb/ManageBenefitsForTax.aspx?ID={0}"                             
                HeaderText="Edit Details"
                Text="Manage" 
                 HeaderStyle-HorizontalAlign ="Left" 
                 >
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:HyperLinkField>

        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>

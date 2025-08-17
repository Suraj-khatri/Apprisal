<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListBenefits.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListBenefits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:GridView ID="GdvBenefitList" runat="server" AutoGenerateColumns = "False" 
        Width="636px" CellPadding="4" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="BenefitName" HeaderText="Name of benefit" 
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="BenefitGroup" HeaderText="Group"  
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="GlCode" HeaderText="Ledger Code"  
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Occurrence" HeaderText="Occurrence"  
                HeaderStyle-HorizontalAlign ="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            <asp:HyperLinkField 
                DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/Company/EmployeeWeb/ManageBenefits.aspx?ID={0}" 
                NavigateUrl="~/Company/EmployeeWeb/ManageBenefits.aspx?ID={0}"                             
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



<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListContributionsMade.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListContributionsMade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
    <tr>
        <td valign="bottom" class="wellcome" align="left">
        <img src="/images/big_bullit.gif">&nbsp;&nbsp;Contribution Made Details View</td>
    </tr>
    <tr>
        <td valign="top" bgcolor="#999999" height="1"></td>
    </tr>
    <tr>
         <td align="center"><div class="addButton"><asp:HiddenField ID="hdnContributionId" runat="server" />
          
            <asp:ImageButton ID="ImgBtnAdd" runat="server" ImageUrl="~/Images/add.gif" 
                onclick="ImgBtnAdd_Click" Visible="False"/></div>
        </td>
    </tr>
    <tr>
        <td align=center>
                <asp:GridView ID="GvEmpContributions" runat="server"
                   AutoGenerateColumns="False"
                    CssClass="GView" CellPadding="5" 
                    GridLines="None" CellSpacing="1">
                    <Columns>
                       
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                        <asp:BoundField DataField="ContributionId" HeaderText="Contribution Id" 
                            Visible="False" />
                        <asp:BoundField DataField="ContributionCode" HeaderText="Contribution Code" />
                        <asp:BoundField DataField="Contributor" HeaderText="Contributor" />
                        <asp:BoundField DataField="ContributionAmount" HeaderText="Amount" />
                        <asp:BoundField DataField="ContributionDate" HeaderText="Date" />
                        <asp:BoundField DataField="ReceiptNumber" HeaderText="Receipt No." />
                        <asp:HyperLinkField 
                            Text=" &nbsp;View" DataNavigateUrlFields="Id" 
                            DataNavigateUrlFormatString="~/Company/EmployeeWeb/ManageContributionsMade.aspx?Id={0}" 
                            NavigateUrl="~/Company/EmployeeWeb/ManageContributionsMade.aspx?Id={0}" 
                            Visible="False" />
                    </Columns>
                    
                    <EmptyDataTemplate>
                    No Record Found !
                    </EmptyDataTemplate>
                    <HeaderStyle 
                    HorizontalAlign="Left" CssClass="HeaderStyle" BorderStyle="None" />
                    <AlternatingRowStyle BackColor="#F7F3F7" />
                </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

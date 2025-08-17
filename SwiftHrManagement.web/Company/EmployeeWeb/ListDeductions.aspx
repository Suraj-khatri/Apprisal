<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListDeductions.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ListDeductions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%">
    <tr>
        <td valign="bottom" class="wellcome" align="left">
        <img src="/images/big_bullit.gif">&nbsp;List Deductions 
           <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" bgcolor="#999999" height="1"></td>
    </tr>
    <tr> 
         <td align="center"><div class="addButton">
            <asp:HiddenField ID="hdnempid" runat="server" />
            <br />
            
            <asp:ImageButton ID="ImgBtnAdd" runat="server" ImageUrl="~/Images/add.gif" 
            onclick="ImgBtnAdd_Click"/></div>
        </td>
    </tr>
        <tr>
            <td align=center>
                <asp:GridView ID="GvEmpDeductions" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="GView" CellPadding="5" 
                    GridLines="None" CellSpacing="1">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="False" />
                                                
                        <asp:BoundField DataField="DeductionName" HeaderText="Heading" />
                        <asp:BoundField DataField="DeductionDate" HeaderText="Deduction Date" />
                        <asp:BoundField DataField="DeductionAmount" HeaderText ="Deduction Amount" />
                        <asp:BoundField DataField="Istaxable" HeaderText="Is Taxable" />
                        <asp:HyperLinkField DataNavigateUrlFields="ID" 
                            DataNavigateUrlFormatString="~/Company/EmployeeWeb/ManageDeductions.aspx?ID={0}" 
                            NavigateUrl="~/Company/EmployeeWeb/ManageDeductions.aspx?ID={0}"                             
                            
                            Text="View" />
                    </Columns>
              <EmptyDataTemplate>
                    No Record Found !
                    </EmptyDataTemplate>                 
                    <HeaderStyle 
                    HorizontalAlign="Left" CssClass="HeaderStyle" BorderStyle="None" />
                    <AlternatingRowStyle BackColor="#F7F3F7"/>
                </asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>

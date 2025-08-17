<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EditSalary.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.EditSalary" %>
<%@ Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" __designer:mapid="fb">
        <tr __designer:mapid="fc">
            <td valign="bottom" class="wellcome" align="left" __designer:mapid="fd">
                <img src="/images/big_bullit.gif" __designer:mapid="fe">&nbsp;&nbsp;Edit Salary Details</td>
        </tr>
        <tr __designer:mapid="ff">
            <td valign="top" bgcolor="#999999" height="1" __designer:mapid="100">
            </td>
        </tr>
        <tr __designer:mapid="101">
            <td __designer:mapid="102">
                &nbsp;</td>
        </tr>
        <tr __designer:mapid="103">
            <td align="center" __designer:mapid="104">
                <asp:GridView ID="GvprofileParam" runat="server" AutoGenerateColumns="False"
                CssClass="GView" CellPadding="5" GridLines="None" CellSpacing="1" 
                OnRowUpdating="GvprofileParam_RowUpdating" >
                    <Columns>
                        <asp:BoundField DataField="rowid" HeaderText="ID" Visible="false"/>
                        <asp:BoundField DataField="prf_name" HeaderText="Deduction/Addition Name" />
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:HiddenField ID="hddProfileId" runat="server" 
                                    Value ='<%# Bind("rowid") %>' />
                                <asp:TextBox ID="TxtParamValue" runat="server" CssClass="inputTextBoxLP" 
                        Text='<%# Bind("prf_value") %>' Width="30px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit/ Update" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Cancel" Visible="False"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                No Record Found !
                    </EmptyDataTemplate>
                    <HeaderStyle  CssClass="HeaderStyle" BorderStyle="None" />
                    <AlternatingRowStyle BackColor="#F7F3F7" />
                </asp:GridView>
    </table>
</asp:Content>

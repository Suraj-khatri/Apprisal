<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="FiscalMonthList.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.FiscalMonthList" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID = "UpPnlFiscal" runat = "server">
    <ContentTemplate>
        <table width="100%">
        <tr>
            <td valign="bottom" class="wellcome" align="left">
                <img src="/images/big_bullit.gif">&nbsp;Fiscal Year Wise Month Settting</asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" bgcolor="#999999" height="1"></td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <div align="right" style="width: 800px; text-align: left;">
                    Fiscal Year<br />
                    <asp:DropDownList ID="DdlfiscalYear" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="DdlfiscalYear_SelectedIndexChanged">
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align=center>
                <asp:GridView ID="GvMonthList" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="GView" CellPadding="5" 
                    GridLines="None" CellSpacing="1"
                    onrowdatabound="GvMonthList_RowDataBound"
                    >
                    <Columns>
                        <asp:BoundField DataField="month_Number" HeaderText="Month Number"/>                        
                        <asp:BoundField DataField="Name" HeaderText="Month Name" />                                              
                        <asp:BoundField DataField="EngFrom" HeaderText="Eng From" />
                        <asp:BoundField DataField="EngTo" HeaderText="Eng To" />
                        <asp:BoundField DataField="NepFrom" HeaderText="Nep From" />
                        <asp:BoundField DataField="NepTo" HeaderText="Nep To" />                        
                        <asp:BoundField DataField="month_Number" HeaderText="" />  
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
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

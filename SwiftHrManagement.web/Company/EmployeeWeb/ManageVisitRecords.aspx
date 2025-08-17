<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageVisitRecords.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageVisitRecords" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 94%;
        }
        .style3
        {
        }
    .style4
    {
        text-align: left;
        }
    .style5
    {
        width: 502px;
    }
        .style7
        {
            text-align: left;
            height: 38px;
            width: 274px;
        }
        .style9
        {
            width: 502px;
            height: 38px;
        }
        .style10
        {
            width: 70px;
        }
        .style11
        {
            text-align: left;
            width: 70px;
        }
        .style12
        {
            text-align: left;
            height: 38px;
            width: 70px;
        }
        .style13
        {
            text-align: left;
            width: 274px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table class="style2">
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3" colspan="2">
                <span class="heading1">Employee Visit Record Detail</span> <hr />
            </td>
        </tr>
        <tr>
            <td class="style11">
                            &nbsp;</td>
            <td class="style4" colspan="2">
                            <div style="text-align: center; height: 13px; width: 450px">
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            </div>
            </td>
        </tr>
        <tr>
            <td class="style11">
                            &nbsp;</td>
            <td class="style13">
                            <asp:HiddenField ID="hdnempid" runat="server" 
                                />
            </td>
            <td class="style5">
                </td>
        </tr>
        <tr>
            <td class="style12">
                          &nbsp;&nbsp; &nbsp;</td>
            <td class="style7">
                          Visit Type:<br />
                          <asp:DropDownList ID="DdlVisitType" runat="server">
                              <asp:ListItem>National</asp:ListItem>
                              <asp:ListItem>International</asp:ListItem>
                          </asp:DropDownList>
            </td>
            <td class="style9">
                Country:<br />
                <asp:DropDownList ID="DdlCountry" runat="server">
                    <asp:ListItem>Nepal</asp:ListItem>
                    <asp:ListItem>PopulateCountryListHere</asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style12">
                          &nbsp;</td>
            <td class="style7">
                          Date From:<br />
                          <asp:TextBox ID="TxtDateFrom" runat="server"></asp:TextBox>
                          <cc1:CalendarExtender ID="TxtDateFrom_CalendarExtender" runat="server" 
                              Enabled="True" TargetControlID="TxtDateFrom">
                          </cc1:CalendarExtender>
            </td>
            <td class="style9">
                Date To:<br />
                          <asp:TextBox ID="TxtDateTo" runat="server"></asp:TextBox>
                          <cc1:CalendarExtender ID="TxtDateTo_CalendarExtender" runat="server" 
                              Enabled="True" TargetControlID="TxtDateTo">
                          </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style12">
                          &nbsp;</td>
            <td class="style7">
                          City:<br />
                          <asp:TextBox ID="TxtCity" runat="server"></asp:TextBox>
                          <br />
            </td>
            <td class="style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                          &nbsp;</td>
            <td class="style7">
                          Place:<br />
                          <asp:TextBox ID="TxtPlace" runat="server" Height="90px" TextMode="MultiLine" 
                              Width="277px"></asp:TextBox>
            </td>
            <td class="style9">
                Reason:<br />
                <asp:TextBox ID="TxtReason" runat="server" Height="90px" TextMode="MultiLine" 
                    Width="277px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style13">
                <br />
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" />
                <br />
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" ValidateRequest="false"  Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="shiftAttendanceSetup.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.shiftAttendanceSetup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <cc1:tabcontainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="visoft__tab_xpie7">
            
    <cc1:TabPanel runat="server" HeaderText="Attendance Shift Setup " ID="TabPanel1">
             <ContentTemplate>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                            <iframe src="/AttendenceWeb/shiftList.aspx" frameborder="0" height="1000px" width="100%"> </iframe>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </ContentTemplate>        
    </cc1:TabPanel>        

    <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText=" Attendance Group Setup ">
                <ContentTemplate>
                <asp:UpdatePanel ID="updatePanel10" runat="server">
                            <ContentTemplate>
                       <iframe src="/AttendenceWeb/groupList.aspx" frameborder="0" height="1000px" width="100%" > </iframe>
                    </ContentTemplate>
                        </asp:UpdatePanel>
                </ContentTemplate>        
    </cc1:TabPanel>
        
    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText=" Weekly Schedule Setup ">
        <ContentTemplate>
            <asp:UpdatePanel ID="updatePanel4" runat="server">
                <ContentTemplate>
                    <iframe src="/AttendenceWeb/weeklyScheduleList.aspx" frameborder="0" height="1000px" width="100%" > </iframe>            
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>        
    </cc1:TabPanel>

    </cc1:tabcontainer>

</asp:Content>

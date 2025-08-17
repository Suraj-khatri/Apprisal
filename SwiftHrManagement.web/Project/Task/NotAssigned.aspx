<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="NotAssigned.aspx.cs" Inherits="SwiftHrManagement.web.Project.Task.NotAssigned" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <table width="100%">
    <tr>
        <td valign="bottom" class="taskHeading" align="left">
        <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;View Not Assign Task</td>
    </tr>
    <tr>
        <td valign="top" bgcolor="#8DB0E2" height="1"></td>
    </tr>
    <tr> 
        <td align="center">        
            <table align="center"> 
                <tr>
                    <td align="Center"><b>Filter</b>
                        <asp:ImageButton ID="ImgHideFilter" runat="server" 
                                    ImageUrl="~/Images/icon_hide.gif" 
                                    Visible="False" onclick="ImgHideFilter_Click"/>
                        <asp:ImageButton ID="ImgShowFilter" runat="server" 
                                ImageUrl="~/Images/icon_show.gif" onclick="ImgShowFilter_Click" />              
                        <br /> <br />
                        <asp:Panel ID="pnlSearch" runat="server" Visible="False">
                            <table>
                            <tr>
                                <td align="right">Start Date:</td>                                                                          
                                <td style="text-align: left">
                                    <asp:TextBox ID="TxtStartDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                   
                                    <cc1:CalendarExtender ID="TxtStartDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtStartDate">
                                    </cc1:CalendarExtender>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="right">End Date:</td>
                                <td style="text-align: left">                                           
                                    <asp:TextBox ID="TxtEndDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                    
                                    <cc1:CalendarExtender ID="TxtEndDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtEndDate">
                                    </cc1:CalendarExtender>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Project Title:</td>
                                <td style="text-align: left">  
                                    <asp:TextBox ID="TxtPTitle" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td style="text-align: left">
                                   <asp:Button ID="BtnFilter" runat="server" CssClass="button" 
                                        onclick="BtnFilter_Click" Text="Filter" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>     
            <div style="text-align: right; width: 800px;">
                <asp:ImageButton ID="ImgAddCompInfo" runat="server" ImageUrl="~/Images/add.gif" 
             onclick="ImgAddCompInfo_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;</div>
        </td>
    </tr>
    <tr>
         <td align=center>           
            <asp:GridView ID="GdvTaskList" runat="server"
                AutoGenerateColumns="False"
                CssClass="taskGView" CellPadding="5" 
                GridLines="None" CellSpacing="1">
                        
                        <Columns>                          
                            <asp:BoundField DataField="Title" HeaderText="Task Title" />
                            <asp:BoundField DataField="ASSIGNBY" HeaderText="Assigned By" />
                            <asp:BoundField DataField="REPORTTO" HeaderText="Reported To" />
                            <asp:BoundField DataField="START_DATE" HeaderText="Start Date" />
                            <asp:BoundField DataField="END_DATE" HeaderText="End Date" />                            
                            <asp:BoundField DataField="PRIORITY" HeaderText="Priority" />                          
                            <asp:HyperLinkField DataNavigateUrlFields="TASK_ID" 
                                DataNavigateUrlFormatString="~/Project/Task/AssignTask/Manage.aspx?TASK_ID={0}" 
                                NavigateUrl="~/Project/Task/AssignTask/Manage.aspx?TASK_ID={0}" 
                                Text="Assign Task" />
                            <asp:HyperLinkField DataNavigateUrlFields="TASK_ID" 
                                DataNavigateUrlFormatString="~/Project/List.aspx?TASK_ID={0}" 
                                NavigateUrl="~/Project/List.aspx?TASK_ID={0}" Text="View Task" />
                            <asp:HyperLinkField DataNavigateUrlFields="TASK_ID" 
                            DataNavigateUrlFormatString="~/Project/Task/Manage.aspx?TASK_ID={0}" 
                            NavigateUrl="~/Project/Task/Manage.aspx?TASK_ID={0}" Text="View" />
                        </Columns>
                        
                 <EmptyDataTemplate>
                    No Record Found !
                    </EmptyDataTemplate>
                    <HeaderStyle 
                    HorizontalAlign="Left" CssClass="taskGridHeader" BorderStyle="None" />
                    <AlternatingRowStyle BackColor="#F7F3F7" />
            </asp:GridView>
        </td>
    </tr>  
</table>
</asp:Content>

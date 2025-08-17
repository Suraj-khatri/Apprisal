<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMasterPage.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.Project.Task.AssignTask.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:GridView ID="GvAssignTask" runat="server" AutoGenerateColumns="False" 
                                  CssClass="Gr" Height="16px" Width="247px">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Id" />
            <asp:BoundField DataField="FNAME" HeaderText="Name" />
            <asp:BoundField DataField="TASK_ID" HeaderText="TASK" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/Project/Task/AssignTask/List.aspx?ID={0}" 
                NavigateUrl="~/Project/Task/AssignTask/List.aspx?ID={0}" Text="View" />
        </Columns>
        <HeaderStyle HorizontalAlign="Left" CssClass ="GridHeader1" />
    </asp:GridView>
</asp:Content>

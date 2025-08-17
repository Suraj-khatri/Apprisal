<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left.ascx.cs" Inherits="ElectronicRechargeSystems.Web.UserControl.Left" %>
 <asp:treeview ID="TreeView1" ForeColor="White" 
    DataSourceId="SiteMapDataSource1" NodeStyle-ChildNodesPadding="10" 
    runat="server" ImageSet="WindowsHelp" Width="154px" >
              <ParentNodeStyle Font-Bold="False" />
              <LevelStyles>
                <asp:TreeNodeStyle Font-Size="13px" Font-Bold="true"/>
                <asp:TreeNodeStyle />
                <asp:TreeNodeStyle Font-Size="13px"/>
              </LevelStyles>
              <nodestyle Font-Size="8pt" forecolor="black" Font-Bold="true" 
                  HorizontalPadding="5px" Font-Names="Tahoma" NodeSpacing="0px" 
                  VerticalPadding="1px"/>
              <SelectedNodeStyle backcolor="#B5B5B5" Font-Underline="False" 
                  HorizontalPadding="0px" VerticalPadding="0px"  />
              <HoverNodeStyle Font-UnderLine="True" ForeColor="#6666AA" />
            </asp:treeview>
      <asp:sitemapdatasource id="SiteMapDataSource1" runat="server" />

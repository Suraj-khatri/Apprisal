<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.OrganoChart.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
function changecolorslowly(){

if(w>200){w=20;return;}
w=w+20;p="r";
e=document.getElementById("r");
e.style.width = w + 'px';
e.style.backgroundColor = 'blue';
t=setTimeout("changecolorslowly();",0);
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

 <table width="100%">
        <tr>
            
            <td valign="bottom" class="wellcome" align="left" colspan="2"><img src="/images/big_bullit.gif">&nbsp;Organization Chart</td>
        </tr>
        <tr>
            
            <td valign="top" bgcolor="#999999" height="1" colspan="2"></td>
        </tr>
        <tr>            
            <td colspan="2">&nbsp;</td>
        </tr>
         <tr>            
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td width="10%">&nbsp;</td>
            <td>
                
<div class="treeViewContainer">
    <asp:TreeView ID="TVChart" runat="server" ExpandDepth="0" 
        onselectednodechanged="TVChart_SelectedNodeChanged" 
        OnTreeNodePopulate="TVChart_TreeNodePopulate" 
        LineImagesFolder="~/TreeLineImages">
        <ParentNodeStyle HorizontalPadding="40px" />
        <LeafNodeStyle HorizontalPadding="80px" />
    </asp:TreeView>
</div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align=center>&nbsp;</td>
        </tr>
    </table>



</asp:Content>

<%--
<asp:TreeView ID="DestinationTree" runat="server"  CssClass="destinationsTree" ExpandDepth="1" 
 onselectednodechanged="DestinationTree_SelectedNodeChanged" 
 ontreenodeexpanded="DestinationTree_TreeNodeExpanded" ShowLines="True" 
 Font-Names="&quot;Segoe UI&quot;,Frutiger,Tahoma,Helvetica,&quot;Helvetica Neue&quot;,Arial,sans-serif">
 <ParentNodeStyle Font-Bold="False" />
 <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
 <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
 <Nodes>--%>
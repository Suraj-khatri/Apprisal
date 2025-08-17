<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManualBenefit_Deduction.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.ManualBenefit_Deduction" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script language="javascript">
        function popupDiv(me) {
            if (me.value == "m") {
                document.getElementById("divSearch").style.display = "block";
            }
            else {
                document.getElementById("divSearch").style.display = "none";
            }
        }
    
        function checkAll(me, ctl) {
            var checkBoxes = document.forms[0].chkEmployee;
            var boolChecked = me.checked;

            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = boolChecked;
            }
        }    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Manual 
                            Addition-Deduction</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Manual Addition-Deduction</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

    <div style="text-align:left;">
        <table>
            <tr>
                 <td class="textformat" nowrap="nowrap">Fiscal Year :</td>
                <td><asp:DropDownList ID="ddlFiscalYear" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>            
            </tr>
            <tr>
                <td class="textformat" nowrap="nowrap">Month :</td>
                 <td>   <asp:DropDownList ID="ddlMonth" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>            
            </tr>
            <tr>
                <td class="textformat" nowrap="nowrap">Salary Item :</td>
                 <td>   <asp:DropDownList ID="ddlSalaryItem" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>            
            </tr>
            <tr>
                <td class="textformat" nowrap="nowrap">Amount :</td>
                <td>    <asp:TextBox ID="txtAmount" runat="server" CssClass="inputTextBoxLP"></asp:TextBox> 
                    <cc1:FilteredTextBoxExtender ID="txtAmount_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtAmount">
                    </cc1:FilteredTextBoxExtender>
                </td>            
            </tr>
            <tr>
                <td class="textformat" nowrap="nowrap">Type:</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="CMBDesign">
                        <asp:ListItem Value="a">Benefit</asp:ListItem>
                        <asp:ListItem Value="d">Deduction</asp:ListItem>
                    </asp:DropDownList>
                </td>            
            </tr>        
            <tr>
                <td class="textformat" nowrap="nowrap">Apply To :</td>
                <td>
                    <asp:DropDownList ID="ddlApplyTo" runat="server" onChange="popupDiv(this);" 
                        Height="25px" CssClass="CMBDesign" 
                        onselectedindexchanged="ddlApplyTo_SelectedIndexChanged">
                        <asp:ListItem Value="a">All</asp:ListItem>
                        <asp:ListItem Value="m">Let me select</asp:ListItem>
                    </asp:DropDownList>
                </td>            
            </tr>
            
            
            <tr>     
                <td class="textformat">
                    <div id="divSearch" style="border:solid 1 red;display:none;">
                        <asp:UpdatePanel ID="upd1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" RenderMode="Inline">
                            <ContentTemplate>
                                <table style="border: thin solid #C0C0C0">
                                    <tr>
                                        <th>Search Criteria</th>            
                                        <th>Enter some text</th>   
                                        <th></th>   
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlSearchCriteria" runat="server">
                                                <asp:ListItem Value="e">Employee</asp:ListItem>
                                                <asp:ListItem Value="d">Department</asp:ListItem>
                                                <asp:ListItem Value="p">Post</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> 
                                         </td>
                                         <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
                                        </td>            
                                    </tr>   
                                </table> 
                                <div><font color="blue">Search Result</font></div>           
                                <div style="border: thin solid #C0C0C0; text-align:left;">
                                    <asp:Table ID="tblResult" runat="server"></asp:Table>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="click" />
                            </Triggers>
                        </asp:UpdatePanel>        
                    </div>                
                </td>
            </tr>  
            <tr>
            <td>&nbsp;</td>
                <td style="text-align: left"><asp:Button ID="btnSave" runat="server" 
                        Text="Save" onclick="btnSave_Click" CssClass="button" /></td>
            </tr>          
        </table>
        <br />           
        <br />        
    </div>
   
<!--################ START FORM STYLE-->
	</td>
    <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
</asp:Content>

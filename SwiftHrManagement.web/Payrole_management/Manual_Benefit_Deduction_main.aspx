<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manual_Benefit_Deduction_main.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.Manual_Benefit_Deduction_main" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script language="javascript">
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;            

            for (i = 0; i < checkBoxes.length; i++){             
                checkBoxes[i].checked = boolChecked ;               
            }
        }    
    </script>
    <style type="text/css">
        .style10
        {
            text-align: left;
        }
    </style>
    </asp:Content>
 
 
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top">
		        <table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		          <tr> 
			        <td valign="top">
				        <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					        <tr>
						        <td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Manual 
                                    Addition Deduction</td>
					        </tr>
					        <tr>
						        <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					        </tr>
				        </table>
				        <table width="99%" border="0" cellspacing="0" cellpadding="0">
					        <tr>
						        <td valign="top" align="center"><br>

						        <!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="" border="0" cellpadding="0" cellspacing="0" width="40px">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Manual Addition Deduction</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content1">
        
<!--################ END FORM STYLE-->
   <asp:UpdatePanel ID="updSearch" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
    <div style="text-align:left;">
        <table align="center">           
                <tr> 
                    <td align="center"><b>Filter</b>
                           <asp:ImageButton ID="ImgBtnHide" runat="server" 
                                    ImageUrl="~/Images/icon_hide.gif" onclick="ImgBtnHide_Click" 
                                    Visible="False"/>
                            <asp:ImageButton ID="ImgBtnShow" runat="server" 
                                    ImageUrl="~/Images/icon_show.gif" onclick="ImgBtnShow_Click" />
                            <br /> <br />
                            <asp:Panel ID="PnlSearch" runat="server" Visible="False" Width="220px">
                                <table >
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td > 
                                            Fiscal Year<br />
                                            <asp:DropDownList ID="ddlFiscalYear" runat="server" CssClass="CMBDesign">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td class="style10">Month<br />
                                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="CMBDesign">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>   
                                    </tr __designer:mapid="6e">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td >
                                            Salary Item<br />
                                            <asp:DropDownList ID="ddlSalaryItem" runat="server" CssClass="CMBDesign">
                                            </asp:DropDownList>
                                        </td>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td >
                                                Type<br />
                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="CMBDesign">
                                                    <asp:ListItem Value="Null">&lt;ALL&gt;</asp:ListItem>
                                                    <asp:ListItem Value="'a'">Benefit</asp:ListItem>
                                                    <asp:ListItem Value="'d'">Deduction</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td >
                                                <asp:Button ID="BtnFilter" runat="server" CssClass="button" 
                                                    onclick="BtnFilter_Click" Text="Filter" />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>   
                                </tr>
                                </table>
                            </asp:Panel>
                    </td>        
                </tr>
            </table> 
        
                <table>                         
                    <tr>
                        <th>Search Criteria</th>            
                        <th>Enter some text</th>   
                        <th></th>   
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSearchCriteria" runat="server" CssClass="CMBDesign">
                                <asp:ListItem Value="e">Employee</asp:ListItem>
                                <asp:ListItem Value="d">Department</asp:ListItem>
                                <asp:ListItem Value="p">Post</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="inputTextBoxLP"></asp:TextBox> 
                         </td>
                         <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
                        </td>            
                    </tr>
                </table>
                <table>   
                    <tr>
                        <td>
                            <div><font color="blue">Search Result</font></div>           
                            <div style="border: thin solid #C0C0C0; text-align:left;">
                                <asp:Table ID="tblResult" runat="server"></asp:Table>
                            </div>
                        </td>
                    </tr>  
                    <tr>
                        <td align="right">
                            <asp:Button ID= "btnDelete" Text="Delete" runat="server" 
                                onclick="btnDelete_Click" />
                            
                            <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm to delete??" Enabled="True" TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                            
                        </td>          
                    </tr>
                </table>
           </ContentTemplate>                        
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="click" />
            </Triggers>
        </asp:UpdatePanel>              
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

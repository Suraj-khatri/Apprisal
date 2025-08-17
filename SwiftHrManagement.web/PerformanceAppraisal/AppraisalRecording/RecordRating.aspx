<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RecordRating.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalRecording.RecordRating" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/listBoxMovement.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
             <td valign="top">
		            <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		              <tr> 
			            <td valign="top">
				            <table width="100%" border="0" cellspacing="0" cellpadding="0">
					            <tr>
						            <td class="wellcome"><img src="/images/big_bullit.gif">Record Appraisal Rating</td>
					            </tr>
					            <tr>
						            <td valign="top" bgcolor="#999999" height="1"></td>
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
    <td width="91%" class="container_tmid"><div>Record Appraisal Rating</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">

    <table width="700" border="0" cellspacing="2" cellpadding="2" class="container">    
    <tr>
        <td colspan="4"><strong><div align="center"> <asp:Label ID="lblMsgDis" runat="server" CssClass="txtlbl"></asp:Label></div></strong></td>
    </tr>
    <tr>
        <td><div class="txtlbl">Fiscal Year:</div></td>
        <td><asp:DropDownList ID="fiscalYear" runat="server" CssClass="CMBDesign"></asp:DropDownList><span class="required">*</span>  
        <asp:RequiredFieldValidator  ID="RFVGrade" runat="server" 
                    ControlToValidate="fiscalYear" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>          
        </td>
        <td><div class="txtlbl">Appraisal Rating:</div></td>
        <td><asp:DropDownList ID="appraisalRating" runat="server" CssClass="CMBDesign"></asp:DropDownList><span class="required">*</span>
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="appraisalRating" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="4"><span class="wellcome1"> Search By</span></td>
    </tr>
    <tr>
        <td><div class="txtlbl">Branch:</div></td>
        <td><asp:DropDownList ID="branch" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" onselectedindexchanged="branch_SelectedIndexChanged"></asp:DropDownList></td>
        <td><div class="txtlbl">Department:</div></td>
        <td><asp:DropDownList ID="department" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" onselectedindexchanged="department_SelectedIndexChanged"></asp:DropDownList></td>
    </tr>
    <tr>
        <td><div class="txtlbl">Position:</div></td>
        <td><asp:DropDownList ID="position" runat="server" CssClass="CMBDesign"></asp:DropDownList></td>
        <td><div class="txtlbl">Salary Title:</div></td>
        <td><asp:DropDownList ID="salaryTitle" runat="server" CssClass="CMBDesign"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td><asp:Button ID="btnSearch" runat="server" CssClass="button" 
                onclick="btnSearch_Click" Text="Search" ValidationGroup="GRADE"></asp:Button> </td>
    </tr>
    <tr>
        <td colspan="4">
            <table>
                    <tr>
                        <td><div class="txtlbl">Unassigned Employee List</div></td>
                        <td>&nbsp;</td>
                        <td><div class="txtlbl">Employee To Be Assigned List</div></td>
                    </tr>
                    <tr>
                        <td>	
                            <asp:DropDownList ID="DdlUnassigned" runat="server" CssClass="CMBDesign" size="30" 
                                multiple="multiple" Width="300px" onselectedindexchanged="DdlUnassigned_SelectedIndexChanged">
                            </asp:DropDownList>
	                        
                        </td>
                        <td><div align="center" class="button" onclick=" return  listbox_moveacross('<%=DdlUnassigned.ClientID %>', '<%=Ddlassigned.ClientID %>');">&gt;&gt;</div><br><br></td>
                        <td>
                                <asp:DropDownList ID="Ddlassigned" runat="server" CssClass="CMBDesign" size="30" multiple="multiple" 
                                Width="300px" onselectedindexchanged="Ddlassigned_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><div align="center"  class="button" onclick="listbox_selectall('<%=DdlUnassigned.ClientID %>', true)" style="width:65px;">Select All </div>	</td>
                        <td>&nbsp;</td>
                        <td><div align="center"  class="button" onclick="listbox_selectall('<%=Ddlassigned.ClientID %>', true)" style="width:65px;">Select All </div></td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                                        onclick="BtnSave_Click" Text=" Search Detail" ValidationGroup="GRADE" />
                                    <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Save?" Enabled="True" 
                                        TargetControlID="BtnSave">
                                    </cc1:confirmbuttonextender>

                                    <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                                        onclick="BtnBack_Click" Text="&lt;&lt; Back" />
                            </td>
                    </tr>
                </table>
        </td>
    </tr>
</table>
   

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
<!--################ END FORM STYLE-->


	<!--		End  content	-->						
                                </td>
                            </tr>
                        </table>			
                    </td>
                </tr>
            </table>	
        </td>
    </tr>
</table>

</asp:Content>

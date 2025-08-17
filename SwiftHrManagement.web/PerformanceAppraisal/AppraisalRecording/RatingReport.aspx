<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RatingReport.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalRecording.RatingReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
						            <td class="wellcome"><img src="/images/big_bullit.gif"> Search Appraisal Rating</td>
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
    <td width="91%" class="container_tmid"><div> Search Appraisal Rating</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">

    <table width="450" border="0" cellspacing="2" cellpadding="2" class="container">    
    <tr>
        <td colspan="2"><strong><div align="center"> <asp:Label ID="lblMsgDis" runat="server" CssClass="txtlbl"></asp:Label></div></strong></td>
    </tr>
    <tr>
        <td><div class="text_form1"  align="right" >Fiscal Year:</div></td>
        <td><asp:DropDownList ID="fiscalYear" runat="server" CssClass="CMBDesign"></asp:DropDownList><span class="required">*</span>  
        <asp:RequiredFieldValidator  ID="RFVGrade" runat="server" 
                    ControlToValidate="fiscalYear" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="GRADE"> </asp:RequiredFieldValidator>          
        </td>
    </tr>
    <tr>
        <td><div align="right" class="text_form1" style="width:110px">Appraisal Rating :</div></td>
        <td>
            <asp:DropDownList ID="ddlRating" runat="server" CssClass="CMBDesign"  />
        </td>
    </tr> 
    <tr>
        <td><div align="right" class="text_form1" style="width:110px">Branch :</div></td>
        <td>
            <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlBranchName_SelectedIndexChanged"/>
        </td>
    </tr>  
    <tr>
        <td><div align="right" class="text_form1" style="width:110px">Department :</div></td>
        <td>
            <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign"  />
        </td>
    </tr> 
    <tr>
        <td></td>
        <td>
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                       Text="Search" ValidationGroup="GRADE" onclick="BtnSave_Click" />
            <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Save?" Enabled="True" 
                TargetControlID="BtnSave">
            </cc1:confirmbuttonextender>
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

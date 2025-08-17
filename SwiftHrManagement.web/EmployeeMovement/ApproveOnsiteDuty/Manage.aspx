<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.ApproveOnsiteDuty.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<head>

<script type="text/javascript" src="../../Jsfunc.js"></script>
</head>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top">   
		    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		        <tr> 
			        <td valign="top">
				        <table width="100%" border="0" cellspacing="0" cellpadding="0">
					        <tr>
						        <td valign="bottom" class="wellcome">
						        <img src="/images/spacer.gif" width="5" height="1">
						        <img src="/images/big_bullit.gif">&nbsp;Onsite Duty Record</td>
					        </tr>
					        <tr>
						        <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					        </tr>
				        </table>
				        <table width="80%" border="0" cellspacing="0" cellpadding="0">
					        <tr>
						        <td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
                                    <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
                                        <tbody>
                                            <tr>
                                                <td width="1%" class="container_tl"><div></div></td>
                                                <td width="91%" class="container_tmid"><div>Approve OnSite Duty </div></td>
                                                <td w   idth="8%" class="container_tr"><div></div></td>
                                            </tr>
                                            <tr>
                                                <td class="container_l"></td>
                                                <td class="container_content">
        
<!--################ END FORM STYLE-->


                                                    <table border="0" cellspacing="5" cellpadding="5" class="container">  

                                                        <tr>    
                                                            <td colspan="2">
                                                                <span class="txtlbl" >Please enter valid  data</span>
                                                                <span class="required" >(* Required fields)</span><br />
                                                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                                                <asp:HiddenField ID="HiddenEmpid" runat="server" />
                                                            </td>
                                                        </tr>
    
                                                        <tr>
                                                            <td nowrap="nowrap" colspan="2" class="txtlbl"><b> Employee Name :</b>
                                                               <asp:label ID="lblEmpId" runat="server"></asp:label>            
                                                            </td>
                                                        </tr>

                                                        <div id="divIsAdvance" runat="server">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div id="osdRpt" runat="server"></div>
                                                                </td>
                                                            </tr>
                                                        </div>
   
                                                        <tr>
                                                            <td nowrap="nowrap" colspan="2"><b>Approve By : </b>
                                                                <asp:Label ID="lblApproveBy" runat="server"></asp:Label>         
                                                            </td>  
                                                        </tr>
                                                        <tr>
                                                            <div id="approvedDate" runat="server">
                                                            <td nowrap="nowrap" colspan="2"><b>Approved Date :</b>
                                                                <asp:Label ID="lblApprovedDate" runat="server"></asp:Label>   
                                                            </td> 
                                                            </div> 
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" colspan="2"><b> Description :</b>
                                                                <asp:Label ID="lblDesc" runat="server" TextMode="MultiLine" Width="431px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td nowrap="nowrap" colspan="2"><b>Approved Remarks :</b>
                                                                <asp:Textbox ID="txtAppRemarks" runat="server" TextMode="MultiLine" Height="62px" 
                                                                 Rows="4" Width="431px"></asp:Textbox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="text-align: center">
                                                                <asp:Button ID="Btn_Approve" runat="server" CssClass="button" 
                                                                    Text="Approve"  ValidationGroup="onsiteduty" onclick="Btn_Approve_Click" />
                                                                <cc1:ConfirmButtonExtender ID="Btn_Approve_ConfirmButtonExtender" runat="server" 
                                                                ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="Btn_Approve">
                                                                </cc1:ConfirmButtonExtender>

                                                                <asp:Button ID="BtCancel" runat="server" CssClass="button" 
                                                                    Text="Cancel" onclick="BtCancel_Click" />
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                                                ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="BtCancel">
                                                                </cc1:ConfirmButtonExtender>
               
                                                                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                                                                    Text="&lt;&lt; Back" onclick="BtnBack_Click" />
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
<script language="javascript" type="text/javascript">

    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=HiddenEmpid.ClientID%>").value = customerValueArray[1];
    }
    </script>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApproveExtensonManage.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.ApproveExtension.ApproveExtensonManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript" language="javascript">

        function validation() {
            if (!window.Page_ClientValidate('riem'))
                return false;
        }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:HiddenField ID="hdnId" runat="server" />
 <table width1="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
			            <td valign="top">
				            <table width="100%" border="0" cellspacing="0" cellpadding="0">
					            <tr>
						            <td valign="bottom" class="wellcome">
						            <img src="/images/spacer.gif" width="5" height="1">
						            <img src="/images/big_bullit.gif">&nbsp;TADA Extention</td>
					            </tr>
					            <tr>
						            <td valign="top" bgcolor="#999999" height="1"></td>
					            </tr>
			                </table>
				            <table width="80%" border="0" cellspacing="0" cellpadding="0">
					            <tr>
						            <td valign="top" align="center"><br/>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->

                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="80%">
                                            <tr>
                                                <td width="1%" class="container_tl"><div></div></td>
                                                <td width="91%" class="container_tmid"><div>TADA Extention</div></td>
                                                <td width="8%" class="container_tr"><div></div></td>
                                            </tr>
      
                                            <td class="container_l"></td>
                                            <td class="container_content">
<!--################ END FORM STYLE-->
                                                <table border="0" cellspacing="5" cellpadding="5" class="container">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="5" cellspacing="5">
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="2"><b class="lbltada"><u>Employee Information </u> </b>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap" valign="bottom"><div align="right" class="txtlbl">Employee Name:</div></td>
                                                                    <td nowrap="nowrap"> 
                                                                        <asp:Label ID="LblEmpName" runat="server" CssClass="txtlbl" />
                                                                    </td>  
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Branch :</div></td>
                                                                    <td nowrap="nowrap" >
                                                                        <asp:Label ID="lblbranch" runat="server" Text="Label" />
                                                                    </td>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Department :</div></td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="lbldepartment" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Position :</div></td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="lblposition" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <b class="lbltada"><u>TADA Information </u></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">City :</div></td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="lblcity" runat="server" Text="Label" />
                                                                    </td>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Country :</div></td>
                                                                    <td   nowrap="nowrap">
                                                                        <asp:Label ID="lblcountry" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Reason for Travel :</div></td>
                                                                    <td nowrap="nowrap" >
                                                                        <asp:Label ID="lblreasontravel" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <div id="divtraveldate" runat="server" visible="true">
                                                                    <tr>
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">From Date:</div></td>
                                                                        <td >
                                                                            <asp:Label ID="lblfromdate" runat="server" Text="Label" />
                                                                        </td>
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">To Date:</div></td>
                                                                        <td>
                                                                            <asp:Label ID="lbltodate" runat="server" Text="Label" />
                                                                        </td>
                                                                    </tr>
                                                                </div>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Extension of Visit :</div></td>
                                                                    <td >
                                                                        <asp:Label ID="lblextension" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <div id="divIsExtVisit" runat="server" visible="false">
                                                                    <tr>           
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">From :</div></td>
                                                                        <td nowrap="nowrap">
                                                                                <asp:Label ID="lblextfrom" runat="server" Text="Label" />
                                                                        </td>
           
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">To :</div></td>
                                                                        <td nowrap="nowrap" >
                                                                            <asp:Label ID="lblextto" runat="server" Text="Label" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>                                        
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">City :</div></td>
                                                                        <td >
                                                                            <asp:Label ID="lblextcity" runat="server" Text="Label" />
                                                                        </td>
           
                                                                        <td nowrap="nowrap" class="style10"><div align="right" class="txtlbl">Country :</div></td>
                                                                        <td  nowrap="nowrap"  >
                                                                            <asp:Label ID="Lblextcountry" runat="server" Text="Label" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Leave Applied :</div></td>
                                                                        <td>
                                                                            <asp:Label ID="lblleaveaaplied" runat="server" Text="Label" />
                                                                        </td>
                                                                        <td nowrap="nowrap"><div align="right" class="txtlbl">No Of. Days:</div></td>
                                                                        <td >
                                                                            <asp:Label ID="lblremainingdays" runat="server" Text="Label" />
                                                                        </td>
                                                                    </tr>
                                                                </div>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Mode of Travel :</div></td>
                                                                    <td >
                                                                        <asp:Label ID="lblmode" runat="server" Text="Label" />
                                                                    </td>
        
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Accomodation :</div></td>
                                                                    <td >
                                                                        <asp:Label ID="lblaccomodation" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Transportation Arrangement :</div></td>
                                                                    <td>
                                                                        <asp:Label ID="lbltransportation" runat="server" Text="Label" />
                                                                    </td>
       
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Meal :</div></td>
                                                                    <td >
                                                                        <asp:Label ID="lblfooding" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <div id="divflightDetails" runat="server" Visible="false">
                                                                    <tr>
                                                                        <td></td> 
                                                                        <td colspan="2"><b class="lbltada"><u>Flight Information </u> </b></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <fieldset>
                                                                                <legend>Flight Details</legend>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Flight Date :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblFlightDate" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">From Place :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblFromPlace" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">To Place :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblToPlace" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Flight Time/Schedule :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblFlightTime" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                        </tr>   
                                                                                    </table>
                                                                            </fieldset>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <fieldset>
                                                                                <legend>Return Flight Details</legend>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Flight Date :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblReturnFlightDate" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">From Place :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblReturnFromPlace" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">To Place :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblReturnToPlace" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Flight Time/Schedule :</div></td>
                                                                                            <td nowrap="nowrap">
                                                                                                <asp:Label ID="lblReturnFlightTime" runat="server" Text="Label"></asp:Label>
                                                                                            </td>
                                                                                        </tr>   
                                                                                    </table>
                                                                            </fieldset>
                                                                        </td>
                                                                    </tr>
                                                                </div>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <b class="lbltada"><u>Other Information </u> </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap"><div align="right" class="txtlbl">Cash Advance Against TADA :</div></td>
                                                                    <td>
                                                                        <asp:Label ID="lblcashadvance" runat="server" Text="Label" />
                                                                    </td>
                                                                </tr>
                                                                <div id="divIsAdvance" runat="server" visible="false">
                                                                    <tr>
                                                                        <td>&nbsp;</td>
                                                                        <td colspan="2">
                                                                            <div id="rpt2" runat="server"></div>
                                                                        </td>
                                                                    </tr>
                                                                </div>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <b class="lbltada"><u>Authorised By</u></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td colspan="2">
                                                                        <div ID="rpt" runat="server"></div>
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <b class="lbltada"><u>Approve By</u></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td colspan="2">
                                                                        <div ID="rptApprove" runat="server"></div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td></td></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    <td>Remarks
                    </br>
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="550px"></asp:TextBox>
                            <span class="errormsg">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtRemarks" Display="Dynamic" ErrorMessage="Required!" 
                                            SetFocusOnError="True" ValidationGroup="reim" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnApprove" runat="server" CssClass="button" 
                                Text="Approve" Width="90" ValidationGroup="reim" OnClientClick="validation();"
                                onclick="btnApprove_Click" />&nbsp;
                        <asp:Button ID="btnReject" runat="server" CssClass="button" 
                                Text="Reject" Width="90"  ValidationGroup="reim"  onclick="btnReject_Click" OnClientClick="validation();" />&nbsp;
                        <asp:Button ID="btnBack" runat="server" CssClass="button" 
                                Text="Back" Width="90" onclick="btnBack_Click"/></td>
                    </tr>
                </table>

  
<!--################ START FORM STYLE-->

            </td>
            <td class="container_r"></td>
        </tr>
    </table>
    
</asp:Content>

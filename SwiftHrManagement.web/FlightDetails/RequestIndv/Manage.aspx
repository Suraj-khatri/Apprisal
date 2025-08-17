<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.FlightDetails.RequestIndv.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    
    <script type="text/javascript" language="javascript">

        function OnDelete(ID) {
            if (confirm("Are you sure to Delete this?")) {
                document.getElementById("<% =hdnAuthorisedBy.ClientID %>").value = ID;
                document.getElementById("<%=btnDeleteAuthorisation.ClientID %>").click();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <head>
        <style type="text/css">
          .display
          {
             display:none;
          }
          .display1
          {
              display:block;
           }
        </style>
        <script type="text/javascript" src="../../Jsfunc.js"></script>
    </head>
    <table width1="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
            </td>
            <asp:HiddenField ID="hdnID" runat="server" />
        </tr>
        <tr>
            <td valign="top">
		        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		            <tr> 
		                <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1">
                                        <img src="/images/big_bullit.gif">&nbsp;Flight Details Request Form
                                    </td>
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

                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
                                            <tr>
                                                <td width="1%" class="container_tl"><div></div></td>
                                                <td width="91%" class="container_tmid"><div>Flight Details Request Form</div></td>
                                                <td width="8%" class="container_tr"><div></div></td>
                                            </tr>
                                            <tr>  
                                                <td class="container_l"></td>
                                                <td class="container_content">
                                <!--################ END FORM STYLE-->
                                                    <asp:UpdatePanel runat="server" ID="pnl1">
                                                        <ContentTemplate>
                                                            <table border="0" cellspacing="2" cellpadding="2" class="container" >
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <span class="txtlbl" >Please enter valid  data!</span>
                                                                        <span class="required" > (* Required fields)</span><br />             
                                                                        <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"/>          
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <fieldset>
                                                                            <legend>Employee Information</legend>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td nowrap="nowrap" valign="bottom">
                                                                                            <div align="right" class="txtlbl">Employee Name:</div>
                                                                                        </td>
                                                                                        <td nowrap="nowrap" colspan="3">
                                                                                            <asp:Label ID="LblEmpName" runat="server" CssClass="txtlbl"/>
                                                                                            <br />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td nowrap="nowrap">
                                                                                            <div align="right" class="txtlbl">Branch :</div>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBranch" runat="server" 
                                                                                                Width="219px" ReadOnly="true"/>
                                                                                        </td>
                                                                                        <td nowrap="nowrap">
                                                                                            <div align="right" class="txtlbl">Department :</div>
                                                                                            </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDepartment" runat="server" 
                                                                                                Width="150px" ReadOnly="true"/>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td nowrap="nowrap">
                                                                                            <div align="right" class="txtlbl">Position :</div>
                                                                                        </td>
                                                                                        <td colspan="3">
                                                                                            <asp:Label ID="lblPosition" runat="server" 
                                                                                                Width="219px" ReadOnly="true"/>
                                                                                        </td>
                                                                                    </tr> 
                                                                                </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <fieldset>
                                                                            <legend>Flight Details</legend>
                                                                            <table>
                                                                                <tr>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">Flight Date :<span class="required">*</span>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <asp:RequiredFieldValidator ID="rfvFlightDate" runat="server" 
                                                                                            ControlToValidate="txtFlightDate" ErrorMessage="Required!" ValidationGroup="flight"
                                                                                            SetFocusOnError="True"/>
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtFlightDate" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" /> 
                                                                                        <cc1:CalendarExtender ID="ceFlightDate" runat="server" 
                                                                                            TargetControlID="txtFlightDate" />                 
                                                                                    </td>
                                                                                    <td nowrap="nowrap"><br />
                                                                                        <div align="right" class="txtlbl">From (Place) :<span class="required">*</span>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <asp:RequiredFieldValidator ID="rfvFrom" runat="server" 
                                                                                            ControlToValidate="txtFrom" ErrorMessage="Required!" ValidationGroup="flight"
                                                                                            SetFocusOnError="True"/>
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">To (Place) :<span class="required">*</span>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <asp:RequiredFieldValidator ID="rfvTo" runat="server" 
                                                                                            ControlToValidate="txtTo" ErrorMessage="Required!" ValidationGroup="flight"
                                                                                            SetFocusOnError="True"/>
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtTo" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">Flight Time/Schedule :<span class="required">*</span>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <asp:RequiredFieldValidator ID="rfvFlightTime" runat="server" 
                                                                                            ControlToValidate="txtFlightTime" ErrorMessage="Required!" ValidationGroup="flight"
                                                                                            SetFocusOnError="True"/>
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtFlightTime" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <fieldset>
                                                                            <legend>Return Flight Details</legend>
                                                                            <table>
                                                                                <tr>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">Flight Date :</div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtReturnFlightDate" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" /> 
                                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                                                            TargetControlID="txtReturnFlightDate" />                 
                                                                                    </td>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">From (Place) :
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtReturnFrom" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">To (Place) :
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtReturnTo" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                    <td nowrap="nowrap"><br />  
                                                                                        <div align="right" class="txtlbl">Flight Time/Schedule :
                                                                                        </div>
                                                                                    </td>
                                                                                    <td nowrap="nowrap" >
                                                                                        <br />
                                                                                        <asp:TextBox ID="txtReturnFlightTime" runat="server" CssClass="inputTextBoxLP1" 
                                                                                            Width="176px" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <fieldset>
                                                                            <legend>Purpose</legend>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox runat="server" ID="txtPurpose" CssClass="inputTextBoxLP1" 
                                                                                                TextMode="MultiLine" Width="500px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <fieldset>
                                                                            <legend>Approval Details :</legend>
                                                                            <table>
                                                                                <tr>
                                                                                    <td nowrap="nowrap">
                                                                                        <br />
                                                                                        <div align="right" class="txtlbl">Authorized By :<span class="required">*</span>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblAuthorisedBy" runat="server" Font-Bold="true"
                                                                                            Font-Size="13px" /><br />
                                                                                        <asp:TextBox ID="txtAuthorisedBy" runat="server" CssClass="inputTextBoxLP1"
                                                                                            Width="300px" AutoPostBack="true" />
                                                                                        <cc1:AutoCompleteExtender ID="aceAuthorisedBy" runat="server" 
                                                                                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                                                                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                                                                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                                                                                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtAuthorisedBy" />
                                                                                        <cc1:TextBoxWatermarkExtender ID="wmeEmpName" 
                                                                                            runat="server" Enabled="True" TargetControlID="txtAuthorisedBy" 
                                                                                            WatermarkCssClass="watermark" WatermarkText="Auto Complete" />
                                                                                        <asp:HiddenField ID="hdnAuthorisedBy" runat="server" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <br />
                                                                                        <asp:Button ID="btnAdd" runat="server" Width="50" CssClass="button" Text="Add" 
                                                                                            ValidationGroup="tada" onclick="btnAdd_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                    <td colspan="2">
                                                                                        <div id="rpt" runat="server">
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                                                                            onclick="BtnSave_Click" Text="Save" Width="50" ValidationGroup="tada" />
                                                                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                                                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave" />
                                                                        <asp:Button ID="BtnDelete" runat="server" Width="50" CssClass="button" 
                                                                            onclick="BtnDelete_Click" Text="Delete" />
                                                                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                                                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete" />
                                                                        <asp:Button ID="BtnBack" runat="server" Width="50" CssClass="button" 
                                                                            onclick="BtnBack_Click1" Text="Back" />
                                                                        <asp:Button ID="btnDeleteAuthorisation" runat="server" CssClass="button" 
                                                                            Text="" OnClick="btnDeleteAuthorisation_Click" style="display:none;" />
                                                                        <%--<asp:Button ID="btnDeleteCurrency" runat="server" CssClass="button"
                                                                            Text="" OnClick="btnDeleteCurrency_Click" style="display:none;" />--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
  
                                <!--################ START FORM STYLE-->

	                                                </td>
                                                    <td class="container_r"></td>
                                                </tr>
                                            <tr>
                                                <td class="container_bl"></td>
                                                <td class="container_bmid"></td>
                                                <td class="container_br"></td>
                                            </tr>
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
</asp:Content>

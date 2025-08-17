<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.Promotion.Probation.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
  .Nodisplay
  {
      display:none;
    
   }
   .display
   {
      display:block;
       }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
  

<head>
    <script type="text/javascript" src="../../../../Jsfunc.js"></script>
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
                                        <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Employee Type Confirmation- Promotion</td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1">
                                        <img src="/images/spacer.gif" width="100%" height="1"></td>
                                        
                                </tr>
                            </table>
                            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center">
                                        <br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
       <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
                 <tbody>
                         <tr>
                                                    <td width="1%" class="container_tl">
                                                        <div>
                                                        </div>
                                                    </td>
                                                    <td width="91%" class="container_tmid">
                                                        <div>
                                                           Manage Confirmation</div>
                                                    </td>
                                                    <td width="8%" class="container_tr">
                                                        <div>
                                                        </div>
                                                    </td>
                                                </tr>
                         <tr>
                                            <td class="container_l">
                                            </td>
                                            <td class="container_content">

<!--################ END FORM STYLE-->
        <asp:UpdatePanel runat="server" ID="Promotion">
        <ContentTemplate>
                          <table border="0" cellspacing="2" cellpadding="2" class="container">

                 
                          
                         
                            <tr>
                                <td class="style12" colspan="3">
                                    Plese enter valid data! <span class="required" >&nbsp;(* Required fields)</span><br /><br />
                                    <div style="height: 13px; width: 221px">
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                    </div>
                                   
                                </td>
                            </tr>

                            
                            <tr>

                                  <td  class="style10" style=" vertical-align:top;">
                                        <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
                                            <legend>Employee Info:</legend>
                                            <table border="0" cellpadding="4" cellspacing="4" width="99%">
                                                 <tr>
                                                     <td colspan="4">
                                                         Employee Name :
                                                         <asp:Label ID="lblEmpName" runat="server" Font-Bold="True" Font-Size="13px"></asp:Label>
                                                         <asp:HiddenField ID="hdnEmpName" runat="server" />
                                                         <br />
                                                         <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="on" 
                                                             AutoPostBack="true" Font-Size="X-Small" ontextchanged="txtEmployee_TextChanged" 
                                                             Width="580px"></asp:TextBox>
                                                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                                             CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                                             DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                                             MinimumPrefixLength="1" 
                                                             ServiceMethod="GetEmployeeListByNameORId" ServicePath="~/Autocomplete.asmx" 
                                                             TargetControlID="txtEmployee">
                                                         </cc1:AutoCompleteExtender>
                                                     </td>
                                                 </tr>
                                                

                                            <tr>
                                                <td nowrap="nowrap"><div align="right" class="">Employee Type</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DddlEmpType" runat="server" CssClass="CMBDesign" Width="150px">
                                                    </asp:DropDownList>         
                                                </td>
                                                 <td nowrap="nowrap"><div align="right" class="">Changed Employee Type</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlChangedEmpType" runat="server" CssClass="CMBDesign" Width="150px">
                                                    </asp:DropDownList>  
                                                    
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                                ControlToValidate="DdlChangedEmpType" Display="dynamic" 
                                                                                ErrorMessage="Required!" SetFocusOnError="True" 
                                                                                ValidationGroup="promotion"></asp:RequiredFieldValidator>       
                                                </td>
                                            </tr>
                                            <tr>
                                               <td nowrap="nowrap"><div align="right" class="">Effective Date</div></td>
                                                <td>
                                                   <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="inputTextBox" Width="150px"></asp:TextBox>  
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                    TargetControlID="txtEffectiveDate">
                                                    </cc1:CalendarExtender>     
                                                </td>
                                            </tr>

                                            </table>
                                         </fieldset>
                                    </td>

            
                                  
                                 </tr>

                                <tr>

                                  <td  class="style10" style=" vertical-align:top;">
                                        <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
                                            <legend>Employee Promotion Info:</legend>
                                                <table border="0" cellpadding="4" cellspacing="4" width="99%">
                                                   <tr>
                                                         <td colspan="4">
                                                           <div align="left">
                                                            <asp:RadioButtonList ID="radioEmpPromotionType" runat="server" 
                                                                   RepeatDirection="Horizontal"  AutoPostBack="true"
                                                                TextAlign="Right" 
                                                                   onselectedindexchanged="radioEmpPromotionType_SelectedIndexChanged">
                                                                <asp:ListItem Value="WP">With Promotion </asp:ListItem>
                                                                <asp:ListItem Value="OP">Without Promotion</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>

                                                        </td> 
                                                   </tr>

                                              <tr>
                                               <div runat="server" id="ShowHidePosition" visible="false">
                                                    <td nowrap="nowrap"><div align="right" class="">Current Position</div></td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlCurrentPosition" runat="server" CssClass="CMBDesign" 
                                                            Width="200px">
                                                        </asp:DropDownList>         
                                                    </td>
                                                     <td nowrap="nowrap"><div align="right" class="">Position</div></td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlPosition" runat="server" CssClass="CMBDesign"  AutoPostBack="true"
                                                            Width="200px" onselectedindexchanged="DdlPosition_SelectedIndexChanged">
                                                        </asp:DropDownList>         
                                                    </td>
                                                </div>
                                            </tr>

                                            <tr>
                                                <td nowrap="nowrap"><div align="right" class="">Salary Set</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlSalarySet" runat="server" CssClass="CMBDesign"  AutoPostBack="true"
                                                        Width="200px" onselectedindexchanged="DdlSalarySet_SelectedIndexChanged">
                                                    </asp:DropDownList>         
                                                </td>
                                              
                                            </tr>
                                            <tr>
                                              <td colspan="4">
                                               <table width="600px">
                                               <tr>
                                                 <td>
                                                    <div id="salarySet" runat="server"></div>
                                                 </td>
                                               </tr>
                                               

                                                </table>
                                              </td>
                                            </tr>
                                                  
                                                </table>
                                         </fieldset>
                                    </td>

            
                                  
                                 </tr>

                                    <tr>

                                  <td  class="style10" style=" vertical-align:top;">
                                        <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
                                            <legend>Employee Transfer Info:</legend>
                                                <table border="0" cellpadding="4" cellspacing="4" width="99%">
                                                   <tr>
                                                         <td colspan="4">
                                                           <div align="left">
                                                            <asp:RadioButtonList ID="radioTransferType" runat="server" 
                                                                   RepeatDirection="Horizontal"  AutoPostBack="true"
                                                                TextAlign="Right" 
                                                                   onselectedindexchanged="radioTransferType_SelectedIndexChanged" >
                                                                <asp:ListItem Value="WT">With Transfer </asp:ListItem>
                                                                <asp:ListItem Value="OT">Without Transfer</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>

                                                        </td> 
                                                   </tr>
                                  <div runat="server" id="showHideTransfer" visible="false">
                                              <tr>
                                                <td nowrap="nowrap"><div align="right" class="">From Branch</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlFromBranch" runat="server" CssClass="CMBDesign" AutoPostBack="true" 
                                                        Width="200px" onselectedindexchanged="DdlFromBranch_SelectedIndexChanged">
                                                    </asp:DropDownList>         
                                                </td>
                                                 <td nowrap="nowrap"><div align="right" class="">To Branch</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlToBranch" runat="server" CssClass="CMBDesign" AutoPostBack="true" 
                                                        Width="200px" onselectedindexchanged="DdlToBranch_SelectedIndexChanged">
                                                    </asp:DropDownList>         
                                                </td>
                                            </tr>

                                            <tr>
                                                <td nowrap="nowrap"><div align="right" class="">From Department</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlFromDept" runat="server" CssClass="CMBDesign" Width="200px">
                                                    </asp:DropDownList>         
                                                </td>
                                                <td nowrap="nowrap"><div align="right" class="">To Departmant</div></td>
                                                <td>
                                                    <asp:DropDownList ID="DdlToDept" runat="server" CssClass="CMBDesign" Width="200px">
                                                    </asp:DropDownList>         
                                                </td>
                                              
                                            </tr>
                        </div>
                                            <tr>
                                              <td colspan="4">
                                                <div id="Div1" runat="server"></div>
                                              </td>
                                            </tr>
                                                  
                                                </table>
                                         </fieldset>
                                    </td>

            
                                  
                                 </tr>


                

                         
                                 <tr>
                                        <td class="style12">
                                        &nbsp;&nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                                                            onclick="BtnSave_Click" ValidationGroup="promotion" />
                                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                        </cc1:ConfirmButtonExtender>
                                        &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" onclick="BtnDelete_Click" Visible="False" />
                                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                                        </cc1:ConfirmButtonExtender>

                                        <asp:Button ID="btnBack" runat="server" CssClass="button"  Text="&lt;&lt;Back" 
                                                onclick="btnBack_Click1" />
                                       
                                        </td>


                                 
                                    </tr>
     
                                    </table>
        </ContentTemplate>
        </asp:UpdatePanel>
<!--################ START FORM STYLE-->
                                            </td>
                                            <td class="container_r">
                                            </td>
                                        </tr>
                         <tr>
                                            <td class="container_bl">
                                            </td>
                                            <td class="container_bmid">
                                            </td>
                                            <td class="container_br">
                                            </td>
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
</asp:Content>

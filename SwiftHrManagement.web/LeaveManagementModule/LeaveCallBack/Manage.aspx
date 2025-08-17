<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveCallBack.Manage" %>

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
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1">
                                        <img src="/images/big_bullit.gif">
                                        &nbsp;&nbsp; Leave CallBack Details
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1">
                                        <img src="/images/spacer.gif" width="100%" height="1">
                                    </td>
                                </tr>
                            </table>
                            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                            <td valign="top" align="center"><br>
          <!--		Begin content	-->
<asp:UpdatePanel ID="CallBack" runat="server">
<ContentTemplate>

      <!--################ START FORM STYLE-->
  <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
      <tbody>
          <tr>
            <td width="1%" class="container_tl"><div></div></td>
            <td width="91%" class="container_tmid"><div> Leave call Back </div></td>
            <td width="8%" class="container_tr"><div></div></td>
          </tr>
          <tr>
            <td class="container_l"> </td>
            <td class="container_content">
        
 <!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container"> 

        <tr>
            <td class="style3" colspan="3">
                <span class="txtlbl">Please enter valid data!</span>
                <span class="required" >&nbsp; (* Required fields)</span>
                <br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        
         <tr>
          <td >
            <fieldset style="list-style:circle; list-style-type:circle;">
                <legend class="subheading">Employee Details:</legend> 
                <table border="0" cellspacing="5" cellpadding="5" class="container" width="100%">
                    <tr>
                        <td class="txtlbl" nowrap="nowrap"><div align="left">Employee :
                            <asp:Label ID="lblEmployeeName" runat="server" CssClass="txtlbl"></asp:Label> 
                            </div>  
                        </td> 
                        
                    </tr>
                </table>
            </fieldset>    
          </td>
        </tr>
        
        <tr>
          <td >
            <fieldset style="list-style:circle; list-style-type:circle;">
                <legend class="subheading">Approved Leave Details:</legend> 
                <table border="0" cellspacing="5" cellpadding="5" class="container" width="100%">
                    <tr>
                        <td class="txtlbl" nowrap="nowrap"><div align="left"> Leave Type : </div> 
                            <asp:DropDownList ID="DdlLeaveName" runat="server" CssClass="CMBDesign"></asp:DropDownList>    
                        </td> 
                         <td class="txtlbl" nowrap="nowrap"><div align="left" >From Date:</div>
                          <asp:TextBox ID="txtApprovedFrom" runat="server" CssClass="inputTextBoxLP" ></asp:TextBox>
                         </td>  
                    </tr>
                    <tr>
                         <td class="txtlbl"><div align="left">To Date  : </div> 
                            <asp:TextBox ID="txtApprovedTo" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                          </td>
                          <td class="txtlbl"><div align="left"> Approved Days  : </div>  
                             <asp:TextBox ID="txtApprovedDays" runat="server" CssClass="inputTextBoxLP" ></asp:TextBox>
                         </td> 
                    </tr>
                    
                </table>
            </fieldset>    
          </td>
        </tr>
        
        
        <tr>
        <td >
            <fieldset style="list-style:circle; list-style-type:circle;">
                <legend class="subheading">Call Back Leave Details:</legend> 
                <table border="0" cellspacing="5" cellpadding="5" class="container" width="100%">
                    <tr>
                        <td class="txtlbl"><div align="left">From Date : </div> 
                            <asp:TextBox ID="txtCallBackFrom" runat="server" CssClass="inputTextBoxLP" AutoPostBack="True" ontextchanged="txtCallBackFrom_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtCallBackFrom_CalendarExtender" runat="server" 
                                 Enabled="True" TargetControlID="txtCallBackFrom">
                            </cc1:CalendarExtender>   
                        </td> 
                         <td class="txtlbl"><div align="left">To Date  : </div> 
       
                            <asp:TextBox ID="txtCallBackTo" runat="server" CssClass="inputTextBoxLP" AutoPostBack="True" ontextchanged="txtCallBackTo_TextChanged"></asp:TextBox>              
                            <cc1:CalendarExtender ID="txtCallBackTo_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtCallBackTo">
                            </cc1:CalendarExtender>
                        </td> 
                    </tr>
                    <tr>
                        <td class="txtlbl"><div align="left"> Call Back Days : </div> 
                         <asp:TextBox ID="txtCallBackDays" runat="server" CssClass="inputTextBoxLP" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="txtlbl">&nbsp;</td>
                  </tr>
                </table>
            </fieldset>    
          </td>
    </tr>
        <tr>
            <td nowrap="nowrap">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                     ValidationGroup="LeaveType" Width="75px" onclick="BtnSave_Click" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                    &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    Text="&lt;&lt; Back" Width="75px" onclick="BtnBack_Click" />
            </td>
            <td>
                &nbsp;        
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
</ContentTemplate>
</asp:UpdatePanel>
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
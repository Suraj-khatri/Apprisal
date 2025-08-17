<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CEASetup.aspx.cs" Inherits="SwiftHrManagement.web.CEA.CEASetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-user"></i>
             CEA Amount Setup
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                             <div id="rptDiv" runat="server"></div>
                             <div class="alert alert-success">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text=" Save " 
                onclick="btnSave_Click"></asp:Button> 
                          
                            <asp:Label ID="lblMsg" runat="server" CssClass=""></asp:Label>
                               </div>
                             </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
    <%--<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
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
                                        &nbsp;&nbsp; CEA Amount Setup
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

      <!--################ START FORM STYLE-->
  <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
      <tbody>
          <tr>
            <td width="1%" class="container_tl"><div></div></td>
            <td width="91%" class="container_tmid"><div> CEA Amount Setup</div></td>
            <td width="8%" class="container_tr"><div></div></td>
          </tr>
          <tr>
            <td class="container_l"> </td>
            <td class="container_content">
        
 <!--################ END FORM STYLE-->
<asp:UpdatePanel ID="Panel1" runat="server">
<ContentTemplate>
 <table border="0" cellspacing="3" cellpadding="3" class="container">
    <tr>
        <td></td>
    </tr>
    <tr>
        <td>
            <div id="rptDiv" runat="server"></div>
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap"><asp:Button ID="btnSave" runat="server" CssClass="button" Text=" Save " 
                onclick="btnSave_Click"></asp:Button> <asp:Label ID="lblMsg" runat="server" CssClass="txtlbl"></asp:Label> </td>
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
    </table>--%>
</asp:Content>



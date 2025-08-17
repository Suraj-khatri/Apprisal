<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageNewRating.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.ManageNewRating" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
     <script language="javascript">
    function GiveData() {
        var value = document.getElementById("<%=ddlNewRating.ClientID %>").value;
        window.returnValue = value;
        window.close();
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sc1" runat="server">
    </asp:ScriptManager>
    
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<%--<td valign="bottom" class="wellcome">
					<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;User Add Details</td>--%>
					</tr>
					<tr>
						<%--<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>--%>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Rating Form</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 
        <table border="0" cellspacing="2" cellpadding="2" class="container">      
    <tr>
        <td>&nbsp;</td>        
        <td>
            <%--<span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!) </span><br />  --%>   
             <div style="text-align: center;">               
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </div>
        </td>            
    </tr>

    <tr> 
      <td nowrap="nowrap">
        <div align="right"> Old Rating:</div>
        
      </td>
      <td>
        <strong> <asp:Label ID="lblOldRating" runat="server"></asp:Label></strong>
      </td>
    </tr>
    <tr>
      <td nowrap="nowrap">
        <div align="right"> Comments:</div>
        
      </td>
      <td>
        <strong><asp:Label ID="lblComments" runat="server" style="text-align:justify;" Width="400px"></asp:Label></strong> 
      </td>     
        
    </tr>    
     <tr>
       <td nowrap="nowrap">
        <div align="right"> New Rating:</div>
        
      </td>
      <td>
        <asp:DropDownList ID="ddlNewRating" runat="server" CssClass="CMBDesign" Width="60px">
        </asp:DropDownList>
      </td>
    </tr>           
    
    <tr>
        <td>&nbsp;</td>
        <td>
           <input type="button" value="Save" onclick="GiveData();" class="button" />
           
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


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
    
    </form>
</body>
</html>

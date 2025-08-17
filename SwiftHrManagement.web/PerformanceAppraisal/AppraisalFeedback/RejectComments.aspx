<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RejectComments.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.RejectComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <script language="javascript">
     function GiveData() {
        var dataList = Array();
        dataList[0] = document.getElementById("<%=txtRemarks.ClientID %>").value;
        window.returnValue = dataList;
        window.close();
    }
</script>

    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    
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
						<td valign="top" align="center"><strong> <asp:Label ID="lblMsg" runat="server" style=" font-size:15px;"></asp:Label> </strong><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Rating Reject Form</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 
        <table border="0" cellspacing="2" cellpadding="2" class="container">      
             
    
    <tr>
       
        <td>
        <asp:TextBox ID="txtRemarks" runat="server" CssClass="inputTextBox" Width="300px" Height="150px" TextMode="MultiLine"></asp:TextBox>
        <br />
        
          <input type="button" value="OK" onclick="GiveData();" class="button" />
           
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
  <%--  <form id="form1" runat="server">
    <div>
    <textarea id = "inputbox"> </textarea> <br />
<input type="button" value="OK" onclick="GiveData();" />
    </div>
    </form>--%>
</body>
</html>

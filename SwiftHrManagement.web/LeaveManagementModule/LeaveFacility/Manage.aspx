<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.LeaveFacility.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function checknumber(obj) {

            var x = obj;

            x = x.replace(",", "");
            x = x.replace(",", "");
            x = x.replace(",", "");
            x = x.replace(",", "");
            x = x.replace(",", "");

            if (x == '') {
                return false;
            }

            var anum = /(^\d+$)|(^\d+\.\d{1,10}$)/;

            if (anum.test(x)) {
                return true;
            }
            else {

                alert("Please input a valid number!");
                field2focus = obj;
                setTimeout('focusField()', 10);
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>

    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <style type="text/css">
        .clickImage
        {
            cursor:pointer;
        }
    </style>

    <script type="text/javascript">

        function SearchEmp() {
            var branchId = document.getElementById("<%=ddlBranch.ClientID%>").value;
            var postId = document.getElementById("<%=ddlPosition.ClientID%>").value;
            if (branchId == "" && postId == "") {
                alert("Select the required data!");
                return;
            }
            var empId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            var URL = "/LeaveManagementModule/LeaveFacility/ListEmployee.aspx?BranchId=" + branchId + "&postId=" + postId + "&EmpId=" + empId;
            GB_show("", URL, 390, 850);
        }

        function AddPage() {
            
           // Response.Redirect("~/LeaveManagementModule/LeaveAssignment/Manage.aspx");
        }

        function UpdateTable(ID) {
            var branchId = document.getElementById("<%=ddlBranch.ClientID%>").value;
            var postId = document.getElementById("<%=ddlPosition.ClientID%>").value;
            if (branchId == "" && postId == "") {
                alert("Select the required data!");
                return;
            }
            document.getElementById("<% =hdnLeaveID.ClientID %>").value = ID;
            document.getElementById("<% =BtnInsert.ClientID %>").click();
     }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px;">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Global Leave Update</td>
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
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div> Global Leave Update </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="7" cellpadding="7" class="container">  
    <tr>
        <td colspan="2">
            <div id="divMsg" runat="server"></div>
            <asp:HiddenField ID="hdnLeaveID" runat="server" />
        </td>
    </tr>
    <tr>
        <td><div align="right" class="label">Branch :</div></td>
        <td align="left">
            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="FltCMBDesign" AutoPostBack="true" 
                Width="200px" onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>&nbsp;<span class="required">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Required!" ControlToValidate="ddlBranch" Display="Dynamic" 
                SetFocusOnError="True" ValidationGroup="Search"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
            <td><div align="right" class="label">Position :</div></td>
            <td align="left">
                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="FltCMBDesign" AutoPostBack="true" 
                    Width="200px" onselectedindexchanged="ddlPosition_SelectedIndexChanged"></asp:DropDownList>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="ddlPosition" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="Search"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="label">Employee :</div></td>
            <td align="left">
                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="FltCMBDesign" Width="200px"></asp:DropDownList>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="left">
                <input  type="button" value="Search" onclick="SearchEmp()" class="button" validationgroup="Search" style="width:60px;" />
                <asp:Button ID="BtnInsert" runat="server" Text="" style="display:none;" onclick="BtnInsert_Click" />  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right" class="text_form"><strong><font size="+1">
                <a href="/LeaveManagementModule/LeaveAssignment/Manage.aspx" class="clickImage">Add New</a></font></strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="rptLeaveType" runat="server"></div>
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
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.DocumentSetupTracking.Manage" Title="Swift HR Management System 1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../../ajax_func.js"></script>
<script type="text/javascript" language="javascript">

    function doInsert(jobid, rowid) {

        var docindex = document.getElementById("DoctypeCode_" + rowid);
        var selected_doc = docindex.options[docindex.selectedIndex].value;
        
        if (selected_doc == 0) {
            alert("NO Documnet selected,\nPlease Select Document");
            return;
        }           
        if (!confirm("Are you sure, you want to add?")) {return; }

        var activeindex = document.getElementById("Activeflag_" + rowid);
        var selected_active = activeindex.options[activeindex.selectedIndex].value;
          
        var query = "Exec proc_SetloanDocs @flag='u',@JobTypeID='" + jobid + "',@rowid='" + rowid + "'";
        query = query + ",@docId='" + selected_doc + "'"
        + ",@active='" + selected_active + "'";

        var url = 'loansetupmanage.aspx?StrQry=' + query + '&jobID=' + jobid;
        exec_AJAX(url, "displayMsg", "");
    }

    function doUpdate(jobid, rowid) {
        if (!confirm("Are you sure, you want to update?")) { return; }
        var activeindex = document.getElementById("Activeflag_" + rowid);
        var selected_active = activeindex.options[activeindex.selectedIndex].value;

        var query = "Exec proc_SetloanDocs @flag='u',@JobTypeID='" + jobid + "',@rowid='" + rowid + "'";
        + ",@active='" + selected_active + "'";
        var url = 'loansetupmanage.aspx?StrQry=' + query;
        exec_AJAX(url, "displayMsg", "");
    }
    function doDelete(jobid) {
        if (!confirm("Are you sure, you want to delete?")) { return; }
        var rowid = '';

        var e = document.aspnetForm.elements.length;
        var cnt = 0;
        for (cnt = 0; cnt < e; cnt++) {
            if (document.aspnetForm.elements[cnt].name == "chkDel" && document.aspnetForm.elements[cnt].checked) {
                rowid = rowid + ',' + (document.aspnetForm.elements[cnt].value);
            }
        }

        var query = "Exec proc_SetloanDocs @flag='d',@JobTypeID='" + jobid + "',@rowid='" + rowid + "'";
        
        var url = 'loansetupmanage.aspx?StrQry=' + query;
        exec_AJAX(url, "displayMsg", "");
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
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="bottom" class="wellcome">
                                    <img src="/images/spacer.gif" width="5" height="1">
                                    <img src="/images/big_bullit.gif">
                                    &nbsp;&nbsp; Document Setup For Category - <asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
                            </tr>
                        </table>
                        <table width="85%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" align="center">


<table width="100%" align="center"  >
    <tr>
        <td><div id="displayMsg"><div id="displayArea" runat="server"></div></div></td>
    </tr>    
</table>

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

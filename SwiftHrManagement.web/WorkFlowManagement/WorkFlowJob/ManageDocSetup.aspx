<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageDocSetup.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob.ManageDocSetup" Title="Swift HR Management System 1.0" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


 <script language="JavaScript" src="../../calendar/calendar_us.js"></script>
<link rel="stylesheet" href="../../calendar/calendar.css">

<script type="text/javascript" src="../../ajax_func.js"></script>
<script type="text/javascript" language="javascript">

    function doInsert(jobid, rowid) 
    {
        var DocValue = document.getElementById("DocId_" + rowid);
        var DocId = DocValue.options[DocValue.selectedIndex].value;
        if (DocId == 0) {
            alert("Please Select Document Name!");
            return;
        }

        var DocTypeValue = document.getElementById("DocType_" + rowid);
        var DocType = DocTypeValue.options[DocTypeValue.selectedIndex].value;

        var DocStatusValue = document.getElementById("DocStatus_" + rowid);
        var DocStatus = DocStatusValue.options[DocStatusValue.selectedIndex].value;

        var DocRecValue = document.getElementById("Rec_Date_" + rowid);
        var DocRecDate = DocRecValue.value;

        var DocSubValue = document.getElementById("Sub_Date_" + rowid);
        var DocSubDate = DocSubValue.value;

        var DocExpValue = document.getElementById("Exp_Date_" + rowid);
        var DocExpDate = DocExpValue.value;

        var DocRemarksValue = document.getElementById("remarks_" + rowid);
        var DocRemarks = DocRemarksValue.value;
               
        if (!confirm("Are you sure, you want to add?")) {return; }

        var query = "Exec ProcDocumentSetup @flag='u',@RowId='" + rowid  + "',@DocType='" + DocType + "',@DocStatus='" + DocStatus + "',@DocSubDate='" + DocSubDate + "',@DocExpiryDate='" + DocExpDate + "',@DocReceivedDate='" + DocRecDate + "',@Remarks='" + DocRemarks + "',@JobId='"+jobid+"',@DocId='"+DocId+"'";
        var url = 'ManageJobDoc.aspx?StrQry=' + query + '&JobID=' + jobid; ;
        exec_AJAX(url, "displayMsg", "");       
    }

    function doUpdate(jobid, rowid) {

        var DocTypeValue = document.getElementById("DocType_" + rowid);
        var DocType = DocTypeValue.options[DocTypeValue.selectedIndex].value;
       
        var DocStatusValue = document.getElementById("DocStatus_" + rowid);
        var DocStatus = DocStatusValue.options[DocStatusValue.selectedIndex].value;

        var DocRecValue = document.getElementById("Rec_Date_" + rowid);
        var DocRecDate = DocRecValue.value;

        var DocSubValue = document.getElementById("Sub_Date_" + rowid);
        var DocSubDate = DocSubValue.value;

        var DocExpValue = document.getElementById("Exp_Date_" + rowid);
        var DocExpDate = DocExpValue.value;

        var DocRemarksValue = document.getElementById("remarks_" + rowid);
        var DocRemarks = DocRemarksValue.value;

        if (!confirm("Are you sure, you want to update?")) { return; }
        var query = "Exec ProcDocumentSetup @flag='u',@RowId='" + rowid +"',@DocType='" + DocType + "',@DocStatus='" + DocStatus + "',@DocSubDate='" + DocSubDate + "',@DocExpiryDate='" + DocExpDate + "',@DocReceivedDate='" + DocRecDate + "',@Remarks='" + DocRemarks + "'";
        var url = 'ManageJobDoc.aspx?StrQry=' + query + '&JobID=' + jobid; ;
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
        var query = "Exec ProcDocumentSetup @flag='d',@JobTypeID='" + jobid + "',@rowid='" + rowid + "'";

        var url = 'ManageJobDoc.aspx?StrQry=' + query;
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
                                    &nbsp;&nbsp; Document List
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
                            </tr>
                        </table>
                        <table width="85%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" align="center">


<table width="100%" align="center">
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

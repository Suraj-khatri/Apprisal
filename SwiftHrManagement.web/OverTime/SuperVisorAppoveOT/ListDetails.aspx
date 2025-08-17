<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ListDetails.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.SuperVisorAppoveOT.ListDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../ajax_func.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

    function submit_form() {
        var btn = document.getElementById("<%=btnHidden.ClientID %>");
        if (btn != null)
            btn.click();
    }

    function nav(page) {
        var hdd = document.getElementById("hdd_curr_page");
        if (hdd != null)
            hdd.value = page;

        submit_form();
    }

    function newTableToggle(idTD, idImg) {
        var td = document.getElementById(idTD);
        var img = document.getElementById(idImg);
        if (td != null && img != null) {
            var isHidden = td.style.display == "none" ? true : false;
            img.src = isHidden ? "/images/icon_hide.gif" : "/images/icon_show.gif";
            img.alt = isHidden ? "Hide" : "Show";
            td.style.display = isHidden ? "" : "none";
        }
    }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
                        <tr>
                            <td align="left" class="wellcome" valign="bottom">
                                <img src="../../Images/big_bullit.gif" />&nbsp;Supervisor OT Approve Details
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#999999" valign="top">
                            </td>
                        </tr>
                            <tr>
                            <td>
                                <div id = "res" align="center"></div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                 <div>
                                    <div id="rpt" runat="server"></div>
                                    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                                </div>
                            </td>
                        </tr>
                    
                    </table> 
                    
                    
    <script language="javascript" type="text/javascript">
        function UpdateRequestPeriod(Obj) {
            var GetReqPeriod = null;
            if (confirm("Are you sure to update?")) {

                var reqHour = document.getElementById('Reqhrs_' + Obj).value;
                //var reqMM = document.getElementById('ReqMM_' + Obj).value;
                
                
                
//                if (reqHour != "" && reqMM != "") {
//                     GetReqPeriod = reqHour + ':' + reqMM;
//                 }
                if (reqHour!="") {
                    GetReqPeriod = reqHour;
                }
                
                else {
                    GetReqPeriod = document.getElementById('ReqTime_' + Obj).value;
                }
          
                //var GetsupervisorRemark = document.getElementById('txtarea_' + Obj).value;
                var Alurl = 'ManageOT.aspx?flag=updateReqTime&txtReqPeriod=' + GetReqPeriod + '&Rowid=' + Obj;

                 exec_AJAX(Alurl, 'res', '');
                   }
               }

               function approveSupervisor(Obj) {
                   var GetReqPeriod = null;
                   
                   if (confirm("Are you sure to Approved ?")) {

                       GetReqPeriod = document.getElementById('ReqTime_' + Obj).value;
                       var GetsupervisorRemark = document.getElementById('txtarea_' + Obj).value;
                       var Alurl = 'ManageOT.aspx?flag=approved&Rowid=' + Obj + '&txtReqPeriod=' + GetReqPeriod + '&Remark=' + GetsupervisorRemark;
                         exec_AJAX(Alurl, 'TDA_' + Obj, '');

                   }
                 }
                 function HDapproveSupervisor(Obj) {
                     if (confirm("Are you sure to Approved ?")) {
                         var GetsupervisorRemark = document.getElementById('txtarea_' + Obj).value;
                         var Alurl = 'ManageOT.aspx?flag=HDapproved&Rowid=' + Obj + '&Remark=' + GetsupervisorRemark;
                         exec_AJAX(Alurl, 'TDA_' + Obj, '');

                     }
                 }

                 function rejectSupervisor(obj) {
                     var getReqPeriod = null;

                     if (confirm("Are you sure to Reject ?")) {

                         getReqPeriod = document.getElementById('ReqTime_' + obj).value;
                         var alurl = 'ManageOT.aspx?flag=reject&Rowid=' + obj + '&txtReqPeriod=' + getReqPeriod;
                         exec_AJAX(alurl, 'TDR_' + obj, '');
                         document.getElementById('TDA_' + Obj).innerHTML = "Rejected";

                     }
                 }

                 function HDrejectSupervisor(Obj) {
                     if (confirm("Are you sure to Reject ?")) {
                         var GetsupervisorRemark = document.getElementById('txtarea_' + Obj).value;
                         var Alurl = 'ManageOT.aspx?flag=HDreject&Rowid=' + Obj + '&Remark=' + GetsupervisorRemark;
                         exec_AJAX(Alurl, 'TDR_' + Obj, '');
                         document.getElementById('TDA_' + Obj).innerHTML = "Rejected";
                     }
                 }

  </script>
                    
</asp:Content>




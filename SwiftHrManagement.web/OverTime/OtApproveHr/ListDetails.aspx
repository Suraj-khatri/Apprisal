<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ListDetails.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.OtApproveHr.ListDetails" %>


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
    <div class="panel">
    <header class="panel-heading">
        <i class="fa fa-caret-right"></i>
        Payment By Hr Details
    </header>
    <div class="panel-body">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <section class="panel">
                    <div class="panel-body">
                        <div class="form-group" style="overflow:auto;">
                            <div id="rpt" runat="server"></div>
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                        <div class="form-group">
                            <div id = "res" align="center"></div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnApprove" runat="server" Text="Post All As Adhoc" CssClass="btn btn-primary" 
                                    onclick="BtnApprove_Click" />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</div>
<script language="javascript" type="text/javascript">
       function UpdateApprovedPeriod(Obj, empID) {
           
            var GetReqPeriod = null;
            if (confirm("Are you sure to Update ?")) {

                var reqHour = document.getElementById('Reqhrs_' + Obj).value;
                //var reqMM = document.getElementById('ReqMM_' + Obj).value;

                if (reqHour != "") {
                    GetReqPeriod = reqHour;
                }

                else {
                    GetReqPeriod = document.getElementById('ReqTime_' + Obj).value;
                }
                

                var GethrRmark = document.getElementById('txtarea_' + Obj).value;
                var ot_rate_id = document.getElementById('rate_type_' + Obj).value;

                var Alurl = 'ManageOT.aspx?flag=hrApproveTime&Remark=' + GethrRmark + '&txtReqPeriod=' + GetReqPeriod + '&OtRateId=' + ot_rate_id + '&empId=' + empID + '&Rowid=' + Obj;
                exec_AJAX(Alurl, 'spn_' + Obj, 'CalcTotal();');
            }
        }
        function ApprovedHardship(Obj, empID) {
            if (confirm("Are you sure to Approve ?")) {

                var Alurl = 'ManageOT.aspx?flag=hrhs&empId=' + empID + '&Rowid=' + Obj;

                exec_AJAX(Alurl, 'spn_' + Obj, 'CalcTotal();');

                document.getElementById('TDA_' + Obj).innerHTML = "Approved";
                document.getElementById('TDR_' + Obj).innerHTML = "Approved";
            }
        }

//        function RejectHardship(Obj, empID) {
//            if (confirm("Are you sure to Reject ?")) {

//                var Alurl = 'ManageOT.aspx?flag=hrhr&empId=' + empID + '&Rowid=' + Obj;

//                exec_AJAX(Alurl, 'TDR_' + obj, '');
//                document.getElementById('TDA_' + Obj).innerHTML = "Rejected";
//            }
//        }

        function RejectHardship(Obj) {
            if (confirm("Are you sure to Reject ?")) {
                var GetsupervisorRemark = document.getElementById('txtarea_' + Obj).value;
                var Alurl = 'ManageOT.aspx?flag=HDreject&Rowid=' + Obj + '&Remark=' + GetsupervisorRemark;
                exec_AJAX(Alurl, 'TDR_' + Obj, '');
                document.getElementById('TDA_' + Obj).innerHTML = "Rejected";
            }
        }

        function CalcTotal() {            
            var amountList = document.getElementsByName("amount");
            var totalAmount = 0;
            for (var i = 0; i < amountList.length;  i++) {
                totalAmount += isNaN(amountList[i].value) ? 0 : parseFloat(amountList[i].value);
            }
            document.getElementById("totalAmount").value = totalAmount.toFixed(2);
            
        }

  </script>
                    
</asp:Content>


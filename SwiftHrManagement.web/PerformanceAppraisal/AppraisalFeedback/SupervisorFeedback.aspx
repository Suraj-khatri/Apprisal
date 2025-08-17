<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="SupervisorFeedback.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.SupervisorFeedback" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
        .error
        {
            color:Red;
        }
</style>
    <script src="../../Jsfunc.js" type="text/javascript"></script>
    <script src="../../js/jquery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../js/jquery/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../js/jquery/jquery.validate.min.js" type="text/javascript"></script>

    <script language = "javascript" type="text/javascript" >
        $.validator.messages.required = "* Required!";
       function OnDdlChange(thisId) {
            var thisVal = $.trim($("#" + thisId).val());
            //alert(thisVal);
            var txtId = thisId.split('_')[1];
            if ( (thisVal < 40) || (thisVal > 60)) {
                //alert("60>n<40");
                $("#super_" + txtId).addClass("required");                
            }
            else {
                $("#super_" + txtId).removeClass("required");
            }
            $("#aspnetForm").validate();
        }

        $(document).ready(function () {
            $(".super_commentArea").each(function () {              
                var id = $(this).attr("id");
                var sid = id.split('_')[1];

                var thisVal = $("#ratingvalue2_" + sid).val();
                if ((thisVal < 40) || (thisVal > 60)) {
                    $(this).addClass("required");
                }
                
            });
        });


        function CheckRequiredFields() {           
            var boolVal = true;
            $(".super_commentArea").each(function () {
                if ($(this).valid() == false ) {
                    boolVal = false;
                }
            });
            if (boolVal == false) {
                $("#aspnetForm").validate().focusInvalid();
                return false;
            }
            else if (!$("#aspnetForm").valid()) {
                $(".required").each(function () {

                    $(this).focus();
                    $(this).addClass("required");

                });
                return false;
            }
            else {
                RepalaceCommaFromComment();
                return true;
            }            
        }

        function ValidateForm() {
            if (!CheckRequiredFields())
                return false;
       
            try {
                var elements = document.getElementsByName("appraisal_fb");
                for (var i = 0; i < elements.length; i++) {
                    elements[i].value = ReplaceInvalidChar(elements[i].value);
                }
                RepalaceCommaFromComment();
                return true;
            }
            catch (ex) {
                return false;
            }
        }
        
        function ReplaceInvalidChar(value) {
            value = value.replace(/'/g, "`");
            value = value.replace(/,/g, " ");
            return value;            
        }

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

        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%= hdnReviewer.ClientID %>").value = customerValueArray[1];

        }

        function RepalaceCommaFromComment() {
            $(".commentArea").each(function () {
                ReplaceComma(this);
            });
        }

        function ReplaceComma(obj) {
            var x = obj.value;
            if (x == "" || x==null||x==undefined)
                return;
            x = replaceAll(x, ",", "~");
            x = replaceAll(x, "'", "`");
                   
            document.getElementById(obj.id).value = x.toString();
        }

        function replaceAll(string, find, replace) {
            return string.replace(new RegExp(escapeRegExp(find), 'g'), replace);
        }

        function escapeRegExp(string) {
            return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
        }

    </script>
    <script type="text/javascript" >

        function trim(str, chars) {
            return ltrim(rtrim(str, chars), chars);
        }

        function ltrim(str, chars) {
            chars = chars || "\\s";
            return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
        }

        function rtrim(str, chars) {
            chars = chars || "\\s";
            return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
        }

        function OnReject(rowId, flag, appraisalId) 
        {
            if (confirm("Are you sure to Reject this message?")) {
                document.getElementById("<%=hdnMatrixId.ClientID %>").value = rowId;
                document.getElementById("<%=hdnRaterType.ClientID %>").value = flag;
                ShowModal(rowId, flag, appraisalId);
                }
             }

        function ShowModal(rowId, flag, appraisalId) {
            var rawData = "";
            var rawData1 = "";
            var dataList = "";
            while (rawData == undefined || rawData == "undefined" || rawData == null || rawData == "") {
                dataList = window.showModalDialog("RejectComments.aspx?matrixId=" + rowId + "&raterType=" + flag + "&appraisalId=" + appraisalId + "", window.self, "dialogHeight:270px;dialogWidth:360px;dialogLeft:300;dialogTop:100';center:yes");
                rawData = trim(dataList[0]);

            }
            document.getElementById("<%=hdnRemarks.ClientID %>").value = rawData;
            document.getElementById("<%=btnReject.ClientID %>").click();
        }

        function PrintMessage(errorCode, errorMsg, url) {
            alert(errorMsg);
            if (errorCode == "0") {
                if (url != "") {
                    window.location.href = url;
                }
            }
        }

        function CalculateRating(which) {
            var result = "0";
            var all_cmb_id = document.getElementById("<%=RatingValue.ClientID %>").value.split(',');          

            var rate = "0";
            for (j = 1; j <= all_cmb_id.length - 1; j++) {            

                if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value != "0") {
                    if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "0") {
                        rate = "0";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "5") {
                        rate = "5";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "10") {
                        rate = "10";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "15") {
                        rate = "15";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "20") {
                        rate = "20";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "25") {
                        rate = "25";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "30") {
                        rate = "30";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "35") {
                        rate = "35";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "40") {
                        rate = "40";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "45") {
                        rate = "45";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "50") {
                        rate = "50";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "55") {
                        rate = "55";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "60") {
                        rate = "60";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "65") {
                        rate = "65";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "70") {
                        rate = "70";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "75") {
                        rate = "75";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "80") {
                        rate = "80";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "85") {
                        rate = "85";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "90") {
                        rate = "90";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "95") {
                        rate = "95";
                    }
                    else if (document.getElementById("ratingvalue" + which + "_" + all_cmb_id[j]).value == "100") {
                        rate = "100";
                    }
                    result = parseFloat(result) + parseFloat(rate);
                }
            }
            totalper = (all_cmb_id.length - 1) * 100;
            var PerValue = ((result / totalper) * 100);
            parent.parent.document.getElementById(parent.parent.GetCtrlId()).innerHTML = roundNumber(PerValue, 2);
            parent.parent.document.getElementById(parent.parent.GetDivOveralllId()).innerHTML = AppraisalWeight(PerValue);
        }

        function roundNumber(rnum, rlength) { // Arguments: number to round, number of decimal places
            var newnumber = Math.round(rnum * Math.pow(10, rlength)) / Math.pow(10, rlength);
            return parseFloat(newnumber); // Output the result to the form field (change for your purposes)
        }

        function AppraisalWeight(Marks) {
            Result = "";

            if (Marks > 0 && Marks <= 20) {
                Result = "Unsatisfactory (US)";
            }
            if (Marks > 20 && Marks <= 40) {
                Result = "Satisfactory (S)";
            }
            if (Marks > 40 && Marks <= 60) {
                Result = "Good (G)";
            }
            if (Marks > 60 && Marks <= 80) {
                Result = "Very Good (VG)";
            }
            if (Marks > 80) {
                Result = "Excellent";
            }
            return Result;
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID= "RatingValue" runat="server" />
    <div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div class="panel-body">
                <div class="form-group">
                    <div id="DivMsg" runat="server"></div>
                    <asp:HiddenField ID="hdnReviewer" runat="server" />
                    <asp:HiddenField ID="hdnMatrixId" runat="server" />
                    <asp:HiddenField ID="hdnRaterType" runat="server" />
                    <asp:HiddenField ID="hdnRemarks" runat="server" />
                    <asp:HiddenField ID="hdnRating" runat="server" />
                    <asp:HiddenField ID="hdnWeight" runat="server" />
                    <asp:HiddenField ID="section6Ques" runat="server" />
                    <asp:Button ID="btn_u" runat="server" onclick="btnUpdate_Click" 
                        Height="24px" style="display:none;" />
                </div>
                <div class="form-group">
                    <div id="matrix" runat="server"></div>
                </div>
                <div class="form-group">
                    <div id="section2" runat="server"></div>
                </div>
                <div class="form-group">
                    <strong>Other Information (to be filled by Appraisee)</strong>
                    <div id="section6" runat="server"></div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnPartialSave" runat="server" CssClass="btn btn-primary" Text="Save" 
                    onclick="btnPartialSave_Click" Visible="false" OnClientClick="return CheckRequiredFields();"/> &nbsp;&nbsp;&nbsp;&nbsp;
               
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save & Forward" OnClientClick = "ValidateForm();"
                        onclick="btnSave_Click" Visible="false" ValidationGroup="save" />
                    
                    <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                    </cc1:ConfirmButtonExtender>
                
                    &nbsp;<asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary" Text="Reject" 
                        onclick="btnReject_Click" style="display:none;"  />
                </div>
                <div class="form-group">
                    <div id="ConfirmMsg" runat="server"></div>
                </div>
            </div>
        </div>
    </div>
       <%-- <tr>
            <td>
                Reviewer Name : 
                <asp:DropDownList ID="ddlReviewer"  runat="server" CssClass="CMBDesign"></asp:DropDownList>
                
             <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlReviewer" Display="None" ErrorMessage="Required"
                        ValidationGroup="save"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
    <script language = "javascript" type = "text/javascript">
        function ShowModalUpdate(rowid, appraisalId) {
            var rawData = "";
            var dataList = "";
            while (rawData == undefined || rawData == "undefined" || rawData == null || rawData == "") {
                dataList = window.showModalDialog("/PerformanceAppraisal/Details/ManageNewRating.aspx?matrixId=" + rowid + "&appraisalId=" + appraisalId + "", window.self, "dialogHeight:200px;dialogWidth:520px;dialogLeft:200;dialogTop:100';center:yes");
                rawData = trim(dataList);
            }
            document.getElementById("<%=hdnRating.ClientID %>").value = dataList;

        }


        function OnUpdate(rowId, appraisalId) {
            if (confirm("Are you sure to Update this message?")) {
                document.getElementById("<%=hdnMatrixId.ClientID %>").value = rowId;
                ShowModalUpdate(rowId, appraisalId);
                document.getElementById("<%=btn_u.ClientID %>").click();

            }
        }
</script>
</asp:Content>

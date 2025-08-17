<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageMatrix.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.Details.ManageMatrix" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
    
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
    </script>
        <script type="text/javascript" >
            function OnReject(rowId, flag, appraisalId) 
            {
                if (confirm("Are you sure to Reject this message?")) {
                    document.getElementById("<%=hdnMatrixId.ClientID %>").value = rowId;
                    document.getElementById("<%=hdnRaterType.ClientID %>").value = flag;
                    document.getElementById("<%=hdnappraisalId.ClientID %>").value = appraisalId;
                    ShowModal(rowId, flag, appraisalId);
                    document.getElementById("<%=btnReject.ClientID %>").click();
                  }
            }
            function ShowModal(rowId, flag, appraisalId) {
                var rawData = "";
                var rawData1 = "";
                var dataList = "";
                while (rawData == undefined || rawData == "undefined" || rawData == null || rawData == "") {
                    dataList = window.showModalDialog("/PerformanceAppraisal/AppraisalFeedback/RejectComments.aspx?matrixId="+rowId+"&raterType="+flag+"&appraisalId="+appraisalId+"", window.self, "dialogHeight:270px;dialogWidth:360px;dialogLeft:300;dialogTop:100';center:yes");
                    rawData = trim(dataList[0]);
                }
                document.getElementById("<%=hdnRemarks.ClientID %>").value = rawData;
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
                //alert(document.getElementById("<%=RatingValue.ClientID %>").value);

                var rate = "0";
                for (j = 1; j <= all_cmb_id.length - 1; j++) {
                    //alert(all_cmb_id[j]);

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

            function roundNumber(rnum, rlength) 
            { // Arguments: number to round, number of decimal places
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
    <asp:HiddenField ID="RatingValue" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="panel-body">
                    <div class="form-group">
                        <div  id = "DivMsg" runat="server"></div> 
                    </div>
                    <div class="form-group">
                        <div id="dek" runat="server"></div> 
                        <asp:HiddenField ID="hdnMatrixId" runat="server" /> 
                        <asp:HiddenField ID="hdnRating" runat="server" /> 
                        <asp:Button ID="btn_u" runat="server" onclick="btnUpdate_Click" 
                            style="display:none;" />
                        <asp:HiddenField ID="hdnRaterType" runat="server" /> 
                        <asp:HiddenField ID="hdnRemarks" runat="server" />
                        <asp:HiddenField ID="hdnappraisalId" runat="server" />
                        <asp:Button ID="btnReject" runat="server" 
                            Height="24px" onclick="btnReject_Click" style="display:none;"  />
                    </div>
                    <div class="form-group">
                        <div id="rpt" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="rptPopulate" runat="server" visible="false">
                        </div>
                    </div>
                    <div class="form-group" id ="btn" runat="server" align="center">
	                    <asp:Button ID="btnPartialSave" runat="server" Text="Save" CssClass="btn btn-primary"  
                            width="75px" onclick="btnPartialSave_Click" Visible="false" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	                    <asp:Button ID="btnSave" runat="server" Text="Save & Forward" CssClass="btn btn-primary" onclick="btnSave_Click" width="100px" Visible="false" />
	                    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                        <div id="confirmMsg" runat="server"></div>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <div class="form-group">
                            <asp:RadioButtonList ID="rdoResponse" runat="server">
                                <asp:ListItem Value="Agree"><strong>I agree with the assesment made by the supervisor and the reviewer</strong></asp:ListItem>
                                <asp:ListItem Value="DisAgree"><strong>I  do not agree with the assesment made by the supervisor and the reviewer</strong></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <label>Comments of the Employee (if any):</label>
                            <asp:TextBox ID="txtComments" runat="server" CssClass="inputTextBoxLP" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-group" id ="Div1" runat="server" align="center">
	                        <asp:Button ID="btnSaveFinal"  runat="server" Text="Save" CssClass="btn btn-primary" width="75px" Visible="false"
                                onclick="btnSaveFinal_Click" />
                            <cc1:ConfirmButtonExtender ID="btnSaveFinal_ConfirmButtonExtender1" runat="server" 
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="btnSaveFinal">
                            </cc1:ConfirmButtonExtender>
                        </div>   
                    </asp:Panel> 
                    </div>
                </div>
            </section>
        </div>
    </div>

<script language = "javascript" type = "text/javascript">
    function ShowModalUpdate(rowid, appraisalId) {
        var rawData = "";
        var dataList = "";
        while (rawData == undefined || rawData == "undefined" || rawData == null || rawData == "") {
            dataList = window.showModalDialog("ManageNewRating.aspx?matrixId=" + rowid + "&appraisalId=" + appraisalId + "", window.self, "dialogHeight:200px;dialogWidth:520px;dialogLeft:200;dialogTop:100';center:yes");
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

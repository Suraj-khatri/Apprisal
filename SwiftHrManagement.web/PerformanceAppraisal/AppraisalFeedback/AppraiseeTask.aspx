<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true"
    CodeBehind="AppraiseeTask.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.AppraiseeTask"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Jsfunc.js" type="text/javascript"></script>
    <script type="text/javascript">
        function PrintMessage(errorCode, errorMsg, url) {
            alert(errorMsg);
            if (errorCode == "0") {
                if (url != "") {
                    window.location.href = url;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <div class="panel-body">
                    <div class="form-group">
                        <div id="DivMsg" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <strong>A. Briefly list the major target/duties and responsibilities the apprisee requires
                        to fulfill during the review period and achievement against them:</strong>
                    </div>
                    <div class="form-group">
                        <label>Target/Duties and Responsibilities :</label>
                        <asp:TextBox ID="txtTaskDefinition" runat="server" CssClass="form-control" TextMode="MultiLine" Width="60%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Achievements:</label>
                        <asp:TextBox ID="txtOtherAchievements" runat="server" CssClass="form-control"
                            TextMode="MultiLine" Width="60%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div id="comment" runat="server">
                            <label>Comments on Target/Duties and Responsibilities:</label>
                        </div>
                        <asp:TextBox ID="txtCommentsOnDuties" runat="server" CssClass="form-control" TextMode="MultiLine" Width="60%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Visible="false" Text="Save"
                            OnClientClick="ValidateForm();" OnClick="btnSave_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnFinalSave" runat="server" Visible="false" CssClass="btn btn-primary"  
                            Text="Save & forward" onclick="btnFinalSave_Click" />
                        <asp:HiddenField runat="server" ID="allwSelfRating" /> 
                        <asp:HiddenField runat="server" ID="hddIsAppraisee" />
                        <asp:HiddenField runat="server" ID="hddAllowApriseer" />
                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                            Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

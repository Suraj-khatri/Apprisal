<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ApprovePurchaseOrder.aspx.cs" Inherits="SwiftAssetManagement.Voucher.ApprovePurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
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


        function GetEmpID(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID%>").Value = EmpIdArray[1];
    }

    </script>

    <div class="row">
        <div class="col-md-10 col-md-offset-1">
             <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                          Aprrove Purchase Order (PO)
                        </header>
            <div class="panel-body">
                <asp:UpdatePanel ID="updatepnl" runat="server">
                    <ContentTemplate>
                        <form class="form-inline">
                            <h4>Purchase Order Information</h4>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            <div class="col-md-6 form-group">
                                <label>Order No :</label>
                                <asp:Label ID="orderno" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Order Date :
                     <asp:Label ID="orderdate" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Vendor Name :
                     <asp:Label ID="vendorname" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Forwarded To :
                     <asp:Label ID="forwardedto" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Forwarded By :
                    <asp:Label ID="forwardedby" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Forwarded Date :
                    <asp:Label ID="forwardeddate" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                            <div class="col-md-6 form-group">
                                Order Status :
                     <asp:Label ID="status" runat="server" CssClass="lblText"></asp:Label>
                            </div>
                        </form>

                        <h4>Product History:</h4>
                        <div id="rptProductHistory" runat="server"></div>

                        <h4>Previous Purchase History:</h4>
                        <div id="rptPurchaseHistory" runat="server"></div>
                        <h4>Forward/Approval:</h4>
                        <div class="form-group">
                            <asp:RadioButton ID="rdoApprove" runat="server" Font-Bold="True"
                                Text="Approve" AutoPostBack="True" OnCheckedChanged="rdoApprove_CheckedChanged" />
                            &nbsp;
                        <asp:RadioButton ID="rdoForward" runat="server" Font-Bold="True"
                            Text="Forward" AutoPostBack="True" OnCheckedChanged="rdoForward_CheckedChanged" />

                        </div>
                        <div class="form-group autocomplete-form">
                            <asp:Label ID="lblFdEmp" runat="server"
                                Text="Forwarded Employee:" Visible="False" Font-Bold="True"></asp:Label><br />
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                TargetControlID="frwdEmployee" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                OnClientItemSelected="GetEmpID">
                            </cc1:AutoCompleteExtender>

                            <asp:TextBox ID="frwdEmployee" runat="server" Visible="False"
                                CssClass="form-control" AutoComplete="off"></asp:TextBox>

                            <cc1:TextBoxWatermarkExtender ID="forwardedto_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="frwdEmployee"
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>

                            <asp:HiddenField ID="hdnEmpId" runat="server" />
                        </div>
                        <h4>PO Product Information:</h4>
                        <div id="rpt" runat="server"></div>
                        <div class="form-group">
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" Text="Approve" CssClass="btn btn-primary"
                                OnClick="BtnSave_Click" ValidationGroup="order" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                ConfirmText="Are you sure to Approve?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
        <asp:Button ID="BtnForwrd" runat="server" Text="Forward" CssClass="btn btn-primary"
            ValidationGroup="order" OnClick="BtnSave_Click" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                ConfirmText="Are you sure to forward?" Enabled="True" TargetControlID="BtnForwrd">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Cancel"
            CssClass="btn btn-primary" OnClick="BtnDelete_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                ConfirmText="Are you sure to Cancel?" Enabled="True"
                                TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
            OnClick="BtnBack_Click" Text="Back"  />

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </section>
        </div>
    </div>


</asp:Content>

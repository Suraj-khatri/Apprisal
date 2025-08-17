<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Deliver.List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var GB_ROOT_DIR = "/greybox/";
    </script>
    <script language="javascript" type="text/javascript">
        function addOther(str) {

            var URL = "/Inventory/Requisition/Deliver/AddOtherInfo.aspx?Id=" + str;
            GB_show("Add Prodcut Information ", URL, 400, 800);
        }
    </script>
    <script type="text/javascript" src="/greybox/AJS.js"></script>
    <script type="text/javascript" src="/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/greybox/gb_scripts.js"></script>
    <link href="/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
    <div class="col-md-10 col-md-offset-1">
        <div class="panel">
            <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
             Dispatch Requisition, Requesting Branch :<asp:Label ID="lblBranchname" runat="server"></asp:Label>
            <asp:HiddenField ID="hdnapid" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </header>
            <div class="panel-body">
                        <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                            
                                <header class="panel-heading">
                                    Requisition Information
                                </header>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <label>Requested Message :</label>
                                <asp:TextBox ID="txtReqMsg" runat="server" CssClass="form-control" TextMode="MultiLine" 
                                    Enabled="false" Width="100%"></asp:TextBox>
                                <asp:Panel ID="unschPnl" runat="server" Visible="false" >
                                <label>Unscheduled Reason :</label>
                                <asp:TextBox ID="txtUnschReason" runat="server" CssClass="form-control" TextMode="MultiLine" 
                                    Enabled="false" Width="100%"></asp:TextBox>
                                </asp:Panel>
                                </div>
                                <div class="col-md-12">
                                     <label>Recommend Message :</label>
                                <asp:TextBox ID="txtRecommedMsg" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%">
                                </asp:TextBox>
                                </div>
                            </div>
                                
                               <div class="row">
                                   <div class="col-md-12">
                                       <label>Approved Message :</label>
                                <asp:TextBox ID="txtAppMsg" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%">
                                </asp:TextBox>
                                   </div>
                                  <%-- <div class="col-md-6">
                                       <label>Dispatch Message :<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine">
                                </asp:TextBox>
                                   </div>--%>
                               </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Dispatch Message :<span class="errormsg">*</span></label>
                                <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%">
                                </asp:TextBox>
                                    </div>
                                    </div>
                                    <div class="row">
                                     <div class="col-md-3">
                                         <label>Is Direct Expenses?</label>
                                    <asp:DropDownList ID="DdlCheckReqType" runat="server" CssClass="form-control" Width="100%">
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                     <div class="col-md-3">
                                        <label>Dispatched Date :</label> <span class="required">*</span>
                                        <asp:TextBox ID="txtDispatchDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtDispatchDate_CalendarExtender" runat="server" Enabled="True" 
                                        TargetControlID="txtDispatchDate">
                                    </cc1:CalendarExtender>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtDispatchDate" ErrorMessage="Required" SetFocusOnError="True"
                                         ValidationGroup="approve"></asp:RequiredFieldValidator>
                                    </div>
                                        </div>
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                                       Text="Dispatch" ValidationGroup="approve" onclick="BtnSave_Click" />
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" 
                                        Text="Back" ValidationGroup="chart" />
                                   
                           </div>
                        </section>
                    </div>
             
        </div>
    </div>
</asp:Content>

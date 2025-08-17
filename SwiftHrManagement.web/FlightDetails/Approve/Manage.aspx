<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.FlightDetails.Approve.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="pnl1">
    <ContentTemplate>   
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                           Flight Authorization
                    </header>
                    <div class="panel-body">
                        <asp:Label ID="lblauthor" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblreadsession" runat="server" Visible="False"></asp:Label>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Employee Information</u></h4>
                                <asp:Label ID="printMsg" Text="Message: " runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Employee Name:</strong>
                            </div>
                            <div class="col-md-9">
                                <strong><asp:Label ID="LblEmpName" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Branch:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lblbranch" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Department:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lbldepartment" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Position:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lblposition" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Flight Information</u></h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Flight Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblFlightDate" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>From Place:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblFromPlace" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>To Place:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblToPlace" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Flight Time/Schedule:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lblFlightTime" runat="server"></asp:Label></strong>
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Return Flight Information</u></h4>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong> Return Flight Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblReturnFlightDate" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Return From (Place):</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblReturnFrom" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Return To (Place):</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblReturnTo" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Return Flight Time/Schedule:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lblReturnFlightTime" runat="server"></asp:Label></strong>
                            </div>
                            
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Purpose</u></h4>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-9 col-md-offset-3 ">
                                <strong><asp:Label ID="lblPurpose" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Authorised By</u></h4>
                            </div>
                        </div>
                       
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <div id="rpt" runat="server"> </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset class="form-group">
                                    <legend>Approval Message</legend>
                                    <asp:TextBox runat="server" ID="txtApprovalMsg" CssClass="form-control" TextMode="MultiLine"/>
                                </fieldset>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" OnClick="BtnSave_Click" Text="Approve" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Accept?"
                                Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                                                                        
                            <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary" OnClick="BtnReject_Click" Text="Reject" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Confirm To Reject?"
                                Enabled="True" TargetControlID="BtnReject">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" OnClick="BtnBack_Click" Text=" Back"  />
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

    
</asp:Content>

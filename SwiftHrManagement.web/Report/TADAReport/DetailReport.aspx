<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/SwiftHRManager.Master" CodeBehind="DetailReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.TADAReport.DetailReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
				                <strong>
                                    <font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                    </font>
                                </strong>
                                <font size="-1">
                                    <strong>
                                    <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                    </strong><br />
                                    Travel Authorization and Reimbursement <br /> <br />
                                </font>     
                            </div>
                            
                            <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <u><b>Employee Information</b></u>
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
                                    <u><b>Travel Order</b></u>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>City:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblcity" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Country:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblcountry" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Reason for Travel:</strong>
                                </div>
                                <div class="col-md-9">
                                    <strong><asp:Label ID="lblreasontravel" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row" id="divtraveldate" runat="server" visible="true">
                                <div class="col-md-3 text-right">
                                    <strong>From Date:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblfromdate" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>To Date:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lbltodate" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Extension of Visit:</strong>
                                </div>
                                <div class="col-md-9">
                                    <strong><asp:Label ID="lblextension" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                             <div id="divIsExtVisit" runat="server" visible="false">
                                 <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>From:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong> <asp:Label ID="lblextfrom" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong> <asp:Label ID="lblextto" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>City:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong> <asp:Label ID="lblextcity" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Country:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong> <asp:Label ID="Lblextcountry" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>Leave Applied:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong> <asp:Label ID="lblleaveaaplied" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>No Of. Days:</strong>
                                    </div>
                                    <div class="col-md-3">
                                    <strong> <asp:Label ID="lblremainingdays" runat="server"></asp:Label></strong>
                                </div>
                                </div>
                            </div>
                             <div class="row" >
                                <div class="col-md-3 text-right">
                                    <strong>Mode of Travel:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblmode" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Accomodation:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblaccomodation" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row" >
                                <div class="col-md-3 text-right">
                                    <strong>Transportation Arrangement:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lbltransportation" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Meal:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblfooding" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Cash Advance Against TADA:</strong>
                                </div>
                                <div class="col-md-9">
                                    <strong><asp:Label ID="lblcashadvance" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row" id="divIsAdvance" runat="server" visible="false">
                                <div class="col-md-3 text-right">
                                    <strong>Currency:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblcurrency" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Amount:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong> <asp:Label ID="lblamount" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Authorized By:</strong>
                                </div>
                                <div class="col-md-9">
                                    <strong><asp:Label ID="lblauthorisedy" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            
                            <div class="row">
                                <div class="col-md-12 ">
                                    <div id="TblReimburse" runat="server"><u><b class="lbltada">Reimbursement:</b></u></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" id="rptDiv" runat="server">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 ">
                                    <div id="TblOthers" runat="server" ><u><b class="lbltada">Others:</b> </u></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12" id="rptDiv2" runat="server">
                                </div>
                            </div>

                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
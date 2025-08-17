<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="ApprovalPage.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.Reimbursement.ApprovalPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <script type="text/javascript" language="javascript">
        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
        }
        function OnChangeEvent(id) {
            var valueDll = document.getElementById("ddl_" + id).value;
            if (valueDll == "Y") {
                document.getElementById("txtAmount_" + id).disabled = false;
            }
            else {
                document.getElementById("txtAmount_" + id).disabled = true;
            }

        }

    </script>
    --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:UpdatePanel runat="server" ID="pnl1">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>  
                           Reimbursement For TADA
                    </header>
                    <div class="panel-body">
                         <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                  <h4><u>Travel Order</u></h4> 
                                 <asp:Label ID="lblauthor" runat="server" Visible="False"></asp:Label>
                                 <asp:Label ID="lblreadsesion" runat="server" Visible="False"></asp:Label>
                            </div>
                         </div>
                         <div class="row">
                             <div class="col-md-3 text-right">
                                 <strong>Employee Name:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="LblEmpName" runat="server"></asp:Label></strong>
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>Branch:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="lblbranch" runat="server" Text="Label"></asp:Label></strong>
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>Department:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="lbldepartment" runat="server" Text="Label"></asp:Label></strong>
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>Position:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="lblposition" runat="server" Text="Label"></asp:Label></strong>
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>City:</strong>
                             </div>
                             <div class="col-md-3">
                             <strong><asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></strong> 
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>Country:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="lblcountry" runat="server" Text="Label"></asp:Label></strong>
                             </div>
                             <div class="col-md-3 text-right">
                                 <strong>Reason for Travel:</strong>
                             </div>
                             <div class="col-md-3">
                                 <strong><asp:Label ID="lblreasontravel" runat="server" Text="Label"></asp:Label></strong>
                             </div>
                         </div>
                         <div id="divtraveldate" runat="server" visible="true">
                                 <div class="row">
                                     <div class="col-md-3 text-right">
                                         <strong>From Date:</strong>
                                     </div>
                                     <div class="col-md-3">
                                        <strong><asp:Label ID="lblfromdate" runat="server" Text="Label"></asp:Label></strong>
                                     </div>
                                     <div class="col-md-3 text-right">
                                         <strong>To Date:</strong>
                                     </div>
                                     <div class="col-md-3">
                                         <strong><asp:Label ID="lbltodate" runat="server" Text="Label"></asp:Label></strong>
                                     </div>
                                     <div class="col-md-3 text-right">
                                         <strong>Extension of Visit:</strong>
                                     </div>
                                     <div class="col-md-3">
                                         <strong><asp:Label ID="lblextension" runat="server" Text="Label"></asp:Label></strong>
                                     </div>
                                 </div>  
                          </div>
                       <div id="divIsExtVisit" runat="server" visible="false">
                       <%--<div id="divIsExtVisit" runat="server" visible="true">--%>
                                              <div class="row">
                                                  <div class="col-md-3 text-right">
                                                      <strong>From:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="lblextfrom" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                                  <div class="col-md-3 text-right">
                                                      <strong>To:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="lblextto" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                                  <div class="col-md-3 text-right">
                                                      <strong>City:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="lblextcity" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                                  <div class="col-md-3 text-right">
                                                      <strong>Country:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="Lblextcountry" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                                  <div class="col-md-3 text-right">
                                                      <strong>Leave Applied:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="lblleaveaaplied" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                                  <div class="col-md-3 text-right">
                                                      <strong>No of.Days:</strong>
                                                  </div>
                                                  <div class="col-md-3">
                                                      <strong><asp:Label ID="lblremainingdays" runat="server" Text="Label"></asp:Label></strong>
                                                  </div>
                                              </div>
                                  </div>
                         <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Mode of Travel:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblmode" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Accomodation:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblaccomodation" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Transportation Arrangement:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbltransportation" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Meal:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblfooding" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                             <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Cash Advance Against TADA:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblcashadvance" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            </div>
                        </div>
                         <div id="divIsAdvance" runat="server" visible="false">
                         <%--<div id="divIsAdvance" runat="server" visible="false">--%>
                                      <div class="row">
                                         <div id="rpt2" runat="server">
                                         </div>
                                      </div>
                          </div>
                         <div class="row">
                              <div class="col-md-12">
                              <div id="rpt" runat="server">
                                          </div>
                              </div>
                          </div>
                         <div id="divreimburse" runat="server" align="left" class="txtlbl">
                            <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                           <h4><u>Reimbursement</u></h4> 
                                      </div>
                                <div class="col-md-12">
                                      <div id="disReimbersement" runat="server">
                                      </div>
                                </div>
                             </div>
                        </div>
                         <div id="divothers" runat="server">
                                 <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                           <h4><u>Others</u></h4> 
                                      </div>
                                          <div class="col-md-12">
                                              <div id="disOtherExp" runat="server">
                                              </div>
                                          </div>
                                  </div>
                                 </div>
                         <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" OnClick="BtnSave_Click"
                                              Text="Approve" ValidationGroup="tada" />
                                          <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Accept?"
                                              Enabled="True" TargetControlID="BtnSave">
                                          </cc1:ConfirmButtonExtender>
                                          <asp:Button ID="BtnVerify" runat="server" CssClass="btn btn-primary" OnClick="BtnVerify_Click"
                                              Text="Verify" ValidationGroup="tada" Visible="false" />
                                          <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Confirm To Verify?"
                                              Enabled="True" TargetControlID="BtnVerify">
                                          </cc1:ConfirmButtonExtender>
                                          <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary" OnClick="BtnReject_Click"
                                              Text="Reject" ValidationGroup="tada" />
                                          <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Confirm To Reject?"
                                              Enabled="True" TargetControlID="BtnReject">
                                          </cc1:ConfirmButtonExtender>
                                          <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" OnClick="BtnBack_Click"
                                              Text="Back" />
                                </div>
                             </div>
                           <div >
                       </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

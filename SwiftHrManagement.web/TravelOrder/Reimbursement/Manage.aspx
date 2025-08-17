<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.Reimbursement.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click" Style="display: none;" />

    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>  
                           Reimbursement For TADA
                    </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                  <h4><u>Employee Information</u></h4> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                 <strong>Employee Name:</strong>
                               </div>
                               <div class="col-md-3">
                                 <strong><asp:Label ID="LblEmpName" runat="server" /></strong>
                               </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                 <strong>Branch:</strong>
                               </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblbranch" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Department:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lbldepartment" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Position:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblposition" runat="server" Text="Label" /></strong>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-6 col-md-offset-3">
                                  <h4><u>TADA Information</u></h4> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                   <strong>City:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblcity" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Country:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblcountry" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Reason for Travel:</strong>
                                </div>
                                <div class="col-md-3">
                                   <strong><asp:Label ID="lblreasontravel" runat="server" Text="Label" /></strong>
                                </div>
                            </div>
                            <div id="divtraveldate" runat="server" visible="true">
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>From Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblfromdate" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lbltodate" runat="server" Text="Label" /></strong>
                                    </div>
                                </div>
                          </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Extension of Visit:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblextension" runat="server" Text="Label" /></strong>
                                </div>
                            </div>
                            
                            <div id="divIsExtVisit" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>From:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblextfrom" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblextto" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>City:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblextcity" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Country:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="Lblextcountry" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Leave Applied:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblleaveaaplied" runat="server" Text="Label" /></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>No Of. Days:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblremainingdays" runat="server" Text="Label" /></strong>
                                    </div>
                                </div>           
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Mode of Travel:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblmode" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Accomodation:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblaccomodation" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Transportation Arrangement:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lbltransportation" runat="server" Text="Label" /></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Meal:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblfooding" runat="server" Text="Label" /></strong>
                                </div>
                            </div>
                            <div id="divflightDetails" runat="server" Visible="false">
                                <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                       <h4><u>Flight Information</u></h4> 
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-left">
                                        <h5>>Flight Details</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                      <strong>Flight Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFlightDate" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>From Place:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFromPlace" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To Place:</strong>
                                    </div>
                                    <div class="col-md-3">
                                       <strong><asp:Label ID="lblToPlace" runat="server" Text="Label"></asp:Label></strong> 
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Flight Time/Schedule:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFlightTime" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-left">
                                        <h5>>Return Flight Details</h5>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>Flight Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFlightDate" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>From Place:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFromPlace" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To Place:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnToPlace" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Flight Time/Schedule:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFlightTime" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                       <h4><u>Other Information</u></h4> 
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>Cash Advance Against TADA:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblcashadvance" runat="server" Text="Label" /></strong>
                                    </div>
                                </div>
                            </div>
                            <div id="divIsAdvance" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="rpt2" runat="server"></div>
                                    </div>
                                </div>
                           </div>
                            <div class="row">
                                <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                       <h4><u>Authorised By</u></h4> 
                                     </div>
                                    <div class="col-md-12">
                                        <div id="rpt" runat="server"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="row">
                                      <div class="col-md-6 col-md-offset-3">
                                       <h4><u>Reimbursement Expenses </u></h4> 
                                     </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <label>From Date<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RequiredFieldValidator ID="rfvFromDate" runat="server"
                                            ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:Label ID="LblDateMsg" runat="server" />
                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"
                                            OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true" />
                                        <cc1:CalendarExtender ID="ceFromDate" runat="server"
                                            Enabled="True" TargetControlID="txtFromDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <label>To Date:<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server"
                                            ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:Label ID="LblDateMsg1" runat="server" />
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"
                                            OnTextChanged="txtToDate_TextChanged" AutoPostBack="true" />
                                        <cc1:CalendarExtender ID="ceToDate" runat="server"
                                            Enabled="True" TargetControlID="txtToDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <label>Expense Head:<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="ddlHead" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:DropDownList ID="ddlHead" runat="server" CssClass="form-control"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged"/>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <label>Currency:<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="ddlHeadCurrency" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:DropDownList ID="ddlHeadCurrency" runat="server" CssClass="form-control" Enabled="false" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <label>Per Day Entitlement:<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtPerDayEntitlement" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:TextBox ID="txtPerDayEntitlement" runat="server" CssClass="form-control"
                                            Enabled="false" />
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <label>Total Entitlement:<span class="required"> *</span></label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="txtTotalEntitlement" Display="Dynamic" ErrorMessage="Required!"
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                        <asp:TextBox ID="txtTotalEntitlement" runat="server" CssClass="form-control" Enabled="false" />
                                    </div>
                                </div>
                                <div id="divbill" runat="server" class="row">
                                    <div class="col-md-3 text-right">
                                        <label>Bills to be enclosed:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlBillEnclosed" runat="server" CssClass="FltCMBDesign"
                                            OnSelectedIndexChanged="ddlBillEnclosed_SelectedIndexChanged"
                                            AutoPostBack="true">
                                            <asp:ListItem Value="">Select</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div id="divclaimamount" runat="server" visible="false">
                                            Claim Amount:
                                            <asp:TextBox ID="txtClaimAmount" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <label>Remarks:</label>
                                    </div>
                                    <div class="col-md-3">
                                         <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Height="30px" />
                                        <asp:Button ID="btnAddNewClaim" runat="server" Text="Add New" CssClass="btn btn-primary"
                                            OnClick="btnAddNewClaim_Click" ValidationGroup="reim" />
                                        <asp:Label ID="lblMsg" runat="server" />
                                    </div>
                                </div>
 <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                  <div id="disReimbersement" runat="server"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label>Other Expenses:</label>
                    <asp:TextBox ID="txtOtherExpenses" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label>Claim Amount:</label>
                     <asp:TextBox ID="txtAmountClaimOther" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>Currency:</label>
                     <asp:DropDownList ID="ddlothercurrency" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <br />
                                <asp:Button ID="btnAddNew" runat="server" CssClass="btn btn-primary"
                                    Text="Add Claim" OnClick="btnAddNew_Click" />
                                <asp:Label ID="lblMsgOther" runat="server" />
           </div>
            <div class="row">
                <div class="col-md-12">
                   <div id="disOtherExpenses" runat="server"></div>
                </div>
            </div>
              <asp:Button ID="btnFinalSave" runat="server" CssClass="btn btn-primary"
                Text="Final Save" OnClick="btnFinalSave_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
                            </div>
                       </div>
                </section>
        </div>
    </div>




</asp:Content>

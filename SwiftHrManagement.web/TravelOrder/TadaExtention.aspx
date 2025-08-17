<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="TadaExtention.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.TadaExtention" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
           
    <style type="text/css">
        .style10
        {
            font-weight: bold;
        }
    </style>
           
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<asp:HiddenField ID="hdnId" runat="server" />

<asp:UpdatePanel runat="server" ID="pnl1">
    <ContentTemplate>   
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right" aria-hidden="true"></i>  
                           TADA Extention
                    </header>
                    <div class="panel-body">
                        <asp:Label ID="lblauthor" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblreadsession" runat="server" Visible="False"></asp:Label>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Employee Information</u></h4>
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
                                <h4><u>TADA Information</u></h4>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>City:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblcity" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Country:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblcountry" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Reason for Travel:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblreasontravel" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row" id="divtraveldate" runat="server" visible="true">
                            <div class="col-md-3 text-right">
                                <strong>From Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblfromdate" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>To Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbltodate" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row" >
                            <div class="col-md-3 text-right">
                                <strong>Extension of Visit:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblextension" runat="server"></asp:Label></strong>
                            </div>
                           
                        </div>
                        
                        <div id="divIsExtVisit" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>From:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblextfrom" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>To:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblextto" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>City:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblextcity" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Country:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="Lblextcountry" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Leave Applied:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblleaveaaplied" runat="server"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>No Of. Days:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblremainingdays" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        <br/>
                        <div class="row" >
                            <div class="col-md-3 text-right">
                                <strong>Mode of Travel:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblmode" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Accomodation:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblaccomodation" runat="server"></asp:Label></strong>
                            </div>
                        </div>
                        <div class="row" >
                            <div class="col-md-3 text-right">
                                <strong>Transportation Arrangement:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbltransportation" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Meal:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblfooding" runat="server"></asp:Label></strong>
                            </div>
                        </div>


                        <div class="row" id="divflightDetails" runat="server" Visible="false">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Flight Information</u></h4>
                            </div>
                            <div class="clearfix"></div>
                            <fieldset>
                                <legend>Flight Details</legend>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong> Flight Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFlightDate" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong> From (Place):</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFromPlace" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong> To (Place):</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblToPlace" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong> Flight Time/Schedule:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblFlightTime" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                            </fieldset>
                            
                            <div class="clearfix"></div>
                            <fieldset>
                                <legend>Return Flight Details</legend>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong>Return Flight Date:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFlightDate" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong> From (Place):</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFromPlace" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 text-right">
                                        <strong> To (Place):</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnToPlace" runat="server"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong> Flight Time/Schedule:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblReturnFlightTime" runat="server"></asp:Label></strong>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Other Information</u></h4>
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
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <div id="rpt2" runat="server" > </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Authorised By:</strong>
                            </div>
                            <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <div id="rpt" runat="server" > </div>
                            </div>
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>TADA Extention Details</u></h4><br/>
                                <asp:Label runat="server" ID="LblMsg" CssClass="errormsg" />
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-6 form-group">
                                From Date:<span class="errormsg">*</span>
                                <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
                                    ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="reim" />
                                <asp:Label ID="LblDateMsg" runat="server" CssClass="errormsg" />
                                <br />
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"  ontextchanged="txtFromDate_TextChanged" AutoPostBack="true" />
                                <cc1:CalendarExtender ID="ceFromDate" runat="server" 
                                    Enabled="True" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender> 
                            </div>
                            <div class="col-md-6 form-group">
                                 To Date:<span class="errormsg">*</span>
                                <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
                                    ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="reim" />
                                <asp:Label ID="LblDateMsg1" runat="server" CssClass="errormsg" />
                                <br />
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" ontextchanged="txtToDate_TextChanged" AutoPostBack="true" />
                                <cc1:CalendarExtender ID="ceToDate" runat="server" 
                                    Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender> 
                            </div>
                        </div>
                         <div class="row ">
                            <div class="col-md-8 form-group">
                                Remarks:<span class="errormsg">*</span>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!" 
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" />
                            </div>
                        </div>
                        <div class="row ">
                            <div class="col-md-6 form-group">
                                Approved By:<span class="errormsg">*</span>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="DdlApprovedBy" Display="Dynamic" ErrorMessage="Required!" 
                                            SetFocusOnError="True" ValidationGroup="reim" />
                                       
                                <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <div id="divIsAdvance" runat="server" > </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary"  Text="Save" onclick="btnSave_Click" ValidationGroup="reim" />&nbsp;
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back"  onclick="btnBack_Click" />&nbsp;
                        <asp:Button ID="btnDeleteRecord" runat="server" CssClass="btn btn-primary"  Text="Delete" onclick="btnDeleteRecord_Click"/>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
   

            
</asp:Content>

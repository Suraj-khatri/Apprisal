<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.NORMAL.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Jsfunc.js" type="text/javascript"></script>
    <script language="javascript">
        function AutocompleteOnSelected(sender, e) 
        {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnEmpId.ClientID %>");
            hdnEmpId.value = CustodianValueArray[1];
        }
        function GetForwardEmployee(sender, e) {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnForwardEmp.ClientID %>");
            hdnForwardEmp.value = CustodianValueArray[1];
        }
        
        function OnDelete(id) {
            if (confirm("Confirm To Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteNominee.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnEmpId" runat="server" />
    <asp:HiddenField ID="hdnForwardEmp" runat="server" />
    <asp:HiddenField ID="hdnId" runat="server" />    
    <asp:Button ID="btnDeleteNominee" runat="server" Text="Button" onclick="btnDeleteNominee_Click" style="display:none;"/>
     <div class="row">
            <div class="col-md-12">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Training Program Details
                         <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <strong>Training Program Information:</strong>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>Training Category:</label>
                                <asp:Label ID="lblCategory" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Program Type:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblProgramType" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>Conducted By:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblConductedBy" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Program Name:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblProgramName" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>Estimated Cost:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblEstimatedCost" runat="server"></asp:Label>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Start Date:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>End Date:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>No Of Hours:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblNoOfHours" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>No Of Days:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Nominee Within:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblNomineeWithin" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>Total Capacity:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblTotCapacity" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Country:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>City:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Venue:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblVenue" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>Created By:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-2 form-group">                            
                                <label>Created Date:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-2 form-group">                            
                                <label>Status:</label>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2 form-group">                            
                                    <label>Narration:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:Label ID="lblNarration" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <strong>Training File Information:</strong>
                                    <div id="displayFile" runat="server"></div>
                            </div>
                            <div class="form-group">
                                <strong>Nominees Information:</strong>
                                    <div id="displayNomniee" runat="server"></div>
                            </div>
                        </div>
                    </section>
                </div>
         </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master"  AutoEventWireup="true" CodeBehind="Acknowledgement.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement.Acknowledgement" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../CapsLock.js"></script>
    <script type="text/javascript" language="javascript">
        function GetEmpName(sender, e) {
            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpName.ClientID%>").Value = EmpIdArray[1];
        }

    </script>   


    <style type="text/css">

        .note-section
        {
            height:40px;
            padding-left:0px !important;
            background:#CCC;
        }

        .note-section p{
           line-height:40px;
           padding-left:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <asp:Label ID="abc" runat="server"></asp:Label>
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Employee Details
                </header>
                <div class="panel-body">                           
                    <div class="form-group autocomplete-form" >
                        <label>Name Of Appraisee:<span class="errormsg">*</span></label>
                        <asp:Label ID="lblEmpName" runat="server" Font-Bold="True"></asp:Label>
                        <asp:HiddenField ID="hdnEmpName" runat="server" />
                        <br />
                        <asp:TextBox ID="txtEmployee" runat="server" AutoComplete="Off" AutoPostBack="true"
                            OnTextChanged="txtEmployee_TextChanged" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                            CompletionInterval="10" CompletionListCssClass="form-control"
                            DelimiterCharacters="" EnableCaching="true" Enabled="true"
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployee"
                            OnClientItemSelected="GetEmpName">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtEmployee_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtEmployee"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                    <div class="form-group">     
                    <div class="form-group row" >
                        <div class="col-md-3">  <label>Present Location:</label></div>
                        <div class="col-md-3"> <asp:TextBox ID="currentBranch" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Department Name:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentDepartment" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div> 
                       <div class=" form-group row">
                        <div class="col-md-3"> <label>Functional Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentFunctionalTitle" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Corporate Designation:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="currentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div>  
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Date of Joining at SBL:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="dateOfJoining" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        <div class="col-md-3"> <label>Tenure in Present Job:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentBranchDept" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                    </div>   
                       <div class="form-group row">
                        <div class="col-md-3"> <label>Tenure in Present Position:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="timeSpentInTheCurrentPosition" runat="server" CssClass="form-control"  ReadOnly="true"></asp:TextBox></div>
                        
                    </div> 
                         <div class="form-group row ">
                        <div class="col-md-3"> <label>Name and functional designation of Supervisor:</label></div>
                             </br>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFUnctionalDesignationOfSupervisor" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                             </div>
                         <div class="form-group row">
                        <div class="col-md-8"> <label>Name and functional designation of Reviewing Officer:</label></div>
                             </br>
                        <div class="col-md-12"><asp:TextBox ID="nameAndFunctionalDesignationOfReviewingOfficer" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                             </div>

                        <div class="form-group row">
                        <div class="col-md-3"> <label>Performance Agreement effective From:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                        <div class="col-md-3"> <label>Performance Agreement effective To:</label></div>
                        <div class="col-md-3"><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"  ></asp:TextBox></div>
                    </div>  
                    </div>      
                   </div>
                 </section>
            <ul class="nav nav-tabs">
                <li><a href="KRAKPI.aspx">KRA /KPI</a></li>
                <li><a href="CriticalJobs.aspx">Critical jobs</a></li>
                <li><a href="PerformanceRating.aspx">Performance Rating</a></li>
                <li  class="active"><a href="Acknowledgement.aspx">Acknowledgement</a></li>
            </ul>


            <div class="tab-content">            
                <div id="acknowledgement" class="tab-pane active">
                    <section class="panel container">
                    <div class="panel-heading"> Aknowledgement  </div> 
                           <div class="form-group row">
                            <div class="col-md-12"  ><asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox><label>I ACKNOWLEDGE AND AGREE TO THE ALL THE POINTS MENTIONED IN THIS AGREEMENT</label></div>
                               </div>
                          <div class="form-group container">                                   
                            <div class="col-md-6 note-section row"><p>Note:Should be done by the Appraisee</p></div>                       
                        </div>                              
                         <div class="form-group row">
                            <div class="col-md-12"  ><label><asp:CheckBox ID="chkAck" runat="server"></asp:CheckBox>I ACKNOWLEDGE AND AGREE TO THE ALL THE POINTS MENTIONED IN THIS AGREEMENT</label></div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-12"  ><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="50%"></asp:TextBox></div>
                        </div>
                        <div class="form-group container">
                            <div class="col-md-6 note-section row"><p>Note:Should be done by the Reviewing Officer</p></div>
                        </div>
                         <div class="form-group row">
                            <div class="col-md-12"  ><label><asp:CheckBox ID="chkHr" runat="server"></asp:CheckBox>I Acknowledge the points mentioned in the agreement</label></div>
                       </div>
                        <div  class="form-group row">
                            <div class="col-md-12"  ><asp:TextBox ID="txtHr" runat="server" TextMode="MultiLine" Width="50%"></asp:TextBox></div>
                        </div>
                        <div class="form-group container">
                            <div class="col-md-6 note-section row"  >Note: Should be done by the Head of HR Department</div>
                        </div>
                </section>
                </div>
            </div>
        </div>
    </div>

</asp:Content>



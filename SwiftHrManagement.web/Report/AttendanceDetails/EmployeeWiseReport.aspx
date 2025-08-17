<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EmployeeWiseReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.EmployeeWiseReport" Title="Swift HRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
     <style type="text/css">
            .style10
            {
                color:#666666;           
            }
     </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                               </font></strong>
                               <font size="-1"><strong>
                             <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong>
                                </font>
                                <font size="-1"><strong>
                                   <strong><span class="style10"> Attendence Report For : 
                                        </span><br />
                                         Employee Name :</strong> 
                                        <asp:Label ID="lblEmployeeName"  runat="server"></asp:Label> <br />
                                        <strong>From Date :</strong> <asp:Label ID="DateFrom"  Text="test it " runat="server"></asp:Label> <strong>To :</strong> 
                                         <asp:Label ID="DateTo"  runat="server"></asp:Label> 
                                     </strong></font>
                            </div>
                            <div id="rptDiv" runat="server"></div>   
                        </div>
                    </section>
                </div>
            </div>
            <asp:HiddenField ID="Hdnflag" runat="server" />
        </div>
    </div>

</asp:Content>

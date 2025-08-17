<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="employeeHistory.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.employeeHistory" Title="Swift HR Management System 1.0" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <%
        DataSet ds = populatedata(this.empId);
        DataTable dt = new DataTable();
        DataTable emp = ds.Tables[0];
        DataTable EmpFrist = ds.Tables[1];
    %>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel ">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    EMPLOYEE RECORD CARD
                </header>
             </section>
            <section class="panel panel-default">
                        <header class="panel-heading">

                                <strong>Personal Profile</strong>
                        </header>
                    <div class="panel-body">
                             <div class=" col-md-6 form-group">
                                    <label>Employee Code:</label>
                                    <%=emp.Rows[0]["EMP_CODE"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Date Of Birth (DOB): </label>
                                <%=emp.Rows[0]["BIRTH_DATE"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Full Name:</label>
                                <%=emp.Rows[0]["EmpName"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Gender:</label>
                                <%=emp.Rows[0]["Gender"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Marital Status:</label>
                                <%=emp.Rows[0]["MaritialStatus"].ToString()%>
                             </div>
                            <div class="col-md-6 form-group">
                                <label>Branch Name:</label>
                                <%=emp.Rows[0]["BranchName"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Department:</label>
                                <%=emp.Rows[0]["Department"].ToString()%>
                            </div>
                            <div class=" col-md-6 form-group">
                                <label>Position:</label>
                                <%=emp.Rows[0]["Position"].ToString()%>
                            </div>
                     
                            <div class=" col-md-6 form-group">
                                <label>Blood Group:</label>
                                <%=emp.Rows[0]["BloodGroup"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Pan Number:</label>
                                <%=emp.Rows[0]["PAN_NUMBER"].ToString()%>
                            </div>
                      
                            <div class="col-md-6 form-group">
                                <label>Date of Appointment (DOA):</label>
                                <%=emp.Rows[0]["APPOINTMENT_DATE"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Date of Joining (DOJ):</label>
                                <%=emp.Rows[0]["JOINED_DATE"].ToString()%>
                            </div>
                            <div class=" col-md-6 form-group">
                                <label>Employee Type:</label>
                                <%=emp.Rows[0]["EmpType"].ToString()%>
                            </div>
                            <div class="col-md-6 form-group">
                                <label>Employee Status:</label>
                                <%=emp.Rows[0]["EmpStatus"].ToString()%>
                            </div>
                   </div>
                 </section>
            <section class="panel panel-default">
                        <header class="panel-heading">
                                    <strong>Address Information</strong>
                        </header>
                            <div class="panel-body">
                                    <div class="col-md-6 form-group">
                                        <label>Permanent Address:</label>
                                        <%=EmpFrist.Rows[0]["PER_STREET_NAME"].ToString()%> | <%=EmpFrist.Rows[0]["PerDistrict"].ToString()%> | <%=EmpFrist.Rows[0]["PerCountry"].ToString()%>
                                    </div>
                       
                                    <div class="col-md-6 form-group">
                                        <label>Municipality/VDC:</label>
                                        <%=EmpFrist.Rows[0]["PER_MUNICIPALITY_VDC"].ToString()%>  <%=EmpFrist.Rows[0]["PER_WARD_NO"].ToString()%>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label>Temporary Address:</label>
                                        <%=EmpFrist.Rows[0]["TEMP_STREET_NAME"].ToString()%> | <%=EmpFrist.Rows[0]["TempDistrict"].ToString()%>|<%=EmpFrist.Rows[0]["TempCountry"].ToString()%>
                                    </div>
                        
                                    <div class="col-md-6 form-group">
                                        <label>Municipality/VDC:</label>
                                        <%=EmpFrist.Rows[0]["TEMP_MUNICIPALITY_VDC"].ToString()%>
                                    </div>
                              </div>
                     </section>

            <section class="panel panel-default">
                         <header class="panel-heading">
                                <strong>Contact Information</strong>
                        </header>
                        <div class="panel-body">
                                <div class=" col-md-6 form-group">
                                    <label>Phone(office):</label>
                                    <%=EmpFrist.Rows[0]["OFFICE_PHONE"].ToString()%> 
                              </div>
                                <div class="col-md-6 form-group">
                                    <label>Phone(Mobile):</label>
                                    <%=EmpFrist.Rows[0]["PERSONAL_MOBILE"].ToString()%>
                                </div>
                       
                                <div class="col-md-6 form-group">
                                    <label>Email:</label>
                                    <%=EmpFrist.Rows[0]["PERSONAL_EMAIL"].ToString()%>
                                </div>
                        </div>
                 </section>
            <section class="panel panel-default">
                    <header class="panel-heading">
                                <strong>Emergency Contact Information</strong>
                     </header>
                        <div class="panel-body">
                            <div class="col-md-6 form-group">
                                <label>Contact Person:</label>
                                <%=EmpFrist.Rows[0]["EM_NAME"].ToString()%>
                            </div>
                        
                            <div class="col-md-6 form-group">
                                <label>Relationship:</label>
                                <%=EmpFrist.Rows[0]["EmRelationship"].ToString()%>
                            </div>
                       
                            <div class="col-md-6 form-group">
                                <label>Address:</label>
                                <%=EmpFrist.Rows[0]["EM_ADDRESS"].ToString()%>
                            </div>
                        
                            <div class="col-md-6 form-group">
                                <label>Phone:</label>
                                <%=EmpFrist.Rows[0]["EM_CONTACTNO1"].ToString()%>
                            </div>
                        
                            <div class="col-md-12 form-group">
                                <label>Email:</label>
                                <%=EmpFrist.Rows[0]["EM_EMAIL"].ToString()%>
                            </div>
                    </div>
                        </section>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-12 form-group">
                        <div id="rptDiv1" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv2" runat="server"></div>
                    </div>
                    <div class=" col-md-12 form-group">
                        <div id="rptDiv3" runat="server"></div>
                    </div>

                    <div class=" col-md-12 form-group">
                        <div id="rptDiv4" runat="server"></div>
                    </div>

                    <div class=" col-md-12 form-group">
                        <div id="rptDiv5" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv6" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv7" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv8" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv9" runat="server"></div>
                    </div>

                    <div class="col-md-12 form-group">
                        <div id="rptDiv10" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

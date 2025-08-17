<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageFamilyMembers.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageFamilyMembers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>   <a href="ListFamilyMembers.aspx?Id=<%=GetEmpId().ToString()%>">List Family Member  </a> &raquo; Manage Family Member 
            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            Please enter valid data!
            <span class="required">(* Required fields!) </span>
            <br />
            <div>
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnempid" runat="server" />
                 <h2>Personal Information</h2>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            Select Relation:<span class="errormsg">*</span>
                        </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ControlToValidate="DdlRelation" Display="Dynamic"
                            ErrorMessage="Required!" ValidationGroup="family" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                        <asp:DropDownList ID="DdlRelation" runat="server" CssClass="form-control" ValidationGroup="family">
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-4 form-group">
                        <label>
                            First Name:<span class="errormsg">*</span>
                        </label>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Required!" ControlToValidate="TxtFirstName" Display="Dynamic"
                            SetFocusOnError="True" ValidationGroup="family"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="TxtFirstName" runat="server" CssClass="form-control" ValidationGroup="family"></asp:TextBox>
                    </div>

                    <div class="col-md-4 form-group">
                        <label>
                            Middle Name:
                        </label>
                        <asp:TextBox ID="TxtMiddleName" runat="server" CssClass="form-control" ValidationGroup="family"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            Last Name:
                        </label>
                        <span class="errormsg">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="Required!" ControlToValidate="TxtLastName" Display="Dynamic"
                            SetFocusOnError="True" ValidationGroup="family"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control" ValidationGroup="family"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Gender:
                        </label>
                        <%--    <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ErrorMessage="Required!" ControlToValidate="DdlGender" Display="Dynamic" 
                  SetFocusOnError="True" ValidationGroup="family"></asp:RequiredFieldValidator>--%>
                        <br />
                        <asp:DropDownList ID="DdlGender" runat="server" CssClass="form-control" ValidationGroup="family">
                        </asp:DropDownList>

                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Date Of Birth:<span class="errormsg">*</span>
                        </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required!" ControlToValidate="TxtDateOfBirth" Display="Dynamic"
                            SetFocusOnError="True" ValidationGroup="family"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="TxtDateOfBirth" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="TxtDateOfBirth_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="TxtDateOfBirth">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            Marital Status:
                        </label>

                        <asp:DropDownList ID="DdlMaritalStatus" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Blood Group:
                        </label>

                        <asp:DropDownList ID="DdlBloodGroup" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Mobile Number:
                        </label>

                        <asp:TextBox ID="TxtMobileNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            Passport Number:
                        </label>
                        <asp:TextBox ID="TxtPassportNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Citizen (Country):
                        </label>

                        <asp:TextBox ID="TxtNationality" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Citizenship Number:
                        </label>

                        <asp:TextBox ID="TxtnationalityNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>
                            Issue Date: 
                        </label>
                        <asp:TextBox ID="txtIssueDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtIssueDate">
                        </cc1:CalendarExtender>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>
                            Current Address:
                        </label>
                        <asp:TextBox ID="TxtCurrentAddress" runat="server"
                            TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>

                    <div class="row"  runat="server" id="familyFileUpload">
               
                        <div class="col-md-4 form-group">
                            <label>
                                File Description:<span class="errormsg">*</span>
                            </label>

                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="TxtFileDescription" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="family"></asp:RequiredFieldValidator>--%>
                            <br />
                            <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                   
                        <div class="col-md-4 form-group">
                            <label>
                                Select File:<span class="errormsg">*</span>
                            </label>

                            <br />
                            <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" class="inputTextBoxLP" />
                        </div>
                    </div>

                    <asp:HiddenField runat="server" ID="familyFileName" />
                    <asp:Panel ID="pnlDisplayFile" runat="server" Visible="false">
                        <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                File Desc.:
                  
                            </label>
                            <asp:Label ID="lblFileDesc" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                View File:
                            </label>
                            <asp:Label ID="lblFileType" runat="server"></asp:Label>
                            <asp:Label ID="lblLink" runat="server"></asp:Label>
                        </div>
                            </div>
                    </asp:Panel>


                    <div id="detail" runat="server">
                    </div>

                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Occupaton:
                            </label>
                            <asp:DropDownList ID="Ddloccupation" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Status:
                            </label>

                            <asp:DropDownList ID="Ddlstatus" runat="server" CssClass="form-control" Width="205px">
                                <asp:ListItem Value="Working">Working</asp:ListItem>
                                <asp:ListItem Value="Retired">Retired</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Work Information ( Only if relative is a working professional )</label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Employer:
                            </label>

                            <asp:TextBox ID="TxtEmployer" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Designation:
                            </label>

                            <asp:TextBox ID="TxtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Office Phone:
                            </label>

                            <asp:TextBox ID="TxtOfficePhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Office Email:
                            </label>

                            <asp:TextBox ID="TxtOfficeEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="TxtOfficeEmail"
                                ErrorMessage="Invalid Email!"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Employer Address:
                            </label>

                            <asp:TextBox ID="TxtEmployerAddress" runat="server" Width="433px" Height="50px"
                                TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row">
                      <div class="col-md-12"><label>Insurance Information</label></div>
                <div class="col-md-4 form-group">
                    <label>
                        Insurer:
                    </label>

                    <asp:TextBox ID="TxtInsurer" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Insurance Policy:
                            </label>

                            <asp:TextBox ID="TxtInsurancePolicy" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Insurance Expiry Date:
                            </label>

                            <asp:TextBox ID="TxtInsurancePolicyExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtInsurancePolicyExpiryDate_CalendarExtender"
                                runat="server" Enabled="True" TargetControlID="TxtInsurancePolicyExpiryDate">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Study Information ( Only if relative is a student )</label>
                        </div>
                <div class="col-md-4 form-group">
                    <label>
                        Study Center Name:
                    </label>
                    <asp:TextBox ID="TxtStudyCenter" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Name Of Course:
                            </label>

                            <asp:TextBox ID="TxtNameOfCourse" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Level Of Study:
                        
                            </label>
                            <asp:TextBox ID="TxtLevelOfStudy" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                                Study Center Phone:
                            </label>
                            <asp:TextBox ID="TxtStudyCenterPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Study Center Email:
                            </label>
                            <asp:TextBox ID="TxtStudyCenterEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="TxtStudyCenterEmail"
                                ErrorMessage="Invalid Email!"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Study Center Address:
                            </label>
                            <asp:TextBox ID="TxtStudyCenterAddress" runat="server" Width="549px"
                                TextMode="MultiLine" Height="50px" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                <div class="form-group">
                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                        OnClick="BtnSave_Click" ValidationGroup="family" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnDelete_Click" Text="Delete"  />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnBack_Click" Text="Back" />
                </div>
                </div>
            </div>
    </div>
</asp:Content>




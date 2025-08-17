<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="EducationDetails.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.EducationDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <div class="panel">
        <header class="panel-heading">
               <i class="fa fa-caret-right"></i><a href="ViewEducation.aspx?Id=<%=GetEmpId().ToString()%>">List Education </a> &raquo; Manage Education
            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
        </header>
        <div class="panel-body">
            <span class="txtlbl"> Plese enter valid data!</span><br/>                  
            <span class="required"> (* Required Fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            <div class="row">
                 <asp:TextBox ID="txtEmpId" runat="server" Visible="false"></asp:TextBox>
                <div class="col-md-4 form-group">
                    <label>
                         Degree: <span class="errormsg">*</span>
                    </label>
                   <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtDegree" Display="Dynamic" 
                                    ErrorMessage="Required!" ValidationGroup="education" 
                                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="txtDegree" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Level:
                    </label>
                   
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="ddllevel" Display="Dynamic" ErrorMessage=" Required!" 
                                    ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                &nbsp;<asp:Label ID="Label1" runat="server" CssClass="required" Text="*"></asp:Label><br />
                                <asp:DropDownList ID="ddllevel" runat="server"  CssClass="form-control">
                                </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        Division:
                    </label>
                    
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                  ControlToValidate="ddlDivision" Display="Dynamic" ErrorMessage=" Required!" 
                                  ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator>
                              &nbsp;<asp:Label ID="Label3" runat="server" CssClass="required" Text="*"></asp:Label><br />
                              <asp:DropDownList ID="ddlDivision" runat="server"  CssClass="form-control" Width="100%">
                              </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Faculty: <span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator 
                                  ID="RequiredFieldValidator8" runat="server" 
                                  ControlToValidate="ddlfaculty" Display="Dynamic" 
                                  ErrorMessage="Required!" ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                              <asp:DropDownList ID="ddlfaculty" runat="server"  CssClass="form-control">                                
                              </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Percentage:
                    </label>
                   
                               <asp:Label ID="Label4" runat="server" CssClass="required" Text="*"></asp:Label>
                               &nbsp;
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                  ControlToValidate="txtPercentage" Display="Dynamic" ErrorMessage="Required!" 
                                  ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                   ControlToValidate="txtPercentage" ErrorMessage="Enter 0 to 100" 
                                   MaximumValue="100" MinimumValue="0.01" Type="Double" 
                                   ValidationGroup="education" SetFocusOnError="True" Display="Dynamic"></asp:RangeValidator>&nbsp;<br />

                            <asp:TextBox ID="txtPercentage" runat="server" CssClass="form-control" 
                                   MaxLength="10"></asp:TextBox>
                             <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                 ControlToValidate="txtPercentage" Display="Dynamic" 
                                    ErrorMessage="Invalid Percentage!" SetFocusOnError="True" Type="Double"
                                        ValidationGroup="education"></asp:CompareValidator>          
                </div>
                <div class="col-md-4 form-group">
                    <label>
   Passed year:
                    </label>
                  
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                  ControlToValidate="ddlPassedYear" Display="Dynamic" ErrorMessage="Required!" 
                                  ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                              &nbsp;<asp:Label ID="Label5" runat="server" CssClass="required" Text="*"></asp:Label><br />
                              <asp:DropDownList ID="ddlPassedYear" runat="server"  CssClass="form-control">
                                    <asp:ListItem Value="">Select Year</asp:ListItem>
                                    <asp:ListItem>Before 1950</asp:ListItem>
                                    <asp:ListItem>1951</asp:ListItem>
                                    <asp:ListItem>1952</asp:ListItem>
                                    <asp:ListItem>1953</asp:ListItem>
                                    <asp:ListItem>1954</asp:ListItem>
                                    <asp:ListItem>1955</asp:ListItem>
                                    <asp:ListItem>1956</asp:ListItem>
                                    <asp:ListItem>1957</asp:ListItem>
                                    <asp:ListItem>1958</asp:ListItem>
                                    <asp:ListItem>1959</asp:ListItem>
                                    <asp:ListItem>1960</asp:ListItem>
                                    <asp:ListItem>1961</asp:ListItem>
                                    <asp:ListItem>1962</asp:ListItem>
                                    <asp:ListItem>1963</asp:ListItem>
                                    <asp:ListItem>1964</asp:ListItem>
                                    <asp:ListItem>1965</asp:ListItem>
                                    <asp:ListItem>1966</asp:ListItem>
                                    <asp:ListItem>1967</asp:ListItem>
                                    <asp:ListItem>1968</asp:ListItem>
                                    <asp:ListItem>1969</asp:ListItem>
                                    <asp:ListItem>1970</asp:ListItem>
                                    <asp:ListItem>1971</asp:ListItem>
                                    <asp:ListItem>1972</asp:ListItem>
                                    <asp:ListItem>1973</asp:ListItem>
                                    <asp:ListItem>1974</asp:ListItem>
                                    <asp:ListItem>1975</asp:ListItem>
                                    <asp:ListItem>1976</asp:ListItem>
                                    <asp:ListItem>1977</asp:ListItem>
                                    <asp:ListItem>1978</asp:ListItem>
                                    <asp:ListItem>1979</asp:ListItem>
                                    <asp:ListItem>1980</asp:ListItem>
                                    <asp:ListItem>1981</asp:ListItem>
                                    <asp:ListItem>1982</asp:ListItem>
                                    <asp:ListItem>1983</asp:ListItem>
                                    <asp:ListItem>1984</asp:ListItem>
                                    <asp:ListItem>1985</asp:ListItem>
                                    <asp:ListItem>1986</asp:ListItem>
                                    <asp:ListItem>1987</asp:ListItem>
                                    <asp:ListItem>1988</asp:ListItem>
                                    <asp:ListItem>1989</asp:ListItem>
                                    <asp:ListItem>1990</asp:ListItem>
                                    <asp:ListItem>1991</asp:ListItem>
                                    <asp:ListItem>1992</asp:ListItem>
                                    <asp:ListItem>1993</asp:ListItem>
                                    <asp:ListItem>1994</asp:ListItem>
                                    <asp:ListItem>1995</asp:ListItem>
                                    <asp:ListItem>1996</asp:ListItem>
                                    <asp:ListItem>1997</asp:ListItem>
                                    <asp:ListItem>1998</asp:ListItem>
                                    <asp:ListItem>1999</asp:ListItem>
                                    <asp:ListItem>2000</asp:ListItem>
                                    <asp:ListItem>2001</asp:ListItem>
                                    <asp:ListItem>2002</asp:ListItem>
                                    <asp:ListItem>2003</asp:ListItem>
                                    <asp:ListItem>2004</asp:ListItem>
                                    <asp:ListItem>2005</asp:ListItem>
                                    <asp:ListItem>2006</asp:ListItem>
                                    <asp:ListItem>2007</asp:ListItem>
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                              </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         Name of Institution:
                    </label>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                   ControlToValidate="txtnameofinstitution" Display="Dynamic" ErrorMessage=" Required!" 
                                   ValidationGroup="education" SetFocusOnError="True"></asp:RequiredFieldValidator>
                               &nbsp;<asp:Label ID="Label6" runat="server" CssClass="required" 
                                   Text="*"></asp:Label><br />
                              <asp:TextBox ID="txtnameofinstitution" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          County:
                    </label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                  ControlToValidate="ddlcountry" Display="Dynamic" ErrorMessage=" Required!" 
                                  ValidationGroup="education" 
                                  SetFocusOnError="True"></asp:RequiredFieldValidator>
                              &nbsp;<asp:Label ID="Label7" runat="server" CssClass="required" Text="*"></asp:Label><br />
                            <asp:DropDownList ID="ddlcountry" runat="server"  CssClass="form-control">                                   
                            </asp:DropDownList>
                </div>
                
            </div>

             <asp:Button ID="btnSave0" runat="server" CssClass="btn btn-primary" 
                                  OnClick="btnSave_Click" Text="Save" ValidationGroup="education" 
                                 />
                              <cc1:ConfirmButtonExtender ID="btnSave0_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave0">
                              </cc1:ConfirmButtonExtender>
                              
                              <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                  onclick="BtnDelete_Click" Text="Delete" />
                              <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                  ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                              </cc1:ConfirmButtonExtender>
                              <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                  onclick="BtnBack_Click" Text=" Back" />
        </div>
    </div>

</asp:Content>


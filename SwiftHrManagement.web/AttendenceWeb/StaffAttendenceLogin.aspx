<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjectMaster.Master" CodeBehind="StaffAttendenceLogin.aspx.cs" Inherits="SwiftHrManagement.web.StaffAttendenceLogin" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:HiddenField ID="hdnUserName" runat="server" />
<asp:HiddenField ID="hdnUserPassword" runat="server" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
           <div class="row">
               <div class="col-md-6 col-md-offset-3">
                   
             
               <div align="center"><asp:Label ID="Lblstatus" runat="server" ForeColor="#993300" style="font-weight: 900;font-size:15px;"></asp:Label><br />
       <div id="OT_div" visible="false" runat="server">You are eligible for OT, Click here to request:&nbsp; <a href="../OverTime/ManageRequestingOverTime.aspx">Request OT</a>
       </div>
       </div>
             <asp:Label ID="lblmsg" runat="server" ForeColor="#993300" 
                    style="font-weight: 900; font-size:15px;"></asp:Label>
             <asp:Panel ID="pnlLogin" runat="server"  Visible="true"> 
           <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            <span class="LoginLable"> HR ATTENDANCE </span><span class="LoginLable1">   Login </span>
        </header>
                 
        <div class="panel-body">
            <div class="form-group">            
                    <label>User name:</label>
                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ControlToValidate="txtEmployeeName" 
                        ErrorMessage="Please Enter Valid Username!!" ValidationGroup="att"></asp:RequiredFieldValidator>
               </div>
                <div class="form-group">
                    <label>
                         HTTP_X_FORWARDED_FORPassword:
                    </label>
                   
                    <asp:TextBox ID="txtEmployeePassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                                    <td class="style15"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtEmployeePassword" 
                                            ErrorMessage="Please Enter Valid Password!!" ValidationGroup="att"></asp:RequiredFieldValidator>
                </div> <div class="form-group">
                      <asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-primary" Text="Login" onclick="btnLogIn_Click" ValidationGroup="att"/>&nbsp;
                    <asp:Button ID="btnLogOut" runat="server" CssClass="btn btn-primary" Text="Logout" onclick="btnLogOut_Click" ValidationGroup="att"/>
             </div>
                    <label>
Current System Date & Time: <asp:Label ID="lblServerTIme" runat="server" ForeColor="#666600" CssClass="txtlbl"></asp:Label>
                    </label>
               
               </div>
        </div>
                        </asp:Panel>
    
             <!--################ LOGINREMARK REASON--> 
            <asp:Panel ID="InLoginRemark" runat="server" Visible="false" >
         <div class="panel">
        <header class="panel-heading">
             <asp:Label ID="Lblloginreason" runat="server" Text=""></asp:Label>
        </header>
        <div class="panel-body">
           
                <div class="form-group">
                    <label>
                         Reason Type :<span class="errormsg">*</span> 
                    </label>
                   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required"
           ControlToValidate="DdlReasonType" ValidationGroup="Reason"   SetFocusOnError="True" > 
        </asp:RequiredFieldValidator>
           <asp:DropDownList ID="DdlReasonType" runat="server" CssClass="form-control" 
           ></asp:DropDownList> 
                </div>
                <div class="form-group">
                    <label>
 Reason Description :<span class="errormsg">*</span>
                    </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
            ControlToValidate="txtBoxDetails" ValidationGroup="Reason"   SetFocusOnError="True" >
            </asp:RequiredFieldValidator><br />
           <asp:TextBox ID="txtBoxDetails" runat="server" CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>
                </div>
            <br/>
            <asp:Button ID="BtnLogIN1" runat="server" CssClass="btn btn-primary" Text="LOGIN" 
            ValidationGroup="Reason" onclick="BtnLogIN1_Click" />&nbsp;
            <asp:Button ID="BtnLogOut1"
                runat="server" CssClass="btn btn-primary" ValidationGroup="Reason" Text="LOGOUT" 
                onclick="BtnLogOut1_Click" />
        </div>
    </div>
        </asp:Panel>
     
         
      

    <!--################ LOGINREMARK REASON-->
           <asp:Panel ID="OtRequest" runat="server" Visible="false">
     <div class="panel">
        <header class="panel-heading">
             Logout &amp; Overtime detail
        </header>
        <div class="panel-body">
            <asp:Label ID="lblLogutMsg" runat="server"></asp:Label>
            <asp:TextBox ID="txtEmpId" runat="server" Visible="false"></asp:TextBox>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
LOGIN TIME: <asp:Label ID="lblLoginTime" runat="server"></asp:Label>
                    </label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                        LOGOUT TIME: <asp:Label ID="lblLogoutTime" runat="server"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                         ACTUAL LOGIN TIME: <asp:Label ID="lblActualLoginTime" runat="server"></asp:Label>
                    </label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          ACTUAL LOGOUT TIME: <asp:Label ID="lblActualLogoutTime" runat="server"></asp:Label>
                    </label>
                </div>
            </div>
             <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                          OT FROM TIME: <asp:Label ID="lblOTfromTime" runat="server"></asp:Label>
                    </label>
                </div>
                <div class="col-md-4 form-group">
                    <label>
  
                    OT TO TIME: <asp:Label ID="lblOTtoTime" runat="server"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
                        OT Hours: <asp:Label ID="lblOTHours" runat="server"></asp:Label>
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
 Apply OT From:
                    </label>
                  
            <asp:TextBox ID="txtFromTime" runat="server"  CssClass="form-control"></asp:TextBox>
              <cc1:CalendarExtender ID="txtFromTime_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtFromTime">
              </cc1:CalendarExtender>
            <asp:DropDownList ID="ddlhourin" runat="server" CssClass="form-control" 
                Width="100px" onselectedindexchanged="ddlhourin_SelectedIndexChanged" AutoPostBack="true">
              
            </asp:DropDownList>
            <asp:DropDownList ID="ddlminutein" runat="server" CssClass="form-control" 
                Width="100px" onselectedindexchanged="ddlminutein_SelectedIndexChanged" AutoPostBack="true">
              
          </asp:DropDownList>
          <asp:Label ID="Label3" runat="server" CssClass="required" Text="*"></asp:Label>
            <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                ControlToValidate="ddlhourin" Display="Dynamic" ErrorMessage="*" InitialValue="" 
                SetFocusOnError="True"  ValidationGroup="back"  ></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                ControlToValidate="ddlminutein" Display="Dynamic" ErrorMessage="*" 
                InitialValue="" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>
 Apply OT To:
                    </label>
                   
          <asp:TextBox ID="txtToTime" runat="server"  CssClass="form-control"></asp:TextBox> 
              <cc1:CalendarExtender ID="txtToTime_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtToTime">
              </cc1:CalendarExtender>
            <asp:DropDownList ID="ddlhourout" runat="server" CssClass="form-control" 
                width="100px" onselectedindexchanged="ddlhourout_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="form-control" 
                Width="100px" onselectedindexchanged="ddlminuteout_SelectedIndexChanged" AutoPostBack="true">             
          </asp:DropDownList>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                          Apply OT Hours:
                    </label>
                 
            <asp:TextBox ID="txtApplyOtHour" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label>
  Apply OT:
                    </label>
                   <asp:DropDownList ID="ddlOTApply" runat="server" CssClass="form-control">
            <asp:ListItem Value="">Select</asp:ListItem>
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N">No</asp:ListItem>
            </asp:DropDownList> <span class="required">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
           ControlToValidate="ddlOTApply" ValidationGroup="ot"   SetFocusOnError="True" > 
        </asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Recommend By: 
                    </label>
                   
        <asp:DropDownList ID="ddlRecommendedBY" runat="server" CssClass="form-control"></asp:DropDownList> 
                </div>
                <div class="col-md-4 form-group">
                    <label>
                         Approve By: 
                    </label>
                   
        <asp:DropDownList ID="ddlApprovedBy" runat="server" CssClass="form-control"></asp:DropDownList> 
                </div>
                 <div class="col-md-4 form-group">
                Remarks:
            <asp:TextBox ID="txtRemarks" runat="server"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required"
           ControlToValidate="txtRemarks" ValidationGroup="ot"   SetFocusOnError="True" > 
        </asp:RequiredFieldValidator>
            </div>
</div>
            <asp:Button ID="btnLogoutOT" runat="server" CssClass="btn btn-primary" Text="LOGOUT" 
            ValidationGroup="ot" onclick="btnLogoutOT_Click"  />
        </div>
    </div>

  
</asp:Panel>
                    </div>
           </div>
       </ContentTemplate>
     
</asp:UpdatePanel>
</asp:Content>

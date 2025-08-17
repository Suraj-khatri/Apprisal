<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingNeedAssessment.Manage"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style10
        {
            font-size: large;
            font-weight: bold;
        }
        .style11
        {
            height: 33px;
        }
        </style>
        <script type="text/javascript">

            function AutocompleteOnSelected(sender, e) {
                var customerValueArray = (e._value).split("|");
                document.getElementById("<%=txtHdnEmpId.ClientID %>").value = customerValueArray[1];
            }
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   

<table width="980" border="0" cellspacing="3" cellpadding="3">
  <tr>
    <td><div align="center" class="style10">Training Needs Assessment (TNA)</div></td>
    <td width="150px" align="right"><img src="../../Images/megaLogo.jpg"/></td>
  </tr>
  <tr>
    <td colspan="2"><em><b>A Training Needs Assessment is being carried out to determine the various training that is required by the staff at Mega Bank Nepal Limited. 
    Results obtained from this form will be used as a basis to identify and prioritize different types of training to help develop a Training Calender. 
    Please answer these questions.</b></em></td>
  </tr>
</table>
<br />

<table>
    <tr>
        <td>
        <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
            <asp:TextBox ID="txtHdnEmpId" runat="server" style="display:none;"></asp:TextBox>
        
        </td>
        
    </tr>
    <tr>
        <td>
        <table align="left" border="1" cellspacing="1" cellpadding="5" class="FormDesign">        
            <tr>
                <td>&nbsp;</td>
                <td nowrap="nowrap"><div align="right">Name:</div></td>
                <td>
                <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True"></asp:DropDownList>
                       
                        <div id ="showEmp" runat="server" visible="false">
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="inputTextBoxLP1" 
                                Width="400px" AutoPostBack="true" ontextchanged="txtEmployee_TextChanged">
                        </asp:TextBox>
                        <cc1:textboxwatermarkextender ID="TextBoxWatermarkExtender1" 
                        runat="server" Enabled="True" TargetControlID="txtEmployee" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:textboxwatermarkextender>

                        <cc1:autocompleteextender ID="AutoCompleteExtender1" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                        MinimumPrefixLength="1"  OnClientItemSelected="AutocompleteOnSelected"
                        ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="txtEmployee">
                        </cc1:autocompleteextender>
                        </div>
                    
                        
                         </td>
                <td><div align="right">Job Title/Position:</div></td>
                <td><asp:DropDownList ID="DdlEmpPosition" runat="server" CssClass="CMBDesign"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><div align="right">Branch Name:</div></td>
                <td><asp:DropDownList ID="DdlBranchName" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
                <td><div align="right">Department:</div></td>
                <td><asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><div align="right">Immediate Supervisor :</div></td>
                <td><asp:DropDownList ID="DdlISupName" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
                <td><div align="right">Position:</div></td>
                <td><asp:DropDownList ID="DdlISupPosition" runat="server" CssClass="CMBDesign"></asp:DropDownList> </td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td><div align="right" style="display:none">Immediate Subrdinate :</div></td>
                <td><asp:DropDownList ID="DdlISubName" runat="server" CssClass="CMBDesign" style="display:none"></asp:DropDownList> </td>
                <td><div align="right" style="display:none">Position:</div></td>
                <td><asp:DropDownList ID="DdlISubPosition" runat="server" CssClass="CMBDesign" style="display:none"></asp:DropDownList> </td>
            </tr>
            <tr>
                <th>1.</th>
                <th colspan="4">What is the overall purpose and objective of this position (Why does this position exist?) </th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:TextBox ID="ans_1" runat="server" TextMode="MultiLine" width="930px"></asp:TextBox> </td>
            </tr>
            <tr>
                <th>2.</th>
                <th colspan="4">State the total number of years of work experience that you have.</th>
            </tr>
            <tr>
                <td class="style11"></td>
                <td colspan="3" class="style11">(a) Work experience at Mega Bank in the present position.</td>
                <td class="style11"><asp:TextBox ID="ans_2_a" runat="server"></asp:TextBox> </td>        
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">(b) Work experience at other Banks in similar responsibilities.</td>
                <td><asp:TextBox ID="ans_2_b" runat="server"></asp:TextBox> </td>        
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">(c) Other experiences.</td>
                <td><asp:TextBox ID="ans_2_c" runat="server"></asp:TextBox> </td>        
            </tr>
            <tr>
                <th>3.</th>
                <th colspan="4">Education: Check the box that indicates the educational qulification(s) that you possess.</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:CheckBox ID="ans_3_master" runat="server"/>Master Degree</td>
                <td><asp:CheckBox ID="ans_3_bachelor" runat="server" />Bachelors Degree </td>
                <td><asp:CheckBox ID="ans_3_special" runat="server" />Special Degree (Specify): <asp:TextBox ID="ans_3_special_degree" runat="server" CssClass="txtTextBox"></asp:TextBox> </td>
                <td><asp:CheckBox ID="ans_3_prof" runat="server" />Professional License (Specify): <asp:TextBox ID="ans_3_prof_degree" runat="server" CssClass="txtTextBox"></asp:TextBox> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:CheckBox ID="ans_3_Other" runat="server" /> Any Others (Specify): <asp:TextBox ID="ans_3_other_degree" runat="server" CssClass="txtTextBox"></asp:TextBox></td>
            </tr>
            <tr>
                <th>4.</th>
                <th colspan="4">List in order of importance the major responsibilities of the job and 
                the regularity with which these are perfomred (daily,weekly,monthly,annually etc).</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    <table class="TBL" width="950px">
                        <tr>
                            <th>SN</th>
                            <th>General Responsibilities</th>
                            <th>Daliy</th>
                            <th>Weekly</th>
                            <th>Monthly</th>
                            <th>Annually</th>
                            <th>&nbsp;</th>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:TextBox ID="txtResponsibilty" runat="server" width="500px"></asp:TextBox></td>
                            <td><asp:CheckBox ID="checkDaily" runat="server" /></td>
                            <td><asp:CheckBox ID="checkWeekly" runat="server" /></td>
                            <td><asp:CheckBox ID="checkMonthly" runat="server" /></td>
                            <td><asp:CheckBox ID="checkAnnually" runat="server" /></td>
                            <td><asp:Button ID="btnAddResponsibility" runat="server" Text="Add New" 
                                    onclick="btnAddResponsibility_Click"/></td>
                        </tr>
                        <tr>
                            <td colspan="6"><div id="disResponsibility" runat="server"></div></td>                            
                        </tr>
                        <tr>
                            <td colspan="7" align="right"><asp:Button ID="BtnDelRes" runat="server" Text="Delete" Visible="false" 
                                    onclick="BtnDelRes_Click"/></td>
                        </tr>
                        <tr>
                            <td colspan="7">Unique Responsibilities (that distinguishes this position from others) </td>
                        </tr>
                        <tr>
                            <th>SN</th>
                            <th>General Responsibilities</th>
                            <th>Daliy</th>
                            <th>Weekly</th>
                            <th>Monthly</th>
                            <th>Annually</th>
                            <th>&nbsp;</th>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:TextBox ID="txtResponsibilty1" runat="server" Width="500px"></asp:TextBox></td>
                            <td><asp:CheckBox ID="checkDaily1" runat="server" /></td>
                            <td><asp:CheckBox ID="checkWeekly1" runat="server" /></td>
                            <td><asp:CheckBox ID="checkMonthly1" runat="server" /></td>
                            <td><asp:CheckBox ID="checkAnnually1" runat="server" /></td>
                            <td><asp:Button ID="btnAddResponsibility1" runat="server" Text="Add New" 
                                    onclick="btnAddResponsibility1_Click"/></td>
                        </tr>
                        <tr>
                            <td colspan="6"><div id="disUniqueResponsibility" runat="server"></div></td>
                        </tr>
                        <tr>
                            <td colspan="7" align="right"><asp:Button ID="BtnDelRes1" runat="server" Text="Delete" Visible="false" 
                                    onclick="BtnDelRes1_Click"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th>5.</th>
                <th colspan="4">What other functions and responsibilies are you performing that are not part of your present job?</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:TextBox ID="ans_5" runat="server" TextMode="MultiLine" width="930px"></asp:TextBox></td>
            </tr>
            <tr>
                <th>6.</th>
                <th colspan="4">How do you feel about the volume of your work? Please choose 1 or 2 at most and provide a reason for your choice(s). Is it</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:CheckBox ID="ans_6_stressful" runat="server"/> Stressful</td>
                <td><asp:CheckBox ID="ans_6_boring" runat="server"/> Boring</td>
                <td><asp:CheckBox ID="ans_6_easy" runat="server"/> Easy</td>
                <td><asp:CheckBox ID="ans_6_difficult" runat="server"/> Difficult</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:CheckBox ID="ans_6_interesting" runat="server"/> Interesting</td>
                <td colspan="3"><asp:CheckBox ID="ans_6_other" runat="server"/> Others (Please Specify)
                <asp:TextBox ID="ans_6_other_detail" runat="server" width="500px"></asp:TextBox> </td>
                
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    Why?<br />
                    <asp:TextBox ID="ans_6_why" runat="server" TextMode="MultiLine" width="930px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>7.</th>
                <th colspan="4">Discribe your working relationship with your supervisor and your colleagues (Interpersonal communication dialogue, feedback and others)</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:TextBox ID="ans_7" runat="server" TextMode="MultiLine" width="930px"></asp:TextBox></td>
            </tr>
            <tr>
                <th>8.</th>
                <th colspan="4">Are you able to use your full knowledge and/or expertise at present? If not, why and how you think can 
                your expertise be enhanced?</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:TextBox ID="ans_8" runat="server" TextMode="MultiLine" width="930px"></asp:TextBox></td>
            </tr>
            <tr>
                <th>9.</th>
                <th colspan="4">If you have attended training previously, please provide the following details:</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    <table class="TBL" width="950px">
                        <tr>
                            <th>SN</th>
                            <th>Type of training (with name & details, if possible)</th>
                            <th>Location</th>
                            <th>Month/Year</th>
                            <th>&nbsp;</th>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:TextBox ID="txtTrainingName" runat="server" Width="500px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtTrainingLocation" runat="server" CssClass="txtTextBox"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtTrainingMonthYear" runat="server"></asp:TextBox></td>
                            <td><asp:Button ID="BtnAddTraining" runat="server" Text="Add New" 
                                    onclick="BtnAddTraining_Click"/></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="4"><div id="rptTrainingDetails" runat="server"></div></td>
                        </tr>
                        <tr>
                              <td colspan="5" align="right"><asp:Button ID="BtnDelTraining" runat="server" Text="Delete" Visible="false" 
                                    onclick="BtnDelTraining_Click"/></td> 
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th>10.</th>
                <th colspan="4">What problems are you facing in discharging your duties and responsibilities effectively?</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4"><asp:TextBox ID="ans_10" runat="server" width="930px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <th>11.</th>
                <th colspan="4">What can be done to remove these problems?</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:CheckBox ID="ans_11_training" runat="server" />Training</td>
                <td colspan="3" valign="top"><asp:CheckBox ID="ans_11_other" runat="server" />Others (Please Specify)
                    <asp:TextBox ID="ans_11_other_detail" runat="server" TextMode="MultiLine" width="660px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>12.</th>
                <th colspan="4">What kind of training reqirements do you foresee for yourself in order to perform your duties now and in future (be as specific as you can)</th>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4">
                    <table class="TBL" width="950px">                
                        <tr>
                            <th>SN</th>
                            <th>Training Requirement Name</th>
                            <th>&nbsp;</th>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:TextBox ID="txtTrainingRequirement" runat="server" Width="500px"></asp:TextBox></td>
                            <td><asp:Button ID="BtnAddTrainingRequirement" runat="server" Text="Add New" 
                                    onclick="BtnAddTrainingRequirement_Click" /></td>
                        </tr>       
                        <tr>
                            <td colspan="2"><div id="disTrainingRequirement" runat="server"></div></td>
                        </tr>  
                        <tr>
                            <td colspan="3" align="right"><asp:Button ID="BtnDelTrainingReq" runat="server" Text="Delete" Visible="false" 
                                    onclick="BtnDelTrainingReq_Click"/></td>
                        </tr>
                        <tr>
                            <td colspan="3">list down other Soft Skills training (Example: writing skills, Comnunication Skills, Motivational skills,
        Leadership Skills, Critical thinking Skills,<br /> Personalitv Development Training, Behavioral Training etc)</td>
                        </tr> 
                        <tr>
                            <th>SN</th>
                            <th>Training Requirement Name</th>
                            <th>&nbsp;</th>
                        </tr>
                         <tr>
                            <td></td>
                            <td><asp:TextBox ID="txtSoftTrainingRequirement" runat="server" Width="500px"></asp:TextBox></td>
                            <td><asp:Button ID="BtnAddSoftTrainingRequirement" runat="server" Text="Add New" 
                                    onclick="BtnAddSoftTrainingRequirement_Click" /></td>
                        </tr>  
                         <tr>
                            <td colspan="2"><div id="disSoftTrainingRequirement" runat="server"></div></td>
                        </tr>    
                        <tr>
                            <td colspan="3" align="right"><asp:Button ID="BtnDelSoftTrainingReq" runat="server" Text="Delete" Visible="false" 
                                    onclick="BtnDelSoftTrainingReq_Click"/></td>
                        </tr>     
                    </table>
                </td>
            </tr>
        </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="980">
                <tr>
                    <th>&nbsp;</th>
                    <th colspan="4" align="left"><asp:Button ID="BtnSave" runat="server" Text="Save" 
                            CssClass="button" onclick="BtnSave_Click"/></th>
                </tr>
                <tr>
                    <th>&nbsp;</th>
                    <td><div align="center" class="style10">Thank You!!!</div></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
 </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

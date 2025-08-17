<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageGradeSetup.aspx.cs" Inherits="SwiftHrManagement.web.SalarySet.ManageGradeSetup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
    <script src="../Jsfunc.js" type="text/javascript"></script>
    <script type="text/javascript">
        function DeleteNotification(RowID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnDeleteId.ClientID %>").value = RowID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
    
        
  </script>
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:HiddenField ID="hdnDeleteId" runat="server" />
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Label ID="abc" runat="server"></asp:Label>
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>  
                            Salary Grade Setup 
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span><br/>
                                <div id="DivMsg" runat="server"></div>
                            </div>

                            <div class="form-group">
                                <label>Salary Title:<span class="errormsg">*</span></label>
                                 <asp:TextBox ID="txtSalaryTitle" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                            </div>
                            
                            
                             <div class="form-group">
                                <label> Grade From:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtGradeFrom" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="manageGrade" BorderColor="#FFFF66"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtGradeFrom" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                  
                            </div>
                            
                             <div class="form-group">
                                <label> Grade To:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtGradeTo" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="manageGrade" BorderColor="#FFFF66"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtGradeTo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                  
                            </div>
                             <div class="form-group">
                                <label> Amount:<span class="errormsg">*</span></label>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="txtAmount" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="manageGrade" BorderColor="#FFFF66"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                                 
                            </div>

                            <div class="form-group">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="manageGrade"
                                    Width="75px" />
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                    OnClick="BtnDelete_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Delete ?" Enabled="True"
                                    TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnBack_OnClick" Text=" Back" />
                                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                    </section>
                     </div>
                </div>
            <div class="row">
                <div  class="col-md-10 col-md-offset-1">
                    <section class="panel">
                         <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                             
                        </div>
                    </section>
                </div>
               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
<%--
<table border="0" cellspacing="5" cellpadding="5" class="container">
        <td></td>
            
            <td><asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" 
                        ValidationGroup="salarysetDetails" Width="75px" onclick="BtnSave_Click" 
                     />
                     
                     <cc1:confirmbuttonextender ID="Button1_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:confirmbuttonextender>
                <asp:Button ID="BtnDelete" runat="server" Text="" onclick="BtnDelete_Click" style="display:none"/>
            
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    Text="&lt;&lt; Back" Width="75px" onclick="BtnBack_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
              <div id="rpt" runat="server"></div>
        
            </td>
        
        </tr>
</table>



<!--################ START FORM STYLE-->
	</td>
        <td class="container_content">
            &nbsp;</td>
    <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid" colspan="2"></td>
    <td class="container_br"></td>
  </tr>
  
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>
			</td>
		  </tr>
	</table>
	</td>
  </tr>
</table>
</form>--%>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApprovedManage.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.ApprovedManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>  
                           Travel Authorization Form
                    </header>
                    <div class="panel-body">
                         <asp:Label ID="lblauthor" runat="server" Visible="False"></asp:Label>
                         <asp:Label ID="lblreadsession" runat="server" Visible="False"></asp:Label>
                        <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                               <h4><u>Employee Information</u></h4> 
                               <asp:Label ID="printMsg" Text="Message: " runat="server" Visible="false"></asp:Label>
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
                                <strong><asp:Label ID="lblbranch" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Department:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbldepartment" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Position:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblposition" runat="server" Text="Label"></asp:Label></strong>
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
                                <strong><asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                           <div class="col-md-3 text-right">
                               <strong>Country:</strong>
                           </div>
                            <div class="col-md-3">
                               <strong><asp:Label ID="lblcountry" runat="server" Text="Label"></asp:Label></strong> 
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>Reason for Travel:</strong>
                            </div>
                            <div class="col-md-3">
                               <strong><asp:Label ID="lblreasontravel" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div id="divtraveldate" class="row" runat="server" visible="true">
                            <div class="col-md-3 text-right">
                                <strong>From Date:</strong>
                            </div>
                            <div class="col-md-3">
                             <strong><asp:Label ID="lblfromdate" runat="server" Text="Label"></asp:Label></strong> 
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>To Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbltodate" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            </div>
                            </div>
                         <div class="row">
                                 <div class="col-md-3 text-right">
                                     <strong>Extension of Visit:</strong>
                                 </div>
                                 <div class="col-md-9">
                                     <strong><asp:Label ID="lblextension" runat="server" Text="Label"></asp:Label></strong>
                                 </div>
                            </div>
                         <div id="divIsExtVisit" class="row" runat="server" visible="false">
                                    <div class="col-md-3 text-right">
                                        <strong>From:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblextfrom" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>To:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblextto" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>City:</strong>
                                    </div>
                                    <div class="col-md-3">
                                       <strong><asp:Label ID="lblextcity" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                         <strong>Country:</strong>
                                    </div>
                                    <div class="col-md-3">
                                       <strong><asp:Label ID="Lblextcountry" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-3 text-right">
                                        <strong>Leave Applied:</strong>
                                    </div>
                                    <div class="col-md-3">
                                        <strong><asp:Label ID="lblleaveaaplied" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                     <div class="col-md-3 text-right">
                                         <strong>No Of. Days:</strong>
                                     </div> 
                                     <div class="col-md-3">
                                         <strong><asp:Label ID="lblremainingdays" runat="server" Text="Label"></asp:Label></strong>
                                     </div>        
                               </div>
                         <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>Mode of Travel:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblmode" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Accomodation:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblaccomodation" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Transportation Arrangement:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lbltransportation" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                                <div class="col-md-3 text-right">
                                    <strong>Meal:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblfooding" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                            </div>
                        <div id="divflightDetails" runat="server" visible="false">
                             <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <h4><u>Flight Details</u></h4>
                                 </div>
                            </div>
                             <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Flight Date:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblFlightDate" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                            <div class="col-md-3 text-right">
                                <strong>From Place:</strong>
                            </div>
                            <div class="col-md-3">
                                <strong> <asp:Label ID="lblFromPlace" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                                 </div>
                            <div class="row">
                                <div class="col-md-3 text-right">
                                    <strong>To Place:</strong>
                                </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblToPlace" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                                 <div class="col-md-3 text-right">
                                     <strong>Flight Time/Schedule:</strong>
                                 </div>
                                <div class="col-md-3">
                                    <strong><asp:Label ID="lblFlightTime" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <h4><u>Return Flight Details</u></h4>
                                 </div>
                            </div>
                             <div class="row">
                                 <div class="col-md-3 text-right">
                                     <strong>Flight Date:</strong>
                                 </div>
                                 <div class="col-md-3">
                                     <strong><asp:Label ID="lblReturnFlightDate" runat="server" Text="Label"></asp:Label></strong>
                                 </div>
                                 <div class="col-md-3 text-right">
                                     <strong>From Place:</strong>
                                 </div>
                                 <div class="col-md-3">
                                     <strong> <asp:Label ID="lblReturnFromPlace" runat="server" Text="Label"></asp:Label></strong>
                                 </div>
                            </div>
                              <div class="row">
                                 <div class="col-md-3 text-right">
                                     <strong>To Place:</strong>
                                 </div>
                                 <div class="col-md-3">
                                     <strong><asp:Label ID="lblReturnToPlace" runat="server" Text="Label"></asp:Label></strong>
                                 </div>
                                 <div class="col-md-3 text-right">
                                     <strong>Flight Time/Schedule:</strong>
                                 </div>
                                 <div class="col-md-3">
                                     <strong><asp:Label ID="lblReturnFlightTime" runat="server" Text="Label"></asp:Label></strong>
                                 </div>
                             </div>
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
                            <div class="col-md-3">
                                <strong><asp:Label ID="lblcashadvance" runat="server" Text="Label"></asp:Label></strong>
                            </div>
                        </div>
                        <div id="divIsAdvance" class="row" runat="server" visible="false">
                             <div id="rpt2" runat="server"></div>
                            <div>&nbsp;</div>
                         </div>
                        

                       <div class="row">
                            <div class="col-md-6 col-md-offset-3">
                                <h4><u>Authorised By</u></h4>
                            </div>
                       </div>
                        <div class="row">
                            <div ID="rpt" runat="server"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 text-right">
                                <strong>Forward To:</strong>
                                
                            </div>
                            <div class="col-md-5 autocomplete-form">
                                <strong><asp:Label ID="lblAuthorisedBy" runat="server"></asp:Label></strong>
                                 <asp:TextBox ID="txtAuthorisedBy" runat="server" CssClass="form-control"
                                     AutoPostBack="true" />
                                 <cc1:AutoCompleteExtender ID="aceAuthorisedBy" runat="server"
                                     CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                     DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                     MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId"
                                     ServicePath="~/Autocomplete.asmx" TargetControlID="txtAuthorisedBy" />
                                 <cc1:TextBoxWatermarkExtender ID="wmeEmpName"
                                     runat="server" Enabled="True" TargetControlID="txtAuthorisedBy"
                                     WatermarkCssClass="form-control" WatermarkText="Auto Complete" />
                                 <asp:HiddenField ID="hdnAuthorisedBy" runat="server" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Recommend And Forward" 
                                      ValidationGroup="tada" onclick="btnAdd_Click"   />
                                  <cc1:ConfirmButtonExtender ID="cbeBtnAdd" runat="server" 
                                      ConfirmText="Confirm To Accept?" Enabled="True" TargetControlID="btnAdd" />
                                
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" OnClick="BtnSave_Click" Text="Approve And End" ValidationGroup="tada" />
                                           <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                               ConfirmText="Confirm To Accept?" Enabled="True" TargetControlID="BtnSave">
                                           </cc1:ConfirmButtonExtender>
                                <asp:Button ID="BtnVerify" runat="server" CssClass="btn btn-primary"
                                        OnClick="BtnVerify_Click" Text="Verify" ValidationGroup="tada" Visible="false" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Confirm To Verify?" Enabled="True" TargetControlID="BtnVerify">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnReject" runat="server" CssClass="btn btn-primary"
                                        OnClick="BtnReject_Click" Text="Reject" ValidationGroup="tada" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                        ConfirmText="Confirm To Reject?" Enabled="True" TargetControlID="BtnReject">
                                    </cc1:ConfirmButtonExtender>
                                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                        OnClick="BtnBack_Click" Text="Back" />
                              </div>
                      </div>
                    </div>
           </section>
        </div>
    </div>









    </td>

    </tr>
    </table>
 </ContentTemplate>
 </asp:UpdatePanel>
  
    <!--################ START FORM STYLE-->

    </td>
    <td class="container_r"></td>
    </tr>
  <tr>
      <td class="container_bl"></td>
      <td class="container_bmid"></td>
      <td class="container_br"></td>
  </tr>

    </table>
    

    <!--################ END FORM STYLE-->


    <!--		End  content	-->
    </td>
					</tr>
			  </table>	
              </td></tr>	
           	
              </table>
              </td>
              </tr>
              </table>

</asp:Content>

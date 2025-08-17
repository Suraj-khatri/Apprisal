<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/SwiftHRManager.Master" CodeBehind="DailyActivityRecord.aspx.cs" Inherits="SwiftHrManagement.web.DailyActivityReport.DailyActivityRecord" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <script type="text/javascript">
    function DeleteDailyActivity(RowID) {
        if (confirm("Are you sure to delete this message?")) {
            document.getElementById("<% =hdnActivityDId.ClientID %>").value = RowID;
            document.getElementById("<% =BtnDelete.ClientID %>").click();
        }
    }
    function EditActivityDetails(RowID) {
        if (confirm("Are you sure to Edit this message?")) {
            document.getElementById("<% =hdnEdivActivityId.ClientID %>").value = RowID;
            document.getElementById("<% =BtnEdit.ClientID %>").click();
        }
    }
  </script>

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Daily Activity Record</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->




<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="50%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Daily Activity Record</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<table border="0" cellpadding="5" cellspacing="5" class="container" width="100%">
   
   
    <tr>
        <td>
            <span class="txtlbl">Please enter valid data! <span class="errormsg">(* are required fields!)</span><br /><br />
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
            <asp:HiddenField ID="hdnfromTime" runat="server" />
            <asp:HiddenField ID="hdntoTime" runat="server" />
            <asp:HiddenField ID="hdnActivityDId" runat="server" />
            <asp:HiddenField ID="hdnEdivActivityId" runat="server" />
            <asp:Button ID="BtnEdit" runat="server" Text="Button" onclick="BtnEdit_Click" style="display:none" />

        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="downPanel" runat="server" GroupingText="Employee Information" CssClass="">
            <div id="ActivityDate"  style="width:"700px">
                <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        <div id="Date" runat="server" class="txtlbl" align="right">Date :</div>
                    </td>
                    <td nowrap>
                     <asp:TextBox ID="txtDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                         <cc1:CalendarExtender ID="ToDateCalendar" runat="server"
                          Enabled="true" EnabledOnClient="true"
                             TargetControlID="txtDate">
                      </cc1:CalendarExtender>
                      
                        <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="button" 
                            onclick="BtnSearch_Click" />
                    </td>   
                </tr> 
                <tr>
                    <td nowrap>
                        <div id="EmployeeName" runat="server" class="txtlbl" align="right">Employee Name :</div>
                    </td>
                    <td nowrap>
                         <asp:Label ID="lblEName" runat="server" CssClass="label"></asp:Label>
                    </td>     
                </tr>
                <tr>
                    <td nowrap>
                        <div id="Branch" runat="server" class="txtlbl" align="right">Branch :</div>
                    </td>
                    <td nowrap>
                        <asp:Label ID="lblBranch" runat="server" CssClass="label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <div id="Department" runat="server" class="txtlbl" align="right">Department :</div>
                    </td>
                    <td>
                        <asp:Label ID="lblDept" runat="server" CssClass="label"></asp:Label>
                    </td>
                </tr>
                </table>
                </div>
            </asp:Panel>
        </td>
        
         <td style="vertical-align:top;" rowspan="2" nowrap="nowrap">
         
          
        </td>
      
    </tr> 
   
    <tr>
        <td nowrap="nowrap">                
        <asp:Panel ID="ProductListPanel" runat="server" GroupingText="Activity Details" CssClass="legend">
            <table width="100%" cellpadding="2" cellspacing="2">
            <tr>
            <td></td>
                <td>
                    <asp:Label ID="lblDMsg" runat="server"  CssClass="label"></asp:Label>
                </td>
            </tr>
            <tr>
               
                 
         <td nowrap ><div align="right"><span class="txtlbl">From Time :</span></div></td>
          <td nowrap="nowrap">
            <asp:DropDownList ID="ddlhourin" runat="server" CssClass="CMBDesign" 
                Width="120px" onselectedindexchanged="ddlhourin_SelectedIndexChanged" AutoPostBack="true">
              <asp:ListItem Value="">Select Hour</asp:ListItem>
              <asp:ListItem>00</asp:ListItem>
              <asp:ListItem>01</asp:ListItem>
              <asp:ListItem>02</asp:ListItem>
              <asp:ListItem>03</asp:ListItem>
              <asp:ListItem>04</asp:ListItem>
              <asp:ListItem>05</asp:ListItem>
              <asp:ListItem>06</asp:ListItem>
              <asp:ListItem>07</asp:ListItem>
              <asp:ListItem>08</asp:ListItem>
              <asp:ListItem>09</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              <asp:ListItem>11</asp:ListItem>
              <asp:ListItem>12</asp:ListItem>
              <asp:ListItem>13</asp:ListItem>
              <asp:ListItem>14</asp:ListItem>
              <asp:ListItem>15</asp:ListItem>
              <asp:ListItem>16</asp:ListItem>
              <asp:ListItem>17</asp:ListItem>
              <asp:ListItem>18</asp:ListItem>
              <asp:ListItem>19</asp:ListItem>
              <asp:ListItem>20</asp:ListItem>
              <asp:ListItem>21</asp:ListItem>
              <asp:ListItem>22</asp:ListItem>
              <asp:ListItem>23</asp:ListItem>
            </asp:DropDownList> :
            <asp:DropDownList ID="ddlminutein" runat="server" CssClass="CMBDesign" 
                Width="120px" onselectedindexchanged="ddlminutein_SelectedIndexChanged" AutoPostBack="true">
              <asp:ListItem Value="">Select Minute</asp:ListItem>
              <asp:ListItem>00</asp:ListItem>
              <asp:ListItem>01</asp:ListItem>
              <asp:ListItem>02</asp:ListItem>
              <asp:ListItem>03</asp:ListItem>
              <asp:ListItem>04</asp:ListItem>
              <asp:ListItem>05</asp:ListItem>
              <asp:ListItem>06</asp:ListItem>
              <asp:ListItem>07</asp:ListItem>
              <asp:ListItem>08</asp:ListItem>
              <asp:ListItem>09</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              <asp:ListItem>11</asp:ListItem>
              <asp:ListItem>12</asp:ListItem>
              <asp:ListItem>13</asp:ListItem>
              <asp:ListItem>14</asp:ListItem>
              <asp:ListItem>15</asp:ListItem>
              <asp:ListItem>16</asp:ListItem>
              <asp:ListItem>17</asp:ListItem>
              <asp:ListItem>18</asp:ListItem>
              <asp:ListItem>19</asp:ListItem>
              <asp:ListItem>20</asp:ListItem>
              <asp:ListItem>21</asp:ListItem>
              <asp:ListItem>22</asp:ListItem>
              <asp:ListItem>23</asp:ListItem>
              <asp:ListItem>24</asp:ListItem>
              <asp:ListItem>25</asp:ListItem>
              <asp:ListItem>26</asp:ListItem>
              <asp:ListItem>27</asp:ListItem>
              <asp:ListItem>28</asp:ListItem>
              <asp:ListItem>29</asp:ListItem>
              <asp:ListItem>30</asp:ListItem>
              <asp:ListItem>31</asp:ListItem>
              <asp:ListItem>32</asp:ListItem>
              <asp:ListItem>33</asp:ListItem>
              <asp:ListItem>34</asp:ListItem>
              <asp:ListItem>35</asp:ListItem>
              <asp:ListItem>36</asp:ListItem>
              <asp:ListItem>37</asp:ListItem>
              <asp:ListItem>38</asp:ListItem>
              <asp:ListItem>39</asp:ListItem>
              <asp:ListItem>40</asp:ListItem>
              <asp:ListItem>41</asp:ListItem>
              <asp:ListItem>42</asp:ListItem>
              <asp:ListItem>43</asp:ListItem>
              <asp:ListItem>44</asp:ListItem>
              <asp:ListItem>45</asp:ListItem>
              <asp:ListItem>46</asp:ListItem>
              <asp:ListItem>47</asp:ListItem>
              <asp:ListItem>48</asp:ListItem>
              <asp:ListItem>49</asp:ListItem>
              <asp:ListItem>50</asp:ListItem>
              <asp:ListItem>51</asp:ListItem>
              <asp:ListItem>52</asp:ListItem>
              <asp:ListItem>53</asp:ListItem>
              <asp:ListItem>54</asp:ListItem>
              <asp:ListItem>55</asp:ListItem>
              <asp:ListItem>56</asp:ListItem>
              <asp:ListItem>57</asp:ListItem>
              <asp:ListItem>58</asp:ListItem>
              <asp:ListItem>59</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlminutein" Display="dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="save">
          </asp:RequiredFieldValidator>
          </td>
          
      </tr>
     <tr>
        <td><div align="right"><span class="txtlbl">To Time:</span></div></td>
          <td>  
            <asp:DropDownList ID="ddlhourout" runat="server" CssClass="CMBDesign" 
                width="120px" onselectedindexchanged="ddlhourout_SelectedIndexChanged" AutoPostBack="true"
               >
              <asp:ListItem Value="">Select Hour</asp:ListItem>
              <asp:ListItem>00</asp:ListItem>
              <asp:ListItem>01</asp:ListItem>
              <asp:ListItem>02</asp:ListItem>
              <asp:ListItem>03</asp:ListItem>
              <asp:ListItem>04</asp:ListItem>
              <asp:ListItem>05</asp:ListItem>
              <asp:ListItem>06</asp:ListItem>
              <asp:ListItem>07</asp:ListItem>
              <asp:ListItem>08</asp:ListItem>
              <asp:ListItem>09</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              <asp:ListItem>11</asp:ListItem>
              <asp:ListItem>12</asp:ListItem>
              <asp:ListItem>13</asp:ListItem>
              <asp:ListItem>14</asp:ListItem>
              <asp:ListItem>15</asp:ListItem>
              <asp:ListItem>16</asp:ListItem>
              <asp:ListItem>17</asp:ListItem>
              <asp:ListItem>18</asp:ListItem>
              <asp:ListItem>19</asp:ListItem>
              <asp:ListItem>20</asp:ListItem>
              <asp:ListItem>21</asp:ListItem>
              <asp:ListItem>22</asp:ListItem>
              <asp:ListItem>23</asp:ListItem>
            </asp:DropDownList>
            : 
            <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="CMBDesign" 
                Width="120px" onselectedindexchanged="ddlminuteout_SelectedIndexChanged" AutoPostBack="true">
              <asp:ListItem Value="">Select Minute</asp:ListItem>
              <asp:ListItem>00</asp:ListItem>
              <asp:ListItem>01</asp:ListItem>
              <asp:ListItem>02</asp:ListItem>
              <asp:ListItem>03</asp:ListItem>
              <asp:ListItem>04</asp:ListItem>
              <asp:ListItem>05</asp:ListItem>
              <asp:ListItem>06</asp:ListItem>
              <asp:ListItem>07</asp:ListItem>
              <asp:ListItem>08</asp:ListItem>
              <asp:ListItem>09</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              <asp:ListItem>11</asp:ListItem>
              <asp:ListItem>12</asp:ListItem>
              <asp:ListItem>13</asp:ListItem>
              <asp:ListItem>14</asp:ListItem>
              <asp:ListItem>15</asp:ListItem>
              <asp:ListItem>16</asp:ListItem>
              <asp:ListItem>17</asp:ListItem>
              <asp:ListItem>18</asp:ListItem>
              <asp:ListItem>19</asp:ListItem>
              <asp:ListItem>20</asp:ListItem>
              <asp:ListItem>21</asp:ListItem>
              <asp:ListItem>22</asp:ListItem>
              <asp:ListItem>23</asp:ListItem>
              <asp:ListItem>24</asp:ListItem>
              <asp:ListItem>25</asp:ListItem>
              <asp:ListItem>26</asp:ListItem>
              <asp:ListItem>27</asp:ListItem>
              <asp:ListItem>28</asp:ListItem>
              <asp:ListItem>29</asp:ListItem>
              <asp:ListItem>30</asp:ListItem>
              <asp:ListItem>31</asp:ListItem>
              <asp:ListItem>32</asp:ListItem>
              <asp:ListItem>33</asp:ListItem>
              <asp:ListItem>34</asp:ListItem>
              <asp:ListItem>35</asp:ListItem>
              <asp:ListItem>36</asp:ListItem>
              <asp:ListItem>37</asp:ListItem>
              <asp:ListItem>38</asp:ListItem>
              <asp:ListItem>39</asp:ListItem>
              <asp:ListItem>40</asp:ListItem>
              <asp:ListItem>41</asp:ListItem>
              <asp:ListItem>42</asp:ListItem>
              <asp:ListItem>43</asp:ListItem>
              <asp:ListItem>44</asp:ListItem>
              <asp:ListItem>45</asp:ListItem>
              <asp:ListItem>46</asp:ListItem>
              <asp:ListItem>47</asp:ListItem>
              <asp:ListItem>48</asp:ListItem>
              <asp:ListItem>49</asp:ListItem>
              <asp:ListItem>50</asp:ListItem>
              <asp:ListItem>51</asp:ListItem>
              <asp:ListItem>52</asp:ListItem>
              <asp:ListItem>53</asp:ListItem>
              <asp:ListItem>54</asp:ListItem>
              <asp:ListItem>55</asp:ListItem>
              <asp:ListItem>56</asp:ListItem>
              <asp:ListItem>57</asp:ListItem>
              <asp:ListItem>58</asp:ListItem>
              <asp:ListItem>59</asp:ListItem>
          </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlminuteout" Display="dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="save">
          </asp:RequiredFieldValidator>
          </td>
       </tr>
      
            </tr>
            <tr>
            
                    <td  class="style10" >
                        <div align="right"><span class="txtlbl">Details:</span></div>
                    </td>
                
                <td>
                    <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" CssClass="inputTextBoxLP" Width="400px" Height="100px"></asp:TextBox>
                </td>
            </tr>
                 <tr>
               <td></td>
                    <td align="right">
                        <asp:Panel ID="PnDelete" runat="server">
                        <div align="left">
                        <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" Width="50" 
                                onclick="BtnSave_Click" ValidationGroup ="save" />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                         </div>
                        </asp:Panel>
                        
                    </td>
                    <td>
                    <asp:Button ID="BtnDelete" runat="server" Text=""  style="display:none;" 
                            onclick="BtnDelete_Click" />
                    </td>
               </tr>
            <tr>
            <td colspan="2">
              <div id="rpt" runat="server">
                <asp:Table ID="Table1" runat="server" Width="100%">
                </asp:Table>
            </div>
            </td>
            </tr>
          
            </table> 
        </asp:Panel>                   
        </td>
       
    </tr>
    <tr>

    <td>
     Recommemded To :
     <asp:DropDownList ID="ddlRecommend" runat="server" CssClass="CMBDesign">
        </asp:DropDownList><span class="errormsg">*</span>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlRecommend" Display="dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="Final">
          </asp:RequiredFieldValidator>
    
    </td>
    </tr>
    <tr>
    
    <td align="center">
      <div align="center">
    
        <asp:Button ID="BtnFinalSave" runat="server" Text="Final Submit" CssClass="button" 
              onclick="BtnFinalSave_Click" ValidationGroup="Final"/>
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
	</tbody>
  </table>

<!--################ END FORM STYLE-->		
	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.OTRequetAll.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        function DeleteNotification(Temp_OtID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =Temp_OtID.ClientID %>").value = Temp_OtID;
                document.getElementById("<% =btn_delete.ClientID %>").click();
            }
        }
   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
   <ContentTemplate>
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                       Over Time Login Entry
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <strong> Over Time\Extra Hour requesting form</strong>
                    </div>
                    <div class="form-group">
                        <span class="txtlbl">Plese enter valid data! </span>
                        <span class="required">(* Required Fields)</span>
                        <asp:HiddenField ID="hdnemployeeID" runat="server" />
                        <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700"></asp:Label>
                        <asp:HiddenField ID="Temp_OtID" runat="server" Value="" />
                        <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Style="display: none" />
                    </div>
                    <div class="form-group">
                        <label>Request Type :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlReqType"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="back" />
                        <asp:DropDownList ID="ddlReqType" runat="server" CssClass="form-control" 
                            onselectedindexchanged="ddlReqType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="">select</asp:ListItem>
                            <asp:ListItem Value="650">Over Time</asp:ListItem>
                            <asp:ListItem Value="1453">Hardship Allowance</asp:ListItem>
                        </asp:DropDownList>
                        
                        
                    </div>
                    <div class="form-group">
                        <div runat="server" id="hardshipHead" visible="false">
                        <label>Hardship Head :<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlHardshipHead" 
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="back" />
                        <asp:DropDownList ID="ddlHardshipHead" runat="server" CssClass="form-control"></asp:DropDownList>
                        
                        </div>
                     </div>

                    <div class="form-group autocomplete-form">
                        <label>Request For :</label>
                         <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" AutoComplete="Off"
                            OnTextChanged="txtEmployeeName_TextChanged" AutoPostBack="true" />
                        <cc1:TextBoxWatermarkExtender ID="txtEmployeeName_TextBoxWatermarkExtender" runat="server"
                            Enabled="True" TargetControlID="txtEmployeeName" WatermarkCssClass="form-control"
                            WatermarkText="Autocomplete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="txtEmployeeName_AutoCompleteExtender" CompletionInterval="10"
                            runat="server" DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx"
                            CompletionListCssClass="autocompleteTextBoxLP" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                            TargetControlID="txtEmployeeName" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>
                    </div>
                    <div class="form-group">
                        <label>Requesting With :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="rfc" runat="server" ControlToValidate="DdlApprovedBy" Display="Dynamic" 
                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="back" />
                        <asp:DropDownList ID="DdlApprovedBy" runat="server" CssClass="form-control" />
                        
                    </div>
                    <div class="form-group">
                        <label>OverTime or Hardship Date :<span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtdateIn"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="back" />
                        <asp:TextBox ID="txtdateIn" runat="server" CssClass="form-control" OnTextChanged="txtdateIn_TextChanged"
                             AutoPostBack="true" />
                        <cc1:CalendarExtender ID="EnteredDate_CalendarExtender" runat="server" Enabled="true" EnabledOnClient="true"
                            TargetControlID="txtdateIn" />
                       
                    </div>
                    <div class="form-group">
                        &nbsp;
                    </div>
                    <div class="form-group">
                        <strong>Attendance Details</strong>
                    </div>
                    <div class="form-group">
                        <div id="rptAtt" runat="server"></div>
                    </div>
                    <div runat="server" id="timing" visible="false">
                        <div class="form-group">
                            <label>Time In :<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlhourin" Display="Dynamic" 
                                ErrorMessage="*" InitialValue="" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="ddlminutein" Display="Dynamic" 
                                ErrorMessage="*" InitialValue="" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlhourin" runat="server" CssClass="form-control" 
                                        OnSelectedIndexChanged="ddlhourin_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Select Hour</asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
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
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlminutein" runat="server" CssClass="form-control" 
                                OnSelectedIndexChanged="ddlminutein_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Select Minute</asp:ListItem>
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
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
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                        <label>Time out :<span class="errormsg">*</span></label>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlhourout" runat="server" CssClass="form-control" 
                                        OnSelectedIndexChanged="ddlhourout_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Select Hour</asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
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
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="form-control" 
                                        OnSelectedIndexChanged="ddlminuteout_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Select Minute</asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
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
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Total Hours:<span class="errormsg">*</span></label>
                             <asp:TextBox ID="txtTotalTime" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Remarks:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtRemarks"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnAdd" runat="server" Text="Add" CssClass="btn btn-primary" ValidationGroup="back"
                        OnClick="BtnAdd_Click" />
                    </div>
                    <div class="form-group">
                            <div id="rtpOt" runat="server"></div>
                    </div>
                    <div class="form-group">
                        <div id="otsave" runat="server" visible="false">
                            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="BtnSave_Click1" />
                        </div>
                    </div>
                </div>
            </div>
            </section>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
<script language="javascript" type="text/javascript">
    function AutocompleteOnSelected(sender, e)
    {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=hdnemployeeID.ClientID%>").value = customerValueArray[1];
        //        alert(document.getElementById("<%=hdnemployeeID.ClientID%>").value);
    }
</script>
</asp:Content>

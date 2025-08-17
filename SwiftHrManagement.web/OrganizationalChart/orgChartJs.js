
var orgChart = function (opt) {
    
    var exMsg =  "Option must be provided as constructor argument and must be json array with minimum field(s) \nEg. {chartDiv: 'Div id to display chart', \nurl: 'page url for node DML Operation',\n select: 'method name to get data to create chart',\n insert: 'method name to add data in db',\n update: 'method name to update data in db',\n del: 'method name to delete data from db' }";

    if (opt == undefined && typeof (opt) != "object")
        throw exMsg;
   
    var defaults = {
          popupHeadText: 'Manage Org Chart'
        , allowLinkOnText: true
        , url: ''
        , showAddDelButton: true
        , select: 'data'
        , insert: 'save'
        , update: 'edit'
        , del: 'delete'
        , chartDiv: 'chart_div'
        , chartManager: 'orgChartManager'
        , extraParam: { utc: new Date().getTime() }
    };

    this.orgChartId = "orgChart_" + Math.floor((new Date().getTime()) / Math.floor(Math.random() * 1000));
    this.chartSetting = this.extend(defaults,opt);
};

orgChart.prototype.getSetting = function () {
    return this.chartSetting;
}

orgChart.prototype.getChartId = function () {
    return this.orgChartId;
}

orgChart.prototype.drawChart = function (jsonString) {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'node');
    data.addColumn('string', 'parentNode');
    data.addColumn('string', 'ToolTip');

    var conf = this.getSetting();

    if (jsonString == undefined || jsonString == null || jsonString == ""){
        var paramToSend = this.extend(conf.extraParam, { MethodName: conf.select });        
        jsonString = this.execAjax(conf.url, paramToSend);
    }

    var jsonData = eval(jsonString);
    if (jsonData.length > 0) {
        for (var i = 0; i < jsonData.length; i++) {
            var pId = (jsonData[i].ParentNodeId == undefined || jsonData[i].ParentNodeId == null || jsonData[i].ParentNodeId == "") ? jsonData[i].NodeId : jsonData[i].ParentNodeId;
            var hiddenData = "[{NodeId:'" + jsonData[i].NodeId + "',ParentNodeId:'" + pId + "', GroupId:'" + jsonData[i].GroupId + "', NodeType:'" + jsonData[i].NodeType + "', IsLeaf:" + jsonData[i].IsLeaf + ", chartId:'" + this.getChartId() + "'}]";
            var nodeText = (conf.allowLinkOnText == true) ? "<a href=\"javascript:void(0);\" onclick=\"return ShowDetail(" + hiddenData + ");\">" + jsonData[i].NodeText + "</a>" : jsonData[i].NodeText;
            data.addRows([[{
                v: jsonData[i].NodeId,
                f: nodeText+ "<input type=\"hidden\" id=\"hdn_" + i + "\" name=\"hdn_tree_node\" value=\"" + hiddenData + "\">"
            }, jsonData[i].ParentNodeId, jsonData[i].NodeTooltip]]);
        }
    }
    else {
        var firstNode = [{ popupHeadText: conf.popupHeadText, MethodName: conf.insert, url: conf.url, NodeId: null, ParentNodeId: null, GroupId: null, NodeType: null, IsLeaf: null, chartId: this.getChartId() }];
        this.MakepopUp(firstNode,true);
    }   

    // Create the chart.
    var chart = new google.visualization.OrgChart(document.getElementById(conf.chartDiv));

    // Draw the chart, setting the allowHtml option to true for the tooltips.
    chart.draw(data, { allowHtml: true });
    //
    if (conf.showAddDelButton == true) {
        google.visualization.events.addListener(chart, 'onmouseover', function (e) {
            var rowId = e.row;

            var btnHolder = document.getElementById("tree_nodeAddRemoveOptContainer_" + rowId);
            if (typeof (btnHolder) != 'undefined' && btnHolder != null)
                return;

            var elm = document.getElementById("hdn_" + rowId);

            $(".tree_nodeAddRemoveOptContainer").remove();

            var obj = eval(elm.value);          
            var addBtn = document.createElement("input");
            addBtn.setAttribute("type", "button");
            addBtn.setAttribute("value", "+");
            addBtn.setAttribute("class", "tree_nodeAddRemoveOpt");
            addBtn.setAttribute("style", "cursor:pointer;");
            addBtn.setAttribute("id", "btnAdd_" + rowId);
            addBtn.bindEvent("click", function (e) {                
                obj[0]["MethodName"] = conf.insert;
                obj[0]["popupHeadText"] = conf.popupHeadText;
                obj[0]["url"] = conf.url;
                orgChart.prototype.MakepopUp(obj);
            });

            var removeBtn = null;
            if (obj[0].IsLeaf == true) {
                removeBtn = document.createElement("input");
                removeBtn.setAttribute("type", "button");
                removeBtn.setAttribute("value", "-");
                removeBtn.setAttribute("class", "tree_nodeAddRemoveOpt");
                removeBtn.setAttribute("id", "btnDell" + rowId);
                removeBtn.setAttribute("style", "cursor:pointer;");
                removeBtn.bindEvent("click", function (e) {
                    if (confirm("Are you sure to delete this node?")) {
                        alert("Delete Node");
                        obj[0]["MethodName"] = conf.del;
                        var delRes = orgChart.prototype.execAjax(conf.url, obj[0]);
                    }
                    else {
                        $(".tree_nodeAddRemoveOptContainer").remove();
                    }

                });
            }

            var btnContainer = document.createElement("div");
            btnContainer.setAttribute("class", "tree_nodeAddRemoveOptContainer");
            btnContainer.setAttribute("id", "tree_nodeAddRemoveOptContainer_" + rowId);
            $(btnContainer).append(addBtn);
            if (obj[0].IsLeaf == true) {
                $(btnContainer).append(removeBtn);
            }
            elm.parentNode.insertBefore(btnContainer, elm.nextSibling);
        });
    }
};

orgChart.prototype.execAjax = function (pageUrl, dataToSend) {
    var dataToReturn;
    $.ajax({
        type: "POST",
        url: pageUrl,
        async: false,
        data: dataToSend,
        success: function (response, status, xhr) {
            dataToReturn = response;
        },
        error: function (request, error) {
            dataToReturn = { "errorCode": "101", "errorMsg": error };
        }
    });
    return dataToReturn;
};

orgChart.prototype.MakepopUp = function (arg, isFirstNode) {
    
    isFirstNode = (isFirstNode == undefined || isFirstNode == null || isFirstNode == "") ? false : true;

    $("#orgChartManager_" + arg[0].chartId).remove();

    /*Pop-up control list*/
    var cl = [
                  { label: 'Parent Type', id: 'ParentType', cssClass: 'form-ctrl org-chart-ctrl', type: 'ddl', allowChange: true, drillDownNode: 'Parent', visible: isFirstNode }
                , { label: 'Parent', id: 'Parent', cssClass: 'form-ctrl org-chart-ctrl', type: 'ddl', allowChange: false, drillDownNode: null, visible: true }
                , { label: 'Child Type', id: 'ChildType', cssClass: 'form-ctrl org-chart-ctrl', type: 'ddl', allowChange: true, drillDownNode: 'Child', visible: (!isFirstNode) }
                , { label: 'Child', id: 'Child', cssClass: 'form-ctrl org-chart-ctrl', type: 'ddl', allowChange: false, drillDownNode: null, visible: (!isFirstNode) }
            ];

    var popBody = document.createElement("div");
    popBody.setAttribute("class", "pop-body");

    for (var i = 0; i < cl.length; i++) {
        var label = document.createElement("label");
        label.appendChild(document.createTextNode(cl[i].label));

        var select = null;
        if (cl[i].type == "ddl") {
            select = document.createElement("select");
            select.setAttribute("class", cl[i].cssClass);
            select.setAttribute("id", cl[i].id);

            if (cl[i].allowChange) {
                select.setAttribute("dril-down-node", cl[i].drillDownNode);
                select.bindEvent("change", function (e) {
                    if (this.value != "" && this.value != null && this.value != undefined) {
                        var ddlNodeName = this.getAttribute("dril-down-node");
                        var ddToSend = {};
                        for (var i = 0; i < cl.length; i++) {
                            ddToSend[cl[i].id] = document.getElementById(cl[i].id).value;
                        }
                        var ddToSendTemp = arg[0];                      
                        ddToSend = orgChart.prototype.extend(ddToSend, ddToSendTemp, ["url"]);
                        ddToSend["MethodName"] = "ddlDrilDown";
                        ddToSend["param"] = ddlNodeName;
                        ddToSend["value"] = this.value;
                        var ddDataStr = orgChart.prototype.execAjax(arg[0].url, ddToSend);
                        var ddData = eval(ddDataStr);
                        var ddlNode = document.getElementById(ddlNodeName);
                        orgChart.prototype.ClearDropdown(ddlNode);
                        for (var ddi = 0; ddi < ddData.length; ddi++) {
                            var option = document.createElement("option");
                            option.text = ddData[ddi].Text;
                            option.value = ddData[ddi].Value;
                            ddlNode.appendChild(option);
                        }
                    }                    
                });
            }
            
            var argTemp = arg[0];           
            var ajxArg = orgChart.prototype.extend(cl[i], argTemp, ["url"]);
            ajxArg["MethodName"] = "loadOrgDdl";
            ajxArg["IsFristNode"] = isFirstNode;
            
            var option_List = orgChart.prototype.execAjax(arg[0].url, ajxArg);
            var optionList = eval(option_List);
            for (var oi = 0; oi < optionList.length; oi++) {
                var option = document.createElement("option");
                option.text = optionList[oi].Text;
                option.value = optionList[oi].Value;
                select.appendChild(option);
            }
        }

        var formElement = document.createElement("div");
        formElement.setAttribute("class", "form-element");

        if (cl[i].visible==false){
            formElement.setAttribute("style", "display:none;");
        }

        $(formElement).append(label);
        $(formElement).append(select);
        $(popBody).append(formElement);
    }

    var popupForm = document.createElement("div");
    popupForm.setAttribute("class", "popup-form");
    var h1 = document.createElement("h1");
    h1.appendChild(document.createTextNode(arg[0].popupHeadText));

    popupForm.appendChild(h1);
    popupForm.appendChild(popBody);

    var popupInner = document.createElement("div");
    popupInner.setAttribute("class", "popup-inner");

    var saveAction = document.createElement("input");
    saveAction.setAttribute("data-popup-close", "popup-area");
    saveAction.setAttribute("type", "button");
    saveAction.setAttribute("value", " Save ");
    saveAction.bindEvent("click", function (e) {  
        var dataToSend = orgChart.prototype.extend(arg[0], {}, ["url"]);
        for (var i = 0; i < cl.length; i++){
            dataToSend[cl[i].id] = document.getElementById(cl[i].id).value;
        }
        var res = orgChart.prototype.execAjax(arg[0].url, dataToSend);
        res = eval("[" + res + "]");       

        if (res[0].ErrorCode == "0") {
            window.location.reload();
        }
        else {
            alert(res[0].Msg)
        }
      
    });

    var closePopup = document.createElement("a");
    closePopup.setAttribute("class", "popup-close");
    closePopup.setAttribute("data-popup-close", "popup-area");
    closePopup.setAttribute("title", " Close ");
    closePopup.setAttribute("id", "Close_OrgChartManager_" + arg[0].chartId);
    closePopup.setAttribute("href", "javascript:void(0);");
    closePopup.appendChild(document.createTextNode("X"));
    closePopup.bindEvent("click", function (e) {
        $("#orgChartManager_" + arg[0].chartId).remove();
    }, false);

    popupInner.appendChild(popupForm);
    popupInner.appendChild(saveAction);
    popupInner.appendChild(closePopup);

    var popup = document.createElement("div");
    popup.setAttribute("class", "popup");
    popup.setAttribute("data-popup", "popup-area");
    popup.setAttribute("id", "orgChartManager_" + arg[0].chartId);
    popup.appendChild(popupInner);
    (document.getElementsByTagName('body'))[0].appendChild(popup);
};

orgChart.prototype.extend = function (a, b, e) {
    if (e == undefined || e == null || typeof (e) != "object")
        e = [];

    var f = {};
    var kl = orgChart.prototype.GetJsonKeys(a);//Object.keys(a);
    for (var i = 0; i < kl.length; i++) {
        if (e.indexOf(kl[i]) == -1) {
            f[kl[i]] = a[kl[i]];
        }
    }

    kl = orgChart.prototype.GetJsonKeys(b);//Object.keys(b);
    for (var i = 0; i < kl.length; i++) {
        if (e.indexOf(kl[i]) == -1) {
            f[kl[i]] = b[kl[i]];
        }       
    }
    return f;
};

orgChart.prototype.ClearDropdown = function (selectbox) {
    var i;
    for (i = selectbox.options.length - 1 ; i >= 0 ; i--) {
        selectbox.remove(i);
    }
};

orgChart.prototype.GetJsonKeys = function (obj) {
    var ret = [];
    for (var prop in obj) if (obj.hasOwnProperty(prop)) ret.push(prop)
    return ret;
};

if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (searchElement, fromIndex) {
        var k;
        if (this == null) {
            throw new TypeError('"this" is null or not defined');
        }

        var o = Object(this);
        var len = o.length >>> 0;
        if (len === 0) {
            return -1;
        }

        var n = +fromIndex || 0;
        if (Math.abs(n) === Infinity) {
            n = 0;
        }

        if (n >= len) {
            return -1;
        }

        k = Math.max(n >= 0 ? n : len - Math.abs(n), 0);
        while (k < len) {
            if (k in o && o[k] === searchElement) {
                return k;
            }
            k++;
        }
        return -1;
    };
}

Element.prototype.bindEvent = function (evt, fn) {
    try{
        this.attachEvent("on" + (evt.toString()), fn);
    }
    catch (ex) {
        this.addEventListener(evt.toString(), fn, true);
    }
    return this;
};
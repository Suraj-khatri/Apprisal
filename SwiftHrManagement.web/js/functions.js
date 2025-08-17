function LoadRegion(flag, divZip, divDistrict, region) {
    if (flag == 'o') {                          //o - for Other
        ShowElement(divZip);
        HideElement(divDistrict);
        GetElement(region).innerHTML = "State";
        return;
    }
    else if (flag == 'n') {                     //n - for Nepal
        ShowElement(divDistrict);
        HideElement(divZip);
        GetElement(region).innerHTML = "Zone";
        return;
    }
}

function ReadData(id, singleQuote, focusIfNull) {
    var obj = document.getElementById(id);
    if (obj) return (singleQuote ? "'" + obj.value + "'" : obj.value);
    return "null";
}

function IsCSVFile(fileName) {
    var file_parts = fileName.split(".");

    if (file_parts[file_parts.length - 1].toUpperCase() == "CSV")
        return true;
    return false;

}

function HideElement(id) {
    ObjHide(GetElement(id));
}

function ObjHide(obj) {
    try {
        obj.style.display = "none";
    } catch (ex) { }
}

function ShowElement(id) {
    ObjShow(GetElement(id));
}

function ObjShow(obj) {
    try {
        obj.style.display = "";
    } catch (ex) { }
}

function OpenInNewWindow(url) {
    window.open(url, "", "width=825,height=500,resizable=1,status=1,toolbar=0,scrollbars=1,center=1");
}
function OpenInNewSmallWindow(url) {
    window.open(url, "", "width=430,height=300,resizable=1,status=1,toolbar=0,scrollbars=1,center=1");
}
function GetValue(id) {
    var obj = document.getElementById(id);
    if (obj == null || obj == undefined)
        return "";
    return obj.value;
}

function GetElement(id) {

    return document.getElementById(id);
}


function GetDateValue(id) {
    var value = GetValue(id);

    if (value == "")
        return value;

    var dateParts = value.split("/");

    if (dateParts.length < 3)
        return "";

    var m = dateParts[0].toString("00");
    var d = dateParts[1].toString("00");
    var y = dateParts[2].toString("0000");

    return y + "-" + m + '-' + d;

}

function SelectOrClearByElement(elements, boolSelect) {
    for (var i = 0; i < elements.length; i++) {
        try {
            elements[i].checked = boolSelect;
        } catch (ex) {
        }
    }
}


function SelectOrClearById(cbContainerId, boolSelect) {
    var elements = GetElement(cbContainerId).getElementsByTagName("input");
    SelectOrClearByElement(elements, boolSelect);
}


function EnableOrDisableDdlByElement(elements, boolDisabled) {
    for (var i = 0; i < elements.length; i++) {
        try {
            elements[i].disabled = boolDisabled;
        } catch (ex) {
        }
    }
}

function EnableOrDisableDdlById(cbContainerId, boolDisabled) {
    var elements = GetElement(cbContainerId).getElementsByTagName("select");
    EnableOrDisableDdlByElement(elements, boolDisabled);
}

function PrintWindow() {
    window.print();
}
function DownloadReport(path) {
    url = path + "/Download.aspx?mode=report";
    OpenInNewWindow(url);
}
function HasValidExtension(fileName, ext) {
    var file_parts = fileName.split(".");

    if (file_parts[file_parts.length - 1].toUpperCase() == ext.toUpperCase())
        return true;

    return false;

}

function DownloadInNewWindow(url) {
    window.open(url, "", "width=825,height=500,resizable=1,status=1,toolbar=0,scrollbars=1,center=1");
}

function SelectFunctions(me, parent) {
    var elements = document.getElementsByName("functionId");
    var cssName = me.className;
    var cssLength = cssName.length;

    var newCss = "";
    var boolChecked = false;
    if (cssName.substr(cssLength - 8, cssLength) == "Selected") {
        newCss = cssName.substr(0, cssLength - 8);
    } else {
        newCss = cssName + "Selected";
        boolChecked = true;
    }

    var parentLength = parent.length;
    for (var i = 0; i < elements.length; i++) {
        if (!elements[i].disabled) {
            var value = elements[i].value;
            if (value.substr(0, parentLength) == parent) {
                elements[i].checked = boolChecked;
            }
        }
    }
    me.className = newCss;
}
function Redirect(url) {
    window.parent.location = url;
}

function OpenDialog(url, height, width, left, top) {
    return window.showModalDialog(url, window.self, "dialogHeight:" + height + "px;dialogWidth:" + width + "px;dialogLeft:" + left + "px;dialogTop:" + top + "px");
}

function CloseDialog(returnValue) {
    window.returnValue = returnValue;
    window.close();
}

function GoBack() {
    window.history.back(1);
}

function OpenWindow(url) {
    var browser = navigator.appName;
    if (browser == "Microsoft Internet Explorer") {
        window.opener = self;
    }

    window.open(url, "", "width=900,height=750,toolbar=no,scrollbars=yes,location=no,resizable =yes");
    window.moveTo(0, 0);
    window.resizeTo(screen.width, screen.height - 100);
    self.close();
}

function FindPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        curleft = obj.offsetLeft
        curtop = obj.offsetTop
        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft
            curtop += obj.offsetTop
        }
    }
    return [curleft, curtop];
}

function numericOnly(obj, e, supportDecimal) {
    //var e = event || evt; // for trans-browser compatibility
	
    var evtobj = window.event ? event : e;
    if (evtobj.altKey || evtobj.ctrlKey)
        return true;

    var charCode = e.which || e.keyCode;
	
    if (charCode == 46 || charCode == 8 || charCode == 9 || charCode == 37 || charCode == 39 || charCode == 109)
        return true;

    var char = String.fromCharCode(charCode);
    //alert(charCode + "    " + char);
	
    if (char == "." || char == "¾" || charCode == 110) {
        if (obj.value.indexOf(".") > -1)
            return false;
        else
            return true;
    }

    if (!isNaN(char))
        return true;

     if ((char >= "0" && char <= "9") || (charCode >= 96 && charCode <= 105))
         return true;

        return false;

}

function manageOnPaste(me) {
    return true;
}

function resetInput(obj, hint, type, isNum) {
    val = parseFloat(obj.value);
    if (type == 1) { //focus 
        if (val == hint || (isNum && isNaN(val))) {obj.value = ""; }
        
    }
    else { //Lost foucs
        if (val.length == 0 || (isNum && isNaN(val))) {obj.value = hint; }
    }
}

function ParseMessageToArray(mes) {
    var results = mes.split("-:::-");
    return results;
}

//function printMessage(data) {
//    var rptCentraizeMassege = window.parent.document.getElementById("rptCentraizeMassege");
//    rptCentraizeMassege.innerHTML = "";

//    var results = data.split("-:::-");

//    var cssClass = results[0] == "0" ? "success" : (results[0] == "1" ? "errorExplanation" : "warning");

//    rptCentraizeMassege.innerHTML = results[1];
//    rptCentraizeMassege.className = cssClass;
//}

//function printMessage(data) {
//    var rptCentraizeMassege = window.parent.document.getElementById("rptCentraizeMassege");
//    rptCentraizeMassege.innerHTML = "";

//    var results = data.split("-:::-");

//    var cssClass = results[0] == "0" ? "success" : (results[0] == "1" ? "errorExplanation" : "warning");

//    rptCentraizeMassege.innerHTML = results[1];
//    rptCentraizeMassege.className = cssClass;

//    parent.SetMessageBox(results[1], result[0]);
//}

function ParseResultJsPrint(errorCode, msg, id) {
    return errorCode + "-:::-" + msg + "-:::-" + id;
}

function cVal(data) {
    var res = parseFloat(data);
    if (isNaN(res)) res = 0;
    return res;
}
function hideMessageBox() {
    var rptCentraizeMassege = document.getElementById("rptCentraizeMassege");
    rptCentraizeMassege.innerHTML = "";
    rptCentraizeMassege.className = "";
}

function SetValueByObj(obj, value, innerHTML) {
    if (innerHTML) {
        obj.innerHTML = value;
    } else {
        obj.value = value;
    }
}

function SetValueById(id, value, innerHTML) {
    SetValueByObj(GetElement(id), value, innerHTML);
}

function SetCSSById(id, css) {
    SetValueByObj(GetElement(id), css);
}

function SetCSSByObj(obj, css) {
    obj.className = css;
}
function CheckNumber(obj) {
    obj.value = cVal(obj.value);
}

function PopUpWindow(url, param) {
    if (param == undefined || param == "") {
        param = "dialogHeight:400px;dialogWidth:500px;dialogLeft:300;dialogTop:100;center:yes";
    }

    return window.showModalDialog(url, window.self, param);
}
function PopUpWithCallBack(url, param) {

    if (param == undefined || param == "") {
        param = "dialogHeight:400px;dialogWidth:500px;dialogLeft:300;dialogTop:100;center:yes";
    }

    errorCode = window.showModalDialog(url, window.self, param);
    CallBack();
}

function TrackChanges(hddField) {
    GetElement(hddField).value = 'y';
}

function OpenInNewWindow(url) {
    window.open(url, "", "width=825,height=500,resizable=1,status=1,toolbar=0,scrollbars=1,center=1");
}

function downloadInNewWindow(url) {
    window.open(url, "", "width=825,height=500,resizable=1,status=1,toolbar=0,scrollbars=1,center=1");
}


function GetIds(name) {

    var elements = document.getElementsByName(name);
    var list = "";

    for (var i = 0; i < elements.length; i++) {
        try {
            if (elements[i].checked) {
                list = list + (list != "" ? ", " : "") + elements[i].value;
            }
        } 
        catch (ex) {
            return "";
        }
    }

    return list;
}

//Textbox with Comma Separation
function CurrencyFormatted(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    i = parseInt((i + .005) * 100);
    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}

function CommaFormatted(amount) {
    var delimiter = ",";
    var a = amount.split('.', 2);
    var d = a[1];
    var i = parseInt(a[0]);
    if (isNaN(i)) { return ''; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    var n = new String(i);
    var a = [];
    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }
    if (n.length > 0) { a.unshift(n); }
    n = a.join(delimiter);
    if (d.length < 1) { amount = n; }
    else { amount = n + '.' + d; }
    amount = minus + amount;
    return amount;

}


function UpdateComma(obj) {
    var s = new String();
    var amt = obj.value.replace(",", "");
    amt = amt.replace(",", "");
    amt = amt.replace(",", "");
    amt = amt.replace(",", "");

    //alert(amt);

    s = CurrencyFormatted(amt);
    s = CommaFormatted(s);

    obj.value = s;
}

function roundNumber(rnum, rlength) { // Arguments: number to round, number of decimal places
    var newnumber = Math.round(rnum * Math.pow(10, rlength)) / Math.pow(10, rlength);
    return parseFloat(newnumber); // Output the result to the form field (change for your purposes)
}

//End

var CTRL = false;
var SHIFT = false;
var ALT = false;
var CHAR_CODE = -1;

function KeyDownHandler(e) {
    var x = '';
    if (document.all) {
        var evnt = window.event;
        x = evnt.keyCode;
    }
    else {
        x = e.keyCode;
    }
    DetectKeys(x, true);
    Lock();
}

function KeyUpHandler(e) {
    var x = '';
    if (document.all) {
        var evnt = window.event;
        x = evnt.keyCode;
    }
    else {
        x = e.keyCode;
    }
    DetectKeys(x, false);
    Lock();

}
function DetectKeys(KeyCode, IsKeyDown) {
    if (KeyCode == '16') {
        SHIFT = IsKeyDown;
        CHAR_CODE = -1;
    }
    else if (KeyCode == '17') {
        CTRL = IsKeyDown;
        CHAR_CODE = -1;
    }
    else if (KeyCode == '18') {
        ALT = IsKeyDown;
        CHAR_CODE = -1;
    }
    else {
        if (IsKeyDown)
            CHAR_CODE = KeyCode;
        else
            CHAR_CODE = -1;
    }
}
function Lock() {
    if (ALT && CHAR_CODE == 76) {
        if (confirm("Are you sure you want to lock application?")) {
//            Session("url") = document.getElementById("frmame_main").contentWindow.location.href;
            var url = document.getElementById("frmame_main").contentWindow.location.href;
            window.location.replace('Lock.aspx?url=' + url);
        }
    }
}

//START RATE MASKING
function checkRateMasking(obj, beforeLength, afterLength) {

    if (isNaN(obj.value)) {

        alert("Please, Enter valid number !");
        setTimeout(function() { obj.focus(); }, 1);
        return;
    }

    if (obj.value.indexOf(".") > 0) {

        var resStr = obj.value.split(".");
        if (beforeLength != "99" && obj.value != "0" && obj.value != "") {
            if (resStr[0].length > beforeLength) {
                if (parseInt(resStr[0].length) != parseInt(beforeLength)) {
                    alert("Error, Only " + beforeLength + " digit(s) are allowed before decimal !");
                    setTimeout(function() { obj.focus(); }, 1);
                    return;
                }
            }
        }
        if (afterLength != "99" && obj.value != "0" && obj.value != "") {
            if (resStr[1].length > afterLength) {
                if (resStr[1].length != afterLength) {
                    alert("Error, Only " + afterLength + " digit(s) are allowed after decimal !");
                    setTimeout(function() { obj.focus(); }, 1);
                    return;
                }
            }
        }
    }
        else {
            if (beforeLength != "99" && obj.value != "0" && obj.value != "") {
                if (parseInt(obj.value.length) != parseInt(beforeLength)) {
                    alert("Error, Only " + beforeLength + " digit(s) are allowed before decimal !");
                    setTimeout(function() { obj.focus(); }, 1);
                    return;
                }
            }
        }


    }
//END MASKING VALIDATION

//ALLOW ONLY 2 NUMBER AFTER DECIMAL 
function CheckDecimal(evt) {
    var element = evt.currentTarget.id;
    var val = document.getElementById(element).value;
    if (isNaN(val)) {
        val = val.replace(/[^0-9\.]/g, '');
        if (val.split('.').length > 2)
            val = val.replace(/\.+$/, "");
    }
    var split = val.split('.');
    if (split.length > 1)
        if (split[1].length > 2) {
            split[1] = split[1].substring(0, 2);
            val = split[0] + '.' + split[1];
        }
    document.getElementById(element).value = val;
}


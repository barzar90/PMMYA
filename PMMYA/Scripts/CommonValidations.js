function opendoc(ctrlpath) {

    window.open(document.getElementById(ctrlpath).value);
    return true;
}

function dialogOpen(dialogname, Height, Width, Bacframe, Modal) {
    str = "#" + dialogname;
    $(str).dialog({
        bgiframe: Bacframe,
        autoOpen: false,
        modal: Modal,
        height: Height,
        width: Width
    });
    $(str).dialog('open');
}

function DisplayCal22(ctrl) {
    jQuery(function DisplayCal2() {

        var ids = ctrl.id;
        $("#" + ids).mask("99/99/9999");

        $("#" + ids).datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            onSelect: function (dateText) { validatedate(this.id) }

        });
    });
}
   

function dialogClosed(dialogname) {
    str = "#" + dialogname;
    $(str).dialog('close');
}

function ValidateChar(Ctrlname, characters) {
    str = "#" + Ctrlname;
    $(str).dialog('close');
}

function toggleDisplay(CtrlName, flag) {
    element = document.getElementById(CtrlName).style;
    if (flag == 1) {
        element.display = 'none';
    }
    else {
        element.display = 'block';
    }
}

function getMarathiNumbers(ctrlname) {
    var i = 0;
    var value = document.getElementById(ctrlname).value;
    var strTempstring = value;
    var NewValue = "";
    while (strTempstring.length > 0) {
        var len = value.length - i;
        var char = strTempstring.substring(0, 1);
        strTempstring = strTempstring.substring(1, len);
        switch (char) {
            case '1':
                NewValue = NewValue + "१";
                break;
            case '2':
                NewValue = NewValue + "२";
                break;
            case '3':
                NewValue = NewValue + "३";
                break;
            case '4':
                NewValue = NewValue + "४";
                break;
            case '5':
                NewValue = NewValue + "५";
                break;
            case '6':
                NewValue = NewValue + "६";
                break;
            case '7':
                NewValue = NewValue + "७";
                break;
            case '8':
                NewValue = NewValue + "८";
                break;
            case '9':
                NewValue = NewValue + "९";
                break;
            case '0':
                NewValue = NewValue + "०";
                break;
            default:
                NewValue = NewValue + char;
                break;

        }
    }
    document.getElementById(ctrlname).value = NewValue;
}

function getEnglishNumbers(ctrlname) {
    var i = 0;
    var value = document.getElementById(ctrlname).value;
    var strTempstring = value;
    var NewValue = "";
    while (strTempstring.length > 0) {
        var len = value.length - i;
        var char = strTempstring.substring(0, 1);
        strTempstring = strTempstring.substring(1, len);
        switch (char) {
            case '१':
                NewValue = NewValue + "1";
                break;
            case '२':
                NewValue = NewValue + "2";
                break;
            case '३':
                NewValue = NewValue + "3";
                break;
            case '४':
                NewValue = NewValue + "4";
                break;
            case '५':
                NewValue = NewValue + "5";
                break;
            case '६':
                NewValue = NewValue + "6";
                break;
            case '७':
                NewValue = NewValue + "7";
                break;
            case '८':
                NewValue = NewValue + "8";
                break;
            case '९':
                NewValue = NewValue + "9";
                break;
            case '०':
                NewValue = NewValue + "0";
                break;
            default:
                NewValue = NewValue + char;
                break;

        }
    }
    document.getElementById(ctrlname).value = NewValue;
}


function getMarathiNumbersValue(value) {
    var i = 0;
    var NewValue = "";
    var strTempstring = value;
    var len = value.toString().length;
    while (strTempstring.toString().length > 0) {
        len = value.toString().length - i;
        var char = strTempstring.toString().substring(0, 1);
        strTempstring = strTempstring.toString().substring(1, len);
        switch (char) {
            case '1':
                NewValue = NewValue + "१";
                break;
            case '2':
                NewValue = NewValue + "२";
                break;
            case '3':
                NewValue = NewValue + "३";
                break;
            case '4':
                NewValue = NewValue + "४";
                break;
            case '5':
                NewValue = NewValue + "५";
                break;
            case '6':
                NewValue = NewValue + "६";
                break;
            case '7':
                NewValue = NewValue + "७";
                break;
            case '8':
                NewValue = NewValue + "८";
                break;
            case '9':
                NewValue = NewValue + "९";
                break;
            case '0':
                NewValue = NewValue + "०";
                break;
            default:
                NewValue = NewValue + char;
                break;

        }
    }
    return NewValue;
}

function getEnglishNumbersValue(value) {
    var i = 0;
    var strTempstring = value;
    var NewValue = "";
    while (strTempstring.length > 0) {
        var len = value.length - i;
        var char = strTempstring.substring(0, 1);
        strTempstring = strTempstring.substring(1, len);
        switch (char) {
            case '१':
                NewValue = NewValue + "1";
                break;
            case '२':
                NewValue = NewValue + "2";
                break;
            case '३':
                NewValue = NewValue + "3";
                break;
            case '४':
                NewValue = NewValue + "4";
                break;
            case '५':
                NewValue = NewValue + "5";
                break;
            case '६':
                NewValue = NewValue + "6";
                break;
            case '७':
                NewValue = NewValue + "7";
                break;
            case '८':
                NewValue = NewValue + "8";
                break;
            case '९':
                NewValue = NewValue + "9";
                break;
            case '०':
                NewValue = NewValue + "0";
                break;
            default:
                NewValue = NewValue + char;
                break;

        }
    }
    return NewValue;
}

function ValidateCharacter1(strValidChars, evt) //Function does not allow to enter character on keypress
{
    //var strValidChars = "0123456789";
    //    var strChar  
    //    var strString = String.fromCharCode(window.event.keyCode.toString());
    //    strChar = strString.charAt(0);
    //    if (strValidChars.indexOf(strChar) == -1)
    //    {
    //        window.event.keyCode = 0
    //    }
    //    return false;
    var strChar = "";

    var charCode = (evt.which) ? evt.which : event.keyCode
    var strString = String.fromCharCode(charCode);
    strChar = strString.charAt(0);

    if (strValidChars2.indexOf(strChar) == -1) {
        return false;
    }
    else {
        return true;
    }
}

function ValidateCharacter(strValidChars, evt) //Function does not allow to enter character on keypress
{
    var strChar = "";
    var charCode = (evt.which) ? evt.which : event.keyCode
    var strString = String.fromCharCode(charCode);
    strChar = strString.charAt(0);
    var strValidChars2 = getEnglishNumbersValue(strValidChars);
    if (strValidChars2.indexOf(strChar) == -1) {
        if ((charCode == 8)) {
            return true;
        }
        else
        {
        return false;
        }
    }
    else {

        return true;
    }
}

function OpenSearchWindow(Flag, CtrlName1, CtrlName2) {
    window.open("../SearchUtil/SearchCustomer.aspx?Flag=" + Flag + "&CtrlName1=" + CtrlName1 + "&CtrlName2=" + CtrlName2 + "", '', 'left=0,top=0,width=800,height=500');
}
function DisplayAlertMessageBox(Message) {
    //    jAlert(Message,"MESSAGE");
    alert(Message);
}
function DisplayConfirmMessageBox(Message) {
    var bl = false;
    jConfirm(Message, 'Confirmation Dialog', function (r) {
        if (r == true) {
            bl = true;
            alert("HI");
        }
        else
            bl = false;
    });

    return bl;
}
function CloseMessageWindow() {
    document.getElementById('divMessage').style.visibility = 'hidden';
}

function Confirm(msg) {
    return confirm(msg);
}

function CheckSession(UserId) {
    if (UserId == "") {
        window.open("../Session.aspx", "_self");
        return false;
    }
    else {
        return true;
    }
}
function pad(number, length) {
    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }
    return str;

}
function ISNULL(strValue) {
    if (strValue == "" || strValue == "null" || strValue == null) {
        return strValue = "";
    }
    else {
        return strValue;
    }
}
function ISNUMBER(strValue) {
    if (strValue == "" || strValue == "null" || strValue == null || strValue == "NaN") {
        return strValue = parseFloat(0);
    }
    else {
        return parseFloat(strValue);
    }
}
function CurrentDate(CtrlName) {
    var dt = new Date();
    var dtstring = pad(dt.getDate(), 2) + '-' + pad(dt.getMonth() + 1, 2) + '-' + dt.getFullYear();
    document.getElementById(CtrlName).value = dtstring;
}
function OpenErrorWindow(ErrorMessage) {
    window.open("Oops.aspx?Msg=" + ErrorMessage, "_self");
}
function isDate(dateStr) {

    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var matchArray = dateStr.match(datePat); // is the format ok?

    if (matchArray == null) {
        DisplayAlertMessageBox("Please enter date as either dd/mm/yyyy or dd-mm-yyyy.");
        return false;
    }

    day = matchArray[1]; // p@rse date into variables
    month = matchArray[3];
    year = matchArray[5];

    if (month < 1 || month > 12) { // check month range
        DisplayAlertMessageBox("Month must be between 1 and 12.");
        return false;
    }

    if (day < 1 || day > 31) {
        DisplayAlertMessageBox("Day must be between 1 and 31.");
        return false;
    }

    if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31) {
        DisplayAlertMessageBox("Month " + month + " doesn`t have 31 days!")
        return false;
    }

    if (month == 2) { // check for february 29th
        var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        if (day > 29 || (day == 29 && !isleap)) {
            DisplayAlertMessageBox("February " + year + " doesn`t have " + day + " days!");
            return false;
        }
    }
    return true; // date is valid
}

function isInteger(s) {
    return parseInt(s, 10) === s;
}

function CheckDate(strEffectdate,ConditionType) {
    var FromDateMM1 = strEffectdate.substring(3, 5);
    var FromDateDD1 = strEffectdate.substring(0, 2);
    var FromDateYYYY1 = strEffectdate.substring(6);

    var CtrlDate = FromDateYYYY1 + "-" + FromDateMM1 + "-" + FromDateDD1;

    var dt = new Date();
    var curdate = pad(dt.getDate(), 2) + '-' + pad(dt.getMonth() + 1, 2) + '-' + dt.getFullYear();
    var Newdate = curdate;
    var ToDateMM1 = Newdate.substring(3, 5);
    var ToDateDD1 = Newdate.substring(0, 2);
    var ToDateYYYY1 = Newdate.substring(6);
    var CurrentDate = ToDateYYYY1 + "-" + ToDateMM1 + "-" + ToDateDD1;

    if (ConditionType == "G") {
        if (CtrlDate < CurrentDate) {
            return false;
        }
        else {
            return true;
        }
    }
    else if (ConditionType == "L") {
        if (CtrlDate > CurrentDate) {
            return false;
        }
        else {
            return true;
        }
    }
}
function EndDate(CtrlName) {
    var CurrentDate = document.getElementById(CtrlName).value;
    var FromFinanceMM1 = CurrentDate.substring(3, 5);
    var FromFinanceDD1 = CurrentDate.substring(0, 2);
    var FromFinanceYYYY1 = CurrentDate.substring(6);
    var StartDate = FromFinanceYYYY1 + '-' + FromFinanceMM1 + '-' + FromFinanceDD1;
    var DateUpto = "";
    if (FromFinanceMM1 == 01 || FromFinanceMM1 == 03 || FromFinanceMM1 == 05 || FromFinanceMM1 == 07 || FromFinanceMM1 == 08 || FromFinanceMM1 == 10 || FromFinanceMM1 == 12) {
        DateUpto = "31-" + FromFinanceMM1 + '-' + FromFinanceYYYY1;
    }
    else if (FromFinanceMM1 == 04 || FromFinanceMM1 == 06 || FromFinanceMM1 == 09 || FromFinanceMM1 == 11) {
        DateUpto = "30-" + FromFinanceMM1 + '-' + FromFinanceYYYY1;
    }
    else if (FromFinanceMM1 == 02) {
        var isleap = (FromFinanceYYYY1 % 4 == 0 && (FromFinanceYYYY1 % 100 != 0 || FromFinanceYYYY1 % 400 == 0));
        if (isleap == true) {
            DateUpto = "29-" + FromFinanceMM1 + '-' + FromFinanceYYYY1;
        }
        else {
            DateUpto = "28-" + FromFinanceMM1 + '-' + FromFinanceYYYY1;
        }
    }
    document.getElementById(CtrlName).value = DateUpto;
}
function IsNoSplChars() {

    if (!(event.keyCode >= 48 && event.keyCode <= 57)

    && !(event.keyCode >= 65 && event.keyCode <= 90)

    && !(event.keyCode >= 97 && event.keyCode <= 122)) {

        event.returnValue = false;

    }

}
function pad(number, length) {
    var str = '' + number;
    while (str.length < length) {
        str = '0' + str;
    }
    return str;

}
function Left(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0, n);
}
function ChangeUpperCase(CtrlName) {
    document.getElementById(CtrlName).value = document.getElementById(CtrlName).value.toUpperCase();
}
function ChangeLowerCase(CtrlName) {
    document.getElementById(CtrlName).value = document.getElementById(CtrlName).value.toLowerCase();
}
function ChangeTitleCase(CtrlName) {
    document.getElementById(CtrlName).value = document.getElementById(CtrlName).value.toTitleCase(); 
}

function Right(str, n) {
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else {
        var iLen = String(str).length;
        return String(str).substring(iLen, iLen - n);
    }
}

function Currentdate(ControlName) {
    var dt = new Date();
    var dtstring = pad(dt.getDate(), 2) + '-' + pad(dt.getMonth() + 1, 2) + '-' + dt.getFullYear();
    document.getElementById(ControlName).value = dtstring;
}
function FieldValidation(Elem, CheckEmpty, CheckInteger, MinLength, MaxLength, FieldName) {
    var Msg = "";
    Msg = FieldName + " ";
    if (CheckEmpty == true) {
        if (document.getElementById(Elem).value == "") {
            Msg = Msg + "cannot be blank";
            DisplayAlertMessageBox(Msg);
            document.getElementById(Elem).focus();
            return false;
        }
    }
    else if (CheckInteger == true) {
        if (document.getElementById(Elem).value == "") {
            Msg = Msg + "cannot be blank";
            DisplayAlertMessageBox(Msg);
            document.getElementById(Elem).focus();
            return false;
        }
        else if (parseInt(document.getElementById(Elem).value) < MinLength) {
            Msg = Msg + "cannot be less than " + MinLength;
            DisplayAlertMessageBox(Msg);
            document.getElementById(Elem).focus();
            return false;
        }
        else if (parseInt(document.getElementById(Elem).value) > MaxLength) {
            Msg = Msg + "cannot be less than " + MaxLength;
            DisplayAlertMessageBox(Msg);
            document.getElementById(Elem).focus();
            return false;
        }
    }
}

function IsNumeric(strString, Message, EmptyAllowed, NegativeAllowed, DecimalAllowed, MaxNoAllowed) {
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;
    var NoOfNegativeSigns = 0; var NoOfDecimalsieDots = 0;
    if (NegativeAllowed == true)
        strValidChars = strValidChars + '-';
    if (DecimalAllowed > 0)
        strValidChars = strValidChars + '.';
    if (EmptyAllowed == true) {
        if (strString.length == 0) return true;
        if (Trim(strString).length == 0) return true;
    }
    else {
        if (strString.length == 0) {
            DisplayAlertMessageBox(Message + ' should not be empty');
            return false;
        }
    }
    // Checking Weather All Characters are numeric are not
    for (i = 0; i < strString.length && blnResult == true; i++) {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            DisplayAlertMessageBox('Invalid characters in ' + Message);
            return false;
        }
    }
    if (NegativeAllowed == true) {
        // Check For -ve Sign Exists Only Once If Exists
        for (i = 0; i < strString.length && blnResult == true; i++) {
            strChar = strString.charAt(i);
            if (strString.charAt(i) == '-') {
                NoOfNegativeSigns++;
            }
        }
        if (NoOfNegativeSigns > 1) {
            DisplayAlertMessageBox('Invalid Number.');
            return false;
        }
        else if (NoOfNegativeSigns == 1) {
            if (strString.indexOf('-') > 0) {
                DisplayAlertMessageBox('Invalid Number');
                return false;
            }
        }
    }
    if (DecimalAllowed > 0) {
        // Check For Decimal Value Exists Only Once If Exists
        for (i = 0; i < strString.length && blnResult == true; i++) {
            strChar = strString.charAt(i);
            if (strString.charAt(i) == '.') {
                NoOfDecimalsieDots++;
            }
        }
        if (NoOfDecimalsieDots > 1) {
            DisplayAlertMessageBox('Invalid Number');
            //alert('Dots Are ' + NoOfDecimalsieDots + ' Times.');
            return false;
        }
        else if (NoOfDecimalsieDots == 1) {
            //alert(strString.substring(strString.indexOf('.') + 1, strString.length).length);
            if (strString.substring(strString.indexOf('.') + 1, strString.length).length > DecimalAllowed) {
                DisplayAlertMessageBox(Message + ' should be only ' + DecimalAllowed + ' Decimal Places.');
                return false;
            }
        }
    }
    if (strString > MaxNoAllowed) {
        DisplayAlertMessageBox(Message + ' should not be more than ' + MaxNoAllowed + '.');
        return false;
    }
    return true;
}

function ChangeColorOnGotFocus(CtrlName) {
    document.getElementById(CtrlName).style.backgroundColor = "#7299fc";
    document.getElementById(CtrlName).style.color = "#FFFFFF";
}
function ChangeColorOnLostFocus(CtrlName) {
    document.getElementById(CtrlName).style.backgroundColor = "";
    document.getElementById(CtrlName).style.color = "#000000";
}
function isNumberKey(evt, strValidChars) {
    var strChar = "";
    var charCode = (evt.which) ? evt.which : event.keyCode
    var strString = String.fromCharCode(charCode);
    strChar = strString.charAt(0);
    DisplayAlertMessageBox(strString);
    if (strValidChars.indexOf(strChar) == -1) {
        return false;
    }
    else {
        return true;
    }

}


function ValidateEMailCharacters() //Function does not allow to enter character not valid for EMail on keypress
{
    var strValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890.@&_";
    var strChar
    var strString = String.fromCharCode(window.event.keyCode.toString());
    strChar = strString.charAt(0);
    if (strValidChars.indexOf(strChar) == -1) {
        window.event.keyCode = 0
    }
    return false;
}
function CheckValidCharacter(validstring, InputString) {
    var charCheck;
    for (var i = 0; i <= InputString.length; i++) {
        charCheck = InputString.substring(i, i + 1);
        if (validstring.indexOf(charCheck) == -1) {
            return false;
        }
    }
    return true;
}
function Trim(str) {
    if (typeof str != "string") { return str; }
    while (str.charAt(0) == (" ")) {
        str = str.substring(1);
    }
    while (str.charAt(str.length - 1) == " ") {
        str = str.substring(0, str.length - 1);
    }
    return str;
}
function Validlength(textlength, MaxLength) {
    if (document.getElementById(textlength).value.length >= MaxLength) {
        window.event.keyCode = 0;
        return false;
    }
}
function EMailCheck(EMailStr, IsMandatory) {
    EMailStr = Trim(EMailStr);
    var checkTLD = 1;
    var knownDomsPat = /^(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum)$/;
    var emailPat = /^(.+)@(.+)$/;
    var specialChars = "\\(\\)><@,;:\\\\\\\"\\.\\[\\]";
    var validChars = "\[^\\s" + specialChars + "\]";
    var quotedUser = "(\"[^\"]*\")";
    var ipDomainPat = /^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/;
    var atom = validChars + '+';
    var word = "(" + atom + "|" + quotedUser + ")";
    var userPat = new RegExp("^" + word + "(\\." + word + ")*$");
    var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$");
    var matchArray = EMailStr.match(emailPat);
    if (EMailStr == '') {
        if (IsMandatory == true) {
            alert('E-Mail should not be blank.');
            return false;
        }
        else {
            return true;
        }
    }
    if (matchArray == null) {
        alert("Invalid EMail ID.");
        return false;
    }
    var user = matchArray[1];
    var domain = matchArray[2];
    for (i = 0; i < user.length; i++) {
        if (user.charCodeAt(i) > 127) {
            //DisplayAlertMessageBox("The username contains invalid characters.");
            alert("The Email Contains Invalid Characters For " + EMailStr);
            return false;
        }
    }
    for (i = 0; i < domain.length; i++) {
        if (domain.charCodeAt(i) > 127) {
            alert("The Domain Name Contains Invalid Characters For " + EMailStr);
            return false;
        }
    }
    if (user.match(userPat) == null) {
        alert("The Email Doesn't Seem To Be Valid For " + EMailStr);
        return false;
    }
    var IPArray = domain.match(ipDomainPat);
    if (IPArray != null) {
        for (var i = 1; i <= 4; i++) {
            if (IPArray[i] > 255) {
                alert("Destination IP address is invalid for " + EMailStr);
                return false;
            }
        }
        return true;
    }
    var atomPat = new RegExp("^" + atom + "$");
    var domArr = domain.split(".")
    var len = domArr.length;
    for (i = 0; i < len; i++) {
        if (domArr[i].search(atomPat) == -1) {
            alert("The domain name does not seem to be valid for" + EMailStr);
            return false;
        }
    }
    if (checkTLD && domArr[domArr.length - 1].length != 2 && domArr[domArr.length - 1].search(knownDomsPat) == -1) {
        alert("The address must end in a well-known domain or two letter " + "country.");
        return false;
    }
    if (len < 2) {
        alert("This address is missing a hostname " + EMailStr);
        return false;
    }
    return true;
}
function ToProperCase(str) {
    strTemp = str;
    strTemp = strTemp.toLowerCase();

    var test = "";
    var isFirstCharOfWord = 1;

    for (var intCount = 0; intCount < strTemp.length; intCount++) {
        var temp = strTemp.charAt(intCount);
        if (isFirstCharOfWord == 1) {
            temp = temp.toUpperCase();
        }
        test = test + temp
        if (temp == " ") {
            isFirstCharOfWord = 1;
        }
        else {
            isFirstCharOfWord = 0;
        }
    }
    return test;
}
function getCharacterCount(SourceTextBox, MaxLength, DestinationLabel) {
    //<textarea name="textarea" style="width: 240px" id="txtAddress" onkeydown=" return getCharacterCount('txtAddress','256','divMessage1')" onkeypress="Validlength('txtAddress', 256)"></textarea>
    //<div id = "divMessage1">
    //</div> 
    var intCharLength = document.getElementById(SourceTextBox).value.length + 1;
    var strText = "";
    if (window.event.keyCode == 8) {
        intCharLength = intCharLength - 1;
        if (document.getElementById(SourceTextBox).value.length == 0) {
            strText = "";
        }
        else {
            intCharLength = intCharLength - 1;
            if (intCharLength < 0) {
                intCharLength = 1;
                strText = "Total characters allowed : " + MaxLength + "<BR>You have typed " + intCharLength + " characters "
            }
            else {
                strText = "Total characters allowed : " + MaxLength + "<BR>You have typed " + intCharLength + " characters "
            }
        }
        document.getElementById(DestinationLabel).innerHTML = strText;
    }
    else {
        strText = "Total characters allowed : " + MaxLength + "<BR>You have typed " + intCharLength + " characters "
        document.getElementById(DestinationLabel).innerHTML = "";
    }
    //document.getElementById(DestinationLabel).innerHTML = strText;
}
function SQLSAFE(strSearchString) {
    var strReplaceString = "";

    if (!((strSearchString == "") || (strSearchString == null) || (strSearchString == "NULL") || (strSearchString == "null") || (strSearchString == "Null"))) {
        if (IsNumericWithAlert(strSearchString, true, true, 2, 10000) == false) {
            strReplaceString = replaceAll(strSearchString, "'", "&#39");
            strReplaceString = replaceAll(strReplaceString, '"', "&#39");
        }
        else {
            strReplaceString = strSearchString;
        }
    }
    else {
        strReplaceString = strSearchString;
    }

    return strReplaceString;
}
function replaceAll(OldString, FindString, ReplaceString) {
    var SearchIndex = 0;
    var NewString = "";
    while (OldString.indexOf(FindString, SearchIndex) != -1) {
        NewString += OldString.substring(SearchIndex, OldString.indexOf(FindString, SearchIndex));
        NewString += ReplaceString;
        SearchIndex = (OldString.indexOf(FindString, SearchIndex) + FindString.length);
    }
    NewString += OldString.substring(SearchIndex, OldString.length);
    return NewString;
}

function CountNoOfOccurance(OldString, FindString, ReplaceString) {
    var SearchIndex = 0;
    var NewString = "";
    var Count = 0;
    while (OldString.indexOf(FindString, SearchIndex) != -1) {
        Count = Count + 1;
        NewString += OldString.substring(SearchIndex, OldString.indexOf(FindString, SearchIndex));
        NewString += ReplaceString;
        SearchIndex = (OldString.indexOf(FindString, SearchIndex) + FindString.length);
    }
    NewString += OldString.substring(SearchIndex, OldString.length);
    return Count;
}
function LoadingPleaseWait(CtrlName) {
    var strGenerateString = "";
    strGenerateString = strGenerateString + "<center>";
    strGenerateString = strGenerateString + "<TABLE BORDER='0' BORDERCOLOR='#000000' CELLPADDING='0' CELLSPACING='0' WIDTH='100%'>";
    strGenerateString = strGenerateString + "<TR>";
    strGenerateString = strGenerateString + "<TD ALIGN='CENTER' VALIGN='MIDDLE' class='nodewhite'>";
    strGenerateString = strGenerateString + "<img src='Images/loading1.jpg'  alt='Report Loading .. Please Wait' />";
    strGenerateString = strGenerateString + "</TD>";
    strGenerateString = strGenerateString + "</TR>";
    strGenerateString = strGenerateString + "</TABLE>";
    strGenerateString = strGenerateString + "</center>";
    document.getElementById(CtrlName).innerHTML = strGenerateString;
    document.getElementById(CtrlName).style.height = "100px";
}
function IsNumericWithAlert(strString, EmptyAllowed, NegativeAllowed, DecimalAllowed, MaxNoAllowed) {
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;
    var NoOfNegativeSigns = 0; var NoOfDecimalsieDots = 0;
    if (NegativeAllowed == true)
        strValidChars = strValidChars + '-';
    if (DecimalAllowed > 0)
        strValidChars = strValidChars + '.';
    if (EmptyAllowed == true) {
        if (strString.length == 0) return true;
        if (Trim(strString).length == 0) return true;
    }
    else {
        if (strString.length == 0) {
            return false;
        }
    }
    // Checking Weather All Characters are numeric are not
    for (i = 0; i < strString.length && blnResult == true; i++) {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            return false;
        }
    }
    if (NegativeAllowed == true) {
        // Check For -ve Sign Exists Only Once If Exists
        for (i = 0; i < strString.length && blnResult == true; i++) {
            strChar = strString.charAt(i);
            if (strString.charAt(i) == '-') {
                NoOfNegativeSigns++;
            }
        }
        if (NoOfNegativeSigns > 1) {
            return false;
        }
        else if (NoOfNegativeSigns == 1) {
            if (strString.indexOf('-') > 0) {
                return false;
            }
        }
    }
    if (DecimalAllowed > 0) {
        // Check For Decimal Value Exists Only Once If Exists
        for (i = 0; i < strString.length && blnResult == true; i++) {
            strChar = strString.charAt(i);
            if (strString.charAt(i) == '.') {
                NoOfDecimalsieDots++;
            }
        }
        if (NoOfDecimalsieDots > 1) {
            return false;
        }
        else if (NoOfDecimalsieDots == 1) {
            //alert(strString.substring(strString.indexOf('.') + 1, strString.length).length);
            if (strString.substring(strString.indexOf('.') + 1, strString.length).length > DecimalAllowed) {
                return false;
            }
        }
    }
    if (strString > MaxNoAllowed) {
        return false;
    }
    return true;
}




function echeck(str) {
    var at = "@";
    var dot = ".";
    var lat = str.indexOf(at);
    var lstr = str.length;
    var ldot = str.indexOf(dot);
    if (str.indexOf(at) == -1) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.indexOf(at, (lat + 1)) != -1) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.indexOf(dot, (lat + 2)) == -1) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    if (str.indexOf(" ") != -1) {
        DisplayAlertMessageBox("Invalid E-mail ID");
        return false;
    }

    return true;
}


function CheckValidatePANCard(CtrlName) {
    var PANCard = document.getElementById(CtrlName).value;
    var regex1 = /^[A-Z]{5}\d{4}[A-Z]{1}$/;
    //this is the pattern of regular expersion
    if (regex1.test(PANCard) == false) {
        DisplayAlertMessageBox('Please enter valid pan number');
        document.getElementById(CtrlName).focus();
        return false;
    }
}

function CheckValidateServiceTaxNo(ServiceTaxCtrlName, PanCardCtrlName) {
    var PANCard = document.getElementById(PanCardCtrlName).value;
    var ServiceTax = document.getElementById(ServiceTaxCtrlName).value;
    var FirstTenChar = ServiceTax.substring(0, 10);
    var MiddleChar = ServiceTax.substring(10, 12);
    var LastChar = ServiceTax.substring(12, 15);
    if (ServiceTax.length < 15) {
        DisplayAlertMessageBox("Please enter a valid Service Tax Number");
        document.getElementById(ServiceTaxCtrlName).focus();
        return false;
    }
    else if (FirstTenChar != PANCard) {
        DisplayAlertMessageBox("Please enter a valid Service Tax Number");
        document.getElementById(ServiceTaxCtrlName).focus();
        return false;
    }
    else if (MiddleChar != "ST" && MiddleChar != "SD") {
        DisplayAlertMessageBox("Please enter a valid Service Tax Number");
        document.getElementById(ServiceTaxCtrlName).focus();
        return false;
    }
    else if (isInteger(LastChar) == false) {
        DisplayAlertMessageBox("Please enter a valid Service Tax Number");
        document.getElementById(ServiceTaxCtrlName).focus();
        return false;
    }

}

function isInteger(string) {

    var numericExpression = /^[0-9]+$/;

    if (string.match(numericExpression)) {

        return true;

    } else {

        return false;

    }

}

function ValidateMobileNo(CtrlName) {
    var MobileNo = document.getElementById(CtrlName).value;
    if (MobileNo != "") {
        var incomingString = MobileNo;
        if ((incomingString).length > 10 || incomingString.search(/[^0-9\-()+]/g) != -1) {
            DisplayAlertMessageBox('Please enter valid mobile number');
            document.getElementById(CtrlName).focus();
            return false;
        }
        else
            return true;
    }
    else {
        DisplayAlertMessageBox('Please enter valid mobile number');
        document.getElementById(CtrlName).focus();
        return false;
    }
}




function toggle(div_id) {
    var el = document.getElementById(div_id);
    if (el.style.display == 'none') { el.style.display = 'block'; }
    else { el.style.display = 'none'; }
}
function blanket_size(popUpDivVar, blanketname) {
    if (typeof window.innerWidth != 'undefined') {
        viewportheight = window.innerHeight;
    } else {
        viewportheight = document.documentElement.clientHeight;
    }
    if ((viewportheight > document.body.parentNode.scrollHeight) && (viewportheight > document.body.parentNode.clientHeight)) {
        blanket_height = viewportheight;
    } else {
        if (document.body.parentNode.clientHeight > document.body.parentNode.scrollHeight) {
            blanket_height = document.body.parentNode.clientHeight;
        } else {
            blanket_height = document.body.parentNode.scrollHeight;
        }
    }
    var blanket = document.getElementById(blanketname);
    blanket.style.height = blanket_height + 'px';
    var popUpDiv = document.getElementById(popUpDivVar);
    popUpDiv_height = blanket_height / 2 - 150; //150 is half popup's height
    //popUpDiv.style.top = popUpDiv_height + 'px';
}
function window_pos(popUpDivVar) {
    if (typeof window.innerWidth != 'undefined') {
        viewportwidth = window.innerHeight;
    } else {
        viewportwidth = document.documentElement.clientHeight;
    }
    if ((viewportwidth > document.body.parentNode.scrollWidth) && (viewportwidth > document.body.parentNode.clientWidth)) {
        window_width = viewportwidth;
    } else {
        if (document.body.parentNode.clientWidth > document.body.parentNode.scrollWidth) {
            window_width = document.body.parentNode.clientWidth;
        } else {
            window_width = document.body.parentNode.scrollWidth;
        }
    }
    var popUpDiv = document.getElementById(popUpDivVar);
    window_width = window_width / 2 - 150; //150 is half popup's width
    //popUpDiv.style.left = window_width + 'px';
}
function popup(windowname, blanketname) {

    //AddPCRI();
    blanket_size(windowname, blanketname);
    window_pos(windowname);
    toggle(blanketname);
    toggle(windowname);
}

function popupClose(windowname, blanketname) {
    blanket_size(windowname, blanketname);
    window_pos(windowname);
    toggle(blanketname);
    toggle(windowname);
}


//Returns Dates and day count for that particular day from selected date to end date of selected month. 
//Day starts with 0 ie Sunday=0, Monday=1.........Saturday=6. Parameters type are Date, int
function getDaysCount(date, day) {
    //   var valid = isDate(date);
    var valid = true;
    if (valid == true) {
        var userDate = new Date(date);
        //        var month = (userDate.getMonth() + 1);
        //        var year = userDate.getFullYear();
        var Dates = new Array();

        //        var modifiedDate = new Date(month + " /" + 1 + " /" + year);


        var modifiedDate = new Date(date);
        var Count = 0;

        while (modifiedDate.getMonth() == userDate.getMonth()) {
            if (modifiedDate.getDay() == day) {
                Dates[Count] = new Date(modifiedDate);
                Count++;
            }
            modifiedDate.setDate(modifiedDate.getDate() + 1);
        }
        Dates[Count] = Count;
        return Dates;

    }
}

// returns dates of selected day to the provided months
function getDaysCountByMonth(date, numberOfMonth) {


    var datePat = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
    var matchArray = date.match(datePat); // is the format ok?


    day = matchArray[1]; // p@rse date into variables
    month = matchArray[3];
    year = matchArray[5];

    var datetime = new Date(month + "/" + day + "/" + year);

    var count;
    var day = datetime.getDay();

    //   var valid = isDate(date);
    var valid = true;
    if (valid == true) {
        var userDate = new Date(datetime);
        var Dates = new Array();

        var endDate = new Date(userDate);
        endDate = new Date(endDate.setMonth(endDate.getMonth() + numberOfMonth));
        var Count = 0;
        while (userDate <= endDate) {
            if (userDate.getDay() == day) {
                var stringDate = userDate.getDate() + "/" + (userDate.getMonth() + 1) + "/" + userDate.getFullYear();
                Dates[Count] = stringDate;
                Count++;
            }
            userDate.setDate(userDate.getDate() + 1);
        }
        Dates[Count] = Count;
        return Dates;
    }


    //function for weeks only

    function weekends(dt) {
        return [dt.getDay() == 0 || dt.getDay() == 6, ""];
    }
   
    jQuery(document).ready(function () {
        jQuery('#date').datepicker({
            dateFormat: 'dd/mm/yy',
            constrainInput: true,
            beforeShowDay: weekends
        });
    });
    //end of functions for weeks only

}

//Added for static grid
function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
    var tbl = document.getElementById(gridId);
    if (tbl) {
        var DivHR = document.getElementById('DivHeaderRow');
        var DivMC = document.getElementById('DivMainContent');
        var DivFR = document.getElementById('DivFooterRow');


        //*** Set divheaderRow Properties ****
        DivHR.style.height = headerHeight + 'px';
        DivHR.style.width = (parseInt(width) - 16) + 'px';
        DivHR.style.position = 'relative';
        DivHR.style.top = '0px';
        DivHR.style.zIndex = '10';
        DivHR.style.verticalAlign = 'top';


        //*** Set divMainContent Properties ****
        DivMC.style.width = width + 'px';
        DivMC.style.height = height + 'px';
        DivMC.style.position = 'relative';
        DivMC.style.top = -headerHeight + 'px';
        DivMC.style.zIndex = '1';


        //*** Set divFooterRow Properties ****
        DivFR.style.width = (parseInt(width) - 16) + 'px';
        DivFR.style.position = 'relative';
        DivFR.style.top = -headerHeight + 'px';
        DivFR.style.verticalAlign = 'top';
        DivFR.style.paddingtop = '2px';


        if (isFooter) {
            var tblfr = tbl.cloneNode(true);
            tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
            var tblBody = document.createElement('tbody');
            tblfr.style.width = '100%';
            tblfr.cellSpacing = "0";


            tblfr.border = "0px";
            tblfr.rules = "none";
            //*****In the case of Footer Row *******
            tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
            tblfr.appendChild(tblBody);
            DivFR.appendChild(tblfr);
        }
        //****Copy Header in divHeaderRow****
        DivHR.appendChild(tbl.cloneNode(true));
    }
}

function OnScrollDiv(Scrollablediv) {
    document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
    document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
}
//end of static grid

// multiple comm separated EmailIds validation
function multipleEmailCheck(txtEmail, IsMandatory) {
    var arrEmailsIDs = new Array();
    arrEmailsIDs = txtEmail.split(",");

    for (i = 0; i < arrEmailsIDs.length; i++) {
        if (EMailCheck(arrEmailsIDs[i], false) == false) {
            return false;
        };
    }

}
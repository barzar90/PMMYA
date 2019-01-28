// @#
function checkfields(ctrl) {
    var str = ctrl.value
    var isnot = "!@#$%^&*+=|\~`?><':;{[}]_.,/()-";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                alert("only alphabets,numbers allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
            }
        }
    }

    return (inval);
}

function checkfields_Utility(ctrl) {
    var str = ctrl.value;
    var isnot = "!#$%^&|\~`?><:;{[}]/-";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                alert("only alphabets,numbers allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
            }

        }
    }

    return (inval);
}

function checkTextFields(ctrl) {
    var str = ctrl.value
    var isnot = "!@#$%^&*+=|\~`?><':;{[}]_";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                alert("only alphabets,numbers  and {.,/()-} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
            }
        }
    }

    return (inval);
}


function checkTextFieldsaddress(ctrl) {
    var str = ctrl.value
    var isnot = "!@#$%^&*+=|\~`?><':;{[}]_";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                // alert("only alphabets,numbers  and {.,/()-} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
                return false;
            }
        }
    }

    return (inval);
}

function checkRefNo(ctrl) {
    var str = ctrl.value
    var isnot = "!@#$%^&*+=\~`?><':;{[}]_()-.,";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                alert("only alphabets,numbers and {|/} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
            }
        }
    }

    return (inval);
}

function checkGatNo(ctrl) {

    var str = ctrl.value
    var isnot = "!@#$%^|&*+=\~`?><':;{[}]_()-.,";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                alert("only alphabets,numbers and {/} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
            }
        }
    }

    return (inval);
}

function RationCardStoreNo(ctrl) {
    var str = ctrl.value
    var isnot = "|!@#$%^&*+=\~`?><':;{[}]_().,";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                //                alert("only alphabets,numbers and {/} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
                return false;
            }
        }
    }

    return (inval);
}



function surveynumber(ctrl) {
    var str = ctrl.value
    var isnot = "|!@#$%^&*+=\~`?><':;{[}]_()-.,";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                //                alert("only alphabets,numbers and {/} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
                return false;
            }
        }
    }

    return (inval);
}



function VehicleNo(ctrl) {
    var str = ctrl.value
    var isnot = "/|!@#$%^&*+=\~`?><':;{[}]_().,-";
    var inval = 0;
    var x;
    for (var i = 0; i < str.length; i++) {
        for (x = 0; x < isnot.length; x++) {
            if (str.charAt(i) == (isnot.charAt(x))) {
                inval = 1;
                //                alert("only alphabets,numbers and {/} space allowed");
                ctrl.value = str.substring(0, str.indexOf(str.charAt(i)));
                ctrl.focus();
                return false;
            }
        }
    }

    return (inval);
}
function AlphaNumCheck(e) {
    var charCode = (e.which) ? e.which : e.keyCode;
    if (charCode == 8) return true;

    var keynum;
    var keychar;
    var charcheck = /[a-zA-Z0-9\s]/;
    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else {
        if (e.which) // Netscape/Firefox/Opera
        {
            keynum = e.which;
        }
        else return true;
    }

    keychar = String.fromCharCode(keynum);
    return charcheck.test(keychar);
}




function valAlphabetic(evt) {

    var charCode;
    var e = evt; // for trans-browser compatibility
    charCode = (e.which) ? e.which : event.keyCode;
    //charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode >= 97 && charCode <= 122 || charCode >= 65 && charCode <= 90 || charCode == 8 || charCode == 32) {
        return true;
    }
    else {
        return false;
    }
}
function onlyNumbers(evt) {

    flag = false
    var e = evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //alert("Only numbers are allowed");
        return false;
    }
    return true;
}

function OnlyNumbersWithDot(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
        return false;

    return true;

}

function checkDate(sender, args) {
    /* works with ajax calender extender*/
    if (sender._selectedDate > new Date()) {
        alert("You cannot select a day greater than today!");
        sender._selectedDate = new Date();
        // set the date back to the current date
        sender._textbox.set_Value(sender._selectedDate.format(sender._format))
    }
}

function IsAlphabetNumeric1(evt) {
    var charCode = (e.which) ? e.which : e.keyCode;
    if (charCode == 8) return true;

    var keynum;
    var keychar;
    var charcheck = /[a-zA-Z0-9]/;
    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else {
        if (e.which) // Netscape/Firefox/Opera
        {
            keynum = e.which;
        }
        else return true;
    }

    keychar = String.fromCharCode(keynum);
    return charcheck.test(keychar);
}

function IsAlphabetNumeric(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z0-9\_]+$/))
        return true
    return false
}

function IsAlphabetNumericAddress(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z0-9\_ ,]+$/))
        return true
    return false
}

function IsAlphabetNumericUserName(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z0-9_.\b]/))
        return true
    return false
}

function IsAlphabetNumericLoginUserName(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z0-9_.@\b]+$/))
        return true
    return false
}

function isNumericKey(evt) {
    flag = false
    var e = evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        alert("Only numbers are allowed");
        return false;
    }
    return true;
}


function IsAlphabet(evt) {   //alphabets and dot(Name field)
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z\b. ]+$/)) {
        return true;
    }
    return false;
}


function IsAlphaNumericOnly(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var txt = String.fromCharCode(charCode)
    if (txt.match(/^[a-zA-Z0-9\b\\]+$/)) {
        return true;
    }
    return false;


}

function isNumericKeyWithHyphen(e) {

    if (window.event) { var charCode = window.event.keyCode; }
    else if (e) { var charCode = e.which; }
    else { return true; }
    if (charCode == 45)
    { return true; }
    else if (charCode > 31 && (charCode < 48 || charCode > 57)) { return false; }
    return true;
}

//function IsAlphaNumeric(evt) {
//    var charCode = (evt.which) ? evt.which : event.keyCode
//    var txt = String.fromCharCode(charCode)
//    if (txt.match(/^[a-zA-Z0-9\b ./]+$/)) {
//        return true;
//    }
//    else {

//        return false;
//    }

//}

//function which checks and allows date less than and equal to today
function checkDateLessThanToday(control) {
    var txt = control;
    var arraydate = txt.value.split("-");

    var txttoday = new Date();
    var curr_date = txttoday.getDate();
    var curr_month = txttoday.getMonth() + 1; //Months are zero based
    var curr_year = txttoday.getFullYear();
    var a = curr_date + "-" + curr_month + "-" + curr_year;

    var val = txt.value;
    var isvalidate = false;
    if (val.length == 10) {
        var splits = val.split("-");
        var dt = new Date(splits[1] + "-" + splits[0] + "-" + splits[2]);
        //Validation for Dates
        if (dt.getDate() == splits[0] && dt.getMonth() + 1 == splits[1] && dt.getFullYear() == splits[2]) {
            isvalidate = true;
        }
        else {
            if (val != "__-__-____") {
                alert("InValid Date.");
                txt.value = "";
                isvalidate = false;
            }
        }
    }
    else {
        if (val != "__-__-____") {
            alert("InValid Date.");
            isvalidate = false;
        }
    }

    if (isvalidate == true) {
        if (arraydate[2] > curr_year) {
            alert("You cannot select a day Greater than today!");
            txt.value = "";
        }
        else if (arraydate[2] == curr_year) {
            if (arraydate[1] > curr_month) {
                alert("You cannot select a day Greater than today!");
                txt.value = "";
            }
            else if (arraydate[1] == curr_month) {
                if (arraydate[0] > curr_date) {
                    alert("You cannot select a day Greater than today!");
                    txt.value = "";
                }
            }
            else {
                if (txt.value > a) {
                    alert("You cannot select a day Greater than today!");
                    txt.value = "";
                }
            }
        }
    }
    return isvalidate;
}


//function which checks only correct date format
function checkValidDate(control) {
    var txt = control;
    var val = txt.value;
    var isvalidate = false;
    if (val.length == 10) {
        var splits = val.split("/");
        var dt = new Date(splits[1] + "/" + splits[0] + "/" + splits[2]);
        //Validation for Dates
        if (dt.getDate() == splits[0] && dt.getMonth() + 1 == splits[1] && dt.getFullYear() == splits[2]) {
            isvalidate = true;
        }
        else {
            if (val != "__/__/____") {
                alert("InValid Date.");
                txt.value = "";
                isvalidate = false;
            }
        }
    }
    else {
        if (val != "__/__/____") {
            alert("InValid Date.");
            isvalidate = false;
        }
    }
}


//function which checks and allows date greater than and equal to today
function checkDateGreaterThanToday(control) {
    var txt = control;
    var arraydate = txt.value.split("/");

    var txttoday = new Date();
    var curr_date = txttoday.getDate();
    var curr_month = txttoday.getMonth() + 1; //Months are zero based
    var curr_year = txttoday.getFullYear();
    var a = curr_date + "/" + curr_month + "/" + curr_year;

    var val = txt.value;
    var isvalidate = false;
    if (val.length == 10) {
        var splits = val.split("/");
        var dt = new Date(splits[1] + "/" + splits[0] + "/" + splits[2]);
        //Validation for Dates
        if (dt.getDate() == splits[0] && dt.getMonth() + 1 == splits[1] && dt.getFullYear() == splits[2]) {
            isvalidate = true;
        }
        else {
            if (val != "__/__/____") {
                alert("InValid Date.");
                txt.value = "";
                isvalidate = false;
            }
        }
    }
    else {
        if (val != "__/__/____") {
            alert("InValid Date.");
            isvalidate = false;
        }
    }

    if (isvalidate == true) {
        if (arraydate[2] < curr_year) {
            alert("You cannot select a day Lesser than today!");
            txt.value = "";
        }
        else if (arraydate[2] == curr_year) {
            if (arraydate[1] < curr_month) {
                alert("You cannot select a day Lesser than today!");
                txt.value = "";
            }
            else {
                if (txt.value < a) {
                    alert("You cannot select a day Lesser than today!");
                    txt.value = "";
                }
            }
        }
    }
}

//Jaydeep 02 April 2014 START: removes leading and trailing spaces
function checkSpace(ctrl) {
    var str = ctrl.value;
    var newstr = str.replace(/(^\s*)|(\s*$)/gi, '') // removes leading and trailing spaces
    ctrl.value = newstr;
}

$(document).ready(function () {
    $('#CertificateReason').change(function () { checkSpace(this) });
    $('input').keyup(function () {
        str = $(this).val()
        str = str.replace(/\s\s+/g, '')
        $(this).val(str)
    })

    var AllTextbox = document.getElementsByTagName("input")
    for (var i = 0; i < AllTextbox.length; i++) {
        if (AllTextbox[i].type == 'text') {
            $('#' + AllTextbox[i].id).change(function () { checkSpace(this) });
            $('#' + AllTextbox[i].id).bind("cut copy paste", function (e) {
                e.preventDefault();
            });
            $('#' + AllTextbox[i].id).attr('autocomplete', 'off');
        }
    };
});

function checkEmailIDSpace() {
    var txtUsername = document.getElementById('<%=txtUsername.ClientID %>');
    var RegularExpressionValidator1 = document.getElementById('<%=RegularExpressionValidator1.ClientID %>');
    var str = txtUsername.value;
    var newstr = str.replace(/(^\s*)|(\s*$)/gi, '') // removes leading and trailing spaces
    txtUsername.value = newstr;
    //ValidatorEnable(document.getElementById('<%= RegularExpressionValidator1.ClientID %>'), false);
}

//Jaydeep 02 April 2014 END: removes leading and trailing spaces

//Kiran 04 April 2014 START

function isValidKey(e) {
    var charCode = e.keyCode || e.which;
    if (charCode == 8 || charCode == 46)
        return true;

    return false;
}

//Kiran
function GetValues() {
    //    var ddlpost = $('#ContentPlaceHolder1_ddlPost', parent.document).val();
    //    //lblPostValue
    //    alert(ddlpost);
}

function UIDLength(srcControl) {
    var uid = srcControl.value;
    if (uid.length < 12) {
        alertPopup("Information", "Please enter valid Aadhar Number !!");
        return false;
    }
    return true;
}
//Jaydeep(03-02-2015)
function validEmailID(val) {
    var txt = val;
    if (txt.match(/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)) {
        return true;
    }
    else {
        return false;
    }
}

function validPassword(val) {
    var txt = val;
    if (txt.match(/^^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$/)) {
        return true;
    }
    else {
        return false;
    }
}


//Pan Card - Kiran
function validPanCardNumber(obj) {
    var txt = $(obj).val();
    if (txt != '') {
        if (txt.match(/[A-Za-z]{5}\d{4}[A-Za-z]{1}/)) {
            return true;
        }
        else {
            $(obj).val('');
            alertPopup("Information", "Invalid Pan Card number");
            return false;
        }
    }
}


function validRationCardNumber(obj) {
    var txt = $(obj).val();
    if (txt != '') {
        if (txt.match(/^([A-Za-z]{2}\d{6})$/)) {
            return true;
        }
        else {
            $(obj).val('');
            alertPopup("Information", "Invalid Ration Card number");
            return false;
        }
    }
}

function convertToUpper(p_textBox) {
    if (p_textBox.value != "") {
        p_textBox.value = p_textBox.value.toUpperCase();
    }
}

function ValidateMsg(p_Lang) {

    if (p_Lang == 'Eng') {
        alert('Kindly note that no details could be corrected in the certificate after this stage. Therefore re-confirm all the details and complete all the required corrections now itself.');
        return false;
    }
    else {
        alert('ह्या स्टेप नंतर प्रमाणपत्रा मधील कुठलीही माहिती दुरुस्त होणार नाही याची नोंद घ्यावी तरी कृपया प्रमाणपत्रातील माहितीची पुन:पडताळणी करुन सर्व दुरुस्ती आत्ताच करुन घेणे.');
        return false;
    }

    return true;
}

function HighlightAllBlankTextbox() {
    
    var AllTextbox = document.getElementsByTagName("input")
    var AllDropDownList = document.getElementsByTagName("select")

    var k = 0;
    for (var i = 0; i < AllTextbox.length; i++) {

        var a = $('label[for=' + AllTextbox[i].id + ']').attr('class');
        if (a == "manadatory") {
            if (AllTextbox[i].type == 'text') {
                if ($('#' + AllTextbox[i].id).val() == '') {
                    $('#' + AllTextbox[i].id).css('background-color', '#fcf8e3');
                    $('#' + AllTextbox[i].id).css('border-color', '#c09853');
                    k = k + 1;
                }
                else {
                    $('#' + AllTextbox[i].id).css('background-color', '#fff');
                    $('#' + AllTextbox[i].id).css('border-color', '#cdcdcd');
                }
            }
        }
    };
    
    for (var i = 0; i < AllDropDownList.length; i++) {
        
        //var ddl = $('label[class=' + AllDropDownList[i].id + ']');
        //var ddl = $('#' + AllDropDownList[i].id).parent();
        var ddl = $('#' + AllDropDownList[i].id).parent().get(0).tagName;
        //        var ddl1 = $('#' + AllDropDownList[i].id).closest('.manadatory');
        var as = $('#' + AllDropDownList[i].id).parent().html();
        var kirn = $('label[for=' + as + ']').attr('class');

        //var ddl = $('label[for=' + AllDropDownList[i].AssociatedControlID + ']').html('.manadatory');
        if (ddl == "manadatory") {

            if (AllDropDownList[i].type == 'select-one') {
                if ($('#' + AllDropDownList[i].id).get(0).selectedIndex == 0) {
                    $('#' + AllDropDownList[i].id).css('background-color', '#fcf8e3');
                    $('#' + AllDropDownList[i].id).css('border-color', '#c09853');
                    k = k + 1;
                }
                else {
                    $('#' + AllDropDownList[i].id).css('background-color', '#fff');
                    $('#' + AllDropDownList[i].id).css('border-color', '#cdcdcd');
                }
            }
        }
    };
    if (k > 0) {
        return true;
    }
    else {
        return false;
    }
}

////////////////// This code is for Change Culture regarding CDAC control ////////////////
var CDACLang = "";
var pathArray = window.location.pathname.split('/');
var strCurrentCulture = window.location.pathname.split('/')[1];
if (strCurrentCulture == "en") {
    CDACLang = "eng";
}
else if (strCurrentCulture == "mr") {
    CDACLang = "mr_in";
}

////////////////// End /// This code is for Change Culture regarding CDAC control ////////////////

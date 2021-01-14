$(document).ready(function () {

    //alert("iuhswiuthtiehbtikdbgtkdg");
   
    $("#dropdown1").change(function () {
        var dropDownVal = $("#dropdown1").val();
        var url = "/Product/Orders?parameters=" + dropDownVal;
        location.replace(url);

    });
    
});


jQuery(document).on('click', 'a[id^="view_"]', function (event) {
   
    event.preventDefault();
    var idSplit = jQuery(this).attr('id').split('_');
    var d = idSplit[1]; 
    //alert(d);

    var url = "/Product/ViewOrders?parameters=" + d;
    location.replace(url);
});


$(document).ready(function () {

    if (readCookie("name") != null) {
        $("#useridtextbox").val(readCookie("name"));
       
    }
   
});

$(document).ready(function () {

    $("button").click(function () {
       
        var section = document.querySelector('#BodyDetail');
        var checkbox = section.querySelectorAll('input[type=checkbox]');

        if (checkbox[0].checked) {
          
            createCookie("name", document.getElementById("useridtextbox").value, 5);
        }
        else {
            if (readCookie("name") != null) { 
                eraseCookie("name");
            }
        }
    });
});

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}








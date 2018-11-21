function newWin(url) {
    var a = document.createElement('a');
    a.setAttribute('href', url);
    a.setAttribute('style', 'display:none');
    a.setAttribute('target', '_blank');
    document.body.appendChild(a);
    a.click();
    a.parentNode.removeChild(a);
} 


function checkNumber(theObj) {
    var reg = /^[0-9]+.?[0-9]*$/;
    if (reg.test(theObj)) {
        return true;
    }
    return false;
}

var wait = 120;
function time(o) {
    if (wait == 0) {
        wait = 120;
        $(o).removeAttr("disabled");
        $(o).html("获取验证码");
    } else {
        wait--;
        $(o).attr("disabled", true);
        $(o).html("重新发送(" + wait + ")");
        setTimeout(function() { time(o) }, 1000);
    }
}
function Sendsms(o) {
    if (wait == 120) {
        time(o);
        $.post("/MyAccount/SendMsg", function (result) {
            if (!result.success) {
                wait = 0;
            } else {
                $(o).data("success", true);
            }
        });
    }
}
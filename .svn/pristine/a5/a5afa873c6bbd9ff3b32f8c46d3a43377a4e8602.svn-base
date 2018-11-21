/*公用方法*/

//刷新验证码
function getNewVerifyCode(obj) {
    var imgSrc = "/Customer/ValidCode";
    var random = Date.parse(new Date()) + Math.round(Math.random() * 1000);
    var src = imgSrc + "?random=" + random;
    obj.attr("src", src);
}
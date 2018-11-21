$(function () {
    var $div_li = $("div.invest_detail_tab ul li");
    $div_li.click(function () {
        $(this).addClass("active")
            .siblings().removeClass("active");
        var index = $div_li.index(this);
        $("div.invest_detail_tab_box > div")
            .eq(index).show()
            .siblings().hide();
    }).hover(function () {
        $(this).addClass("hover");
    },
        function () {
            $(this).removeClass("hover");
        });

    $('#invest').click(function () {
        //判断用户是否登录
        if (IsLoginAccount() && IsOpenAccount()) {
            var investmoney = $('#investMoney').val();
            if (parseInt(investmoney) > parseInt(remainMoney)) {
                IsEnoughMoney();
            } else {
                //判断用户是否勾选隐私协议
                var loanId = $('#loanId').val();
                var transferId = $('#transferId').val();

                $.post("/MyAccount/UseInvestType", function (data) {
                    if (data.success) {
                        $.ajax({
                            url: '/Transfer/InvestTransfer',
                            data: { "loanId": loanId, "transferId": transferId, "investMoney": investmoney },
                            type: 'POST',
                            success: function (data) {
                                if (data.code === 220) {
                                    location.href = data.redirect;
                                } else {
                                    layer.alert(data.message);
                                }
                            }
                        });
                    } else {
                        $("#riskingTest").show();
                    }
                });
            }
        }
        return false;
    });

    $('#recharge_now,#toRecharge').click(function () {
        if (IsLoginAccount() && IsOpenAccount()) {
            //弹窗提示用户登录
            location.href = "/MyAccount/Recharge";
        }
        //跳转至充值页面
        return false;
    });

    $('#toOpenAccount').click(function () {
        if (IsLoginAccount()) {
            location.href = "/MyAccount/OpenAccountInfo";
        }
        return false;
    })

    $('#boxLogin').click(function () {
        IsLoginAccount();
    });

    $('#openAccountClose,#openAccountCancel').click(function () {
        $("#red_envelopes_mask").hide();
        $('#openAccount').hide();
    });

    $('#lessMoneyClose,#rechargeCancel').click(function () {
        $("#red_envelopes_mask").hide();
        $('#lessMoeny').hide();
    });
    $("#openRiskingtestClose").click(function () {
        $("#riskingTest").hide();
    });
});

function IsLoginAccount() {
    if (isLogin === "False") {
        $('#returnUrl').val(window.location.href);
        //登录弹窗
        $("#red_envelopes_mask").show();
        $('#loginBox').show();
        //判断用户是否存在刷新页面行为
        if (existLogin === "True") {
            $('#verifycodeboxwindow').show();
            //刷新验证码
            getNewVerifyCode($('#validCodeImageWindow'));
        }
        return false;
    }
    return true;
}

function IsOpenAccount() {
    if (openAccount === "False") {
        $('#red_envelopes_mask').show();
        $('#openAccount').show();
        return false;
    }
    return true;
}
function IsEnoughMoney() {
    $('#red_envelopes_mask').show();
    $('#lessMoeny').show();
}

function toClaimsList() {
    location.href = "/Transfer/ClaimsList";
}
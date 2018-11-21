$(function () {
    CaculateIntrest(1);
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
    $(".most_invest").mouseover(function () {
        var explanation = $(".most_invest_explanation").html();
        layer.tips("<span style='color:#333'>" + explanation + "</span>", this, {
            tips: [3, '#fff2cf']
        });
    });

    $("input.cast_click_input").click(function () { //红包弹框
        if (IsLoginAccount()) {
            if (redCount > 0) {
                //判断是否输入投资金额
                var investMoney = $('#investMoney').val();
                //投资金额是否为空
                if (moneyFormat(investMoney)) {
                    $.ajax({
                        url: '/MyInvest/RedList',
                        type: 'post',
                        data: { "loanId": loanId, "investMoney": investMoney * minInvestMoney },
                        success: function (data) {
                            if (data.success) {
                                var results = JSON.parse(data.data);
                                var redId = $('#useRedId').val();
                                var html = "";
                                if (results.length === 0) {
                                    html = '<tr><td valign="top" colspan="5" class="dataTables_empty">无可用红包</td></tr>';
                                } else {
                                    $.each(results,
                                        function (index, info) {
                                            var classes = info.state ? "" : "gray_bg";
                                            var disables = info.state ? "" : "disabled";
                                            var lableclass = info.state ? "label_circle" : "label_circle_border";
                                            var checked = redId == info.redId ? "checked" : "";
                                            html += '<tr class="' +
                                                classes +
                                                '"><td class="checbox_style"><div class="checkbox checkbox-danger">';
                                            html += '<input type="radio" data-redid=' + info.redId + ' data-name=' + info.redName + ' data-money=' + info.redMoney + '  name="radio4" id="radio_' +
                                                index +
                                                '" value="' +
                                                index +
                                                '" ' +
                                                disables +
                                                ' ' + checked + '>';
                                            html += '<label for="radio_' + index + '" class="' + lableclass + '"></label></div></td>';
                                            html += '<td style="width:110px;"><em>' +
                                                info.redMoney +
                                                '</em>元</td><td style="width:200px;" class="red_name">' +
                                                info.redName +
                                                '</td><td style="width:150px;">' +
                                                info.expireDate +
                                                '</td>';
                                            html += '<td style="width:280px;"><span class="red_introductions" >' +
                                                info.des +
                                                '</span>';
                                            html += '<span class="red_introductions_real display-none">' +
                                                info.introduction +
                                                '</span></td></tr>';
                                        });
                                }

                                $('#redList').empty().append(html);
                            } else {
                                var html = '<tr><td valign="top" colspan="5" class="dataTables_empty">无可用红包</td></tr>';
                                $('#redList').empty().append(html);
                            }
                        }
                    });
                    $("#red_envelopes_mask").show();
                    $(".red_envelopes_box").animate({
                        top: '180px'
                    }).show();
                }
            }
        }
    });

    $('#confirmRedPackage').click(function () {
        //获取选中的radio
        var redId = $('#redList input:radio:checked').data("redid");
        if (redId == null || redId === "") {
            return;
        } else {
            var redName = $('#redList input:radio:checked').data("name");
            var redMoeny = $('#redList input:radio:checked').data("money");
            $('#redUse').val(redName + "(" + redMoeny + "元)");
            $('#useRedId').val(redId);
            $("#red_envelopes_mask").hide();
            $(".red_envelopes_box").animate({ top: '0px' }).hide();
            $(".calculator_box").animate({ top: '0px' }).hide();
        }
    });
    $('#cancelRedPackage').click(function () {
        $('#redUse').val("输入购买金额后选择红包");
        $('#useRedId').val("");
        $("#red_envelopes_mask").hide();
        $(".red_envelopes_box").animate({ top: '0px' }).hide();
        $(".calculator_box").animate({ top: '0px' }).hide();
    });

    $(".close_windown").click(function () { //关闭红包蒙版
        $("#red_envelopes_mask").hide();
        $(".red_envelopes_box").animate({ top: '0px' }).hide();
        $(".calculator_box").animate({ top: '0px' }).hide();
    });
    $('#redList').on("mouseover", ".red_introductions",
        function () {
            layer.tips($(this).next().html(),
                this,
                {
                    tips: [1, '#ec4961']
                });
        });
    $('#redList').on("mouseleave", ".red_introductions",
        function () {
            $(".layui-layer").hide();
        });
    //$('.red_introductions').mouseover(function() {
    //    layer.tips($(this).next().html(),
    //        this,
    //        {
    //            tips: [3, '#ec4961']
    //        });
    //});
    $(".repayment_plan").click(function () { //计算器弹框
        var investMoney = $('#investMoney').val();
        if (investMoney !== "" || investMoney != undefined) {
            $('#calculateMoney').val(investMoney);
        }

        $("#red_envelopes_mask").show();
        $(".calculator_box").animate({
            top: '80px'
        }).show();
    });
    $('#dynamictable').DataTable({
        "language": {
            "emptyTable": "",
            "sZeroRecords": ""
        },
        "scrollY": "196px",
        "scrollCollapse": true,
        "paging": false
    });
    $("#dynamictablered").DataTable({
        "scrollY": "214px",
        "scrollCollapse": true,
        "paging": false
    });
    $("#detailclick").click(function () { //查看计算器详情
        $(".loantable").show();
        $(this).hide();
    });

    $("#foldclick").click(function () { //收起计算器
        $(".loantable").hide();
        $("#detailclick").show();
    });

    $('.hiSlider1').hiSlider();
    $('#recharge_now,#toRecharge').click(function () {
        if (IsLoginAccount()) {
            //弹窗提示用户登录
            location.href = "/MyAccount/RechargeAndWithdraw";
        }
        //跳转至充值页面
        return false;
    });
    $("#investMoney").keydown(function () {
        var mun = $("#investMoney").val();
        if (mun == "0") {
            $(this).val("1");
        }
        $("#useRedId").val("");
        if (redCount > 0) {
            $("#redUse").val("输入购买金额后选择红包");
        }
    });
    $("#investMoney").keyup(function () {
        var mun = $("#investMoney").val();
        if (checkNumber(mun)) {
            if (mun == "0") {
                $(this).val("1");
                mun = 1;
            }
            if (!isRealNum(mun)) {
                $('#nInvestMoney').text(0);
                $('#intrest').text(0);
                return;
            } else {
                CaculateIntrest(mun);
            }
        }
    });

    $('#invest').click(function () {
        var investMoney = $('#investMoney').val();
        //判断用户是否登录
        if (IsLoginAccount() && IsAuthAll(investMoney)) {
            //是否勾选隐私政策
            //if (!$("#checkbox88").is(':checked')) {
            //    layer.tips('请先阅读《隐私政策》！', '#tp');
            //    return false;
            //}
            //投资金额是否为空
           
            if (moneyFormat(investMoney)) {
                var useRed = $('#useRedId').val();

                var redId = 0;
                if (useRed != null || typeof (useRed) !== "undefined") {
                    redId = useRed;
                }
                var postMoney = $('#investMoney').val() * minInvestMoney;
                //var newwindow = window.open("about:blank");
                $.post("/MyInvest/CheckUserInvestType", { "loanRiskType": $("#loanRiskType").val() }, function (data) {
                    if (data.investerrisktype) {
                        if (data.loanrisktype || $("#risking_tips").data("ensure")) {
                            $.ajax({
                                url: '/MyInvest/InvestLoan',
                                data: { "loanId": loanId, "redId": redId, "investMoney": postMoney },
                                type: 'POST',
                                beforeSend: function () {
                                    $('#investLoading').show();
                                },
                                success: function (data) {
                                    if (data.code =="200") {
                                        layer.alert(data.message, function() {
                                            location.reload();
                                        });
                                    } else {
                                        $('#investLoading').hide();
                                        //投资余额不足
                                        if (data.code =="215") {
                                            IsEnoughMoney();
                                        } else {
                                            layer.alert(data.message);
                                        }
                                    }
                                }
                            });
                        } else {
                            $("#investrisktypedesc").html(data.msg1);
                            $("#loanrisktypedesc").html(data.msg2);
                            $("#risking_tips").show();
                        }
                    } else {
                        $("#riskingTest").show();
                    }
                });

                return false;
            }
        }
        return false;
    });

    $('.partialInvest').click(function () {
        if (isLogin === "True") {
            var loanid = $(this).data("loanid");
            location.href = "/myinvest/investdetail?loanid=" + loanid;
        } else {
            //登录弹窗
            IsLoginAccount();
        }
    });

    $('#openAccountCancel').click(function () {
        $("#red_envelopes_mask").hide();
        $('#openAccount').hide();
    });

    $('#boxLogin').click(function () {
        IsLoginAccount();
    });
    $('#toOpenAccount').click(function () {
        location.href = "/MyAccount/OpenAccountInfo";
    });

    $('#openAccountCancel').click(function () {
        $("#red_envelopes_mask").hide();
        $('#openAccount').hide();
    });

    $('#openAccountClose').click(function () {
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

    $('#reloadMoney').click(function () {
        $.ajax({
            url: '/MyInvest/LoanAvaliableMoney',
            data: { "loanId": loanId },
            type: 'POST',
            success: function (data) {
                $('#remainInvestMoney').text(data.result);
            }
        });
        return false;
    });

    $('#moneyAllIn').click(function() {
        if (IsLoginAccount() && IsAuthAll()) {
            //获取用户余额
            var surplusMoney = $('#remainInvestMoney').text();
            //如果用户余额大于剩余可投 剩余可投分数最大
            var surplusCount = 0;
            if (surplusMoney > surplusLoan) {
                surplusCount = parseInt(surplusLoan / 100);
                $('#investMoney').val(surplusCount);
                CaculateIntrest(surplusCount);
            } else {
                surplusCount = parseInt(surplusMoney / 100);
                $('#investMoney').val(surplusCount);
                CaculateIntrest(surplusCount);
            }

        }
    });
    var value;
    $(".position_jian").click(function () {
        var investValue = $("input.input_num").val();
        if (investValue == "" || investValue == "0") {
            $("input.input_num").val(1);
            CaculateIntrest(1);
        } else if (investValue >= 1) {
            value = parseInt($("input.input_num").val());
            var value1 = value + 1;
            $("input.input_num").val(value1);
            $(".position_jia i").css("color", "#333");
            CaculateIntrest(value1);
        }
    });
    $(".position_jia").click(function () {
        var investValue = $("input.input_num").val();
        if (investValue == "" || investValue == "0" || investValue == "1") {
            $("input.input_num").val(1);
            CaculateIntrest(1);
        } else if (investValue > 1) {
            value = parseInt($("input.input_num").val());
            var value2 = value - 1;
            if (value2 <= 1) {
                $("input.input_num").val(1);
                $(".position_jia i").css("color", "#cccccc");
            } else {
                $("input.input_num").val(value2);
                $(".position_jia i").css("color", "#333");
            }
            CaculateIntrest(value2);
        }
    })



});

function moneyFormat(money) {
    if (money === null || money === "") {
        $("#investMoney").focus();
        layer.tips('投资金额不能为空！', '#investMoney', { tips: [2, "#ec4961"] });
        return false;
    } else {
        if (!isRealNum(money)) {
            $("#investMoney").focus();
            layer.tips('投资金额格式不正确！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }
        money = money * minInvestMoney;
        //投资金额格式是否正确
        var exp = /^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$/;
        if (!exp.test(money)) {
            $("#investMoney").focus();
            layer.tips('投资金额格式不正确！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }
        if (parseFloat(money) <= 0) {
            $("#investMoney").focus();
            layer.tips('投资金额不能小于或等于0！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }

        if (parseFloat(money) % 100 !== 0) {
            $("#investMoney").focus();
            layer.tips('投资金额必须为100的整数倍！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }

        if (parseFloat(money) > parseFloat($("#pro_surplus_money").val())) {
            $("#investMoney").focus();
            layer.tips('投资金额不能大于可投金额！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }
        if ($("#pro_min_invest_money").val() !== "") {
            if (parseFloat($("#pro_surplus_money").val()) > parseFloat($("#pro_min_invest_money").val())) {
                if (parseFloat(money) < parseFloat($("#pro_min_invest_money").val())) {
                    $("#investMoney").focus();
                    layer.tips('投资金额不能小于项目最低投标额度！', '#investMoney', { tips: [2, "#ec4961"] });
                    return false;
                }
            } else {
                //如果可投金额小于最小投标额度了，必须一次性投满
                if (parseFloat(money) !== parseFloat($("#pro_surplus_money").val())) {
                    $("#investMoney").focus();
                    layer.tips('当前可投金额小于最低投标额度，投资金额必须等于可投金额！', '#investMoney', { tips: [2, "#ec4961"] });
                    return false;
                }
            }
        }
        if ($("#pro_max_invest_money").val() !== "") {
            if (parseFloat(money) > parseFloat($("#pro_max_invest_money").val())) {
                $("#investMoney").focus();

                layer.tips('投资金额不能大于项目最高投标额度！', '#investMoney', { tips: [2, "#ec4961"] });
                return false;
            }
        }
        if (parseFloat(money) < parseFloat($("#otherMoney").val())) {
            layer.tips('使用红包金额不能大于投资金额！', '#investMoney', { tips: [2, "#ec4961"] });
            return false;
        }
        return true;
    }
}

function moneyCaculate(money) {
    if (money === null || money === "") {
        $("#calculateMoney").focus();
        layer.tips('投资金额不能为空！', '#calculateMoney', { tips: [2, "#ec4961"] });
        return false;
    } else {
        //投资金额格式是否正确
        var exp = /^([1-9][\d]{0,7}|0)(\.[\d]{1,2})?$/;
        if (!exp.test(money)) {
            $("#calculateMoney").focus();
            layer.tips('投资金额格式不正确！', '#calculateMoney', { tips: [2, "#ec4961"] });
            return false;
        }
        if (parseFloat(money) <= 0) {
            $("#calculateMoney").focus();
            layer.tips('投资金额不能小于或等于0！', '#calculateMoney', { tips: [2, "#ec4961"] });
            return false;
        }

        if (parseFloat(money) % 100 !== 0) {
            $("#calculateMoney").focus();
            layer.tips('投资金额必须为100的整数倍！', '#calculateMoney', { tips: [2, "#ec4961"] });
            return false;
        }
    }
    return true;
}

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
        $("#red_envelopes_mask").show();
        $('#openAccount').show();
        return false;
    }
    return true;
}

function IsAuthAll(money) {
    var jiesuan = $('#jiesuan_auth').val();
    var bohai = $('#bohai_auth').val();
    var invest = $('#invest_auth').val();
    var risk = $('#risk_auth').val();
    if (jiesuan == "0" || bohai == "0" || invest == "0" || risk == "0") {
        $("#red_envelopes_mask").show();
        $('#invest_tips').show();
        return false;
    }
    var authMoney = $("#hidMoney").val();
    if (parseFloat(authMoney) < parseFloat(money) * minInvestMoney) {
        $("#red_envelopes_mask").show();
        $('#authMoney').show();
        $('#invest_tips').show();
        return false;
    }
    return true;
}

function IsEnoughMoney() {
    $("#red_envelopes_mask").show();
    $('#lessMoeny').show();
}

function ToInvestList(loanType) {
    //if (loanType === 1) {
    //    location.href = "/myinvest/newhandlist";
    //}
    //if (loanType === 2) {
    //    location.href = "/myinvest/wiselist";
    //}
    //if (loanType === 3) {
    //    location.href = "/myinvest/dreamlist";
    //}
    location.href = "/myinvest/recommendedlist";
}

function isRealNum(val) {
    // isNaN()函数 把空串 空格 以及NUll 按照0来处理 所以先去除
    if (val === "" || val == null) {
        return false;
    }
    if (!isNaN(val)) {
        return true;
    } else {
        return false;
    }
}

function CaculateIntrest(mun) {
    if (mun == 0) {
        $('#nInvestMoney').text(0);
        $('#intrest').text(0);

    } else {
        var nInvestMoney = mun * minInvestMoney;
        $('#nInvestMoney').text(nInvestMoney);

        $.post("/myinvest/InvestIncome?loanId=" +
            loanId +
            "&money=" +
            nInvestMoney +
            "&repayment=" +
            type +
            "&deadLine=" +
            deadLine +
            "&loanRate=" +
            loanRate,
            function (data) {
                if (data.success) {
                    $('#intrest').text(data.result);
                }
            });

        if (parseInt(redCount) > 0) {
            $.post("/myinvest/BestRedInfo?loanId=" + loanId + "&investMoney=" + nInvestMoney,
                function (data) {
                    if (data.success) {
                        var redInfo = JSON.parse(data.data);
                        var redName = redInfo.RedName;
                        var redMoeny = redInfo.RedMoney;
                        var redId = redInfo.RedId;
                        $('#redUse').val(redName + "(" + redMoeny + "元)");
                        $('#useRedId').val(redId);
                    }
                });
        }
    }

}


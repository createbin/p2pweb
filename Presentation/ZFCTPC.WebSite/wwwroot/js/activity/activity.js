// Write your Javascript code.

$(function () {

    var $div_li = $("div.hoceremony_tab ul li");
    $div_li.click(function () {
        $(this).addClass("selected")            //当前<li>元素高亮
            .siblings().removeClass("selected");  //去掉其它同辈<li>元素的高亮
        var index = $div_li.index(this);  // 获取当前点击的<li>元素 在 全部li元素中的索引。
        $("div.hoceremony_tab_box > div")   	//选取子节点。不选取子节点的话，会引起错误。如果里面还有div 
            .eq(index).show()   //显示 <li>元素对应的<div>元素
            .siblings().hide(); //隐藏其它几个同辈的<div>元素
    }).hover(function () {
        $(this).addClass("hover");
    }, function () {
        $(this).removeClass("hover");
    })
    var $dd1 = $(".hoceremony_tab_box1 table tr td.xuanze1 dl dd");
    var $dd2 = $(".hoceremony_tab_box1 table tr td.xuanze2 dl dd");
    var $dd3 = $(".hoceremony_tab_box1 table tr td.xuanze3 dl dd");
    var $dd4 = $(".hoceremony_tab_box1 table tr td.xuanze4 dl dd");
    var $dd5 = $(".hoceremony_tab_box1 table tr td.xuanze5 dl dd");
    $dd1.click(function () {
       
        var dd1_index = $dd1.index(this);
        if (dd1_index == 0) {
            $(this).parent().parent().prev().html(240000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 1) {
            $(this).parent().parent().prev().html(80000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 2) {
            $(this).parent().parent().prev().html(40000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 3) {
            $(this).parent().parent().prev().html(20000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
    })
    $dd2.click(function () {
        var dd1_index = $dd2.index(this);
        if (dd1_index == 0) {
            $(this).parent().parent().prev().html(600000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 1) {
            $(this).parent().parent().prev().html(200000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 2) {
            $(this).parent().parent().prev().html(100000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 3) {
            $(this).parent().parent().prev().html(50000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
    })
    $dd3.click(function () {
        var dd1_index = $dd3.index(this);
        if (dd1_index == 0) {
            $(this).parent().parent().prev().html(1200000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 1) {
            $(this).parent().parent().prev().html(400000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 2) {
            $(this).parent().parent().prev().html(200000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 3) {
            $(this).parent().parent().prev().html(100000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
    })
    $dd4.click(function () {
        var dd1_index = $dd4.index(this);
        if (dd1_index == 0) {
            $(this).parent().parent().prev().html(1800000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 1) {
            $(this).parent().parent().prev().html(600000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 2) {
            $(this).parent().parent().prev().html(300000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 3) {
            $(this).parent().parent().prev().html(150000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
    })
    $dd5.click(function () {
        var dd1_index = $dd5.index(this);
        if (dd1_index == 0) {
            $(this).parent().parent().prev().html(2400000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 1) {
            $(this).parent().parent().prev().html(800000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 2) {
            $(this).parent().parent().prev().html(400000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
        if (dd1_index == 3) {
            $(this).parent().parent().prev().html(200000);
            $(this).find("img").attr("src", "/images/activity/hoceremony/gouxuan1.png");
            $(this).siblings().find("img").attr("src", "/images/activity/hoceremony/gouxuan.png");
        }
    })
})
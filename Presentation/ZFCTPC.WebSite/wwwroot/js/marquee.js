/***
	@description 基于 jQuery 的多功能无缝滚动插件
	@中房创投
	@time:2014-05-10
	@常用参数：
		 auto: true                     # 是否自动滚动
         interval: 3000                 # 间隔时间（毫秒）
         direction: 'forward'           # 向前 -  forward / 向后 - backward
         speed: 500                     # 移动速度（毫秒）
         showNum: 1                     # 显示个数
         stepLen: 1                     # 每次滚动步长
         type: 'horizontal'             # 水平滚动 - horizontal / 垂直滚动 - vertical
         prevElement: null              # 上一组按钮元素
         prevBefore: function() {}      # 上一组移动前回调
         prevAfter: function() {}       # 上一组移动后回调
         nextElement: null              # 下一组按钮元素
         nextBefore: function() {}      # 下一组移动前回调
         nextAfter: function() {}       # 下一组移动后回调
         pauseElement: null             # 暂停按钮元素
         pauseBefore: function() {}     # 暂停前回调
         pauseAfter: function() {}      # 暂停后回调
         resumeElement: null            # 继续按钮元素
         resumeBefore: function() {}    # 继续前回调
         resumeAfter: function() {}     # 继续后回调
	@使用方法：
	<div id="wrap1" class="wrap">
		<ul>
			<li>1</li>
			<li>2</li>
		</ul>
	</div>
	<script type="text/javascript">
		$(function() {
			$('#wrap1').marquee();
		})
	</script>		 
***/

!function(a){var b;b=function(){function b(b,c){this.elements={wrap:b,ul:b.children(),li:b.children().children()},this.settings=a.extend({},a.fn.marquee.defaults,c),this.cache={allowMarquee:!0}}return b.prototype.init=function(){this.setStyle(),this.move(),this.bind()},b.prototype.setStyle=function(){var a,b,c,d,e,f,g,h;switch(d=this.elements.li.outerWidth(!0),c=this.elements.li.outerHeight(!0),b=Math.max(parseInt(this.elements.li.css("margin-top"),10),parseInt(this.elements.li.css("margin-bottom"),10)),this.settings.type){case"horizontal":h=this.settings.showNum*d,g=c,f=9999,e="auto",a="left",this.cache.stepW=this.settings.stepLen*d,this.cache.prevAnimateObj={left:-this.cache.stepW},this.cache.nextAnimateObj={left:0},this.cache.leftOrTop="left";break;case"vertical":h=d,g=this.settings.showNum*c-b,f="auto",e=9999,a="none",this.cache.stepW=this.settings.stepLen*c-b,this.cache.prevAnimateObj={top:-this.cache.stepW},this.cache.nextAnimateObj={top:0},this.cache.leftOrTop="top"}this.elements.wrap.css({position:"relative",width:h,height:g,overflow:"hidden"}),this.elements.ul.css({position:"relative",width:f,height:e}),this.elements.li.css({"float":a})},b.prototype.bind=function(){var a,b,c,d,e,f;f=this,null!=(a=this.settings.prevElement)&&a.click(function(a){a.preventDefault(),f.prev()}),null!=(b=this.settings.nextElement)&&b.click(function(a){a.preventDefault(),f.next()}),null!=(c=this.settings.pauseElement)&&c.click(function(a){a.preventDefault(),f.pause()}),null!=(d=this.settings.resumeElement)&&d.click(function(a){a.preventDefault(),f.resume()}),null!=(e=this.elements.wrap)&&e.hover(function(){f.pause()},function(){f.resume()})},b.prototype.move=function(){var a,b,c;if(c=this,this.settings.auto){switch(this.settings.direction){case"forward":b=c.prev;break;case"backward":b=c.next}a=c.settings.interval,setTimeout(function(){b.call(c),setTimeout(arguments.callee,a)},a),this.cache.moveBefore=this.cache.moveAfter=function(){return null}}else this.cache.moveBefore=function(){return c.cache.allowMarquee=!1},this.cache.moveAfter=function(){return c.cache.allowMarquee=!0}},b.prototype.prev=function(){var a,b,c;c=this,this.cache.allowMarquee&&(this.cache.moveBefore.call(this),this.settings.prevBefore.call(this),b=this.elements.ul,a=b.children().slice(0,this.settings.stepLen),a.clone().appendTo(b),b.animate(this.cache.prevAnimateObj,this.settings.speed,function(){b.css(c.cache.leftOrTop,0),a.remove(),c.cache.moveAfter.call(c),c.settings.prevAfter.call(c)}))},b.prototype.next=function(){var a,b,c;c=this,this.cache.allowMarquee&&(this.cache.moveBefore.call(this),this.settings.nextBefore.call(this),b=this.elements.ul,a=b.children().slice(-this.settings.stepLen),a.clone().prependTo(b),b.css(c.cache.leftOrTop,-this.cache.stepW).animate(this.cache.nextAnimateObj,this.settings.speed,function(){a.remove(),c.cache.moveAfter.call(c),c.settings.nextAfter.call(c)}))},b.prototype.pause=function(){this.settings.pauseBefore.call(this),this.cache.allowMarquee=!1,this.settings.pauseAfter.call(this)},b.prototype.resume=function(){this.settings.resumeBefore.call(this),this.cache.allowMarquee=!0,this.settings.resumeAfter.call(this)},b}(),a.fn.marquee=function(c){this.each(function(){var d;d=new b(a(this),c),d.init()})},a.fn.marquee.defaults={auto:!0,interval:3e3,direction:"forward",speed:500,showNum:1,stepLen:1,type:"horizontal",prevElement:null,prevBefore:function(){},prevAfter:function(){},nextElement:null,nextBefore:function(){},nextAfter:function(){},pauseElement:null,pauseBefore:function(){},pauseAfter:function(){},resumeElement:null,resumeBefore:function(){},resumeAfter:function(){}}}(jQuery);
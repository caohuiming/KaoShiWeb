
function app(fixed){

	var appurl = '', position = '';
	var ios = /iphone/i.test(navigator.userAgent);
	var d = new Date();
	var year = d.getFullYear();
	var month = d.getMonth() + 1;
	if (month < 10) {
		month = '0' + month;
	}
	if (ios) {
		var appurl = 'https://itunes.apple.com/cn/app/51xueche/id1006396148?l=zh&ls=1&mt=8';
	} else {
		var appurl = 'http://imtt.dd.qq.com/16891/51E52E1CB042A586BFF55702B375FEEB.apk?fsname=51xueche.apk';
	}
	if (fixed) {
		var position = 'position:fixed;';
	}
	document.write('<div class="app" style="width:100%;bottom:0px;left:0px;font-size:0;' + position + '">');
	document.write('	<a href="' + appurl + '" style="display:block;">');
	document.write('		<img src="http://cdn.c1km1.com/app/download/down' + year + '' + month + '.png" style="width:100%;">');
	if (fixed) {
		document.write('		<span style="width:14px;right:0px;padding:15px 10px;position:absolute;top:50%;transform:translateY(-50%);-webkit-transform:translateY(-50%);"><img src="http://cdn.c1km1.com/app/download/close.png" style="width:100%;"></span>');
	}
	document.write('	</a>');
	document.write('</div>');

}
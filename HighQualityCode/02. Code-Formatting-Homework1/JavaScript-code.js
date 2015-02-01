var pX = 0, pY = 0,
	isNetscape = navigator.appName == "Netscape";

if (isNetscape) {
	document.captureEvents(Event.MOUSEMOVE);
}

document.onmousemove = function mouseMove(evn) {
	if (isNetscape) {
		pX = evn.pageX - 5;
		pY = evn.pageY;	
		
		if (document.layers['ToolTip'].visibility != 'show') {
			PopTip();
		}
	} else {	
		pX = event.x - 5;
		pY = event.y;
		
		if (document.all['ToolTip'].style.visibility != 'visible') {
			PopTip();
		}
	}
}

function PopTip() {
	var theLayer, addScroll;
	
	if (isNetscape) {
		if ((pX + 120) > window.innerWidth) {
			pX = window.innerWidth - 150;
		}
		
		theLayer = document.layers['ToolTip'];
		theLayer.left = pX + 10;
		theLayer.top = pY + 15;
	} else {
		theLayer = document.all['ToolTip'];
		
		if (theLayer) {
			pX = event.x - 5;
			pY = event.y;
			
			addScroll = false;
			if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
				(navigator.userAgent.indexOf('MSIE 6')) > 0) {
				addScroll = true;
			}
			
			if (addScroll) {
				pX = pX + document.body.scrollLeft;
				pY = pY + document.body.scrollTop;
			}
			
			if ((pX + 120) > document.body.clientWidth) {
				pX = pX - 150;
			}
			
			theLayer.style.pixelLeft = pX + 10;
			theLayer.style.pixelTop = pY + 15;
		}
	}
	
	ShowElement('ToolTip');
}

function ShowMenu1() {
	ShowElement("menu1");
}

function ShowMenu2() {
	ShowElement("menu2");
}

function HideMenu1() {
	HideElement("menu1");
}

function HideMenu2() {
	HideElement("menu2");
}

function HideElement(id) {
	if (isNetscape) {
		document.layers[id].visibility = 'hide';
	} else {
		document.all[id].style.visibility = 'hidden';
	}
}

function ShowElement(id) {
	if (isNetscape) {
		document.layers[id].visibility = 'show';
	} else {
		document.all[id].style.visibility = 'visible';
	}
}
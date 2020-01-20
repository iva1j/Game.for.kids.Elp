#pragma strict

var panelInfoCanvas : Canvas;
var infoOpen = false;

function Start () {
	
}

function Update () {
	
}

function InfoPanel () {
	if (infoOpen == false){
	
	infoOpen = true;
	panelInfoCanvas.enabled = true;

	}

	else if (infoOpen == true) {
	
	infoOpen = false;
	panelInfoCanvas.enabled = false;

	}
}
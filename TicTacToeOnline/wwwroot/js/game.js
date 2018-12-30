﻿var mySymbol;

$(function () {
    for (var i = 0; i < 9; i++) {
	var gameCell = document.getElementById(i);
	gameCell.onclick = function () { markSquare(i); };
    }

    GetPlayerSymbol();
})

function GetPlayerSymbol() {
    $.ajax({
	type: "POST",
	url: "/Game/PlayerSymbol",
	contentType: "application/json;charset=utf-8",
	success: function (data) {
	    mySymbol = Json.toJson(data);
	},
	error: function (data) {
	    errorFunc(data);
	}
    });
}

function markSquare(squareIndex) {
    debugger;
    $.ajax({
	type: "POST",
	url: "/Game/Mark",
	data: {
	    index: squareIndex
	},
	contentType: "application/json; charset=utf-8",
	dataType: "json",
	success: function (data) {
	    TurnUpdate(data);
	},
	error: errorFunc(data)
    });
}

function TurnUpdate(data) {
    response = Json.toJson(data);
    var isWinner = response.Winner;
    var squareIndexToUpdate = response.LastSquareMarked;
    var squareSymbolToUpdate = response.LastMarkedSymbol;
    updateBoard(squareIndexToUpdate, squareSymbolToUpdate);

    if (isWinner === "Winner") {
	WinningActions();
    } else if (isWinner === "Tie") {
	TieActions();
    } else if (isWinner == "Loser") {
	LoseActions();
    }
}

function updateBoard(squareIndex, squareSymbol) {

    var square = getElementById(squareIndex);
    square.disabled = true;

    if (squareSymbol === 'X') {
	square.className = "btn btn-danger btn-game";
    } else {
	square.className = "btn btn-danger btn-game";
    }

}

function WinningActions() {

}

function TieActions() {

}

function LoseActions() {

}

function errorFunc(errordata) {
    alert("data: " ,errordata);
    
}
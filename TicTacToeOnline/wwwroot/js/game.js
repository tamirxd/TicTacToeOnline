var mySymbol;
var currentPlayer;
var squaresMarked = [];
var squaresUnmarked = [0, 1, 2, 3, 4, 5, 6, 7, 8];
var gameStarted = false;

$(function () {
    for (var i = 0; i < 9; i++) {
	var gameCell = document.getElementById(i);
	gameCell.onclick = function () { markedSqaures(i); };
	gameCell.disabled = true;
    }

    getStartingValues();
  })

function getStartingValues() {
    $.ajax({
	type: "POST",
	url: "/Game/GetStartingValues",
	contentType: "application/json;charset=utf-8",
	success: function (data) {
	    setStartingValues(data);
	},
	error: function (data) {
	    errorFunc(data);
	}
    });
}

function setStartingValues(data) {
    mySymbol = data.playerSymbol;
    currentPlayer = data.firstPlayerSymbol;
    if (currentPlayer === mySymbol) {
	enableRemainingSquares();
    }
    else {
	disableRemainingSquares();
    }
}

function disableRemainingSquares() {

}

function enableRemainingSquares() {
    squaresMarked.forEach(function (index) {
	var gameCell = getElementById(index);
	gameCell.disabled = false;
    });
}

function markedSqaures(squareIndex) {
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
	error: function (data) {
	    errorFunc(data)
	}
    });
}

function TurnUpdate(data) {
    response = JSON.parse(data);
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
    squaresMarked.push(squareIndex);
    var indexToRemove = squaresUnmarked.indexOf(squareIndex);
    squaresUnmarked.splice(indexToRemove, 1);
    square.disabled = true;

    if (squareSymbol === 'X') {
	square.className = "btn btn-danger btn-game";
    } else {
	square.className = "btn btn-primary btn-game";
    }

}

function WinningActions() {

}

function TieActions() {

}

function LoseActions() {

}

function errorFunc(errordata) {
    alert("data: ", errordata);

}

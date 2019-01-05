var mySymbol;
var currentPlayer;
var squaresMarked = [];
var squaresUnmarked = [0, 1, 2, 3, 4, 5, 6, 7, 8];
var gameStarted = false;
var gameStartedInterval;
var checkTurnInterval;

$(function () {
    for (var i = 0; i < 9; i++) {
	var gameCell = document.getElementById(i);
	gameCell.onclick = function () { MarkSquare(i); };
	gameCell.disabled = true;
    }

    getStartingValues();
    gameStartedInterval = setInterval(checkIfGameStarted, 2000);
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
    disableRemainingSquares();
}

function toggleSquares() {
    if (currentPlayer === mySymbol) {
	enableRemainingSquares();
    }
    else {
	disableRemainingSquares();
    }
}

function disableRemainingSquares() {
    squaresMarked.forEach(function (index) {
	var gameCell = document.getElementById(index);
	gameCell.disabled = true;
    });
}

function enableRemainingSquares() {
    debugger;
    squaresUnmarked.forEach(function (index) {
	var gameCell = document.getElementById(index);
	gameCell.disabled = false;
    });
}

function MarkSquare(squareIndex) {
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
    response = data;
    var isWinner = response.winner;
    var squareIndexToUpdate = response.lastMarkedSquare;
    var squareSymbolToUpdate = response.lastMarkedSymbol;
    updateBoard(squareIndexToUpdate, squareSymbolToUpdate);

    if (isWinner === "Winner") {
	WinningActions();
    } else if (isWinner === "Tie") {
	TieActions();
    } else if (isWinner == "Loser") {
	LoseActions();
    }
    togglePlayers();
}

function updateBoard(squareIndex, squareSymbol) {
    var square = document.getElementById(squareIndex);
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

function checkTurn() {
    if (gameStarted) {
	$.ajax({
	    type: "POST",
	    url: "/Game/Turn",
	    contentType: "application/json; charset=utf-8",
	    dataType: "json",
	    success: function (data) {
		checkForNextTurn(data);
	    },
	    error: function (data) {
		errorFunc(data)
	    }
	});
    }
}

function checkForNextTurn(data) {
    debugger;
    //jsonData = JSON.parse(data);

    if (data.lastMarkedSymbol !== mySymbol) {
	togglePlayers(data.lastMarkedSymbol);
	toggleSquares();
    }

    if (data.lastMarkedSymbol !== "None") {
	TurnUpdate(data);
    }
}

function togglePlayers(symbol) {
    if (symbol !== "None") {
	if (symbol === "X") {
	    currentPlayer = "O";
	} else {
	    currentPlayer = "X";
	}
    }
}

function checkIfGameStarted() {
    $.ajax({
	type: "POST",
	url: "/Game/GameStarted",
	contentType: "application/json; charset=utf-8",
	dataType: "json",
	success: function (data) {
	    updateStartValue(data);
	},
	error: function (data) {
	    errorFunc(data)
	}
    });
}

function updateStartValue(data) {
    var parsedJson = JSON.parse(data);
    gameStarted = parsedJson.gameStarted;

    if (gameStarted) {
	window.clearInterval(gameStartedInterval); /*****STOPPED HERE****/
	checkTurnInterval = setInterval(checkTurn, 2000);
    }
}


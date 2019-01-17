var mySymbol;
var currentPlayer;
var squaresMarked = [];
var squaresUnmarked = [0, 1, 2, 3, 4, 5, 6, 7, 8];
var gameStarted = false;
var gameStartedInterval;
var checkTurnInterval;
var isBoardUpdated = false;

$(function () {
    var i;
    for (i = 0; i < 9; i++) {
	var gameCell = document.getElementById(i);
	gameCell.onclick = function () { return MarkSquare(this.id); };
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
    squaresUnmarked.forEach(function (index) {
	var gameCell = document.getElementById(index);
	if (gameCell != undefined) {
	    gameCell.disabled = true;
	}
    });
}

function enableRemainingSquares() {
    squaresUnmarked.forEach(function (index) {
	var gameCell = document.getElementById(index);
	if (gameCell != undefined) {
	    gameCell.disabled = false;
	}
    });
}

function MarkSquare(squareIndex) {
    $.ajax({
	type: "post",
	dataType: "json",
	url: "/Game/Mark",
	data: {
	    index: squareIndex,
	},
	success: function (data) {
	    postMarkActions(data);
	},
	error: function (data) {
	    errorFunc(data)
	}
    });
}

function postMarkActions(data) {
    TurnUpdate(data);
    isBoardUpdated = false;
    disableRemainingSquares();
    if (data.winner === "None") {
	checkTurnInterval = setInterval(function () { checkTurn(); }, 2000);
    }
}

function TurnUpdate(data) {
    var isWinner = data.winner;
    var squareIndexToUpdate = data.lastMarkedSquare;
    var squareSymbolToUpdate = data.lastMarkedSymbol;
    updateBoard(squareIndexToUpdate, squareSymbolToUpdate);

    if (checkForEndGame(isWinner)) {
	endgameActions(isWinner);
    } else {
	togglePlayers(data.lastMarkedSymbol);
    }
}

function checkForEndGame(isWinner) {
    if (isWinner != "None") {
	return true;
    }
    return false;
}

function endgameActions(isWinner) {
    if (isWinner === mySymbol) {
	winnerActions();
    } else if (isWinner === "Tie") {
	TieActions();
    } else {
	loserActions();
    }
}

function updateBoard(squareIndex, squareSymbol) {
    var square = document.getElementById(squareIndex);
    squaresMarked.push(squareIndex);
    var indexToRemove = squaresUnmarked.indexOf(squareIndex);
    squaresUnmarked[indexToRemove] = -1;
    square.disabled = true;

    if (squareSymbol === 'X') {
	square.className = "btn btn-danger btn-game";
    } else {
	square.className = "btn btn-primary btn-game";
    }
}

function WinningActions(winnerSymbol) {
    disableRemainingSquares();
    if (winnerSymbol === mySymbol) {
	winnerActions();
    } else {
	loserActions();
    }
}

function TieActions() {
    endgame("Tie");
}

function winnerActions() {
    endgame("Win");
}

function loserActions() {
    endgame("Lose");
}

function endgame(endReason) {
    disableRemainingSquares();
    endgameMessage(endReason);
    redirectToHomepage()
}

function redirectToHomepage() {
    setTimeout(function () {
	window.location.href = "../..";
    }, 7000);
}

function endgameMessage(type) {
    if (type === "Win") {
	blinkMessage("Congrats! You are the winner! FeelsGoodMan");
    } else if (type === "Lose") {
	blinkMessage("You lost! FeelsBadMan");
    } else {
	blinkMessage("An amazing tie! FeelsWierdMan");
    }
}

//function blinkMessage(text) {
//	adjustEndgameDiv();
//	var blinkText = $(".blinking");
//	$(".blinking").textContent = text;
//	setInterval(function () {
//	    blinkText.toggleClass("blink");
//	}, 1000);
//}

function blinkMessage(text) {
    $(".blinking").innerHTML = text;
    function blinker() {
	$('.blinking').fadeOut(500);
	$('.blinking').fadeIn(500);
    }

    setInterval(blinker, 1000);
}

function adjustEndgameDiv() {
    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    var endgameDiv = document.getElementById("endgameText");
    var divW = $(endgameDiv).width();
    var divH = $(endgameDiv).height();

    endgameDiv.style.position = "absolute";
    endgameDiv.style.top = (windowHeight / 2) - (divH / 2) + "px";
    endgameDiv.style.left = (windowWidth / 2) - (divW / 2) + "px";
}

function errorFunc(errordata) {
    alert("data: ", errordata);
}

function checkTurn() {
    $.ajax({
	type: "POST",
	url: "/Game/Turn",
	contentType: "application/json; charset=utf-8",
	dataType: "json",
	success: function (data) {
	    debugger;
	    checkForNextTurn(data);
	},
	error: function (data) {
	    errorFunc(data)
	}
    });
}

function checkForNextTurn(data) {
    if (data.lastMarkedSymbol !== "None" && !isBoardUpdated && data.lastMarkedSymbol !== mySymbol) {
	updateBoard(data.lastMarkedSquare, data.lastMarkedSymbol);
	enableRemainingSquares();
	clearInterval(checkTurnInterval);
	isBoardUpdated = true;
	togglePlayers(data.lastMarkedSymbol);
    }

    if (checkForEndGame(data.winner)) {
	disableRemainingSquares();
	endgameActions(data.winner);
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

    //   if (currentPlayer === mySymbol) {
    //clearInterval(checkTurnInterval);
    //   }
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
    if (data.gameStarted) {
	clearInterval(gameStartedInterval);
	if (currentPlayer !== mySymbol) {
	    checkTurnInterval = setInterval(checkTurn, 2000);
	} else {
	    enableRemainingSquares();
	}
    }
}

/* לשים טקטסט מתחת לכל ה DIV*/
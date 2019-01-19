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
    displayWaitingMessage();
}

function displayWaitingMessage() {
    var msg = document.createElement('p');
    msg.id = "wait-msg";
    msg.innerHTML = "Waiting for an opponent";
    msg.style.color = "grey";
    document.getElementById("msg-box").appendChild(msg);
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
	removeElement("my-turn-msg");
	displayOpponentTurnMsg();
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
    clearMsgBox();
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
    var msg = document.createElement('p');

    if (type === "Win") {
	msg.style.color = "green";
	msg.innerHTML = "Congrats! You are the winner! FeelsGoodMan";
    } else if (type === "Lose") {
	msg.style.color = "red";
	msg.innerHTML = "You lost! FeelsBadMan";
    } else {
	msg.style.color = "yellow";
	msg.innerHTML = "An amazing tie! FeelsWierdMan";
    }

    document.getElementById("msg-box").appendChild(msg);
}

function errorFunc(errordata) {
    alert(errordata, errordata);
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
	removeElement("opponent-turn-msg");
	displayMyTurnMsg();
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
	    displayOpponentTurnMsg();
	    checkTurnInterval = setInterval(checkTurn, 2000);
	} else {
	    displayMyTurnMsg();
	    enableRemainingSquares();
	}
	removeElement("wait-msg");
    }
}

function displayOpponentTurnMsg() {
    var msg = document.createElement('p');
    msg.id = "opponent-turn-msg";
    msg.innerHTML = "This is your opponent's turn";
    msg.style.color = "red";
    document.getElementById("msg-box").appendChild(msg);
}

function displayMyTurnMsg() {
    var msg = document.createElement('p');
    msg.id = "my-turn-msg";
    msg.innerHTML = "This is your turn";
    msg.style.color = "green";
    document.getElementById("msg-box").appendChild(msg);
}


function removeElement(id) {
    var elem = document.getElementById(id);
    return elem.parentNode.removeChild(elem);
}

function clearMsgBox() {
    $('#msg-box').empty();
}
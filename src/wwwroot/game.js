const field = document.getElementById("field");
const startMessage = document.getElementsByClassName("startMessage")[0];
const startgameOverlay = document.getElementsByClassName("start")[0];
const scoreElement = document.getElementsByClassName("scoreContainer")[0];
const startButton = document.getElementsByClassName("startButton")[0];
let game = null;
let currentCells = {};

function handleApiErrors(result) {
    if (!result.ok) {
        alert(`API returned ${result.status} ${result.statusText}. See details in Dev Tools Console`);
        throw result;
    }
    return result.json();
}

async function startGame(levelNumber) {
    game = await fetch("/api/games/",
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(levelNumber)
        }).then(handleApiErrors);
    window.history.replaceState(game.id, "The Game", "/" + game.id);
    renderField(game);
}

function makeMove(userInput) {
    if (!game || game.isFinished) return;
    console.log("send userInput: %o", userInput);
    fetch(`/api/games/${game.id}/moves`,
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(userInput)
            })
        .then(handleApiErrors)
        .then(newGame => {
            game = newGame;
            updateField(game);
            leaderBoard();
        });
}

function renderField(game) {
    field.innerHTML = "";
    for (let y = 0; y < game.height; y++) {
        const row = document.createElement("tr");
        for (let x = 0; x < game.width; x++) {
            const cell = document.createElement("td");
            cell.id = "td_" + x + "_" + y;
            cell.dataset.x = x;
            cell.dataset.y = y;
            cell.addEventListener("click", onCellClick);
            row.appendChild(cell);
        }
        field.appendChild(row);
    }
    updateField(game);
}

function updateField(game) {
    if (game) {
        scoreElement.innerText = `Your score: ${game.score}`;
        startMessage.innerText = `Your score: ${game.score}. Again?`;
    }
    setTimeout(
        () => {
            startgameOverlay.classList.toggle("hidden", !game.isFinished);
            startButton.focus();
        },
        300);

    const cells = game.cells;
    const existedCells = {};
    for (let newCell of cells) {
        if (newCell.id in currentCells) {
            moveCell(newCell);
        } else {
            createCell(newCell);
        }
        existedCells[newCell.id] = newCell;
    }
    for (var currentCell of Object.values(currentCells)) {
        if (!(currentCell.id in existedCells)) {
            deleteCell(currentCell);
        }
    }
    currentCells = existedCells;
}

function moveCell(cell) {
    const cellDiv = document.getElementById(cell.id);
    updateCellDiv(cellDiv, cell);
}

function createCell(cell) {
    let cellDiv = document.createElement("div");
    cellDiv.id = cell.id;
    cellDiv.addEventListener("click", onCellClick);
    updateCellDiv(cellDiv, cell);
    document.body.appendChild(cellDiv);
}

function deleteCell(cell) {
    let cellDiv = document.getElementById(cell.id);
    cellDiv.remove();
}

function updateCellDiv(cellDiv, cell) {
    const staticGridCell = document.getElementById(`td_${cell.pos.x}_${cell.pos.y}`);
    const rect = staticGridCell.getBoundingClientRect();
    cellDiv.dataset.x = cell.pos.x;
    cellDiv.dataset.y = cell.pos.y;
    cellDiv.style.width = rect.width;
    cellDiv.style.height = rect.height;
    cellDiv.style.top = rect.top + "px";
    cellDiv.style.left = rect.left + "px";
    cellDiv.style.zIndex = cell.zIndex;
    cellDiv.className = cell.type + " animated cell";
    cellDiv.innerText = cell.content;
}


function addKeyboardListener() {
    window.addEventListener("keydown",
        e => {
            if (game && game.monitorKeyboard) {
                makeMove({ keyPressed: e.keyCode });
                if (e.keyCode >= 37 && e.keyCode <= 40)
                    e.preventDefault();
            }
        });
};

function addResizeListener() {
    window.addEventListener("resize",
        () => updateField(game));
}

function onCellClick(e) {
    if (!game || !game.monitorMouseClicks) return;
    const x = e.target.dataset.x;
    const y = e.target.dataset.y;
    makeMove({ clickedPos: { x, y } });
}



async function initLevelsCount() {
    fetch(`/api/games/levels`,
            {
                method: "GET"
            })
        .then(handleApiErrors)
        .then(countLevels => {
            var selectList = document.getElementById("LevelList");
            for (var i = 1; i <= countLevels; i++) {
                var option = document.createElement("option");
                option.value = i;
                option.text = i;
                selectList.appendChild(option);
            }
        });
}

async function leaderBoard() {

    fetch(`/api/games/leaderboard`,
        {
            method: "GET"
        })
        .then(handleApiErrors)
        .then(data => {
            var table = document.getElementById("localleaderboard");
            Object.entries(data).forEach(([key, value]) => {
                var line = document.createElement("tr");
                var levelNumber = document.createElement('td');
                var score = document.createElement('td');
                levelNumber.innerHTML = key;
                score.innerHTML = value;
                line.appendChild(levelNumber);
                line.appendChild(score);
                table.appendChild(line);
            });
        });
}

function initializePage() {
    const gameId = window.location.pathname.substring(1);
    initLevelsCount();
    leaderBoard();
    // use gameId if you want
    startButton.addEventListener("click", e => {
        startgameOverlay.classList.toggle("hidden", true);
        var selectElement = document.getElementById("LevelList");
        var levelNumber = selectElement.options[selectElement.selectedIndex].value;
        startGame(levelNumber);
    });
    addKeyboardListener();
    addResizeListener();
    startButton.focus();
}

initializePage();
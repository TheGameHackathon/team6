import React from 'react';
import styles from './styles.css'
import Gapped from '@skbkontur/react-ui/Gapped';
import PropTypes from 'prop-types';

export const Row = () => {
    return (<div>
        <Gapped gap={3}>
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
            <Cell class={styles.wall} />
        </Gapped>
    </div>)
};

export const Cell = (props) => {
    return (<div className={styles.cell}>
        <img className={props.class}/>
    </div>);
};

Cell.propTypes = {
    class: PropTypes.string
};

export default class Field extends React.Component {
    render() {
        return (<div className={styles.root}>
            <Gapped vertical gap={3}>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
                <Row/>
            </Gapped>
            <script>
                {window.addEventListener("keydown", this.handlerClick)};
            </script>
        </div>);
    }

    handlerClick (event) {
        switch (event.key) {
            case "ArrowUp":
                console.log("up");
                break;
            case "ArrowDown":
                console.log("down");
                break;
            case "ArrowLeft":
                console.log("left");
                break;
            case "ArrowRight":
                console.log("right");
                break;
            default:
                return
        }
    }
    
    componentDidMount() {
        const fieldJson = sendRequest()
    }
}

function sendRequest (url) {
    return fetch(url).then(response => {
        if (response.ok) {
            return response.json()
        }
        return Promise.reject('${response.status}', '${response.statusText}')
    })
}

const field = [
    [
        {type: "Empty"},
        {type: "Box"},
        {type: "Empty"}
    ],
    [
        {type: "Empty"},
        {type: "Empty"},
        {type: "Empty"}
    ],
    [
        {type: "Empty"},
        {type: "Box"},
        {type: "Empty"}
    ]
]

const directions = {
    'Up': {'x': 0, 'y': -1},
    'Down': {'x': 0, 'y': 1},
    'Left': {'x': -1, 'y': 0},
    'Right': {'x': 1, 'y': 0}
}

function isInBounds(field, direction, playerPosition) {
    if (directions[direction === undefined])
        throw "Unknown direction";
    const newPosition = {
        x: playerPosition['x'] + directions[direction]['x'],
        y: playerPosition['y'] + directions[direction]['y']
    }
    if (newPosition['x'] < 0 || newPosition['x'] >= field[0].length || 
    newPosition['y'] < 0 || newPosition['y'] >= field.length)
        return false;
    return true;
}

function makeMove(field, direction, playerPosition) {
    if (!isInBounds(field, direction, playerPosition))
        return false;
    const nextPos = {
        x: playerPosition['x'] + directions[direction]['x'],
        y: playerPosition['y'] + directions[direction]['y']
    }
    const nextNextPos = {
        x: nextPos['x'] + directions[direction]['x'],
        y: nextPos['y'] + directions[direction]['y']
    }
    const currentCell = field[playerPosition.y][playerPosition.x];
    const nextCell = field[nextPos['y']][nextPos['x']]
    let nextNextCell = {
        type: "Wall",
        object: "Empty"
    }
    if (isInBounds(field, direction, nextPos))
        nextNextCell = field[nextNextPos['y']][nextNextPos['x']]
    if (nextCell.type === "Wall")
        return false
    else if (nextCell.object !== "Box") {
        currentCell.object = "Empty";
        nextCell.object = "Player";
        return true
    } else {
        if (nextNextCell.type === "Wall" || nextNextCell.object === "Box")
            return false;
        else {
            currentCell.object = "Empty";
            nextCell.object = "Player";
            nextNextCell.object = "Box";
            return true;
        }
    }
}

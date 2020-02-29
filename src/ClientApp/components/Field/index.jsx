import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {
    render () {
        return (
            <div className={ styles.root }>
                <script>
                    {window.addEventListener("keydown", this.handlerClick)};
                </script>
            </div>
        );
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
}

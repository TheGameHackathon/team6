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
}


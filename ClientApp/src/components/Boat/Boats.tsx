import React, { Component } from 'react';
import { BoatsList } from './BoatsList';
import {Boat} from "../../types/data";

export class Boats extends Component {
    static displayName = Boats.name;

    constructor({props}: { props: any }) {
        super(props);
        this.state = {
            showModal: false
        };
        this.redirectToCrew = this.redirectToCrew.bind(this)
    }

    redirectToCrew(boat: Boat){
        // @ts-ignore

        this.props.history.push("/crew",
            boat);
    }
    render() {
        return (
            <div>
                <h1>Boat Manager</h1>
                <div>
                    <BoatsList boatComponent={this} />
                </div>

            </div>
        );
    };
}

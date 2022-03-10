import React, {Component} from "react";
import {BoatsList} from "../Boat/BoatsList";
import {Boat} from "../../types/data";
import { CrewList } from './CrewList';

interface ICrewProps{
    boat:Boat
}
interface ICrewState{
    boat:Boat
}
export class Crew extends Component<ICrewProps,ICrewState> {
    static displayName = Crew.name;
    constructor(props:ICrewProps) {
        super(props);
        this.state={
            boat: props.boat

        }
    }

    render() {
        return (
            <div>
                <h1>Crew Manager</h1>
                <h4>Crew of: {this.state.boat.name}</h4>
                <div>
                    <CrewList crewComponent={this}/>
                </div>

            </div>
        );
    };
}
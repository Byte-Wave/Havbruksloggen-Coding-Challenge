import React, {Component} from 'react';
import {IBoat, Boat, ICrewMember} from '../../types/data';
import {Boats} from "./Boats";
import {map} from "react-bootstrap/ElementChildren";

interface BoatProps {
    boats: Boat[],
    loading: boolean
}

export class BoatsList extends Component<{}, BoatProps> {
    static displayName = BoatsList.name;
    private boats: Boat[] = [];

    constructor({props}: { props: any }) {
        super(props);
        this.state = {
            boats: [],
            loading: true
        };
    }

    componentDidMount() {
        this.populateBoatData();
    }

    static renderBoatsTable: React.FC<Boat[]> = (boats: Boat[]) => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Producer</th>
                    <th>Build Number</th>
                    <th>LOA</th>
                    <th>B</th>
                </tr>
                </thead>
                <tbody>
                {boats.map(boat =>
                    <tr>
                        <td>{boat.name}</td>
                        <td>{boat.producer}</td>
                        <td>{boat.buildNumber}</td>
                        <td>{boat.maximumLength}</td>
                        <td>{boat.maximumWidth}</td>
                    </tr>
                )}

                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BoatsList.renderBoatsTable(this.state.boats);

        return (
            <div>
                <h4 id="tabelLabel">Boat Data</h4>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateBoatData() {

        const response = await fetch('/api/boats/all');

        const data = await response.json();

        this.setState({
            boats: data.result,
            loading: false
        });
    }

}
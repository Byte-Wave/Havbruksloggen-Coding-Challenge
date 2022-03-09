import React, {Component} from 'react';
import {IBoat, Boat, ICrewMember} from '../../types/data';
import {Boats} from "./Boats";
import {map} from "react-bootstrap/ElementChildren";
import Badge from 'react-bootstrap/Badge'
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

    async deleteFunc(id: string){
        const requestOptions = {
            method: 'DELETE'
        };
        const response = await fetch('/api/boats/delete?id='+id, requestOptions);

        const data = await response.json();
        this.setState({
            boats: [],
            loading: true
        });
        this.populateBoatData();
    }
    renderBoatsTable: React.FC<Boat[]> = (boats: Boat[]) => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Producer</th>
                    <th>Build Number</th>
                    <th>LOA</th>
                    <th>B</th>
                    <th></th>
                    <th></th>
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
                        <td><Badge bg="warning" >Edit</Badge></td>
                        <td><Badge bg="danger" onClick={()=>{this.deleteFunc(boat.id)}}>Delete</Badge></td>
                    </tr>
                )}

                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderBoatsTable(this.state.boats);

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
        console.log(data)
        this.setState({
            boats: data.result,
            loading: false
        });
    }

}
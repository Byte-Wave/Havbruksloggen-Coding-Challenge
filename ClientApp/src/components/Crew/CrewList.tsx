
import React, {Component} from 'react';
import {IBoat, Boat, ICrewMember, CrewMember} from '../../types/data';
import {map} from "react-bootstrap/ElementChildren";
import Badge from 'react-bootstrap/Badge'
import {Button, Image} from "react-bootstrap";
import {CrewAdd} from "./CrewAdd";
import Nav from 'react-bootstrap/Nav'
// @ts-ignore
import ReactModal from 'react-modal';
import {Boats} from "../Boat/Boats";
import {Crew} from "./Crew";

interface CrewListProps {
    crewComponent: Crew
}
interface CrewListState {
    crewMembers: CrewMember[],
    loading: boolean,
    showAddCrewMemberModal: boolean,
    selectedCrewMember: CrewMember | null
}

export class CrewList extends Component<CrewListProps, CrewListState> {
    static displayName = CrewList.name;
    private crewMembers: CrewMember[] = [];

    constructor({props}: { props: any }) {
        super(props);
        this.state = {
            crewMembers: [],
            loading: true,
            showAddCrewMemberModal: false,
            selectedCrewMember: null
        };
        this.handleOpenAddBoatModal = this.handleOpenAddBoatModal.bind(this);
        this.handleCloseAddBoatModal = this.handleCloseAddBoatModal.bind(this);
        this.handleOpenEditBoatModal = this.handleOpenEditBoatModal.bind(this);
    }
    handleOpenAddBoatModal() {
        this.setState({
            showAddCrewMemberModal: true,
            selectedCrewMember: null
        });
    }
    handleOpenEditBoatModal(boat: CrewMember) {
        this.setState({
            showAddCrewMemberModal: true,
            selectedCrewMember: boat
        });
    }
    async handleCloseAddBoatModal() {
        this.setState({
            crewMembers: [],
            loading: true,
            showAddCrewMemberModal: false
        });
        setTimeout('', 500);
        await this.populateBoatData()
    }

    componentDidMount() {
        this.populateBoatData();
    }

    async deleteFunc(id: string){
        const requestOptions = {
            method: 'DELETE'
        };
        await fetch('/api/boats/delete?id='+id, requestOptions)
            .then(async (response)=>{
                const data = response.json();
                this.setState({
                    crewMembers: [],
                    loading: true,
                    showAddCrewMemberModal: false
                });
                setTimeout('', 500);
                await this.populateBoatData()
            });


    }

    renderCrewMembersTable: React.FC<CrewMember[]> = (crewMembers: CrewMember[]) => {
        return (
            <div>
                <div>
                    <Nav variant="pills" defaultActiveKey="/home">
                        <Nav.Item>
                            <div>
                                <Button variant="btn btn-primary" onClick={this.handleOpenAddBoatModal}>Add Crew Member</Button>
                            </div>
                        </Nav.Item>
                        <Nav.Item>
                            <div className="button-margin">
                                <Button
                                    variant="btn btn-primary"
                                    onClick={()=>{
                                        this.setState({
                                            crewMembers: [],
                                            loading: true,
                                            showAddCrewMemberModal: false
                                        });
                                        setTimeout('', 500);
                                        this.populateBoatData()
                                    }}
                                >Refresh
                                </Button>
                            </div>
                        </Nav.Item>
                    </Nav>
                </div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th></th>
                        <th>Name</th>
                        <th>Producer</th>
                        <th>Build Number</th>
                        <th>LOA</th>
                        <th>B</th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    {crewMembers.map(crewMember =>
                        <tr className={"center"}>
                            <td>
                                <Image
                                    height="100px"
                                    src={crewMember.picture}
                                >
                                </Image>
                            </td>
                            <td>{crewMember.name}</td>
                            <td>{crewMember.name}</td>
                            <td>{crewMember.name}</td>
                            <td>{crewMember.name}</td>
                            <td>{crewMember.name}</td>
                            <td>
                                <Badge
                                    bg="dark"
                                    onClick={
                                        () => {

                                        }
                                    }
                                >Crew
                                </Badge>
                            </td>
                            <td>
                                <Badge
                                    bg="warning"
                                    onClick={
                                        () => {
                                            //this.handleOpenEditBoatModal(boat);
                                        }
                                    }
                                >Edit
                                </Badge>
                            </td>
                            <td>
                                <Badge
                                    bg="danger"
                                    onClick={
                                        () => {
                                            //this.deleteFunc(boat.id);
                                        }
                                    }
                                >Delete
                                </Badge>
                            </td>
                        </tr>
                    )}

                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCrewMembersTable(this.state.crewMembers);
        return (
            <div>
                <div>
                    <ReactModal
                        isOpen={this.state.showAddCrewMemberModal}
                        contentLabel="Minimal Modal Example"
                    >
                        <CrewAdd crewListRef={this}/>
                        <Button
                            id = "createModalCloseBtn"
                            variant="secondary"
                            onClick={this.handleCloseAddBoatModal}>
                            Close Modal
                        </Button>
                    </ReactModal>
                </div>
                <h4 id="tabelLabel">Boat Data</h4>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateBoatData() {
        console.log("Sending Request for crew")
        const response = await fetch('/api/crew/all');
        console.log(response)
        const data = await response.json();
        console.log(data)
        this.setState({
            crewMembers: data.result,
            loading: false,
            showAddCrewMemberModal: false
        });
    }

}

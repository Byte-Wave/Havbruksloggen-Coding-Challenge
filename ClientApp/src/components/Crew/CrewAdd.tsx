import React, {Component} from "react";
import {BoatsList} from "../Boat/BoatsList";
import {Boat, CrewMember} from "../../types/data";
import {CrewRole} from "../../types/enums";
import Form from "react-bootstrap/Form";
import {Button} from "react-bootstrap";
import {CrewList} from "./CrewList";
import Creatable from 'react-select/creatable';
import {forEach} from "react-bootstrap/ElementChildren";

interface CrewAddProps{
    crewListRef: CrewList
}

export class CrewAdd extends Component<CrewAddProps> {
    static displayName = CrewAdd.name;

    crewMember: CrewMember = new CrewMember();
    isEdit: boolean = false;
    constructor(props: CrewAddProps) {
        super(props);
        if (props.crewListRef.state.selectedCrewMember != null) {
            this.crewMember = props.crewListRef.state.selectedCrewMember;
            this.isEdit = true;
            this.crewMember.picture = "";
        }
        else {
            this.crewMember = new CrewMember();
            this.isEdit = false;
        }
        this.state = {
        };
    }

    async sendCreateCrewMemberData(crewMember:CrewMember) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(crewMember)
        };
        const response = await fetch('/api/crew/create', requestOptions);
        console.log(requestOptions)
        console.log(response)
        const data = await response.json();
        this.setState({
            boats: data.result,
            loading: true
        });
    }
    async sendUpdateCrewMemberData(crewMember:CrewMember) {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(crewMember)
        };
        const response = await fetch('/api/crew/update?id='+crewMember.id, requestOptions);

        const data = await response.json();
        this.setState({
            boats: data.result,
            loading: true
        });
    }
    // @ts-ignore
    getBase64 = file => {
        return new Promise(resolve => {
            let fileInfo;
            let baseURL: string | ArrayBuffer | null = "";
            // Make new FileReader
            let reader = new FileReader();

            // Convert the file to base64 text
            reader.readAsDataURL(file);

            // on reader load somthing...
            reader.onload = () => {
                // Make a fileInfo Object
                console.log("Called", reader);
                baseURL = reader.result;
                console.log(baseURL);
                resolve(baseURL);
            };
            console.log(fileInfo);
        });
    };

    // @ts-ignore
    handleFileInputChange = (event) => {
        console.log(event.target.files[0]);
        let file = event.target.files[0];

        this.getBase64(file)
            .then(result => {
                file["base64"] = result;
                console.log(file);
                this.crewMember.picture = file["base64"];
                this.crewMember.pictureName = file["name"];
                this.crewMember.pictureType = file["type"];
            })
            .catch(err => {
                console.log(err);
            });
    }
    // @ts-ignore
    handleSubmit = (event) => {
        event.preventDefault();
        this.crewMember.name = event.target.name.value;
        this.crewMember.email = event.target.email.value;
        this.crewMember.age = event.target.age.value;
        this.crewMember.certifiedUntil = event.target.certifiedUntil.value;
        this.crewMember.role = event.target.role.value;
        this.crewMember.boatId = this.props.crewListRef.props.crewComponent.props.boat.id
        //this.boat.picture = event.target.picture.value.
        console.log(this.crewMember);
        if(this.isEdit){
            this.sendUpdateCrewMemberData(this.crewMember).then(()=>{
                this.props.crewListRef.populateBoatData();
            });
        }
        else {
            this.sendCreateCrewMemberData(this.crewMember).then(()=>{
                this.props.crewListRef.populateBoatData();
            });
        }



    }

    render() {
        return (
            <div>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group className="mb-3" controlId="boatFormName">
                        <Form.Label>Name</Form.Label>
                        <Form.Control type="text" defaultValue={this.crewMember.name} placeholder="John Smith" name="name"/>
                        <Form.Text className="text-muted">
                            Crew member's full name
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormProd">
                        <Form.Label>Producer</Form.Label>
                        <Form.Control
                            type="email"
                            defaultValue={this.crewMember.email}
                            placeholder="john.smith@gmail.com,"
                            name="email" />
                        <Form.Text className="text-muted">
                            Crew member's email adress
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormBuildNum">
                        <Form.Label>Age</Form.Label>
                        <Form.Control type="number" defaultValue={this.crewMember.age} placeholder="1233" name="age"/>
                        <Form.Text className="text-muted">
                            Crew member's Age.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormLOA">
                        <Form.Label>Crew Role</Form.Label>

                        <Form.Select defaultValue={this.crewMember.role} placeholder="select a role" name="role">
                            <option value={CrewRole.DeckCadet}>Deck Cadet</option>
                            <option value={CrewRole.MotorMan}>Motor Man</option>
                            <option value={CrewRole.ChiefEngineer}>Chief Engineer</option>
                            <option value={CrewRole.Captain}>Captain</option>
                        </Form.Select>
                        <Form.Text className="text-muted">
                            Crew member's role.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormB">
                        <Form.Label>Certified Until</Form.Label>
                        <Form.Control type="date" defaultValue={this.crewMember.certifiedUntil} placeholder="2.3" name="certifiedUntil"/>
                        <Form.Text className="text-muted">
                            Crew member's certificate valid until.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormPhoto">
                        <Form.Label>Picture</Form.Label>
                        <Form.Control type="file" accept="image/*" name="picture" onInput={this.handleFileInputChange}/>
                        <Form.Text className="text-muted">
                            Crew member's picture
                        </Form.Text>
                    </Form.Group>
                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>
        );
    };
}

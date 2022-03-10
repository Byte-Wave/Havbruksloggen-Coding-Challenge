import React, {Component} from "react";
import {BoatsList} from "../Boat/BoatsList";
import {Boat, CrewMember} from "../../types/data";
import Form from "react-bootstrap/Form";
import {Button} from "react-bootstrap";
import {CrewList} from "./CrewList";

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

    async sendCreateCrewMemberData(boat:CrewMember) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(boat)
        };
        const response = await fetch('/api/crew/create', requestOptions);

        const data = await response.json();
        this.setState({
            boats: data.result,
            loading: true
        });
    }
    async sendUpdateCrewMemberData(boat:CrewMember) {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(boat)
        };
        const response = await fetch('/api/crew/update?id='+boat.id, requestOptions);

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
        this.crewMember.email = event.target.producer.value;
        this.crewMember.age = event.target.buildNumber.value;
        this.crewMember.certifiedUntil = event.target.maximumLength.value;
        this.crewMember.role = event.target.maximumWidth.value;
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
                        <Form.Control type="text" defaultValue={this.crewMember.name} placeholder="Black Pearl" name="name"/>
                        <Form.Text className="text-muted">
                            Name of the Boat.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormProd">
                        <Form.Label>Producer</Form.Label>
                        <Form.Control type="text" defaultValue={this.crewMember.name} placeholder="BMW" name="producer" />
                        <Form.Text className="text-muted">
                            Producer of the Boat.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormBuildNum">
                        <Form.Label>Build Number</Form.Label>
                        <Form.Control type="number" defaultValue={this.crewMember.age} placeholder="1233" name="buildNumber"/>
                        <Form.Text className="text-muted">
                            Build Number of the Boat.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormLOA">
                        <Form.Label>LOA</Form.Label>
                        <Form.Control type="text" defaultValue={this.crewMember.age} placeholder="8.6" name="maximumLength"/>
                        <Form.Text className="text-muted">
                            Maximum length of boat, in meters.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormB">
                        <Form.Label>B</Form.Label>
                        <Form.Control type="text" defaultValue={this.crewMember.age} placeholder="2.3" name="maximumWidth"/>
                        <Form.Text className="text-muted">
                            Maximum width of boat, in meters.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="boatFormPhoto">
                        <Form.Label>Picture</Form.Label>
                        <Form.Control type="file" accept="image/*" name="picture" onInput={this.handleFileInputChange}/>
                        <Form.Text className="text-muted">
                            Picture of the boat.
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

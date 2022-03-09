import React, { Component } from 'react';
import { BoatsList } from './BoatsList';
import ReactModal from 'react-modal';
import { BoatAdd } from './BoatAdd';
import { Button} from 'react-bootstrap';

export class Boats extends Component {
    static displayName = Boats.name;

    constructor(props) {
        super(props);
        this.state = {
            showModal: false
        };
        this.handleOpenModal = this.handleOpenModal.bind(this);
        this.handleCloseModal = this.handleCloseModal.bind(this);
        this.closeBtnRef = React.createRef()
    }
    handleOpenModal() {
        this.setState({ showModal: true });
    }
    handleCloseModal() {
        this.setState({ showModal: false });
    }
    render() {
        return (
            <div>
                <h1>Boat Manager</h1>
                <Button variant="btn btn-primary" onClick={this.handleOpenModal}>Add Boat</Button>
                <div>
                    <ReactModal
                        isOpen={this.state.showModal}
                        contentLabel="Minimal Modal Example"
                    >
                        <BoatAdd closeBtnRef = {this.closeBtnRef} />
                        <Button
                            ref = {this.closeBtnRef}
                            id = "createModalCloseBtn"
                            variant="secondary"
                            onClick={this.handleCloseModal}>
                            Close Modal
                        </Button>
                    </ReactModal>
                </div>
                <div>
                    <BoatsList />
                </div>

            </div>
        );
    };
}

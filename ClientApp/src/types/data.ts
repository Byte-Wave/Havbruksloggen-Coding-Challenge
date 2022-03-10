import {CrewRole} from "./enums";


export interface IBoat {
    id: string;
    name: string;
    producer: string;
    buildNumber: number;
    maximumLength: number;
    maximumWidth: number;
    picture: string
    pictureName: string;
    pictureType: string;
    crew: ICrewMember[];
}

export class Boat implements IBoat {
    id: string;
    name: string;
    producer: string;
    buildNumber: number;
    maximumLength: number;
    maximumWidth: number;
    picture: string;
    pictureName: string;
    pictureType: string;
    crew: ICrewMember[];

    constructor(
        id: string = "",
        name: string = "",
        producer: string = "",
        buildNumber: number = 0,
        maximumLength: number = 0,
        maximumWidth: number = 0,
        picture: string = "",
        pictureName: string = "",
        pictureType: string = "",
        crew: ICrewMember[] = []) {
        this.id = id;
        this.name = name;
        this.producer = producer;
        this.buildNumber = buildNumber;
        this.maximumLength = maximumLength;
        this.maximumWidth = maximumWidth;
        this.picture = picture;
        this.pictureName = picture;
        this.pictureType = picture;
        this.crew = crew;
    }
}

export interface ICrewMember {
    id: string;
    name: string;
    age: number;
    email: string;
    role: CrewRole;
    certifiedUntil: string;
    boatId: string;
    picture: string;
    pictureName: string;
    pictureType: string;
}

export class CrewMember implements ICrewMember {
    id: string;
    name: string;
    age: number;
    email: string;
    role: CrewRole;
    certifiedUntil: string;
    boatId: string;
    picture: string;
    pictureName: string;
    pictureType: string;

    constructor(
        id: string = "",
        name: string = "",
        age: number = 0,
        email: string = "",
        role: CrewRole = CrewRole.DeckCadet,
        certifiedUntil: string ="",
        boatId: string = "",
        picture: string = "",
        pictureName: string = "",
        pictureType: string = "",) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.email = email;
        this.role = role;
        this.certifiedUntil = certifiedUntil;
        this.boatId = boatId;
        this.picture = picture;
        this.pictureName = picture;
        this.pictureType = picture;
    }


}
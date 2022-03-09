import { CrewRole } from "./enums";


export interface IBoat {
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
}
export class Boat implements IBoat{
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
        producer:string = "",
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
    picture?: string;
    age: number;
    email: string;
    role: CrewRole;
    certifiedUntil: Date;
    boatId: number;
    boat: IBoat;
}

import { CrewRole } from "./enums";

export interface ICrewForm {
    name: string;
    picture?: string;
    age: number;
    email: string;
    role: CrewRole;
}

export interface IBoatForm {
    name: string;
    producer: string;
    buildNumber: string;
    maximumLength: number;
    maximumWidth: number;
    picture: string;
}
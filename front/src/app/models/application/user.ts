import { Role } from "./role";

export class User {
    UserId!: string;
    Name!: string;
    LastName!: string;
    Email!: string;
    Password!: string;
    BirthDate!: Date;
    ID!: string;
    Gender!: string;
    CreateDate!: Date;

    Role!: Role;
}
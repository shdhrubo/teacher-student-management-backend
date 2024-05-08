import { IStudent } from "./student.model";

export interface IStudentWithId extends IStudent{
   id: number;
}
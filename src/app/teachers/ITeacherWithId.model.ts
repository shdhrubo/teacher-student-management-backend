import { ITeacher } from "./teacher.model";

export interface ITeacherWithId extends ITeacher {
    id: number;
  }
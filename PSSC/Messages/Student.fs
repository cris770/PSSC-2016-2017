namespace Student

open System
open Messages

type CreateNewStudent ={
    StudentId:Guid;
    Name:String;
    StudyYear:int;
} with interface ICommand

type StudentCreated={
    StudentId:Guid;
    Name:String;
    StudyYear:int;
} with interface IEvent

type AddCourseForStudent={
    CourseId:Guid;
    StudentId:Guid;
    Name:String;
} with interface ICommand

type CourseAddedForStudent = {
    CourseId:Guid;
    StudentId:Guid;
} with interface IEvent
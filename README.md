## Project Description (!FD)
Project for 'PSSC' - Domain driven development

Project structure:

* Models (DDD Models)
	* Common (Classes used in more than 1 context)
	* Contexts (Bounded contexts)
		* Deanship 
		* Professor 
		* Student 
	* Generics (Value objects)
	* Repositories (Empty for now)
* Testing (Unit testing)

Bounded contexts:
- Deanship
- Professor
- Student

Context   - Aggregate root:
* Deanship  - StudyYear
* Professor - Subjects
* Student	- GradeReport

The Deanship is able to create a new StudyYear and manage all the subjects (Add, Update).

The Professor is able to see all his subjects (TeachingSubject) and the enrolled students. He is able to add grades, attendances and set the activity proportion.

The Student is able to see his grades.
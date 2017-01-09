# PSSC-2016-2017

SharedKernel project: contains a subset of the domain model. If multiple teams are working on the same project, every team must be notified
before making any change to it. So far it contains two classes:
-Entity: an abstract class with and Id propery of type Guid; every entity inherits from it;
-ValueObject: their notion of equlity isn't based on identity, instead two object are wqual if all their fields are equal
              they should be immutable(if you want to change a value object, you should replace the object with a new one)
   
Bounded contexts: course management & reporting (to be implemented)
Grades for a certian course and student can be added only using the ProfessorAggregate root
Courses cand be assigned only by a Deanship

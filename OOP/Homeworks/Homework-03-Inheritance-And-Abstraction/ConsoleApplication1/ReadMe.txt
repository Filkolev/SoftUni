I believe this problem is poorly written and very confusing. That's why, in order to make something that actually works, I redefined it to some extent. Here is what I did:

I created a static class SchoolData which serves as a sort of database for the school. It holds lists of all students, teachers, classes and disciplines. 
Many properties from other classes are extracted from SchoolData, thus they are bound to it, but not to each other (e.g. Classrooms do not communicate with Students directly).

I created interfaces for each class to raise abstraction. I added an interface IDescribable for all classes holding details as an optional field.

Each Classroom (I call it classroom to reduce confusion) has a set of students, teachers and disciplines, identifier and details. 
When creating a classroom one should add it's identifier and a set of disciplines.
Teachers are extracted based on disciplines (through the SchoolData class), students are added to a classroom when created (in the Student constructor).
Classroom is responsible for validating student numbers as each student should have a unique number within a class.

Each discipline has a name, number of lectures and details. 
Teachers are extracted from SchoolData, meaning disciplines are assigned when creating a teacher, not the other way around.
Classrooms and (and students respectively) are extracted from SchoolData. Disciplines are assigned to classrooms, not the other way around. 

Each person has name and details.

Each student has:
name - inherited from Person;
classroom - assigned when creating a student, not when creating a classroom;
class number - validated when student is added to classroom by the Classroom class;
disciplines - entirely depends on the classroom the student is in; extracted from SchoolData;
teachers = extracted from SchoolData;

Each teacher has:
classrooms - extracted from SchoolData, based on the disciplines the teacher teaches and the classes assigned to the discipline;
disciplines - assigned when creating a teacher;

Still not pretty. But it works, I think.

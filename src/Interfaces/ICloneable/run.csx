// ICloneable
// ------------------------------------------------------------------------------------------------------
// Supports cloning, which creates a new instance of a class with the same value as an existing instance.
// ------------------------------------------------------------------------------------------------------

#load "entities.csx"

var student1 = new Student("James");
student1.SetAverage(9.7);

var student2 = (Student)student1.Clone();
student2.SetAverage(4);

WriteLine(student1);
WriteLine(student2);

#load "entities.csx"
#load "utils.csx"

var school = new School();
var teachers = school.GetTeachers();
var mailingList = new MailingList();

// Add() is covariance, we can use a more derived type
mailingList.Add(teachers);

// The Set<T> constructor uses a contravariance interface, IComparer<in T>
// We can use a more generic type than required.
var teacherSet = new SortedSet<Teacher>(teachers, new PersonNameComparer());

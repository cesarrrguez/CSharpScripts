#load "entities.csx"
#load "utils.csx"

Utils.CovarianceDelegate covarianceDelegate = null;
Person person = null;

// Covariance with Delegate
WriteLine("Covariance with Delegate");

// Get Teacher from teacher
covarianceDelegate = Utils.GetTeacherFromTeacher;
person = covarianceDelegate(new Teacher());

// Get Person from teacher
covarianceDelegate = Utils.GetPersonFromTeacher;
person = covarianceDelegate(new Teacher());

// Contravariance with Delegate
WriteLine("\nContravariance with Delegate");

// Get Person from person
covarianceDelegate = Utils.GetPersonFromPerson;
person = covarianceDelegate(new Teacher());

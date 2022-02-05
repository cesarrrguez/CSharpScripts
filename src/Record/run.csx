#load "records.csx"
#load "entities.csx"

// CLASSES
var personAsClass = new PersonAsClass
{
    FullName = "John Smith",
    DateOfBirth = new DateTime(1990, 12, 1)
};

var personAsClass2 = new PersonAsClass
{
    FullName = "John Smith",
    DateOfBirth = new DateTime(1990, 12, 1)
};

WriteLine(personAsClass); // Submission#0+PersonAsClass
WriteLine(personAsClass == personAsClass2); // False
WriteLine(ReferenceEquals(personAsClass, personAsClass2)); // False

WriteLine();

// RECORDS
var personAsRecord = new PersonAsRecord("John Smith", new DateTime(1990, 12, 1));
var personAsRecord2 = new PersonAsRecord("John Smith", new DateTime(1990, 12, 1));

WriteLine(personAsRecord); // Person { FullName = John Smith, DateOfBirth = 01/12/1990 0:00:00 }
WriteLine(personAsRecord == personAsRecord2); // True
WriteLine(ReferenceEquals(personAsRecord, personAsRecord2)); // False

// Copy record using with keyword
var personAsRecordOlder = personAsRecord with { DateOfBirth = new DateTime(1980, 12, 1) };
WriteLine(personAsRecordOlder); // PersonAsRecord { FullName = John Smith, DateOfBirth = 01/12/1990 0:00:00 }

// Deconstructing a record
var (fullName, dateOfBirth) = personAsRecord;
WriteLine($"{fullName} {dateOfBirth}"); // John Smith 01/12/1990 0:00:00

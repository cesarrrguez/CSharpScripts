#load "entities.csx"

Child child_1 = new Child();
child_1.Age = 10;
child_1.Name = "Bryan";
child_1.StreetAddress = "Seattle, WA 98124";
WriteLine(child_1);

Child child_2 = new Child() { Age = 10, Name = "Bryan", StreetAddress = "Seattle, WA 98124" };
WriteLine(child_2);

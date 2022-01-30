#load "valueObjects.csx"

var address1 = new Address("Street", "ZipCode", "City");
var address2 = new Address("Street", "ZipCode", "City");

WriteLine(address1.Equals(address2));

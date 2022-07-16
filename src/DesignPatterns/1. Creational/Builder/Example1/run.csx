#load "services.csx"
#load "builders.csx"

var builder = new FerrariBuilder();
var director = new SportsCarBuildDirector(builder);

// Make builder
director.Build();

// Make product
var car = builder.Build();

// Print
WriteLine(car);

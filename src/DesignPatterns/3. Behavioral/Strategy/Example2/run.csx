#load "entities.csx"
#load "strategies.csx"

// Context + Ale Brewing Strategy
var beer = new Beer(new AleBrewingStrategy());
beer.Brew();

// Lager Brewing Strategy
beer.SetBrewingStrategy(new LagerBrewingStrategy());
beer.Brew();

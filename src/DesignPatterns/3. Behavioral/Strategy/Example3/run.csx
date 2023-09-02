var aleBrewingStrategy = () => WriteLine("Ale Brewing Strategy");
var lagerBrewingStrategy = () => WriteLine("Lager Brewing Strategy");

var beer = (Action strategy) =>
{
    WriteLine("Configuring...");
    strategy();
};

beer(aleBrewingStrategy);
beer(lagerBrewingStrategy);

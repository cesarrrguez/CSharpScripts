#load "entities.csx"

// Ingredients
var meat = new Ingredient("Meat", 120);
var lettuce = new Ingredient("Lettuce", 10);
var cheese = new Ingredient("Cheese", 40);
var tomato = new Ingredient("Tomato", 20);
var onion = new Ingredient("Onion", 10);
var bacon = new Ingredient("Bacon", 30);

// CheeseBurger Composite
var cheeseBurguer = new CompositeBurger("CheeseBurger");
cheeseBurguer.Add(meat);
cheeseBurguer.Add(lettuce);
cheeseBurguer.Add(cheese);
cheeseBurguer.Add(tomato);
cheeseBurguer.Add(onion);
WriteLine(cheeseBurguer);

// Bacon CheeseBurger Composite
var baconSheeseBurguer = new CompositeBurger("Bacon CheeseBurger");
baconSheeseBurguer.Add(cheeseBurguer);
baconSheeseBurguer.Add(bacon);
WriteLine(baconSheeseBurguer);

// Double CheeseBurger Composite
var doubleSheeseBurguer = new CompositeBurger("Double CheeseBurger");
doubleSheeseBurguer.Add(cheeseBurguer);
doubleSheeseBurguer.Add(meat);
WriteLine(doubleSheeseBurguer);

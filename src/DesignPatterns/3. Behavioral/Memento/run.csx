#load "entities.csx"

Product product = new Product();
product.Set("Phone");

// Save
var memento = product.SaveToMemento();

// Set again
product.Set("Tv");

// Restore
product.RestoreFromMemento(memento);

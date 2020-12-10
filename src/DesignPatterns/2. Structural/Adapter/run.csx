#load "services.csx"

var encryptSystem = new EncryptSystem();

// Non adapted encryption
encryptSystem.Encrypt();
WriteLine();

// Adapted encryption
var encryptLibrary = new EncryptLibrary();
var encryptLibraryToSystem = new EncryptLibraryToEncryptSystem(encryptLibrary);
encryptLibraryToSystem.Encrypt();

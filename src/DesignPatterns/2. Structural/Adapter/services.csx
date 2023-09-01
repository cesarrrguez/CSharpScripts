#load "interfaces.csx"

// Target
public class EncryptSystem : IEncryptSystem
{
    public void Encrypt() => WriteLine("Encrypt data system");
}

// Adapter
public class EncryptLibrary : IEncryptLibrary
{
    public void Encrypt() => WriteLine("Encrypt data library");
}

// Adaptee
public class EncryptLibraryToEncryptSystem : IEncryptSystem
{
    private readonly IEncryptLibrary _encryptLibrary;

    public EncryptLibraryToEncryptSystem(IEncryptLibrary encryptLibrary)
    {
        _encryptLibrary = encryptLibrary;
    }
    public void Encrypt()
    {
        WriteLine("Encrypt data library to system");
        _encryptLibrary.Encrypt();
    }
}

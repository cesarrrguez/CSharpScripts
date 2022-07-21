var operationsDB = OperationsDB();
operationsDB.Add();
operationsDB.Update();
operationsDB.Delete();

public (Action Add, Action Update, Action Delete) OperationsDB()
{
    return (
            () => WriteLine("Add"),
            () => WriteLine("Update"),
            () => WriteLine("Delete")
    );
}

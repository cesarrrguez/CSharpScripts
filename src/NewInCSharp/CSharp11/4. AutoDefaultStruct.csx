internal struct MyStruct
{
    public int Value { get; set; } // 0 by default
}

var myStruct = new MyStruct();
WriteLine(myStruct.Value);

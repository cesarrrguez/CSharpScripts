string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;

WriteLine(longMessage);

var longitude = 0;
var latitude = 1;
var location = $$"""
   You are at {{{longitude}}, {{latitude}}}
   """;

WriteLine(location);

int age = 40;

WriteLine($"The use is {age} years old, which is {age switch
{
    > 80 => "old",
    > 60 => "getting old",
    > 20 => "a good age",
    _ => "young"
}}");

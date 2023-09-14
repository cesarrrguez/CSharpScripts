#load "../../../packages.csx"

#load "entities.csx"

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var user = new User
{
    Name = "Thomas Heinz",
    Age = 25,
    Addresses = new Dictionary<string, Address>
    {
        { "home", new  Address
            {
                Street = "2720  Sundown Lane",
                City = "Kentucketsville",
                State = "Calousiyorkida",
                Zip = "99978"
            }
        },
        { "work", new  Address
            {
                Street = "1600 Pennsylvania Avenue NW",
                City = "Washington",
                State = "District of Columbia",
                Zip = "20500"
            }
        }
    }
};

var serializer = new SerializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();

var yaml = serializer.Serialize(user);
WriteLine(yaml);

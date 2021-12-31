using System.Reflection;

using AutoFixture.Kernel;

public class UserSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is ParameterInfo parameterInfo &&
            parameterInfo.ParameterType == typeof(string))
        {
            if (parameterInfo.Name == "password")
                return "123456";

            if (parameterInfo.Name == "email")
                return "cesar.rrguez@email.com";
        }

        return new NoSpecimen();
    }
}

public class PasswordSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is ParameterInfo parameterInfo &&
            parameterInfo.ParameterType == typeof(string) &&
            parameterInfo.Name == "password")
        {
            return "123456";
        }

        return new NoSpecimen();
    }
}

public class EmailSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is ParameterInfo parameterInfo &&
            parameterInfo.ParameterType == typeof(string) &&
            parameterInfo.Name == "email")
        {
            return "cesar.rrguez@email.com";
        }

        return new NoSpecimen();
    }
}

public class SpanishCountrySpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is ParameterInfo parameterInfo &&
            parameterInfo.ParameterType == typeof(string) &&
            parameterInfo.Name == "name")
        {
            return "ES";
        }

        return new NoSpecimen();
    }
}

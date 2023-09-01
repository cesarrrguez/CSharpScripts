#load "entities.csx"
#load "builders.csx"

using AutoFixture;

public class DummyProductCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Product>(comp => comp.With(p => p.Name, "Dummy Product"));
    }
}

public class ExpensiveDummyProductCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Product>(comp =>
            comp.With(p => p.Name, "Dummy Product").
                 With(p => p.Cost, double.MaxValue));
    }
}

public class UserCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new PasswordSpecimenBuilder());
        fixture.Customizations.Add(new EmailSpecimenBuilder());
    }
}

public class SpanishUserCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new SpanishCountrySpecimenBuilder());
        fixture.Customize(new UserCustomization());
    }
}

public class AdultUserCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize(new SpanishUserCustomization());
        fixture.Customize<User>(comp => comp.With(p => p.BornDate,
                                DateOnly.FromDateTime(DateTime.Now.AddYears(-25))));
    }
}

public class UserWithDummyProductCustomization : CompositeCustomization
{
    public UserWithDummyProductCustomization() :
        base(new UserCustomization(), new DummyProductCustomization())
    {
    }
}

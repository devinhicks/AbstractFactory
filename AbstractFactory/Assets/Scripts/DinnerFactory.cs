using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDinnerFactory
{
    IDinner Create(DinnerRequirements requirements);
}

//public abstract class AbstractDinnerFactory
//{
//    public abstract ICheesey GetCheesey(DinnerRequirements requirements);
//    public abstract IVegan GetVegan(DinnerRequirements requirements);
//}

public class DinnerFactory //: AbstractDinnerFactory
{
    private readonly IDinnerFactory _factory;
    private readonly DinnerRequirements _requirements;

    public DinnerFactory(DinnerRequirements requirements)
    {
        _factory = requirements.IsVegan ?
            (IDinnerFactory)new Vegan() : new Cheesey();
        _requirements = requirements;
    }

    public IDinner Create()
    {
        return _factory.Create(_requirements);
    }
}

public class Cheesey : IDinnerFactory
{
    public IDinner Create(DinnerRequirements requirements)
    {
        switch (requirements.SkillLevel)
        {
            case 1:
                if (requirements.NumberOfGuests >= 3) return new Pizza();
                return new MacAndCheese();
            case 2:
                return new Cheeseburger();
            case 3:
                return new Souffle();
            default:
                return new MacAndCheese();
        }
    }
}

public class Vegan : IDinnerFactory
{
    public IDinner Create(DinnerRequirements requirements)
    {
        switch (requirements.SkillLevel)
        {
            case 1:
                if (requirements.NumberOfGuests >= 3) return new Bruschetta();
                return new Tofu();
            case 2:
                return new VeggieStew();
            case 3:
                return new Ratatouille();
            default:
                return new Tofu();
        }
    }
}
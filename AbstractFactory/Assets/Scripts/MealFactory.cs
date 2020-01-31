using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMealFactory
{
    IMeal Create(MealRequirements requirements);
}

//public abstract class AbstractDinnerFactory
//{
//    public abstract ICheesey GetCheesey(DinnerRequirements requirements);
//    public abstract IVegan GetVegan(DinnerRequirements requirements);
//}

public class MealFactory //: AbstractDinnerFactory
{
    private readonly IMealFactory _factory;
    private readonly MealRequirements _requirements;

    public MealFactory(MealRequirements requirements)
    {
        if (!requirements.IsHuman)
        {
            _factory = (IMealFactory)new Ogre();
        }
        else
        {
            switch(requirements.mealTime)
            {
                case 0:
                    _factory = (IMealFactory)new Breakfast();
                    break;
                case 1:
                    _factory = (IMealFactory)new Lunch();
                    break;
                case 2:
                    _factory = (IMealFactory)new DinDin();
                    break;
                default:
                    _factory = (IMealFactory)new Breakfast();
                    break;
            }
        }
        _requirements = requirements;
    }

    public IMeal Create()
    {
        return _factory.Create(_requirements);
    }
}

public class Breakfast : IMealFactory
{
    public IMeal Create(MealRequirements requirements)
    {
        if (requirements.competence)
        {
            return new Omelette();
        }
        else
        {
            return new Toast();
        }
    }
}

public class Lunch : IMealFactory
{
    public IMeal Create(MealRequirements requirements)
    {
        if (requirements.competence)
        {
            return new Burger();
        }
        else
        {
            return new Chips();
        }
    }
}

public class DinDin : IMealFactory
{
    public IMeal Create(MealRequirements requirements)
    {
        if (requirements.competence)
        {
            return new Chili();
        }
        else
        {
            return new Rice();
        }
    }
}

public class Ogre : IMealFactory
{
    public IMeal Create(MealRequirements requirements)
    {
        return new Onion();
    }
}

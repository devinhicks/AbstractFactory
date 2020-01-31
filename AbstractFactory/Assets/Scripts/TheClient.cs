using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TheClient : MonoBehaviour
{
    public int mealTime; //0 - breakfast, 1 - lunch, 2 - dinner
    public bool competence; //true if can cook, false if cannot
    public bool IsHuman; //true if human, false if ogre

    public Toggle mornToggle;
    public Toggle aftToggle;
    public Toggle nightToggle;
    public Toggle compToggle;
    public Toggle humanToggle;

    public Canvas questionsUI;
    public Text foodName;

    private MealRequirements requirements;

    void Start()
    {
        requirements = gameObject.AddComponent<MealRequirements>();

        requirements.mealTime = Mathf.Max(mealTime);
        requirements.competence = competence;
        requirements.IsHuman = IsHuman;

    }

    public void Cook()
    {
        if (mornToggle.isOn)
        {
            requirements.mealTime = 0;
        }
        else if (aftToggle.isOn)
        {
            requirements.mealTime = 1;
        }
        else
        {
            requirements.mealTime = 2;
        }

        requirements.competence = compToggle.isOn;
        requirements.IsHuman = humanToggle.isOn;

        questionsUI.gameObject.SetActive(false);

        MealFactory factory = new MealFactory(requirements);
        IMeal m = factory.Create();
        foodName.gameObject.SetActive(true);
        if (m is Onion)
        {
            foodName.text = "It's all Ogre now." +
                "\n\n\n\n\n\n\n\nPress Enter to play again!";
        }
        else
        {
            foodName.text = "Enjoy your " + m.ToString() +
            "!\n\n\n\n\n\n\nPress Enter to play again!";
        }
        
        GameObject.Instantiate(Resources.Load(m + "Prefab"));
    }
}

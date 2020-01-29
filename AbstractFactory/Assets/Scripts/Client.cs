using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public int SkillLevel;
    public int NumberOfGuests;
    public bool IsVegan;

    public Slider skillSlider;
    public Slider guestSlider;
    public Slider cheeseToggle;

    public Canvas questionsUI;
    public Text foodName;

    private DinnerRequirements requirements;

    void Start()
    {
        requirements = gameObject.AddComponent<DinnerRequirements>();

        requirements.NumberOfGuests = Mathf.Max(NumberOfGuests);
        requirements.IsVegan = IsVegan;
        requirements.SkillLevel = Mathf.Max(SkillLevel);
    }

    public void MakeDinner()
    {
        requirements.NumberOfGuests = (int)guestSlider.value;
        requirements.SkillLevel = (int)skillSlider.value;
        if (cheeseToggle.value == 1)
        {
            requirements.IsVegan = false;
        }
        else
        {
            requirements.IsVegan = true;
        }

        questionsUI.gameObject.SetActive(false);

        DinnerFactory factory = new DinnerFactory(requirements);
        IDinner d = factory.Create();
        foodName.text = d.ToString();
        GameObject.Instantiate(Resources.Load(d + "Prefab"));
    }
}

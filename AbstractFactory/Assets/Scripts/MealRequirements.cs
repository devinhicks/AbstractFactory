using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealRequirements : MonoBehaviour
{
    public int mealTime; //0 - breakfast, 1 - lunch, 2 - dinner
    public bool competence; //true if can cook, false if cannot
    public bool IsHuman; //true if human, false if ogre
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarOfPerson : MonoBehaviour
{
    public Slider slide;
    public GameObject Person;
    private void Start()
    {
        slide.maxValue = Person.GetComponent<UserEntityController>().health;
    }
    private void Update()
    {
        slide.value = Person.GetComponent<UserEntityController>().health;
    }
}

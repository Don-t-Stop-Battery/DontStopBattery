using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float energy = 100f;
    [SerializeField]
    Slider slider;

    private void Start()
    {
        StartCoroutine("EnergyDown");
    }

    private void Update()
    {
        EnergyDown();
    }
    public float Energy
    {
        get
        {
            return energy;
        }
        set
        {
            if(energy<0) energy = value;
        }
    }

    private void EnergyDown()
    {
        energy-= Time.deltaTime;
        slider.value = energy;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float energy = 100f;

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

    private 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float energy = 100f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI scoreText;
    float decimalScore;
    int score;

    private void Update()
    {
        EnergyDown();
        Score();
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = "Score : " + score;
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

    private void Score()
    {
        decimalScore += Time.deltaTime;
        score = Mathf.RoundToInt(decimalScore)*100;
    }

    private void EnergyDown()
    {
        energy-= Time.deltaTime;
        slider.value = energy;
    }

    public void AddEnergy(int eneryPoint)
    {
        energy += eneryPoint;
    }

}

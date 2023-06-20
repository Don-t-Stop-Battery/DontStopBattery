using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private float energy = 100f;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    Image GameOverPenal;
    float decimalScore;
    int score;
    int coin = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine("Score");
        StartCoroutine("GameOver");
    }

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
    public float Energy { get => energy; set => energy = Mathf.Clamp(value, 0, 100); }

    public int Coin { get => coin; set => energy = value; }

    IEnumerator Score()
    {
        while (true)
        {
            decimalScore += Time.deltaTime;
            score = Mathf.RoundToInt(decimalScore)*100;
            yield return null;
        }
    }
    private void StopScore()
    {
        StopCoroutine("Score");
    }

    private void EnergyDown()
    {
        energy-= Time.deltaTime;
        slider.value = energy;
    }

    public void AddEnergy(int eneryPoint)
    {
        energy += eneryPoint;
        energy = Mathf.Clamp(energy, 0, 100);
    }
    IEnumerator GameOver()
    {
        while (true)
        {
            if (energy <= 0)
            {
                StopScore();
                GameOverPenal.gameObject.SetActive(true);
                GameOverPenal.DOFade(0.6f, 0.5f);
            }
                yield return null;
        }
    }

}

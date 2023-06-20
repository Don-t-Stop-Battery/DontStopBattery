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
    [SerializeField]
    TextMeshProUGUI coinText;
    float decimalScore;
    int score;
    int coin = 0;
    bool isDead = false;

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
        CoinUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = "Score : " + score;
    }
    public void CoinUpdate()
    {
        coinText.text = ": " + coin;
    }
    public float Energy { get => energy; set => energy = Mathf.Clamp(value, 0, 100); }

    public int Coin { get => coin; set => coin = value; }

    public bool IsDead { get => isDead; set => isDead = value; }

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
                isDead = true;
                StopScore();
                GameOverPenal.gameObject.SetActive(true);
                GameOverPenal.DOFade(0.6f, 0.5f);
            }
                yield return null;
        }
    }

}

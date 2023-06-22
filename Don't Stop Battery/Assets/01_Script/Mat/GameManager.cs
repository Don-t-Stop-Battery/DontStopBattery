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
    bool isDead;

    bool power;

    public int up = 17;
    public float eee = 3;

    private void Awake()
    {
        instance = this;
        up = 17;
        eee = 3;
    }
    private void Start()
    {
        StartCoroutine("Score");
        StartCoroutine("GameOver");
        StartCoroutine(bo());
        StartCoroutine(E());
        UpdateCoin();
        up = 17;
        eee = 3;
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

    public void UpdateCoin()
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

    public void Goodpower(){
        power = true;
    }

    public void oldpower(){
        power = false;
    }
    private void EnergyDown()
    {
        if(power == false){
            energy-= Time.deltaTime * eee;
            slider.value = energy;
        }
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
                isDead = true;
                GameOverPenal.gameObject.SetActive(true);
                GameOverPenal.DOFade(0.6f, 0.5f);
                StartCoroutine(ho());
            }
                yield return null;
        }
    }

    IEnumerator ho(){
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

    IEnumerator bo(){
        yield return new WaitForSeconds(7.5f);
        up += 2;
    }

    IEnumerator E(){
        yield return new WaitForSeconds(12.5f);
        eee += 0.5f;
    }
}

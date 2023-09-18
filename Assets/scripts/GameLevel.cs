using UnityEngine;
using TMPro;

public class GameLevel : MonoBehaviour
{
    public static GameLevel Instance;
    public static int Score;

    public GameObject startWaveButton;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public EnemyGenerator[] generators;

    public int money;
    public int wave;
    public int indexP;
    public float moneyTimer;
    public bool isStartWave;

    private void Start()
    {
        Instance = this;
        moneyText.text = money.ToString();
        waveText.text = wave.ToString();
        moneyTimer = 2.5f;
        indexP = PlayerPrefs.GetInt("index", 1);
    }
    private void OnDestroy()
    {
        indexP++;
        if (indexP > 3)
        {
            indexP = 1;
        }
        PlayerPrefs.SetInt("index", indexP);
    }
    private void Update()
    {
        if (isStartWave)
        {
            moneyTimer -= Time.deltaTime;

            if(moneyTimer <= 0f)
            {
                AddMoney(10);
                moneyTimer = 5f;
                if (Enemy.EnemyList.Count <= 0)
                {
                    isStartWave = false;
                    startWaveButton.gameObject.SetActive(true);
                    PlayerPrefs.SetString("record" + indexP, Score.ToString());
                    
                }
            }            
        }
    }

    public void StartWave()
    {
        wave++;
        waveText.text = wave.ToString();

        for (int i = 0; i < generators.Length; i++)
        {
            generators[i].CreateWave();
        }

        isStartWave = true;
    }

    public void GameOver()
    {

    }

    public void AddMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    public void RemoveMoney(int value)
    {
        money -= value;
        moneyText.text = money.ToString();
    }

}

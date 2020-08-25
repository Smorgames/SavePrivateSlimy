using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More then one GameController on the scene");
            return;
        }
        else
        {
            instance = this;
        }
    }

    private float timer;

    [HideInInspector]
    public bool canSpawn = false;
    private bool isGameActive = false;

    public GameObject enemyPrefab;

    public TextMeshProUGUI timerUI;

    [HideInInspector]
    public bool isPlayerDead = false;

    public float timeToWin = 90f;

    public GameObject coinPrefab;

    public TextMeshProUGUI countToStart;
    public GameObject pause;

    public GameObject win;
    public GameObject lose;

    public GameObject[] heroes;
    public Transform heroSpawnPoint;
    [HideInInspector]
    public GameObject pickedHero;

    public float[] spawnCoordinates;

    public TextMeshProUGUI percentageText;

    public string levelToUnlock;

    private LevelWaves levelWavesComponent;
    public string levelNumber;

    public float[] moneySpawnTime;

    private void Start()
    {
        levelWavesComponent = GetComponent<LevelWaves>();
        timer = 0f;
        timerUI.text = string.Format("{0:00.00}", ((int)timer).ToString());
        StartCoroutine(CountToStart());
        PickHero();
    }

    private void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;
            timerUI.text = string.Format("{0:00.00}", ((int)timer).ToString());
        }

        if (canSpawn)
            StartCoroutine(levelWavesComponent.Level(levelNumber));

        if (timer >= timeToWin)
        {
            UnlockLevel();
            win.GetComponent<Win>().Victory();
        }
    }
    
    private void SpawnCoin()
    {
        Instantiate(coinPrefab, new Vector2(Random.Range(-11f, 4.5f), 26f), Quaternion.identity);
    }

    IEnumerator CountToStart()
    {
        pause.SetActive(false);
        Time.timeScale = 0;
        countToStart.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        countToStart.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        countToStart.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        countToStart.enabled = false;
        Time.timeScale = 1;
        isGameActive = true;
        canSpawn = true;
        pause.SetActive(true);
        Instantiate(pickedHero, heroSpawnPoint.position, Quaternion.identity);
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(moneySpawnTime[0], moneySpawnTime[1]));
            SpawnCoin();
        }
    }

    public void Lose()
    {
        Time.timeScale = 0;
        //print(Mathf.Round((int)((Time.time / timeToWin) * 100)));
        lose.GetComponent<Lose>().PlayerDeath();
        StartCoroutine(CountDownToPercentage());

        print(Mathf.Round((int)((timer / timeToWin) * 100))); // check level win

        if (Mathf.Round((int)((timer / timeToWin) * 100)) > 75)
            UnlockLevel();

        // unlock next level if player passed 75 % of game
        // sound effect about unlock next level
    }

    public void PickHero()
    {
        for (int i = 0; i < heroes.Length; i++)
        {
            if (PlayerPrefs.GetInt("HeroNumber") == i)
                pickedHero = heroes[i];
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(spawnCoordinates[0], spawnCoordinates[2]), new Vector2(spawnCoordinates[0], spawnCoordinates[3]));
        Gizmos.DrawLine(new Vector2(spawnCoordinates[0], spawnCoordinates[3]), new Vector2(spawnCoordinates[1], spawnCoordinates[3]));
        Gizmos.DrawLine(new Vector2(spawnCoordinates[1], spawnCoordinates[3]), new Vector2(spawnCoordinates[1], spawnCoordinates[2]));
        Gizmos.DrawLine(new Vector2(spawnCoordinates[1], spawnCoordinates[2]), new Vector2(spawnCoordinates[0], spawnCoordinates[2]));
    }

    IEnumerator CountDownToPercentage()
    {
        int intVariable = 0;

        while(intVariable < Mathf.Round((int)((timer / timeToWin) * 100)) + 1)
        {
            percentageText.text = intVariable.ToString();
            intVariable++;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, new Vector2(Random.Range(spawnCoordinates[0], spawnCoordinates[1]), Random.Range(spawnCoordinates[2], spawnCoordinates[3])), Quaternion.identity);
        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        if (enemy.transform.position.x < -30 && enemy.transform.position.x > -50)
        {
            enemyComponent.moveDirection = "FLTR";
            enemyComponent.stopCoordinate = -27f;
        }

        if (enemy.transform.position.x < 50 && enemy.transform.position.x > 30)
        {
            enemyComponent.moveDirection = "FRTL";
            enemyComponent.stopCoordinate = 27f;
        }

        if (enemy.transform.position.y < 30 && enemy.transform.position.y > 20)
        {
            enemyComponent.moveDirection = "FTTB";
            enemyComponent.stopCoordinate = 12.5f;
        }

        if (enemy.transform.position.y < -20 && enemy.transform.position.y > -30)
        {
            enemyComponent.moveDirection = "FBTT";
            enemyComponent.stopCoordinate = -12.5f;
        }
    }

    private void UnlockLevel()
    {
        AudioManager.instance.Play("NextLevelIsUnlocked");
        PlayerPrefs.SetInt(levelToUnlock, 1);
    }
}

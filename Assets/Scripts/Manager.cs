using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject playedForTooLong;

    public float SuperDeathTime;
    public float SuperDeathTimeTimer;

    public const int MaxMarinesAmount = 15;

    public float TimeBeforeDelveAgain;
    public float TimeBeforeCombat;

    private float TimeBeforeEventCounter;

    public float DifficultyIncreaseTimeStep;
    public float DifficultyIncreaseTimeStepTimer;

    //[HideInInspector]
    public GameObject[] AllMarines;
    public GameObject[] AllMonsters;
    int random;
    public int HappeningChance;

    public GameObject EnemyPrefab;

    public Transform[] EnemySpawnPlaces;

    public TextMeshProUGUI monsterLVLtext;
    private int diffLevel = 1;

    public enum StageState
    {
        None,
        Delve,
        Combat,
        Event
    };

    public StageState stageState;

    private static Manager _instance;

    public static Manager Instance { get { return _instance; } }

    void Update()
    {
        SuperDeathTimeTimer += Time.deltaTime;

        if(SuperDeathTimeTimer > SuperDeathTime)
        {
            SuperDeathTimeTimer = 0.0f;
            EnemyPrefab.GetComponent<health>().HP += 1000;
            EnemyPrefab.GetComponent<monsterStats>().damage += 45;
            diffLevel += 100;
            monsterLVLtext.text = diffLevel.ToString();
            playedForTooLong.SetActive(true);
        }

        DifficultyIncreaseTimeStepTimer += Time.deltaTime;

        if(DifficultyIncreaseTimeStepTimer > DifficultyIncreaseTimeStep && EnemyPrefab)
        {
            EnemyPrefab.GetComponent<health>().HP += 25;
            EnemyPrefab.GetComponent<monsterStats>().damage += 1;
            DifficultyIncreaseTimeStepTimer = 0;
            diffLevel++;
            monsterLVLtext.text = diffLevel.ToString();

        }

        switch (stageState)
        {
            case StageState.None:
                break;
            case StageState.Delve:
                TimeBeforeEventCounter += Time.deltaTime;
                if (TimeBeforeEventCounter > TimeBeforeCombat)
                {
                    Combat();
                }
                break;
            case StageState.Combat:
                break;
            case StageState.Event:
                break;
            default:
                break;
        }
    }

    private void Combat()
    {
        random = Random.Range(0, HappeningChance);
        if (random == 0)
        {
            TimeBeforeEventCounter = 0;
            if(CountMarines() <= 7)
                SpawnEnemies(Random.Range(3, 5));
            else
            {
                SpawnEnemies(Random.Range(4, 10));
            }
            stageState = StageState.Combat;
        }
    }

    public void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject monsterClone = Instantiate(EnemyPrefab, EnemySpawnPlaces[Random.Range(0, EnemySpawnPlaces.Length)].position, Quaternion.identity);
            monsterClone.SetActive(true);
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _instance.AllMarines = GameObject.FindGameObjectsWithTag("marine");
    }

    public static GameObject PickRandomMarine()
    {
        _instance.AllMarines = GameObject.FindGameObjectsWithTag("marine");
        return _instance.AllMarines[Random.Range(0, _instance.AllMarines.Length)];
    }

    public static GameObject PickRandomMonsters()
    {
        _instance.AllMonsters = GameObject.FindGameObjectsWithTag("monster");
        return _instance.AllMonsters[Random.Range(0, _instance.AllMonsters.Length)];
    }

    public static int CountMarines()
    {
        return GameObject.FindGameObjectsWithTag("marine").Length;
    }

    public void MoveToDelveStage()
    {
        Manager.Instance.stageState = Manager.StageState.Delve;
    }
}

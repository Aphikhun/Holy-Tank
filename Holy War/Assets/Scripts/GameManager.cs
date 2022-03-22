using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public float enemySpeed;
    public float delayShoot;
    public int dmgBonus = 0;
    public string result;
    [SerializeField] private GameObject[] spawnP;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] stage;
    [SerializeField] private float delay;
    [SerializeField] private int enemy;
    private float time;
    private int a;
    

    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        a = 0;
        score = 0;
        time = 3f;
        enemySpeed = 2f;
        delayShoot = 2f;
        delay = 5f;
        enemy = 1;
    }

    // Update is called once per frame
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > delay && !TankControl.instance.isDead)
        {
            a++;
            time = 0;
            Instantiate(enemyPrefab[Random.Range(0,enemy)], spawnP[Random.Range(0,6)].transform.position, Quaternion.identity);
        }

        if (a >= 5 && !TankControl.instance.isDead)
        {
            Instantiate(enemyPrefab[2], spawnP[Random.Range(0, 6)].transform.position, Quaternion.identity);
            a = 0;
        }

        if (score >= 500)
        {
            delay = 3f;
            enemySpeed = 3f;
            delayShoot = 1.5f;
            stage[1].SetActive(true);
            stage[2].SetActive(false);
        }
        if (score >= 1000)
        {
            enemy = 2;
            delay = 2f;
            enemySpeed = 3f;
            delayShoot = 1.5f;
            stage[1].SetActive(true);
            stage[2].SetActive(false);
        }
        if(score >= 2000)
        {
            dmgBonus = 5;
            delay = 1.5f;
            enemySpeed = 3.5f;
            delayShoot = 1.5f;
            stage[0].SetActive(true);
            stage[1].SetActive(false);
        }
        Result();
       
    }
    void Result()
    {
        if (score <= 0)
        {
            result = "USELESS";
        }
        else if (1000 > score && score >= 500)
        {
            result = "NOT BAD";
        }
        else if (1500 > score && score >= 1000)
        {
            result = "GOOD";
        }
        else if (2000 > score && score >= 1500)
        {
            result = "PERFECT";
        }
        else if (score >= 2000)
        {
            result = "CRAZY";
        }
    }

}

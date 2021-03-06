﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> /* this GameManager is the type*/
{
    private static GameManager instance = null;
    //creating the one single instance of game manager 

    [SerializeField]
    private GameObject spawnPoint;


    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int maxEnemiesOnScreen;
    [SerializeField]
    private int totalEnemies;
    [SerializeField]
    private int enemiesPerSpawn;

    [SerializeField]
    private int enemiesOnScreen = 0;
    const float spawnDelay = 1.0f;


    void Awake()
    {
        /*  if (instance == null)
          {
              instance = this;
          }
          else if (instance != this)
          {
              Destroy(gameObject);
              DontDestroyOnLoad(gameObject);
          }
      }*/
    }
    //everytime creating a singleton we will have to rewrite this code over and over.

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawn());
    }

    /*    private void Update()
        {
            spawnEnemy();
        }

        void spawnEnemy()
        {
            if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
            {
                for (int i = 0; i < enemiesPerSpawn; i++)
                {
                    if (enemiesOnScreen < maxEnemiesOnScreen)
                    {
                        GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                        newEnemy.transform.position = spawnPoint.transform.position;
                        enemiesOnScreen += 1;
                    }
                }
            }

        */

    IEnumerator spawn()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(spawn());

        }

    }


    public void removeEnemyFromScreen()
    {
        if (enemiesOnScreen > 0)
        {
            enemiesOnScreen -= 1;
        }
        GameManager.instance.removeEnemyFromScreen();
        Destroy(gameObject);
    }


}

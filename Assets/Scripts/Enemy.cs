using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int target = 0;
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float navigationUpdate;
    //navigationUpdate aims to let object moving from vectors to vectors.

    private Transform enemy;
    private float navigationTime = 0;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Transform>();
        //addressing the properties of transform allowing you to access other scripts or components

    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                if (target < waypoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, waypoints[target].position, navigationTime);

                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                }
                navigationTime = 0;
                //resetting navTime to 0 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "checkpoint")
        {
            //debugging print("hellow world1");

            target += 1;
            // debugging print("hello world2");
        }
        else if (other.tag == "Finish")
        {
            GameManager.Instance.removeEnemyFromScreen();
            Destroy(gameObject);
        }
    }

}

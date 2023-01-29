using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuestionAnswerList;

public class EnemySpawn : MonoBehaviour
{
    public PauseGame pauseGame;
    public GameObject[] enemies = new GameObject[4];
    public Transform[] spawnPlace = new Transform[4];


    public float timer = 5f;
    public float time = 5f;
    public int damage = 0;
    public int hp = 0;
    public bool isPause = false;

    private void Spawn()
    {
        var rnd1 = new System.Random();
        int en = rnd1.Next(0, enemies.Length);
        var rnd2 = new System.Random();
        int pos = rnd2.Next(0, spawnPlace.Length);

        GameObject newEnemy = Instantiate(enemies[en], spawnPlace[pos].position, transform.rotation);
        
        newEnemy.transform.SetParent(transform);
    }


    void Update()
    {
        if (!isPause)
            time -= Time.deltaTime;

        if (0f > time)
        {
            Spawn();

            if (timer > 1f)
                timer -= 0.5f;

            Enemy[] allEnemies = transform.GetComponentsInChildren<Enemy>();
            //for (int i = allEnemies.Length - 1; i > (allEnemies.Length - 1) / 2; i--)
            //    allEnemies[i].UpgradeParametrs(damage, hp);
            allEnemies[allEnemies.Length - 1].UpgradeParametrs(damage, hp);

            damage += 5;
            hp += 15;
            time = timer;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public MouseLook playerSens;
    public Weapon weapon;
    public EnemySpawn enemySpawn;
    GameObject[] enemies;

    public GameObject objectToFind;

    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0;i < enemies.Length; i++)
            enemies[i].GetComponent<Animator>().enabled = false;

        playerMovement.isPause = true;
        playerSens.isPause = true;
        weapon.isPause = true;
        enemySpawn.isPause = true;
        EnemyNavMesh[] allChildren = objectToFind.transform.GetComponentsInChildren<EnemyNavMesh>();
        for (int i = 0; i < allChildren.Length; i++)
            allChildren[i].isPause = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
            enemies[i].GetComponent<Animator>().enabled = true;

        playerMovement.isPause = false;
        playerSens.isPause = false;
        weapon.isPause = false;
        enemySpawn.isPause = false;
        EnemyNavMesh[] allChildren = objectToFind.transform.GetComponentsInChildren<EnemyNavMesh>();
        for (int i = 0; i < allChildren.Length; i++)
            allChildren[i].isPause = false;
    }
}

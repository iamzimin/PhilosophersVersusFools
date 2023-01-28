using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public MouseLook playerSens;
    public Weapon weapon;

    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        playerMovement.isPause = true;
        playerSens.isPause = true;
        weapon.isPause = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.isPause = false;
        playerSens.isPause = false;
        weapon.isPause = false;
    }
}

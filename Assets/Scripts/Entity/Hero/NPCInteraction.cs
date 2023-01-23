using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Camera cam;
    public QuestionSystem questionSystem;
    public int range = 5;
    public KeyCode interactionKey = KeyCode.F;

    private bool isUIActivate = false;
    void InteractionWithNPC()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.rigidbody.tag == "Philosopher" && !isUIActivate)
            {
                //Debug.Log("123 " + hit.rigidbody);
                questionSystem.ActivateQuestion();
                isUIActivate = true;
            }
            else //fixme fix me todo to do delete
            {
                questionSystem.DeactivateQuestion();
                isUIActivate = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
            InteractionWithNPC();
    }
}

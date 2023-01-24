using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Camera cam;
    public QuestionSystem questionSystem;
    public ShopManager shopManager;
    public int range = 5;
    public KeyCode interactionKey = KeyCode.F;

    //private bool isUIActivate = false;
    void InteractionWithNPC()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.rigidbody.tag == "Aristotel")
            {
                questionSystem.ActivateQuestionChoice();
            }
            else if (hit.rigidbody.tag == "Sokrat")
            {
                questionSystem.ActivateQuestionEnter();
            }
            else if (hit.rigidbody.tag == "Seller")
            {
                //shopManager
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
            InteractionWithNPC();
    }
}

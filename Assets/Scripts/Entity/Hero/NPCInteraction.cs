using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Camera cam;
    public int range = 5;
    public KeyCode interactionKey = KeyCode.F;

    void InteractionWithNPC()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.rigidbody.tag == "Philosopher")
                Debug.Log("123 " + hit.rigidbody);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
            InteractionWithNPC();
    }
}

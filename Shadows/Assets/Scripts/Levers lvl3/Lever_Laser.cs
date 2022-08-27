using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Laser : MonoBehaviour
{
    public GameObject SkeleLaser;
    bool canInteract;
    ShadowMover shadow;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            shadow.s_Levers(SkeleLaser);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        shadow = collision.GetComponent<ShadowMover>();
        if (shadow == null)
        {
            canInteract = false;
        }
        if (collision.tag == "Shadow")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library_switch : MonoBehaviour
{
    public GameObject LibraryLight;
    bool canInteract;
    Mover player;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            player.p_Levers(LibraryLight);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Mover>();
        if (player == null)
        {
            canInteract = false;
        }
        if (collision.tag == "Player")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}

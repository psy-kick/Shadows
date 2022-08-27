using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallandExit : MonoBehaviour
{
    public List<GameObject> Hall;
    public List<GameObject> Exit;
    bool canInteract;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Activations();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
    void Activations()
    {
        foreach (GameObject g in Hall)
        {
            g.SetActive(!g.activeSelf);
        }
        foreach (GameObject g in Exit)
        {
            g.SetActive(!g.activeSelf);
        }
    }
}

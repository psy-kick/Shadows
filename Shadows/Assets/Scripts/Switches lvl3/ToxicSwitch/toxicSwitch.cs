using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicSwitch : MonoBehaviour
{
    public List<GameObject> Toxic_lasers;
    public List<GameObject> Toxic_lights;
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
        foreach (GameObject g in Toxic_lasers)
        {
            g.SetActive(!g.activeSelf);
        }
        foreach (GameObject g in Toxic_lights)
        {
            g.SetActive(!g.activeSelf);
        }
    }
}

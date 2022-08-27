using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarylvl2Switch : MonoBehaviour
{
    public List<GameObject> Lib1;
    public List<GameObject> lib2;
    public List<GameObject> lib3;
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
        foreach (GameObject g in Lib1)
        {
            g.SetActive(!g.activeSelf);
        }
        foreach (GameObject g in lib2)
        {
            g.SetActive(!g.activeSelf);
        }
        foreach (GameObject g in lib3)
        {
            g.SetActive(!g.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{
    public List<GameObject> Door;
    public List<GameObject> Toxic_lights1;
    bool canInteract;
    public string DoorAnims;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Activations();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shadow")
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
        foreach (GameObject g in Door)
        {
            g.GetComponent<Animator>().SetTrigger(DoorAnims);
        }
        foreach (GameObject g in Toxic_lights1)
        {
            g.SetActive(!g.activeSelf);
        }
    }
}

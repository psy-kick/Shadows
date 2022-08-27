using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers3 : MonoBehaviour
{
    public GameObject TrapDoor;
    public GameObject Lever;
    bool canInteract;
    public string LeversAnim;
    public string LeversAnimfordoors;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            GetAnimators();
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
    void GetAnimators()
    {
        TrapDoor.GetComponent<Animator>().SetTrigger(LeversAnim);
        Lever.GetComponent<Animator>().SetTrigger(LeversAnimfordoors);
    }
}

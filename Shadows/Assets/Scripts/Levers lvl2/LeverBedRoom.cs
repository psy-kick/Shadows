using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBedRoom : MonoBehaviour
{
    public GameObject BedroomLight;
    bool canInteract;
    public GameObject Lever;
    ShadowMover shadow;
    public string LeversAnim;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            GetAnimators();
            shadow.s_Levers(BedroomLight);
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
    void GetAnimators()
    {
        Lever.GetComponent<Animator>().SetTrigger(LeversAnim);
    }
}

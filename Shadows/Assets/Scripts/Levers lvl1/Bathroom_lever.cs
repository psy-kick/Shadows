using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom_lever : MonoBehaviour
{
    public GameObject LibraryLight;
    private void Start()
    {
        LibraryLight = GameObject.Find("LibraryLight");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shadow")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShadowMover Shadow = collision.GetComponent<ShadowMover>();
                if (Shadow != null)
                {
                    Shadow.s_Levers(LibraryLight);
                }
            }
        }
    }
}

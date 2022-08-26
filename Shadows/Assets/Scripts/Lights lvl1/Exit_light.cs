using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_light : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shadow")
        {
            ShadowMover Shadow = collision.GetComponent<ShadowMover>();
            if (Shadow != null)
            {
                Shadow.Die();
            }
        }
    }
}

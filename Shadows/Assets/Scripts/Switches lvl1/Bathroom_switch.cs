using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathroom_switch : MonoBehaviour
{
    public GameObject BathroomSwitch;
    private void Start()
    {
        BathroomSwitch = GameObject.Find("BathroomSwitch");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Mover Player = collision.GetComponent<Mover>();
                if (Player != null)
                {
                    Player.p_Levers(BathroomSwitch);
                }
            }
        }
    }
}

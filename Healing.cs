using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public GameObject HealthDrop;


    void OnTriggerEnter2D(Collider2D heal)
    {
        if (heal.CompareTag("Player"))
        {
             HealthDrop.SetActive(false);
           // Destroy(this.gameObject);
        }
    }

    


    void Update()
    {
        // Each frame, check if in contact with player
        // if true, deactivate
     
    }
}

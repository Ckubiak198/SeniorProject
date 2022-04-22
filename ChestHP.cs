using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHP : MonoBehaviour
{
    public GameObject chestTwo;
    public GameObject HealthDrop;
    public int maxHealth = 1;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Instantiate(chestTwo, transform.position, Quaternion.identity);

            Destroy(this.gameObject);

            HealthDrop.SetActive(true);
        }    
    }

}
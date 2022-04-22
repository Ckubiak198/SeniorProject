using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxUserHealth = 6;
    public static int userCurrentHealth;
    public GameObject HealthDrop;
    public GameObject Player;
    public int healthPickUp = 1;
    private Animator m_animator;

    void Start()
    {
        userCurrentHealth = maxUserHealth;
        m_animator = GetComponent<Animator>();
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Health"))
        {
            if (userCurrentHealth < maxUserHealth)
            {
                userCurrentHealth = userCurrentHealth + healthPickUp;

               // Destroy.HealthDrop;
            }
        }
    }


    public void TakeDamage(int damage)
    {
        userCurrentHealth -= damage;
        m_animator.SetTrigger("Hurt");
    }

    void Die()
    {
        Player.SetActive(false);
        //play ani and wait
    }

    void Update()
    {
        if (userCurrentHealth < 1)
        {
            Die();
        }

      /*  if (Input.GetMouseButtonDown(1))
        {
            enemyBandit.banditAttackDamage = 0;
        } */


    }
}

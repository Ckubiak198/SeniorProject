using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackArea;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask chestLayers;
    public int attackDamage = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemyLayers);
        Collider2D[] hitChests = Physics2D.OverlapCircleAll(attackArea.position, attackRange, chestLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<enemyBandit>().TakeDamage(attackDamage);
        }
        foreach(Collider2D chest in hitChests)
        {
           chest.GetComponent<ChestHP>().TakeDamage(attackDamage);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (attackArea == null)
            return;
        
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }
}

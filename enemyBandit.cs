using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBandit : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    public GameObject LightBandit;
    public int banditCurrentHealth;
    public int banditMaxHealth = 3;
    public Transform banditAttackArea;
    public float banditAttackRange = 0.5f;
    public LayerMask playerLayers;
    public static int banditAttackDamage = 1;
    public float cooldown = 2f;
    private float lastAttackedAt = -9999f;
    public bool isAttacking = false;
    public float speed;
    private Transform target;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        banditCurrentHealth = banditMaxHealth;
        //StartCoroutine(attackPlayer());
        target = Player.transform;
       
     
    }

  /*  IEnumerator attackPlayer()
    {
        while (PlayerHealth.userCurrentHealth > 1)
        {
            Attack();
            yield return new WaitForSecondsRealtime(1);
        }
    } */

    public void TakeDamage(int attackDamage)
    {
        banditCurrentHealth -= attackDamage;
        m_animator.SetTrigger("Hurt");
    }

    void Die()
    {
        m_animator.SetTrigger("Death");
       // StopCoroutine(attackPlayer());
    }
    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // play animation when moving, stop running when close
        if (Vector3.Distance(transform.position, target.position) < 1.4f)
        {
            speed = 0f;
            m_animator.SetInteger("AnimState", 1);
        }
        else
        {
            speed = 1.0f;
            m_animator.SetInteger("AnimState", 2);
        }


        //swap directions, speed doesn't work
         /*    if (GetComponent<Rigidbody2D>().velocity > 0)
                 transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
             else if (GetComponent<Rigidbody2D>().velocity < 0)
                 transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); */


        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        if (banditCurrentHealth < 1)
        {
            Die();
            LightBandit.SetActive(false);
            // Could change to static through rigidbody, then disable collider
            // Also have to disable the AI so it doesn't attack
        }



        //     if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Attack();
        //    }
        /*    if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                banditAttackDamage = 0;

            }    
            else
            {
                banditAttackDamage = 1;
            } */
        if (isAttacking == true)
        {
            if (Time.time > lastAttackedAt + cooldown)
            {
                Attack();
              
                lastAttackedAt = Time.time;

            }
        }
    }

    void Attack()
    {
        if (isAttacking == true)
        {
            m_animator.SetTrigger("Attack");
        }

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(banditAttackArea.position, banditAttackRange, playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(banditAttackDamage);
            Debug.Log("User health is " + PlayerHealth.userCurrentHealth);
        }
       
    }

    void OnDrawGizmosSelected()
    {
        if (banditAttackArea == null)
            return;

        Gizmos.DrawWireSphere(banditAttackArea.position, banditAttackRange);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isAttacking = false;
    }


    

  /*  void secondTrigger()
    {
        while (PlayerHealth.userCurrentHealth > 1)
        {
            isAttacking = true;
        }
    } */
  


}

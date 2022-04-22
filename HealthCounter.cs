using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{

    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    public GameObject Health4;
    public GameObject Health5;
    public GameObject Health6;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.userCurrentHealth == 6)
        {
            Health6.SetActive(true);
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health5.SetActive(false);
            Health4.SetActive(false);
        }
        if (PlayerHealth.userCurrentHealth == 5)
        {
            Health6.SetActive(false);
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health5.SetActive(true);
            Health4.SetActive(false);
        }
        if (PlayerHealth.userCurrentHealth == 4)
        {
            Health6.SetActive(false);
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health5.SetActive(false);
            Health4.SetActive(true);
        }
        if (PlayerHealth.userCurrentHealth == 3)
        {
            Health6.SetActive(false);
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(true);
            Health5.SetActive(false);
            Health4.SetActive(false);
        }
        if (PlayerHealth.userCurrentHealth == 2)
        {
            Health6.SetActive(false);
            Health1.SetActive(false);
            Health2.SetActive(true);
            Health3.SetActive(false);
            Health5.SetActive(false);
            Health4.SetActive(false);
        }
        if (PlayerHealth.userCurrentHealth == 1)
        {
            Health6.SetActive(false);
            Health1.SetActive(true);
            Health2.SetActive(false);
            Health3.SetActive(false);
            Health5.SetActive(false);
            Health4.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEnemy : MonoBehaviour
{
    private float healthActivationTime = 10f;
    [SerializeField] private GameObject Shield;

    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    void Update()
    {
        healthActivationTime -= Time.deltaTime;
        if (healthActivationTime <= 0f)
        {
            healthActivationTime = 0f;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(Shield, healthActivationTime);
        }

    }
}
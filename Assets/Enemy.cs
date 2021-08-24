using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AgroDetection agroDetection;
    private Health healthTarget;
    [SerializeField]
    private float attackRefreshRate;
    [SerializeField]
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        agroDetection = GetComponent<AgroDetection>();
        agroDetection.OnAggro += AgroDetection_OnAggro;
        
    }

    private void AgroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            healthTarget = health;
        }
    }

    // Update is called once per frame
     private void Update()
    {
        if (healthTarget!= null) 
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        }  
    }
    private void Attack()
    {
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefreshRate;
    }
}

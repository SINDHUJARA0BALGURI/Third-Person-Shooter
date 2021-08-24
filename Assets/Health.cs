using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int startingHealth = 5;
    int currentHealth;
    // Start is called before the first frame update
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
    // Update is called once per frame
    public void TakeDamage(int damageamount)
    {
        currentHealth -= damageamount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
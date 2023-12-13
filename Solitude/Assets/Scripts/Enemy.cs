using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int health = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Dead");
        animator.SetBool("death", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
 
}

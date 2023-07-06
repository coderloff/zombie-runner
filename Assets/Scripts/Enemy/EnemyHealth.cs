using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;
    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitpoints -= damage;
        if(hitpoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        GetComponent<Animator>().SetTrigger("Die");
        isDead = true;
    }
}

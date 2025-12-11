using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponUpdate : MonoBehaviour
{
    

    //attackTrigger variable form player
    private PlayerController playerController;

    //to avoid hitting the same enemy multiple times in one attack
    public List<Collider2D> hitEnemies = new List<Collider2D>();

    //reference for enemy controller

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerController._isAttacking)
        {
            //add enemy that has been hit to the set
            if (!hitEnemies.Contains(collision))
            {
                collision.gameObject.GetComponent<EnemyController>().health -= 1;
                Debug.Log("Weapon hit an enemy!");
                hitEnemies.Add(collision);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerController._isAttacking)
        {
            //add enemy that has been hit to the set
            if (!hitEnemies.Contains(collision))
            {
                collision.gameObject.GetComponent<EnemyController>().health -= 1;
                Debug.Log("Weapon hit an enemy!");
                hitEnemies.Add(collision);
            }
        }
    }


    public void Attack()
    {
        //Debug.Log("Weapon attack executed!");
    }

    //clear all hit enemis
    public void ResetAttack()
    {
        hitEnemies.Clear();
    }
}

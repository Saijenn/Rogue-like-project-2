using UnityEngine;

public class WeaponUpdate : MonoBehaviour
{
    //attackTrigger variable form player
    private PlayerAttack playerAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerAttack.isAttacking)
        {
            Debug.Log("Weapon hit an enemy!");
            //collision.gameObject.SetActive(false);
        }
    }

    public void Attack()
    {
        //Debug.Log("Weapon attack executed!");
    }
}

using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{

    private WeaponUpdate weaponUpdate;

    //reference for weapon
    [SerializeField] GameObject weaponObject;

   

    //Weapon animator
    private Animator weaponAnimator;

    //check if swinging weapon
    public bool attackTrigger { get; private set; }
    //get = anyone can read it
    //private set = only this script can change it

  
    public bool isAttacking { 
        get 
        { 
            return weaponAnimator.GetBool(AttackAnimationStrings.IsAttacking);
        }
    }

    private void Awake()
    {
        //set attack to false
        attackTrigger = false;

        //Get component for animator
        weaponAnimator  = weaponObject.GetComponentInChildren<Animator>();

        //Get component for weapon update
        weaponUpdate = GetComponentInChildren<WeaponUpdate>();
    }

    // Update is called once per frame
    void Update()
    {
        //swing animation
        weaponAnimator.SetBool(AttackAnimationStrings.attackTrigger, attackTrigger);

        //Player Attack
        if (Input.GetMouseButtonDown(0) && !attackTrigger && !isAttacking)
        {
            //in attack state
            attackTrigger = true;

            //swing weapon
            weaponUpdate.Attack();
        }
        else attackTrigger = false;

        //clear enemy list after stop attack
        if (!isAttacking)
        {
            weaponUpdate.hitEnemies.Clear();
        }
    }
}

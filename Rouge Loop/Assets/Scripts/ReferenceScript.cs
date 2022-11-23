using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceScript : MonoBehaviour
{

    WeaponDamage d;
    // Start is called before the first frame update
    void Awake()
    {
        d= GetComponentInChildren<WeaponDamage>();
    }

     public void EnableDamageCollider()
    {
        d.EnableDamageCollider();
    }
    public void DisableDamageCollider()
    {
        d.DisableDamageCollider();
    }
    public void enableInvicibility(){
        HelpVariables.isInvincible=true;
        print("Invincible now");
    }
    public void disableInvicibility(){
        HelpVariables.isInvincible=false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageOLD : MonoBehaviour
{
    public float damage;
    TimeHandling time;
    public BoxCollider weaponCollider;
    bool damageAllowed = true;
    // Start is called before the first frame update
    void Awake()
    {
        time = FindObjectOfType<TimeHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        print(other.tag);
        print("Fuktioniert");
        if(other.tag=="Player" && damageAllowed){
            print("Player hit");
            time.playerGetsHit(damage);
            damageAllowed = false;
            Invoke("allowDamage",0.8f);
        }
        if(other.tag=="Enemy"&& damageAllowed){
            print("Enemy hit");
            other.GetComponentInParent<DynamicEnemy>().getsHit(damage);
            damageAllowed = false;
            Invoke("allowDamage",0.8f);
        }
    }


    void allowDamage(){
        damageAllowed = true;
        print("damage Allowed now");
    }
}

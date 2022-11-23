using UnityEngine;
public class WeaponDamage : MonoBehaviour
{

    // Skript wird an jeweilige Waffe angehangen 
    // Reference Skript dann an Gegner/Spieler um ColliderFunktionen in Animation Evenets nutzen zu können
    public BoxCollider damageCollider;

    public float damage;
    bool damageAllowed = true;
    TimeHandling time;
    Animator animator;
    //string hitPath;
    string hitPath = "event:/SFX/Global/High Hits";

    private void Awake()
    {
        damageCollider = GetComponent<BoxCollider>();
        // damageCollider.isTrigger = true;
        damageCollider.enabled = false;
        time = FindObjectOfType<TimeHandling>();
        animator = GetComponentInParent<Animator>();
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }
    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        
        print(other.tag);
        print("Fuktioniert");
        if(other.tag=="Player" && damageAllowed){
            FMODUnity.RuntimeManager.PlayOneShot(hitPath, GetComponent<Transform>().position);
            print("Player hit");
            time.playerGetsHit(damage);
            // damageAllowed = false;          
            // Invoke("allowDamage",0.8f);
        }
        if((other.tag=="Enemy"&& damageAllowed&& tag!="EnemyWeapon") || (other.tag=="Enemy"&& animator.GetBool("wantsToCombo") && tag!="EnemyWeapon")){
            FMODUnity.RuntimeManager.PlayOneShot(hitPath, GetComponent<Transform>().position);
            print("Enemy hit" + tag);
            other.GetComponentInParent<DynamicEnemy>().getsHit(damage);
            // damageAllowed = false;
            // Invoke("allowDamage",0.4f);
        }
    }

    void allowDamage(){
        damageAllowed = true;
        print("damage Allowed now");
    }
}
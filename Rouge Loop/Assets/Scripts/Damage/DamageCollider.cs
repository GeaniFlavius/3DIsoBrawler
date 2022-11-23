using UnityEngine;
public class DamageCollider : MonoBehaviour
{
    public BoxCollider damageCollider;
    public Collider playerCollider;
    public float damage = 10;
    private CharacterController characterController;
    
    private void Awake()
    {
        //damageCollider = GetComponentInChildren<BoxCollider>();
        damageCollider.isTrigger = true;
        damageCollider.enabled = true;
        
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }
    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (tag == collision.tag) return;

            Stats stats = collision.GetComponentInParent<Stats>();
            if (stats != null)
            {
                print(tag+"calls Takedamage on " + collision.tag);
                stats.TakeDamage(damage, collision.tag);
            }

        
    }
}
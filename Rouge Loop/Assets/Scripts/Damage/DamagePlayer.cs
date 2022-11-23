using UnityEngine;
public class DamagePlayer : MonoBehaviour
{
    private float damage = 10;
    
    private void OnTriggerEnter(Collider collision)
    {
        print("---------------------------------------------");
        print(collision.tag +" has entered the Radius of " +tag );
        string otherTag = collision.tag;
        Stats stats = collision.GetComponentInParent<Stats>();
        if (stats != null)
        {
            print("stats are not NULL");
            print("calling Takedamage on "+ collision.tag);
            stats.TakeDamage(damage, tag);
        }
        print("---------------------------------------------");
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float healthlevel = 10;
    public float maxHealth;
    public float presentHealth;
    
    string deathSoundPath = "event:/SFX/Global/Death Sound";

    private void Start()
    {
        maxHealth = HealthMultyplyer();
        presentHealth = maxHealth;
    }

    private float HealthMultyplyer()
    {
        // 1 level gives 30 health.
        // could be a curve
       return maxHealth = healthlevel * 3;
    }
    
    public void TakeDamage(float damage, string otherTag)
    {
        print("TakeDamage has been called from"+ otherTag +"on "+ tag);
        
        if (otherTag == "Player" || otherTag == "Enemy")
        {
            presentHealth -= damage;
        }

        if (tag == "Player" && presentHealth <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(deathSoundPath, GetComponent<Transform>().position);
            SceneManager.LoadScene("FlaviusPrototypeScene(DoNotModify)");
        }
        if (tag == "Enemy" && presentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}

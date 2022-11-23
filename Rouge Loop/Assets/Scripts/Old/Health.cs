using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    private float invincibilityTimer;

    private void Update()
    {
        health -= Time.deltaTime;
    }

    private void addHealth(float amount)
    {
        health += amount;
    }
    private void substractHealth(float amount)
    {
        health -= amount;
    }
}

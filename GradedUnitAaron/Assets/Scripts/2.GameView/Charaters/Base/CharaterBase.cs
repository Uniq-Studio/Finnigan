using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBase : MonoBehaviour
{
    #region Movement
    public float walkSpeed = 12;
    public float runSpeed = 24;
    public float jumpSpeed;
    public float jumpHeight;
    #endregion

    #region Stanima for running
    public float staminaMax;
    public float refillStaminaSpeed;
    #endregion

    #region Health
    public float healthCurrent = 100;
    public float healthMax = 100;
    public float refillHealth = 5;
    #endregion

    #region Attack
    public float attackDamage;
    public float attackDamageSpeed;
    #endregion

    #region Defence
    public float defence;
    public float defenceMax;
    #endregion

    public void TakeDamage(float damage)
    {
        healthCurrent -= (damage - defence);
    }

    public void AttackDamage(float otherHealth)
    {
        otherHealth -= attackDamage;
    }

    public void RegenerateHealth()
    {
        healthCurrent += refillHealth * Time.fixedDeltaTime;
    }
}

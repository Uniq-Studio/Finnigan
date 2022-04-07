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
    public float stamina;
    public float staminaMax;
    public float refillStamina;
    public float refillStaminaSpeed;
    #endregion

    #region Health
    public float health = 100;
    public float healthMax = 100;
    public float refillHealth = 5;
    public int refillHealthSpeed = 5;
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
        health -= (damage - defence);
    }

    public void AttackDamage(float otherHealth)
    {
        otherHealth -= attackDamage;
    }

    public IEnumerator Regenerate()
    {
        if (health < healthMax)
        {
            //Add health, with x amount of health
            //More can be earnt
            health += refillHealth;

            //Player cant go over max health
            if (health > healthMax)
            {
                health = healthMax;
            }
            //Waiting to do it again
            yield return new WaitForSeconds(refillHealthSpeed);
        }

        if (stamina < staminaMax)
        {
            //Add health, with x amount of stamina
            //More can be earnt
            stamina += refillStamina;

            //Player cant go over max stamina
            if (stamina > staminaMax)
            {
                stamina = staminaMax;
            }
            //Waiting to do it again
            yield return new WaitForSeconds(refillStaminaSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterBase : MonoBehaviour
{
    #region Movement
    public float walkSpeed = 12;
    public float runSpeed = 24;
    public float jumpSpeed;
    public float jumpHight;
    #endregion

    #region Stanima for running
    public float stanimaMax;
    public float refillStanimaSpeed;
    #endregion

    #region Health
    public float startHealth = 100;
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

    #region Reputation Worth
    public float reputationWorthMax;
    public float reputationWorthMin;
    #endregion

}

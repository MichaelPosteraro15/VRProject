using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour, IGameManager
{

    public ManagerStatus status { get; private set; }
    public int health { get; private set; }//salute effettiva
    public int maxHealth { get; private set; }//massima salute
    public int healthPackValue { get; private set; }
    public int barValueDamage { get; private set; }

    //inizializziamo gli elementi
    public void Startup()
    {
        Debug.Log("Player manager starting...");
        health = 5;
        maxHealth = 100;
        healthPackValue = 2;
        barValueDamage = maxHealth / health;
        status = ManagerStatus.Started;
    }


}
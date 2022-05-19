using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CASSE CHE CONTIENE LE COSTANTI PER GESTIRE GLI EVENTI tra event-->messenger<---listner
public class GameEvent : MonoBehaviour
{
    public const string ENEMY_HIT = "ENEMY_HIT";
    public const string SPEED_CHANGED = "SPEED_CHANGED";
    public static bool isPaused = false;
}

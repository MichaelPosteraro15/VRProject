using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon :MonoBehaviour
{

    public Transform cam;
    public Animator animator;

    //danno definiti nella classe weaponsDamage
    public float damage;
    //distanza da cui puo colpire l'arma
    public float distance;
    //impatto che ha l'arma con i rigidbody
    public float impact;

    //metodo che gestisce  il colpo
    public abstract void _shoot();
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private float life = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void react(float damage)
    {
        life = life-damage;
        if (life<0)
        { StartCoroutine(Die()); }
        else
        {
            Debug.Log("Colpito");
        }
    }

    private IEnumerator Die()
    {
        EnemyMovement enemy = GetComponent<EnemyMovement>();
        enemy.dieAnimation();
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    public void reactSleep()
    {
        StartCoroutine(Sleep()); 
        
    }

    private IEnumerator Sleep()
    {
        EnemyMovement enemy = GetComponent<EnemyMovement>();
        enemy.dieAnimation();
        yield return new WaitForSeconds(120f);
        enemy.wakeup();
    }
}

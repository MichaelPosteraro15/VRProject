using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    private GameObject _bullet;
    private EnemyMovement _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        _enemy.agent.speed = 0;
        _enemy.animator.SetBool("Shooting", true);
        _bullet = Instantiate(bulletPrefab) as GameObject;
        _bullet.transform.position = transform.position;

    }
}

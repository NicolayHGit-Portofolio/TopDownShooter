using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    public EnemyObject enemySettings;

    [SerializeField]
    float _minDist = 6f;

    [SerializeField]
    GameObject _target;

    Vector2 _movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = enemySettings.speed;
        _minDist = enemySettings.minDist;

        if (_target == null)
        {
            _target = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        if (_target == null || GameManager.gm.gameOver)
            return;

        Vector2 direction = (Vector2)_target.transform.position;
        Rotate(direction);
        direction -= rb.position;
        direction.Normalize();
        _movement = direction;        
    }

    void FixedUpdate()
    {
        if (_target == null || GameManager.gm.gameOver)
            return;

        float distance = Vector2.Distance(transform.position, _target.transform.position);
        if (distance > _minDist)
            Movement(_movement);
        else
            UseWeapon();
    }
}

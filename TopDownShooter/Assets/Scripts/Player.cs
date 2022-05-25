using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    public PlayerObject playerSettings;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = playerSettings.speed;
	}

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            UseWeapon();
        }
    }

    void FixedUpdate()
    {
        Movement(movement);
        Rotate(mousePos);
    }

}
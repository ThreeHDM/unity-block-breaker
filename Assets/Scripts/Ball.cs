﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //Configuration fields
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        //Calculamos la diferencia entre los vectores ( ball y paddle)
        paddleToBallVector = transform.position - paddle1.transform.position; // si no aclaro nada transform se refiere al Gameobject del script. En este caso Ball
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        
        LaunchOnMouseClick();

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //Excepto para el componente transform, debemos usar GetComponent para manipular otros componentes. Como por ej, rigidbody
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        //Creamos un vector que nos dice la posición actual del paddle
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //para acceder a un componente usamos la siguiente sintaxis
            GetComponent<AudioSource>().Play();
        }
        
    }
}

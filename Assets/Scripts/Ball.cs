using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //Configuration fields
    [SerializeField] Paddle paddle1;

    //State
    Vector2 paddleToBallVector;


    // Start is called before the first frame update
    void Start()
    {
        //Calculamos la diferencia entre los vectores ( ball y paddle)
        paddleToBallVector = transform.position - paddle1.transform.position; // si no aclaro nada transform se refiere al Gameobject del script. En este caso Ball
    }

    // Update is called once per frame
    void Update()
    {
        //Creamos un vector que nos dice la posición actual del paddle
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        
    }
}

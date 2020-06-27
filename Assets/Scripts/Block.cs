using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Creo el método que se dispara cuando hay una colisión. Lo dispara el Engine
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destruimos el game object. Podríamos destruir un asset o un component también. El segundo parametro es el tiempo (se le pasa un float)
        Destroy(gameObject);
    }
}

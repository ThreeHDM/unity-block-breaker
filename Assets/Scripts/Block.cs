using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    //Creo el método que se dispara cuando hay una colisión. Lo dispara el Engine
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Previo a destruir el objeto reproducimos el sonido de destrucción. Como primer param pasamos el clip, como segundo la position como vector. En este caso accedemos a la position de la camara para que todos los sonidos suenen en la camara. Si lo hicieramos en el objeto sonarían algunos lejos otros cerca.
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //Destruimos el game object. Podríamos destruir un asset o un component también. El segundo parametro es el tiempo (se le pasa un float)
        Destroy(gameObject);
    }
}

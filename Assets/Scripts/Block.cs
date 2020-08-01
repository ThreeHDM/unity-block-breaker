using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Block : MonoBehaviour
{

    //Config Params
    [SerializeField] AudioClip breakSound = default;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites; //creamos un array para los sprites

    //Chached reference
    Level level;

    //State variables
    [SerializeField] int timesHit; // Only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        //FindObjectOfType looks for the class we pass inside the angle brackets.
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    //Creo el método que se dispara cuando hay una colisión. Lo dispara el Engine
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++; // Incrementamos la cantidad veces que fue golpeado

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; //llamamos al componente getcomponent del block
    }

    private void DestroyBlock()
    {
        PlayBlockDestroyedSFX();

        //Destruimos el game object. Podríamos destruir un asset o un component también. El segundo parametro es el tiempo (se le pasa un float)
        Destroy(gameObject);

        level.BlockDestroyed();

        //Llamamos al método que ejecuta el efecto visual
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroyedSFX()
    {
        //Traemos el objeto GameStatus (instanciamos) y llamamos al método
        FindObjectOfType<GameSession>().AddToScore();

        //Previo a destruir el objeto reproducimos el sonido de destrucción. Como primer param pasamos el clip, como segundo la position como vector. En este caso accedemos a la position de la camara para que todos los sonidos suenen en la camara. Si lo hicieramos en el objeto sonarían algunos lejos otros cerca.
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        //Instanciar un objecto con instanciate. Esto ocurre al ejecutar el juego.
        //una de las opciones es pasar la position del objeto y otra la rotación. Hay más opciones Ver docs de Unity
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        //Destruimos el objeto VFX - el segundo param es tiempo se pasa como float. Los float lleva una f en C#
        Destroy(sparkles, 1f);
    }
}

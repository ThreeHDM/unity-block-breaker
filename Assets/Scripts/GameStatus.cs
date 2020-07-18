﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //Creo un campo en la UI de Unity con un valor predeterminado para la velocidad del juego. Además le agrego [Range] lo que transforma a la UI en un slider entre el min y el max
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
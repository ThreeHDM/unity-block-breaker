using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Llamamos a TMPro
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Configuration parameters -----------------------------
    //Creo un campo en la UI de Unity con un valor predeterminado para la velocidad del juego. Además le agrego [Range] lo que transforma a la UI en un slider entre el min y el max
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    //Creamos un campo serializado para scoreText usando TextMeshProUGUI. En ese campo vinculamos el ScoreText GameObject
    [SerializeField] TextMeshProUGUI scoreText;

    //State variables
    [SerializeField] int currentScore = 0; // inicializamos el score en 0

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}

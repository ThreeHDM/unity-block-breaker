using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Llamamos a TMPro
using TMPro;

public class GameSession : MonoBehaviour
{
    //Configuration parameters -----------------------------
    //Creo un campo en la UI de Unity con un valor predeterminado para la velocidad del juego. Además le agrego [Range] lo que transforma a la UI en un slider entre el min y el max
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    //Creamos un campo serializado para scoreText usando TextMeshProUGUI. En ese campo vinculamos el ScoreText GameObject
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //State variables
    [SerializeField] int currentScore = 0; // inicializamos el score en 0

    //El métdo Awake es el primero que se ejecuta. En este caso lo utilizamos para saber si ya existe un objeto gameStatus que venga de otra Scene. Si es así destruímos el objeto en el que estamos, sino lo conservamos.
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        if(gameStatusCount > 1)
        {
            //Bugfix de singleton
            gameObject.SetActive(false);
            Destroy(gameObject);
        } 
        else
        {
            //Conserva el objeto a pesar de que se cargue otra escena (al hacer load).
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//agregamos el namespace SceneManagement para usar todo su contenido
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        //declaramos una variable que trainga el índice actual de la escena usando SceneManager class
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Cargamos la siguiente escena a la que estamos
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

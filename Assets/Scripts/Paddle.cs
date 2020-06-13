using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float ScreenWidthUnits = 16f; //Los numeros de tipo float deben tener una f

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Buscamos la posición en cada eje (x,y) por frame. Calculamos la proporcion con el ancho de la pantalla. Hay 16 unidades de ancho por lo que multiplicamos por ese número.
        //Debug.Log(Input.mousePosition.x / Screen.width * ScreenWidthUnits);
        float mousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthUnits;
        //Creamos un vector2 (2D) para guardar las coordenadas.
        // esto es type varname = new Object
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        //Definimos la pos x de paddlePos para limitar al paddle en los extremos de la pantalla usando Mathf.Clamp que setea el min y el máx
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        //Seteamos la posición del GameObject refiriendonos al componente transform y a la propiedad position
        transform.position = paddlePos;

    }
}

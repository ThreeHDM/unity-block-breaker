using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Los numeros de tipo float deben tener una f
    [SerializeField] float ScreenWidthUnits = 16f;

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
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        //Seteamos la posición del GameObject refiriendonos al componente transform y a la propiedad position
        transform.position = paddlePos;

    }
}

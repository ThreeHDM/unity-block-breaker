using UnityEngine;

public class Ball : MonoBehaviour
{

    //Configuration fields
    [SerializeField] Paddle paddle1 = default; //Se agrega esta palabra reservada 'default' para solucionar warning Warning CS0649: Field 'Ball.paddle1' is never assigned to, and will always have its default value null (CS0649)
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds = default;
    [SerializeField] float randmoFactor = 0.2f;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    


    // Start is called before the first frame update
    void Start()
    {
        //Calculamos la diferencia entre los vectores ( ball y paddle)
        paddleToBallVector = transform.position - paddle1.transform.position; // si no aclaro nada transform se refiere al Gameobject del script. En este caso Ball

        myAudioSource = GetComponent<AudioSource>(); //para acceder a un componente usamos esta sintaxis
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }
        
        LaunchOnMouseClick();

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            //Reemplazamos la sintaxis anterior (la dejo comentada) ya que ahora traemos el componente RigidBody2D
            myRigidBody2D.velocity = new Vector2(xPush, yPush);

            //Excepto para el componente transform, debemos usar GetComponent para manipular otros componentes. Como por ej, rigidbody
            //GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        //Creamos un vector que nos dice la posición actual del paddle
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (
                Random.Range(0f, randmoFactor),
                Random.Range(0f, randmoFactor)
            );

        if (hasStarted)
        {
            //hacemos random el sonido y lo almacenamos en clip
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip); // play one shot no se detiene cuando suena otro clip y se le pasa como param el clip
            myRigidBody2D.velocity += velocityTweak;
        }
        
    }
}

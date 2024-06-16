using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5.0f;  // Velocidad inicial de la pelota
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Asignar una velocidad inicial a la pelota
        rb.velocity = new Vector2(initialSpeed, initialSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Aquí puedes manejar lo que sucede cuando la pelota colisiona con otros objetos
        // Por ejemplo, puedes añadir lógica para rebotes personalizados si es necesario
    }
}

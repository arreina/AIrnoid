using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // Velocidad constante de la pelota
    private Rigidbody2D rb;
    public Transform respawnPoint; // Punto de reinicio para la pelota
    public float minYPosition = -5f; // Posición mínima Y antes de reiniciar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void Update()
    {
        // Reiniciar la pelota si sale del área de juego
        if (transform.position.y < minYPosition)
        {
            RespawnBall();
        }
    }

    void LaunchBall()
    {
        // Dar a la pelota una dirección inicial hacia arriba y un poco a la derecha
        rb.velocity = new Vector2(1, 1).normalized * speed;
    }

    void RespawnBall()
    {
        // Reiniciar la posición de la pelota y lanzar de nuevo
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero;
        LaunchBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Calcular el punto de contacto relativo en la raqueta
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            // Crear una nueva dirección basada en el punto de contacto
            Vector2 dir = new Vector2(x, 1).normalized;

            // Ajustar la velocidad de la pelota
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            // Ignorar la física realista y controlar manualmente el rebote
            Vector2 velocity = rb.velocity;

            // Establecer un ángulo fijo de salida para el rebote
            float reboundAngle = 45f; // Ángulo de 45 grados como ejemplo
            Vector2 reboundDirection = new Vector2(Mathf.Cos(reboundAngle * Mathf.Deg2Rad), Mathf.Sin(reboundAngle * Mathf.Deg2Rad)).normalized;

            // Ajustar la dirección de la pelota basada en el ángulo fijo
            rb.velocity = reboundDirection * speed;
        }
    }


    // Calcular el punto de contacto relativo en la raqueta
    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        // Devuelve un valor entre -1 y 1
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }
}

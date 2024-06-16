using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // Velocidad constante de la pelota
    private Rigidbody2D rb;
    public Transform respawnPoint; // Punto de reinicio para la pelota
    public float minYPosition = -5f; // Posici�n m�nima Y antes de reiniciar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void Update()
    {
        // Reiniciar la pelota si sale del �rea de juego
        if (transform.position.y < minYPosition)
        {
            RespawnBall();
        }
    }

    void LaunchBall()
    {
        // Dar a la pelota una direcci�n inicial hacia arriba y un poco a la derecha
        rb.velocity = new Vector2(1, 1).normalized * speed;
    }

    void RespawnBall()
    {
        // Reiniciar la posici�n de la pelota y lanzar de nuevo
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

            // Crear una nueva direcci�n basada en el punto de contacto
            Vector2 dir = new Vector2(x, 1).normalized;

            // Ajustar la velocidad de la pelota
            rb.velocity = dir * speed;
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            // Ignorar la f�sica realista y controlar manualmente el rebote
            Vector2 velocity = rb.velocity;

            // Establecer un �ngulo fijo de salida para el rebote
            float reboundAngle = 45f; // �ngulo de 45 grados como ejemplo
            Vector2 reboundDirection = new Vector2(Mathf.Cos(reboundAngle * Mathf.Deg2Rad), Mathf.Sin(reboundAngle * Mathf.Deg2Rad)).normalized;

            // Ajustar la direcci�n de la pelota basada en el �ngulo fijo
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

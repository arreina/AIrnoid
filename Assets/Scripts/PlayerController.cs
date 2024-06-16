using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;  // Velocidad de movimiento de la raqueta
    public float boundary = 8.0f;  // Limite horizontal de movimiento de la raqueta

    void Update()
    {
        // Obtener el movimiento horizontal del jugador
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Calcular la nueva posición de la raqueta
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        // Limitar la posición de la raqueta dentro de los límites de la pantalla
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        // Aplicar la nueva posición a la raqueta
        transform.position = newPosition;
    }
}

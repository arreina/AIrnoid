using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;  // Velocidad de movimiento de la raqueta
    public float boundary = 8.0f;  // Limite horizontal de movimiento de la raqueta

    void Update()
    {
        // Obtener el movimiento horizontal del jugador
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Calcular la nueva posici�n de la raqueta
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);

        // Limitar la posici�n de la raqueta dentro de los l�mites de la pantalla
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);

        // Aplicar la nueva posici�n a la raqueta
        transform.position = newPosition;
    }
}

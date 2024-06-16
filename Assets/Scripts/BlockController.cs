using UnityEngine;

public class BlockController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destruir el bloque
            Destroy(gameObject);
        }
    }
}

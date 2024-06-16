using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.03f, 0.97f); // Clamping horizontalmente entre 0.03 y 0.97 para evitar que la bola se pierda
        viewPos.y = Mathf.Clamp(viewPos.y, 0.03f, 0.97f); // Clamping verticalmente entre 0.03 y 0.97 para evitar que la bola se pierda
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}

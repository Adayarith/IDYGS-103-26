using UnityEngine;

public class ControlTiro : MonoBehaviour
{
    public float fuerzaLanzamiento = 12f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si la bola está detenida y haces clic izquierdo, aplica un impulso
        if (rb.linearVelocity.magnitude < 0.05f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 direccionTiro = new Vector2(1f, 0.3f).normalized;
                rb.AddForce(direccionTiro * fuerzaLanzamiento, ForceMode2D.Impulse);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class FigurasAzules : MonoBehaviour
{
    public float velocidad = 4f;
    private Vector2 direccionMovimiento;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        float x = Random.Range(-1f, 1f) > 0f ? 1f : -1f;
        float y = Random.Range(-1f, 1f) > 0f ? 1f : -1f;
        direccionMovimiento = new Vector2(x, y).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = direccionMovimiento * velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Vector2 normal = collision.contacts[0].normal;
            direccionMovimiento = Vector2.Reflect(direccionMovimiento, normal).normalized;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            MovimientoPlayer player = collision.gameObject.GetComponent<MovimientoPlayer>();

            if (player != null && !player.enZonaSegura)
            {
                Debug.Log("¡Tocado fuera de la zona segura! Reiniciando juego...");
                ReiniciarJuego();
            }
            else
            {
                Debug.Log("El jugador está a salvo en la zona segura.");
            }
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
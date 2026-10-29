using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector2 direccionActual = Vector2.right; // Empieza moviéndose a la derecha por defecto
    [HideInInspector] public bool enZonaSegura = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direccionActual = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direccionActual = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direccionActual = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direccionActual = Vector2.right;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccionActual * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaSegura"))
        {
            enZonaSegura = true;
            Debug.Log("Jugador en Zona Segura");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaSegura"))
        {
            enZonaSegura = false;
            Debug.Log("Jugador salió de la Zona Segura");
        }
    }
}
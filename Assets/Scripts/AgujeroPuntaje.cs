using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena
using TMPro;

public class AgujeroPuntaje : MonoBehaviour
{
    public static int puntosRojas = 0;
    public static int puntosAzules = 0;

    [Header("Condición de Victoria")]
    public int metaParaGanar = 3; // Número de bolas necesarias para ganar y reiniciar

    private static TextMeshProUGUI textoMarcadorGlobal;

    void Start()
    {
        if (textoMarcadorGlobal == null)
        {
            GameObject objTexto = GameObject.Find("TextoMarcador");
            if (objTexto != null)
            {
                textoMarcadorGlobal = objTexto.GetComponent<TextMeshProUGUI>();
            }
        }
        ActualizarUI();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Si cae la bola blanca, regresa al centro
        if (collision.CompareTag("PelotaBlanca") || collision.name.Contains("BolaBlanca"))
        {
            collision.transform.position = Vector3.zero;
            Rigidbody2D rbB = collision.GetComponent<Rigidbody2D>();
            if (rbB != null)
            {
                rbB.linearVelocity = Vector2.zero;
                rbB.angularVelocity = 0f;
            }
        }
        // 2. Si cae una bola de color (Roja o Azul)
        else if (collision.CompareTag("BolaColor") || collision.name.Contains("Roja") || collision.name.Contains("Azul"))
        {
            if (collision.name.Contains("Roja"))
            {
                puntosRojas++;
            }
            else if (collision.name.Contains("Azul"))
            {
                puntosAzules++;
            }

            ActualizarUI();
            Destroy(collision.gameObject);

            // 3. Verificar si algún jugador alcanzó la meta para reiniciar
            if (puntosRojas >= metaParaGanar || puntosAzules >= metaParaGanar)
            {
                ReiniciarJuego();
            }
        }
    }

    void ActualizarUI()
    {
        if (textoMarcadorGlobal != null)
        {
            textoMarcadorGlobal.text = "Rojas: " + puntosRojas + "     Azules: " + puntosAzules;
        }
    }

    void ReiniciarJuego()
    {
        // Reiniciamos los contadores estáticos antes de recargar la escena
        puntosRojas = 0;
        puntosAzules = 0;

        // Recarga la escena actual desde cero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
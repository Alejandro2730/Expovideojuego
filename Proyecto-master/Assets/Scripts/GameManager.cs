using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TEXTOS
    public Text txtTutorial;
    
    // TXT ATRIBUTOS
    public float tiempoEnPantalla = 3f;
    public float tiempoEnEscena = 0f;
    public float tiempoDesvanecimiento = 1f;

    string tiempoEscenaAnteriorKey;

    string [] textos = new string[]{
        "Aquí tenemos el inicio del tutorial",
        "Nuevo Texto1",
        "Nuevo Texto2"
    };

    //VARIABLES DINÁMICAS
    Player1Controller player1;
    Player2Controller player2;
    int cont;
    int vidita;
    int vidita2;
    int balas;
    int cant;
    int gemas;
    int mividita;
    public int vidas;

    private string tiempoTranscurridoPath = "Assets/TiempoTranscurrido.txt"; // Ruta del archivo de texto
    
    void Start()
    {
        player1 = FindObjectOfType<Player1Controller>();
        player2 = FindObjectOfType<Player2Controller>();
        cont = 0;
        vidita = 1;
        vidita2 = 1;
        balas = 50;
        cant = 0;
        vidas = 1;
        gemas = 0;
        mividita = 10;

        StartCoroutine(MostrarTextoRoutine(textos));
        CargarTiempoTranscurrido(); // Cargar el tiempo al iniciar la escena
    }

    void OnDestroy()
    {
        GuardarTiempoTranscurrido();
    }

    void Update()
    {
        tiempoEnEscena += Time.deltaTime;
        Debug.Log("Tiempo transcurrido: " + tiempoEnEscena);
    }

    void GuardarTiempoTranscurrido()
    {
        // Crea o abre el archivo de texto
        StreamWriter writer = new StreamWriter(tiempoTranscurridoPath);

        // Escribe el tiempo transcurrido en el archivo
        writer.WriteLine(tiempoEnEscena.ToString());

        // Cierra el archivo
        writer.Close();
    }

    public void CargarTiempoTranscurrido()
    {
        // Verifica si el archivo existe
        if (File.Exists(tiempoTranscurridoPath))
        {
            // Lee el contenido del archivo
            string tiempoTranscurridoString = File.ReadAllText(tiempoTranscurridoPath);

            // Convierte el tiempo transcurrido de cadena a flotante
            if (float.TryParse(tiempoTranscurridoString, out float tiempoGuardado))
            {
                // Asigna el tiempo guardado al tiempo en escena
                tiempoEnEscena = tiempoGuardado;
                Debug.Log("Tiempo cargado: " + tiempoEnEscena);
            }
            else
            {
                Debug.LogWarning("No se pudo convertir el tiempo transcurrido guardado en un valor flotante.");
            }
        }
        else
        {
            Debug.Log("No se encontró el archivo de tiempo transcurrido.");
        }
    }

    public int Cont()
    {
        return cont;
    }
    public int Vidita()
    {
        return vidita;
    }
    public int Vidita2()
    {
        return vidita2;
    }
    public int Balas()
    {
        return balas;
    }
    public int Cantidad()
    {
        return cant;
    }
    public int Vidas()
    {
        return vidas;
    }
    public int Gemas()
    {
        return gemas;
    }
    public int Medusa()
    {
        return mividita;
    }
    public void SumaMonedas()
    {
        cont++;
    }
    public void RestarVidaMedusa(int menos)
    {
        mividita -= menos;
    }
    public void RestaVida()
    {
        vidita--;
    }
    public void RestaVida2()
    {
        vidita2--;
    }
    public void MenosBalas(int resta)
    {
        balas -= resta;
    }
    public void MasBalas(int suma)
    {
        balas += suma;
    }
    public void CantZombie()
    {
        cant++;
    }
    public void RestaVidaZombie(int menos)
    {
        vidas -= menos;
    }
    public void SumarGemas()
    {
        gemas++;
    }

    IEnumerator MostrarTextoRoutine(string[] txt)
    {
        foreach(string texto in txt)
        {
            txtTutorial.text = texto;
            txtTutorial.CrossFadeAlpha(1f, tiempoDesvanecimiento, false);

            yield return new WaitForSeconds(tiempoEnPantalla);

            txtTutorial.CrossFadeAlpha(0f, tiempoDesvanecimiento / 2f, false);

            yield return new WaitForSeconds(tiempoDesvanecimiento / 2f);
        }

        // Guardar el tiempo transcurrido al final de la secuencia de texto
        GuardarTiempoTranscurrido();
    }
}
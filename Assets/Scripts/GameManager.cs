using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text respuestaText;
    public Text puntajeText;
    public List<Text> puntajesEnemigosTexts;


    List<Pregunta> preguntas;
    int preguntaActual;
    bool finalizado;
    bool habilitarClick;
    public float puntajeTotal;
    List<float> puntajesEnemigos;
    const int NUM_ENEMIGOS = 3;
    public int puestoFinal;

    private static System.Random rand = new System.Random();

    void Awake()
    {
        DontDestroyOnLoad(this);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        puntajesEnemigos = new List<float>();
        for (int i = 0; i < NUM_ENEMIGOS; ++i){
            puntajesEnemigos.Add(0f);
        }

        // * Para agregar una pregunta, debe tener exactamente 6 guiones bajos en cada puesto.
        Pregunta[] prs = {
            new Pregunta("El personaje tendra que correr a traves de ______ y esquivar ______", 2),
            new Pregunta("El jugador puede ahorrar para mejorar su ______", 1),
            new Pregunta("Si el personaje consume ______, podra ______", 2),
            new Pregunta("La debilidad del villano es ______", 1)
        };
        preguntas = new List<Pregunta>(prs);
        preguntaActual = 0;
        finalizado = false;
        ActualizarText();
        habilitarClick = true;
        puntajeTotal = 0;
        puestoFinal = 0;
    }

    public void RecibirRespuesta(Respuesta respuesta){
        habilitarClick = false;
        puntajeTotal += respuesta.puntaje;
        for (int i = 0; i < NUM_ENEMIGOS; ++i){
            puntajesEnemigos[i] += Random.Range(10,25);
        }
        preguntas[preguntaActual].AgregarRespuesta(respuesta);
        if (preguntas[preguntaActual].EstaCompleta()){
            if (preguntaActual == preguntas.Count - 1){
                FinDelJuego();
            }else{
                preguntaActual++;
            }
        }
        ActualizarText();
        habilitarClick = true;
    }

    public void NotificarMovimiento(){
        habilitarClick = false;
    }

    void ActualizarText(){
        respuestaText.text = preguntas[preguntaActual].pregunta;
        puntajeText.text = $"Puntos: {puntajeTotal}";
        for (int i = 0; i < NUM_ENEMIGOS; ++i){
            puntajesEnemigosTexts[i].text = $"Puntaje: {puntajesEnemigos[i]}";
        }
    }

    Pregunta DarPreguntaActual(){
        return preguntas[preguntaActual];
    }

    void FinDelJuego(){
        finalizado = true;
        print("Fin del juego");
        CalcularPuesto();
        SceneManager.LoadScene("FinDeJuego");
    }

    void CalcularPuesto(){
        puestoFinal = 1;
        for(int i = 0; i < NUM_ENEMIGOS; ++i){
            if (puntajeTotal < puntajesEnemigos[i]) ++puestoFinal;
        }
    }

    public bool SePuedeOprimirBoton(){
        return habilitarClick && !finalizado;
    }

    public bool HaGanado(){
        return puestoFinal == 1;
    }

}

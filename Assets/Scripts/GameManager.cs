using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text respuestaText;
    List<Pregunta> preguntas;
    int preguntaActual;
    bool finalizado;
    bool habilitarClick;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Pregunta[] prs = {
            new Pregunta("El personaje tendrá que correr a través de ______ y esquivar ______", 2),
            new Pregunta("El jugador puede ahorrar para mejorar su ______", 1)
        };
        preguntas = new List<Pregunta>(prs);
        preguntaActual = 0;
        finalizado = false;
        ActualizarText();
        habilitarClick = true;
    }

    public void RecibirRespuesta(string respuesta){
        habilitarClick = false;
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

    void ActualizarText(){
        respuestaText.text = preguntas[preguntaActual].pregunta;
    }

    Pregunta DarPreguntaActual(){
        return preguntas[preguntaActual];
    }

    void FinDelJuego(){
        finalizado = true;
        print("Fin del juego");
    }

    public bool SePuedeOprimirBoton(){
        return habilitarClick && !finalizado;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

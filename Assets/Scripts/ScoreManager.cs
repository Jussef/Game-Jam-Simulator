using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public AudioSource loser;
    public AudioSource winer;

    public Text textEstatusFinJuego,
                textNombreGameJam,
                textTema,
                textMainPage,
                textSubPage,
                textBottomPage;

    int preguntaActual;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        preguntaActual = 0;
        if (GameManager.instance){
            GameManager gameManager = GameManager.instance;
            bool gano = gameManager.HaGanado();
            string estatus = gano ? "¡Has Ganado!" : "Perdiste :C";
            textEstatusFinJuego.text = $"{estatus}\nHas quedado en el puesto {gameManager.puestoFinal}";
            textMainPage.text = $"Ronda 1 - Obtuviste {gameManager.puntajeTotal} puntos";
            //textSubPage.text = $"lol";
            textBottomPage.text = gano ? "¡Felicidades ganando en esta gamejam!" : "¡Mejor suerte para la próxima!";
            updateSubText();
            //Destroy(gameManager.gameObject);
        if (gano)
        {
            winer.Play();
            print(gano);
        }
        else
        {
            loser.Play();
            print(gano);
        }
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        if (GameManager.instance){
            Destroy(GameManager.instance.gameObject);
            ScoreManager.instance = null;
        }
    }

    public void flechaIzquierda(){
        if (GameManager.instance){
            int sz = GameManager.instance.numeroPreguntas();
            preguntaActual = (preguntaActual + sz-1) % sz; // * hack para restar un elemento y dar la vuelta
            updateSubText();
        }
    }

    public void flechaDerecha(){
        print("fdfd");
        if (GameManager.instance){
            
            int sz = GameManager.instance.numeroPreguntas();
            print($"dfdf {sz} preguntas");
            preguntaActual = (preguntaActual + 1) % sz;
            updateSubText();
        }
    }

    public void updateSubText(){
        if (GameManager.instance){
            Pregunta pregunta = GameManager.instance.obtenerPregunta(preguntaActual);
            textSubPage.text = pregunta.pregunta;
        }
        
    }
}

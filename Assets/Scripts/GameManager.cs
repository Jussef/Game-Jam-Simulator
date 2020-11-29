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

    private static List<Pregunta> archivoDePreguntas = new List<Pregunta>(new Pregunta[]{
            new Pregunta("El personaje tendra que correr a traves de ______ y esquivar ______", 2),
            new Pregunta("El jugador puede ahorrar para mejorar su ______", 1),
            new Pregunta("Si el personaje consume ______, podra destruir ______", 2),
            new Pregunta("La debilidad del villano es ______", 1)
            ,new Pregunta("Para curarse tendra que tomar ______",1)
            ,new Pregunta("La moneda del juego son ______",1)
            ,new Pregunta("En el multijugador pelearan para saber quien es el mejor ______",1)
            ,new Pregunta("Romper un ______ te dara ______ extra",2)
            ,new Pregunta("Beber ______ te hace inmortal",1)
            ,new Pregunta("El enemigo final es un ______ que dispara ______",2)
            ,new Pregunta("La debilidad del villano es ______",1)
            ,new Pregunta("Si destruyes el ______ desbloquearas a ______",2)
            
            ,new Pregunta("Tocar a ______ te matara",1)
            ,new Pregunta("Si usas el cheat Mofongos, invocaras un ______ que come ______",2)
            //,new Pregunta("Gracias a ______, ______ puede ______",3)
            ,new Pregunta("Hay un nivel secreto en el que utilizaras a ______ montando un ______",2)
            ,new Pregunta("En este juego no hay puntos, solo hay ______",1)
            ,new Pregunta("Puedes mezclar 2 ______ y 3 ______ para obtener un ______",3)
            ,new Pregunta("En el DLC hay un cameo especial de ______",1)
            ,new Pregunta("¿Cual seria el super poder? ______",1)
            ,new Pregunta("Si combinas ______ y ______ pasa al siguiente nivel inmediatamente.",2)
        });
    List<Pregunta> preguntas;
    int preguntaActual;
    bool finalizado;
    bool habilitarClick;
    public float puntajeTotal;
    List<float> puntajesEnemigos;
    const int NUM_ENEMIGOS = 3;
    public int puestoFinal;

    AudioSource audioSource;

    private static System.Random rand = new System.Random();

    void Awake()
    {
        DontDestroyOnLoad(this);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        puntajesEnemigos = new List<float>();
        for (int i = 0; i < NUM_ENEMIGOS; ++i){
            puntajesEnemigos.Add(0f);
        }

        // * Para agregar una pregunta, debe tener exactamente 6 guiones bajos en cada puesto.
        
        preguntas = SeleccionarNAleatorios(5);
        preguntaActual = 0;
        finalizado = false;
        ActualizarText();
        habilitarClick = true;
        puntajeTotal = 0;
        puestoFinal = 0;
    }

    public void RecibirRespuesta(Respuesta respuesta){
        //sonarExplosion();
        habilitarClick = false;
        puntajeTotal += respuesta.puntaje;
        for (int i = 0; i < NUM_ENEMIGOS; ++i){
            puntajesEnemigos[i] += Random.Range(1,8) * 5;
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

    public void sonarExplosion(){
        audioSource.Play();
    }

    public Pregunta obtenerPregunta(int i){
        return preguntas[i];
    }

    public int numeroPreguntas(){
        return preguntas.Count;
    }

    List<Pregunta> SeleccionarNAleatorios(int n){
        int sz = archivoDePreguntas.Count;
        int restantes = n;
        List<Pregunta> lista2 = new List<Pregunta>();
        for(int i = 0; i < sz && restantes > 0; ++i){
            if (Random.Range(i,sz-1) >= sz-restantes){
                lista2.Add(archivoDePreguntas[i]);
                --restantes;
            }
        }
        return lista2;
    }

    public static void Reiniciar(){
        foreach(Pregunta p in archivoDePreguntas){
            p.Reiniciar();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text textEstatusFinJuego,
                textNombreGameJam,
                textTema,
                textMainPage,
                textSubPage,
                textBottomPage;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (GameManager.instance){
            GameManager gameManager = GameManager.instance;
            bool gano = gameManager.HaGanado();
            string estatus = gano ? "¡Has Ganado!" : "Perdiste :C";
            textEstatusFinJuego.text = $"{estatus}\nHas quedado en el puesto {gameManager.puestoFinal}";
            textMainPage.text = $"Ronda 1 - Obtuviste {gameManager.puntajeTotal} puntos";
            //textSubPage.text = $"lol";
            textBottomPage.text = gano ? "¡Felicidades ganando en esta gamejam!" : "¡Mejor suerte para la próxima!";
            Destroy(gameManager.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

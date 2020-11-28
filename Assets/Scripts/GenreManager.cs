using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenreManager : MonoBehaviour
{
    public static GenreManager instance;
    static List<string> generos = new List<string>{
        "Homenaje",
        "Zelda",
        "RPG",
        "Aventura",
        "Deportes",
        "Accion",
        "Comida",
        "Musical",
        "Animales",
        "Jammer"
    };

    List<string> generosSeleccionados;

    public List<GameObject> objGeneros;

    [HideInInspector]
    public string generoElegido;

    void Awake(){
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        generoElegido = null;
        generosSeleccionados = SeleccionarNAleatorios(objGeneros.Count);
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateText(){
        for (int i = 0; i < generosSeleccionados.Count; ++i){
            string genero = generosSeleccionados[i];
            var objeto = objGeneros[i];
            objeto.GetComponent<BotonGenero>().PonerTexto(genero);
        }
    }

    List<string> SeleccionarNAleatorios(int n){
        int sz = generos.Count;
        int restantes = n;
        List<string> lista2 = new List<string>();
        for(int i = 0; i < sz && restantes > 0; ++i){
            if (Random.Range(i,sz-1) >= sz-restantes){
                lista2.Add(generos[i]);
                --restantes;
            }
        }
        return lista2;
    }

    public void ElegirGenero(string genero){
        generoElegido = genero;
        SceneManager.LoadScene("Partida");
    }
}

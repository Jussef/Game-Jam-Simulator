using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;
using UnityEngine.UI;

public class ClickWord : MonoBehaviour
{
    static Respuesta[] palabras = {
        new Respuesta("Anime",30),
        new Respuesta("Camioneta",25),
        new Respuesta("Bailar",20), 
        new Respuesta("Grito",25), 
        new Respuesta("Alegría",20), 
        new Respuesta("Ego",10),
        new Respuesta("Banderas",20), 
        new Respuesta("Trampas",30), 
        new Respuesta("Mario",15), 
        new Respuesta("Sigilo",15), 
        new Respuesta("Dinero",10), 
        new Respuesta("Rancho",20), 
        new Respuesta("Disco",20), 
        new Respuesta("Batman",20), 
        new Respuesta("Medallas",10), 
        new Respuesta("Impacto",20), 
        new Respuesta("Clonar",30), 
        new Respuesta("Heroe",10), 
        new Respuesta("Peluche",20), 
        new Respuesta("Deportes",15), 
        new Respuesta("Bambu",30)
    };
    static System.Random rand  = new System.Random();
    Transform transform;
    Text texto;
    Vector2 destino = new Vector2(100,200);
    Vector2 velocidad;
    Respuesta palabraAsignada;
    bool moverse;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        texto = transform.GetChild(0).gameObject.GetComponent<Text>();
        ObtenerPalabraNueva();
        
    }

    public void EnviarMensajeAlGameManager(){
        GameManager.instance.RecibirRespuesta(palabraAsignada);
        ObtenerPalabraNueva();
        //Destroy(gameObject);
    }

    void ObtenerPalabraNueva(){
        int i = rand.Next(palabras.Length);
        palabraAsignada = palabras[i];
        texto.text = palabraAsignada.respuesta;
    }

    public Vector2 Vector3To2(Vector3 vec3){
        return new Vector2(vec3.x,vec3.y);
    }
}

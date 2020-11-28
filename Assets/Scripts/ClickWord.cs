using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;
using UnityEngine.UI;

public class ClickWord : MonoBehaviour
{
    static Respuesta[] palabras = {
        new Respuesta("Anime",30),
        new Respuesta("Camioneta",45),
        new Respuesta("Bailar",20), 
        new Respuesta("Grito",25), 
        new Respuesta("Alegría",20), 
        new Respuesta("Ego",10),
        new Respuesta("Bandera",20), 
        new Respuesta("Trampas",30), 
        new Respuesta("Mario",20), 
        new Respuesta("Sigilo",20), 
        new Respuesta("Dinero",10), 
        new Respuesta("Rancho",20)
    };
    static System.Random rand  = new System.Random();
    Transform transform;
    Text texto;
    Respuesta palabraAsignada;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        texto = transform.GetChild(0).gameObject.GetComponent<Text>();
        int i = rand.Next(palabras.Length);
        palabraAsignada = palabras[i];

        texto.text = palabraAsignada.respuesta;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void Click(){
        GameManager.instance.RecibirRespuesta(palabraAsignada);
        Destroy(gameObject);
    }
}

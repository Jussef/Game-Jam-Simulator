using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;
using UnityEngine.UI;

public class ClickWord : MonoBehaviour
{
    static string[] palabras = {"Anime","Camioneta", "Bailar", "Grito", "Alegría", "Ego",
        "Bandera", "Trampas", "Mario", "Sigilo", "Dinero", "Rancho"};
    static System.Random rand  = new System.Random();
    Transform transform;
    Text texto;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        texto = transform.GetChild(0).gameObject.GetComponent<Text>();
        int i = rand.Next(palabras.Length);
        texto.text = palabras[i];
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void Click(){
        GameManager.instance.RecibirRespuesta(texto.text);
        print("aaaaa");
        Destroy(gameObject);
    }
}

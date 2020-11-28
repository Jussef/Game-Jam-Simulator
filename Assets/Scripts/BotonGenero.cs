using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonGenero : MonoBehaviour
{
    Transform transform;
    Text txtGenero;
    string genero;
    // Start is called before the first frame update
    void Start()
    {
        transform =  GetComponent<Transform>();
        txtGenero = transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void PonerTexto(string texto){
        genero = texto;
        txtGenero.text = texto;
    }

    public void Click(){
        GenreManager.instance.ElegirGenero(genero);
    }
}

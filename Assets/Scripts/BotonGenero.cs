using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonGenero : MonoBehaviour
{
    Transform transform;
    Text txtGenero;
    // Start is called before the first frame update
    void Start()
    {
        transform =  GetComponent<Transform>();
        txtGenero = transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    public void PonerTexto(string texto){
        txtGenero.text = texto;
    }
}

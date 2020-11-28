using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterChose : MonoBehaviour, IPointerClickHandler
{
    public GameObject contador;
    public GameObject panel;
    [SerializeField] private List<GameObject> imagenes;
    [SerializeField] private List<GameObject> elegidos;

    private List<string> miembros = new List<string>() { "Programador", "Diseñador", "Musico" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnPointerClick(PointerEventData pointerEventData)
    {
        bool outline = gameObject.GetComponentInChildren<Outline>().enabled;
        gameObject.GetComponentInChildren<Outline>().enabled = !outline;

        if(gameObject.GetComponentInChildren<Outline>().enabled)
        {
            int iContador = int.Parse(contador.GetComponent<Text>().text);
            iContador++;
            if (iContador < 2)
                contador.GetComponent<Text>().text = iContador + "";
            else
            {
                panel.SetActive(true);
                int i = 0;
                foreach (GameObject imagen in imagenes)
                {
                    if (imagen.GetComponentInChildren<Outline>().enabled)
                    {
                        elegidos[i].GetComponent<Image>().sprite = imagen.GetComponent<Image>().sprite;
                        elegidos[i].transform.Find("Text").GetComponent<Text>().text = miembros[Random.Range(0, 2)];
                        i++;
                    }
                }
            }
        }
    }
}

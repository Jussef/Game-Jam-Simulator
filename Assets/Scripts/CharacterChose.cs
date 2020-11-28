using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterChose : MonoBehaviour, IPointerClickHandler
{
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
    }
}

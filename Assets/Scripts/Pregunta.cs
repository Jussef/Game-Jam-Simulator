using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta{
  public string pregunta;
  private string _preguntaOriginal;
  int espacios;
  List<Respuesta> respuestasElegidas;
  public Pregunta(string pregunta, int espacios){
    this.pregunta = pregunta;
    this._preguntaOriginal = pregunta;
    this.espacios = espacios;
    this.respuestasElegidas = new List<Respuesta>();
  }

  public void AgregarRespuesta(Respuesta respuesta){
    
    this.respuestasElegidas.Add(respuesta);
    int i = this.pregunta.IndexOf("______");
    this.pregunta = this.pregunta.Remove(i,6);
    this.pregunta = this.pregunta.Insert(i,respuesta.respuesta);
  }

  public void Reiniciar(){
    this.pregunta = _preguntaOriginal;
    this.respuestasElegidas.Clear();
  }

  public bool EstaCompleta(){
    return this.respuestasElegidas.Count == espacios;
  }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta{
  public string pregunta;
  private string _preguntaOriginal;
  int espacios;
  List<string> respuestasElegidas;
  public Pregunta(string pregunta, int espacios){
    this.pregunta = pregunta;
    this._preguntaOriginal = pregunta;
    this.espacios = espacios;
    this.respuestasElegidas = new List<string>();
  }

  public void AgregarRespuesta(string respuesta){
    this.respuestasElegidas.Add(respuesta);
    int i = this.pregunta.IndexOf("______");
    MonoBehaviour.print($"pregunta 1: {this.pregunta}");
    this.pregunta = this.pregunta.Remove(i,6);
    MonoBehaviour.print($"pregunta 2: {this.pregunta}");
    this.pregunta = this.pregunta.Insert(i,respuesta);
    MonoBehaviour.print($"pregunta 3: {this.pregunta}");
  }

  public void Reiniciar(){
    this.pregunta = _preguntaOriginal;
  }

  public bool EstaCompleta(){
    return this.respuestasElegidas.Count == espacios;
  }

}
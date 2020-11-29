using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;
using UnityEngine.UI;

public class AnimarBoton : MonoBehaviour
{
    Transform transform;
    Vector3 posicionInicial;
    Vector3 posicionLocalInicial;
    Quaternion rotacionInicial;
    Rigidbody2D rgb;
    Text texto;
    public Vector2 destino;
    Vector2 velocidad;
    bool moverse;
    public float aceleracionRotacion;
    public float velocidadMovimiento;
    public float numFramesMovimiento;
    public float numFramesAntelacionAudio;
    int vueltas;

    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        moverse = false;
        rgb = GetComponent<Rigidbody2D>();
        vueltas = 0;
        posicionLocalInicial = transform.localPosition;
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    public Vector2 Vector3To2(Vector3 vec3){
        return new Vector2(vec3.x,vec3.y);
    }

    void FixedUpdate(){
      if (moverse){
        rgb.angularVelocity -= aceleracionRotacion;
        ++vueltas;
        if (numFramesMovimiento - vueltas == numFramesAntelacionAudio){
          GameManager.instance.sonarExplosion();
        }
        if (vueltas >= numFramesMovimiento){
          Finalizar();
        }
      }
    }

    public void MoverseYGirar(){
      if(!moverse && GameManager.instance.SePuedeOprimirBoton()){
        GameManager.instance.NotificarMovimiento();
        moverse = true;
        velocidad = (destino - Vector3To2(transform.localPosition)) * velocidadMovimiento;
        rgb.velocity = velocidad;
      }
    }

    public void Finalizar(){
      moverse = false;
      rgb.velocity = new Vector3(0,0,0);
      rgb.angularVelocity = 0f;
      transform.localPosition = posicionLocalInicial;
      transform.position = posicionInicial;
      transform.rotation = rotacionInicial;
      vueltas = 0;
      GetComponent<ClickWord>().EnviarMensajeAlGameManager();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_enemy : MonoBehaviour
{
    public Transform posJugador;
    public float distancia = 2f;
    public float speed = 2f;
    
    public enum Comportamiento
    {
        seguir,
        mirar
    }
    public Comportamiento comportamiento;

    void Start()
    {
        
    }
    
   
    void Update()
    {
    chequearDistancia();
      
        if(comportamiento == Comportamiento.mirar)
            transform.LookAt(posJugador);
    perseguirJugador();

    }

    void perseguirJugador()
    {
        transform.position = Vector3.Lerp(transform.position , posJugador.position , speed * Time.deltaTime);
    }

    void chequearDistancia()
    {
        float dist = Vector3.Distance(posJugador.position , transform.position);
        if(dist < distancia)
        {
            speed = 0;
        }else
        {
            speed=2;
        }  
    }  
}
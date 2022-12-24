using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public Transform posJugador;
    public float distancia = 0.5f;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        perseguirJugador();   
    }

    void perseguirJugador()
    {
        transform.position = Vector3.Lerp(transform.position , posJugador.position , speed * Time.deltaTime);
        
    }



}

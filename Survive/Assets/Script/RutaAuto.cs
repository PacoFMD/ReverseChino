using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutaAuto : MonoBehaviour {
    public Transform jugador;
    public Transform mipos;
    int velocidad = 3, rotaciónVel = 3;


    private void Awake()
    {
        //miPos = transform;
    }

    // Use this for initialization
    void Start () {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

      //  transform.LookAt(jugador,Vector3(position.x, position.y, position.z));
	}
}

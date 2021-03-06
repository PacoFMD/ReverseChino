﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningControl : MonoBehaviour {
    public GameObject[] goSpawner, goEnemigo;
    int CuantosEnemigos = 28, x, y, aux;
    int[] enemigosInActivos = new int[48];
    int[] posicion = new int[20]; //siempre sabemos la cantidad de spawnpoint que va a ver 
    public float tiempo = 0, TiempoDeEspera = 10;
    // Use this for initialization
    void Start()
    {
        goSpawner = GameObject.FindGameObjectsWithTag("Spawner");
        y = 0;
        x = 0;
    }

    // Update is called once per frame
    void Update () {
        tiempo += Time.deltaTime;

		if(tiempo >= TiempoDeEspera)
        {
            LosEnemigos();
            x = 0;
            tiempo = 0;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            EnemigosFueraDelRango();
        }

	}


    void EncontrarPuntosCercanos()
    {
        for (int i = 0; i < goSpawner.Length; i++)
        {
            if (goSpawner[i].gameObject.GetComponent<Spawner>().PuedoSpawnear == true) // se que objeto en que posición es verdadero
            {
                posicion[x] = i; // el objeto que es verdadero, su id se guarda en un espacio de memoria de posicion
                x++;            // se incrementa el espacio para el siguiente
            }
            //else
            //{
            //    Debug.Log(goSpawner[i].name);
            //}

        }
    }


    void LosEnemigos()
    {

        EncontrarPuntosCercanos();
        aux =  CuantosEnemigos / x ;   // divido la cantidad de enemigo entre el tamaño de los objetos que son verdaderos ya sea, 1,2,3

        for(int i = 0; i < x; i++)    // recorro el arreglo
        {
            goSpawner[posicion[i]].GetComponent<Spawner>().Invocador(aux); // el valor del arreglo en esa posción será el objeto que puede instanciar
        }        
    }

    void EnemigosFueraDelRango()
    {
       
        goEnemigo = GameObject.FindGameObjectsWithTag("Enemigo");

        for(int i = 0; i< goEnemigo.Length; i++)
        {
            if(goEnemigo[i].GetComponentInChildren<PoderCaminar>().Activo == false) //si el objeto enemigo numero  esta en falso entonces 
            {
                enemigosInActivos[y] = i;                                          //se guarda en un arreglo de enemigoInActivos 
                y++;
            }
        }

        EncontrarPuntosCercanos();

        for (int i = 0; i < y; i++)
        {
            //Debug.Log("Acecando al Spawn "+ goEnemigo[enemigosInActivos[i]].name);
            goEnemigo[enemigosInActivos[i]].GetComponent<CapsuleCollider>().enabled = false;
            goEnemigo[enemigosInActivos[i]].transform.position = goSpawner[posicion[0]].transform.position;
            goEnemigo[enemigosInActivos[i]].GetComponent<CapsuleCollider>().enabled = true;

        }

    }

}

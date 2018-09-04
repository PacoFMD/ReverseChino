using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningControl : MonoBehaviour {
    public GameObject[] goSpawner;
    int CuantosEnemigos = 28, x;
    int[] posicion = new int[20]; //siempre sabemos la cantidad de spawnpoint que va a ver 
    public float tiempo = 0;
    // Use this for initialization
    void Start()
    {
        goSpawner = GameObject.FindGameObjectsWithTag("Spawner");
        x = 0;
    }

    // Update is called once per frame
    void Update () {
        tiempo += Time.deltaTime;

		if(tiempo >= 5)
        {
            LosEnemigos();
            x = 0;
            tiempo = 0;
        }
	}

    void LosEnemigos()
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

        int aux;
        aux =  CuantosEnemigos / x ;   // divido la cantidad de enemigo entre el tamaño de los objetos que son verdaderos ya sea, 1,2,3

        for(int i = 0; i < x; i++)    // recorro el arreglo
        {
            goSpawner[posicion[i]].GetComponent<Spawner>().Invocador(aux); // el valor del arreglo en esa posción será el objeto que puede instanciar
        }

        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemigo;
    public bool PuedoSpawnear = false;
    public float TiempoEspera = 2;
    float tiempo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tiempo += Time.deltaTime;
	}

    public void CambioDeEstado()
    {
        PuedoSpawnear = !PuedoSpawnear;
    }

    public int Invocador(int cuantos)
    {
        
        Debug.Log(this.name);
        print(cuantos);
        for (int i = 0; i <= cuantos; i++)
        {
            if (tiempo >= TiempoEspera)
            {
                Instantiate(enemigo, transform.position, transform.rotation);
                tiempo = 0;
            }
        }
        
        return 0;
    }
}

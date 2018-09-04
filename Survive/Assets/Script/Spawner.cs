using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public bool PuedoSpawnear = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CambioDeEstado()
    {
        PuedoSpawnear = !PuedoSpawnear;
    }

    public int Invocador(int cuantos)
    {
        Debug.Log(this.name);
        print(cuantos);
        return 0;
    }
}

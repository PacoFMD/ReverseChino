using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCerca : MonoBehaviour {
    public GameObject[] Spawner;
	// Use this for initialization
	void Start () {
        Spawner = GameObject.FindGameObjectsWithTag("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        for (int i = 0; i < Spawner.Length; i++)
        {
            if(other.gameObject.name == Spawner[i].name)
            {
                //Debug.Log(other.gameObject.name);
                Spawner[i].gameObject.GetComponent<Spawner>().CambioDeEstado();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        for (int i = 0; i < Spawner.Length; i++)
        {
            if (other.gameObject.name == Spawner[i].name)
            {
                //Debug.Log(other.gameObject.name);
                Spawner[i].gameObject.GetComponent<Spawner>().CambioDeEstado();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RutaAuto : MonoBehaviour {

    public PoderCaminar scPC;
    [SerializeField]
    public Transform objetivo;
    NavMeshAgent navMeshEnemigo;

    private void Awake()
    {
        //miPos = transform;
    }

    // Use this for initialization
    void Start () {
        navMeshEnemigo = this.GetComponent<NavMeshAgent>();

        if(navMeshEnemigo == null)
        {
            Debug.Log("Falta el navmesh del objecto " + gameObject.name);

        }
        else
        {
            Debug.Log("Si hay NavMesh");
            Seguimiento();
        }

       // jugador = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        //  transform.LookAt(jugador,Vector3(position.x, position.y, position.z));
        Seguimiento();
	}

    void Seguimiento()
    {
        if (scPC.Sigo)
        {
            if (objetivo != null)
            {
                Debug.Log(objetivo.name);
                Vector3 nuevaPos = objetivo.transform.position;
                navMeshEnemigo.SetDestination(nuevaPos);
            }
        }
    }
}

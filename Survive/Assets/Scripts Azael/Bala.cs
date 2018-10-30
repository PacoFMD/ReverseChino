using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float velocidad = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

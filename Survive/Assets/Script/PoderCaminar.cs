using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderCaminar : MonoBehaviour {
    public bool Sigo = true;
    public bool Activo = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Detector")
        {

            Activo = true;
            Sigo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Detector")
        {
            Sigo = false;
            //Debug.Log(Sigo);
            Activo = false;
        }
    }


}

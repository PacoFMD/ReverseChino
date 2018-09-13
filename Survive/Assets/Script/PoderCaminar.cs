using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderCaminar : MonoBehaviour {
    public bool Sigo = true;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Detector")
        {
            Sigo = !Sigo;
            Debug.Log(Sigo);
        }
    }


}

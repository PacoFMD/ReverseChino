using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chino_Rotador : MonoBehaviour {

    float VeloRotacion = 20f;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * VeloRotacion * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * VeloRotacion * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }
}

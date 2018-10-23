using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chino_FuncionesMenu : MonoBehaviour {

    public GameObject[] Botones;
    public GameObject[] Submenus;
    public GameObject MenuPausa;
    GameObject Actual;
    public Transform PuntoAparicion;
    public Camera CamClave;
	
	public void ActivarBoton(int nboton)
    {
        Botones[nboton].SetActive(true);
    }

    public void AparecerObjClave(string nombreobjclave)
    {
       if(Actual != null) Destroy(Actual);
       Actual =(GameObject) Instantiate(Resources.Load(nombreobjclave), PuntoAparicion.position, Quaternion.identity);
    }

    public void Resetearmenu()
    {
        if (Actual != null) Destroy(Actual);
        Submenus[0].SetActive(true);
        for (int i = 1; i < Submenus.Length; i++)
        {
            Submenus[i].SetActive(false);
        }

        /*MenuPausa.transform.Find("MenuOclave").gameObject.SetActive(false);
        /*MenuPausa.transform.Find("BotonesMenuPausa").gameObject.SetActive(true);*/

    }


}

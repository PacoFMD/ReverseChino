using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {

    public AudioSource sonidos;
    public AudioClip Disparo, Recarga, Escopeta, Pistola, Rafaga;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void reproduce(int sonido)
    {
        switch (sonido)
        {
            case 1:
                sonidos.PlayOneShot(Disparo);
                break;
            case 2:
                sonidos.PlayOneShot(Recarga);
                break;
            case 3:
                sonidos.PlayOneShot(Escopeta);
                break;
            case 4:
                sonidos.PlayOneShot(Pistola);
                break;
            case 5:
                sonidos.PlayOneShot(Rafaga);
                break;
        }
    }
}

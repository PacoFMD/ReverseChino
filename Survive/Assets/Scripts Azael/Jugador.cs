using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

    public GameObject Arma1;
    public GameObject Arma2;
    public GameObject[] Armas;
    public int ArmaActual = 0;
    public Transform WeaponHolder;
    float fuerzalanzar = 2000.0f;

    public Camera JugadorCam;

    public bool slot1 = false;
    public bool slot2 = false;

    void Start()
    {
        Armas = new GameObject[] { Arma1, Arma2 };
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Y_btn_1") && slot1 == true && slot2 == true)
        {
            if (ArmaActual == 1)
            {
                ArmaActual = 0;

                Armas[0].GetComponent<Arma>().puedesdisparar = true;
                Armas[1].GetComponent<Arma>().puedesdisparar = false;

                Armas[0].SetActive(true);
                Armas[1].SetActive(false);
            }
            else if (ArmaActual == 0)
            {
                ArmaActual = 1;

                Armas[1].GetComponent<Arma>().puedesdisparar = true;
                Armas[0].GetComponent<Arma>().puedesdisparar = false;

                Armas[0].SetActive(false);
                Armas[1].SetActive(true);
            }
        }
        if (Input.GetButtonDown("RB_btn_1") && ArmaActual == 0)
        {
            StartCoroutine(tirar());
        }
        else if (Input.GetButtonDown("RB_btn_1") && ArmaActual == 1)
        {
            StartCoroutine(tirar2());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("X_btn_1"))
        {
            if (other.CompareTag("M4") || other.CompareTag("Escopeta") || other.CompareTag("50CAL") || other.CompareTag("REVOLVER") || other.CompareTag("UMP"))
            {
                if (slot1 == true && slot2 == true)
                {
                    //Tirar Arma Equipada--------------------------------------------------------------
                    Rigidbody armaRigidBody = Armas[ArmaActual].AddComponent<Rigidbody>();
                    Armas[ArmaActual].GetComponent<Arma>().puedesdisparar = false;
                    armaRigidBody.AddRelativeForce(Vector3.left * fuerzalanzar);
                    Armas[ArmaActual].GetComponent<Transform>().parent = null;
                    //---------------------------------------------------------------------------------
                    Armas[ArmaActual] = (GameObject)Instantiate(other.gameObject, WeaponHolder);

                    Armas[ArmaActual].GetComponent<Arma>().fpsCam = JugadorCam;

                    Destroy(Armas[ArmaActual].GetComponent<Rigidbody>());
                    if (other.CompareTag("Escopeta"))
                    {
                        Armas[ArmaActual].transform.localPosition = new Vector3(0.07522355f, 0.00317008f, 0.09492859f);
                        Armas[ArmaActual].transform.localRotation = Quaternion.Euler(-0.028f, 89.358f, -0.003f);
                    }
                    if (other.CompareTag("M4"))
                    {
                        Armas[ArmaActual].transform.localPosition = new Vector3(0.017f, -0.039f, 0.271f);
                        Armas[ArmaActual].transform.localRotation = Quaternion.Euler(-2.408f, -3.234f, 0.275f);
                    }
                    if (other.CompareTag("50CAL"))
                    {
                        Armas[ArmaActual].transform.localPosition = new Vector3(0.028f, -0.081f, 0.392f);
                        Armas[ArmaActual].transform.localRotation = Quaternion.Euler(0.284f, 86.897f, -3.77f);
                    }
                    if (other.CompareTag("REVOLVER"))
                    {
                        Armas[ArmaActual].transform.localPosition = new Vector3(0.134f, -0.08f, 0.175f);
                        Armas[ArmaActual].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                    if (other.CompareTag("UMP"))
                    {
                        Armas[ArmaActual].transform.localPosition = new Vector3(0.04299887f, -0.09927747f, 0.08002368f);
                        Armas[ArmaActual].transform.localRotation = Quaternion.Euler(0.346f, -94.00301f, 2.482f);
                    }
                    Armas[ArmaActual].GetComponent<Arma>().puedesdisparar = true;
                    other.gameObject.SetActive(false);

                }
                else if (slot1 == false && slot2 == false)
                {
                    Destroy(Armas[0]);
                    Armas[0] = (GameObject)Instantiate(other.gameObject, WeaponHolder);

                    Armas[0].GetComponent<Arma>().fpsCam = JugadorCam;
                    Destroy(Armas[0].GetComponent<Rigidbody>());



                    if (other.CompareTag("Escopeta"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.07522355f, 0.00317008f, 0.09492859f);
                        Armas[0].transform.localRotation = Quaternion.Euler(-0.028f, 89.358f, -0.003f);
                    }
                    if (other.CompareTag("M4"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.017f, -0.039f, 0.271f);
                        Armas[0].transform.localRotation = Quaternion.Euler(-2.408f, -3.234f, 0.275f);
                    }
                    if (other.CompareTag("50CAL"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.028f, -0.081f, 0.392f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0.284f, 86.897f, -3.77f);
                    }
                    if (other.CompareTag("REVOLVER"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.134f, -0.08f, 0.175f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                    if (other.CompareTag("UMP"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.04299887f, -0.09927747f, 0.08002368f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0.346f, -94.00301f, 2.482f);
                    }

                    Armas[0].GetComponent<Arma>().enabled = true;

                    Armas[0].GetComponent<Arma>().puedesdisparar = true;

                    other.gameObject.SetActive(false);
                    slot1 = true;
                    ArmaActual = 0;
                    Armas[0].SetActive(true);
                    Armas[1].SetActive(false);
                }
                else if (slot1 == true && slot2 == false)
                {
                    Destroy(Armas[1]);
                    Armas[1] = (GameObject)Instantiate(other.gameObject, WeaponHolder);
                    Armas[1].GetComponent<Arma>().fpsCam = JugadorCam;
                    Destroy(Armas[1].GetComponent<Rigidbody>());

                    if (other.CompareTag("Escopeta"))
                    {
                        Armas[1].transform.localPosition = new Vector3(0.07522355f, 0.00317008f, 0.09492859f);
                        Armas[1].transform.localRotation = Quaternion.Euler(-0.028f, 89.358f, -0.003f);
                    }
                    if (other.CompareTag("M4"))
                    {
                        Armas[1].transform.localPosition = new Vector3(0.017f, -0.039f, 0.271f);
                        Armas[1].transform.localRotation = Quaternion.Euler(-2.408f, -3.234f, 0.275f);
                    }
                    if (other.CompareTag("50CAL"))
                    {
                        Armas[1].transform.localPosition = new Vector3(0.028f, -0.081f, 0.392f);
                        Armas[1].transform.localRotation = Quaternion.Euler(0.284f, 86.897f, -3.77f);
                    }
                    if (other.CompareTag("REVOLVER"))
                    {
                        Armas[1].transform.localPosition = new Vector3(0.134f, -0.08f, 0.175f);
                        Armas[1].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                    if (other.CompareTag("UMP"))
                    {
                        Armas[1].transform.localPosition = new Vector3(0.04299887f, -0.09927747f, 0.08002368f);
                        Armas[1].transform.localRotation = Quaternion.Euler(0.346f, -94.00301f, 2.482f);
                    }

                    Armas[0].GetComponent<Arma>().enabled = true;
                    Armas[1].GetComponent<Arma>().enabled = true;

                    Armas[1].GetComponent<Arma>().puedesdisparar = true;
                    Armas[0].GetComponent<Arma>().puedesdisparar = false;

                    other.gameObject.SetActive(false);
                    slot2 = true;
                    ArmaActual = 1;
                    Armas[0].SetActive(false);
                    Armas[1].SetActive(true);
                }
                else if (slot1 == false && slot2 == true)
                {
                    Destroy(Armas[0]);
                    Armas[0] = (GameObject)Instantiate(other.gameObject, WeaponHolder);
                    Armas[0].GetComponent<Arma>().fpsCam = JugadorCam;
                    Destroy(Armas[0].GetComponent<Rigidbody>());

                    if (other.CompareTag("Escopeta"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.07522355f, 0.00317008f, 0.09492859f);
                        Armas[0].transform.localRotation = Quaternion.Euler(-0.028f, 89.358f, -0.003f);
                    }
                    if (other.CompareTag("M4"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.017f, -0.039f, 0.271f);
                        Armas[0].transform.localRotation = Quaternion.Euler(-2.408f, -3.234f, 0.275f);
                    }
                    if (other.CompareTag("50CAL"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.028f, -0.081f, 0.392f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0.284f, 86.897f, -3.77f);
                    }
                    if (other.CompareTag("REVOLVER"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.134f, -0.08f, 0.175f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                    }
                    if (other.CompareTag("UMP"))
                    {
                        Armas[0].transform.localPosition = new Vector3(0.04299887f, -0.09927747f, 0.08002368f);
                        Armas[0].transform.localRotation = Quaternion.Euler(0.346f, -94.00301f, 2.482f);
                    }

                    Armas[0].GetComponent<Arma>().enabled = true;
                    Armas[1].GetComponent<Arma>().enabled = true;

                    Armas[0].GetComponent<Arma>().puedesdisparar = true;
                    Armas[1].GetComponent<Arma>().puedesdisparar = false;

                    other.gameObject.SetActive(false);
                    slot1 = true;
                    ArmaActual = 0;
                    Armas[0].SetActive(true);
                    Armas[1].SetActive(false);
                }
            }
        }
    }

    IEnumerator tirar()
    {
        yield return new WaitForSeconds(.4f);
        Rigidbody armaRigidBody = Armas[ArmaActual].AddComponent<Rigidbody>();
        Armas[ArmaActual].GetComponent<Arma>().puedesdisparar = false;
        armaRigidBody.AddRelativeForce(Vector3.left * fuerzalanzar);
        Armas[ArmaActual].GetComponent<Transform>().parent = null;
        slot1 = false;
        ArmaActual = 1;
        Armas[1].GetComponent<Arma>().puedesdisparar = true;
        if (slot2 == true)
        {
            Armas[1].SetActive(true);
        }
    }

    IEnumerator tirar2()
    {
        yield return new WaitForSeconds(.4f);
        Rigidbody armaRigidBody = Armas[ArmaActual].AddComponent<Rigidbody>();
        Armas[ArmaActual].GetComponent<Arma>().puedesdisparar = false;
        armaRigidBody.AddRelativeForce(Vector3.left * fuerzalanzar);
        Armas[ArmaActual].GetComponent<Transform>().parent = null;
        slot2 = false;
        ArmaActual = 0;
        Armas[0].GetComponent<Arma>().puedesdisparar = true;
        if (slot1 == true)
        {
            Armas[0].SetActive(true);
        }
    }

}

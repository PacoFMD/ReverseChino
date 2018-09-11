using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chino_Movimiento : MonoBehaviour
{
    [Header("Arrastrame")]
    public GameObject MenuPausa;
    //public Camera cam;

    [Space(1)]

    [Header("Estadisticas")]
    bool estagachado, estacorriendo, enpausa=false;
    public float vel = 5, factorcarrera= 2.2f;
    Rigidbody Rb;
    Transform Tra,tracam;
    CapsuleCollider colai;
    Vector3 movim;
    float rotacioncamx, Vida = 100f, sens8 = -1;

    //Todo esto es para el tween de la camara
    Vector3 PuntoA;
    Vector3 PuntoB;
    public float tiempMovim; 
    float factMovim;


    void Start()
    {
        factMovim = 1.0f / tiempMovim;
        Rb = GetComponent<Rigidbody>();
        Tra = GetComponent<Transform>();
        tracam = GetComponentInChildren<Transform>().Find("MainCamera");
        colai = GetComponent<CapsuleCollider>();
    }
  
    void Update()
    {

        float UpDown = Input.GetAxis("Vertical" );
        float LeftRight = Input.GetAxis("Horizontal");

        float camy = Input.GetAxis("Mouse Y");
        float camx = Input.GetAxis("Mouse X");

        bool Interact = Input.GetButtonDown("Interact");
        bool Space =    Input.GetButtonDown("Jump");
        bool Crouch =   Input.GetButtonDown("Crouch");
        bool Sprint =   Input.GetButtonDown("Fire3");
        bool Menu =     Input.GetButtonDown("Cancel");

        //Detecta inputs y los convierte a coordenadas globales, se suman, se multiplican por velocidad y se guardan en vector
        Vector3 movimx = Tra.right * LeftRight;
        Vector3 movimz = Tra.forward * UpDown;

        movim = (movimx + movimz).normalized * vel;


        if (enpausa)
        {
            Pausar();
        }
        else { Despausar(); }
        //Salto
        if (Space && EnSuelo())
        {
            Rb.AddForce(Vector3.up * 200f);
        }

        //Camara en y
        if (camy != 0)
        {
            rotacioncamx += sens8 * camy * Time.deltaTime * 150;
            rotacioncamx = Mathf.Clamp(rotacioncamx, -80, 40);

            tracam.localEulerAngles = new Vector3(rotacioncamx, tracam.localEulerAngles.y, tracam.localEulerAngles.z);
        }

        //Agacharse
        if (Crouch && !estagachado)
        {
            vel /= 2;
            estagachado = true;
            //StartCoroutine(movercamara());
            StartCoroutine(cambiartamaño());
        }
        else if (Crouch && estagachado)
        {
            vel *= 2;
            estagachado = false;
            //StartCoroutine(movercamara());
            StartCoroutine(cambiartamaño());
        }

        //Sprint 
        if (Sprint && !estacorriendo && UpDown > 0.5)
        {
            vel *= factorcarrera;
            estacorriendo = true;
        }

        //desactivar sprint
        if (UpDown < .5 && (LeftRight < 0.6 || LeftRight > -0.6) && estacorriendo)
        {
            estacorriendo = false;
            vel /= factorcarrera;
        }

        //Camara y mono en x
        if(!enpausa) Tra.Rotate(0, camx * 3, 0);


        //Interacciones
        if (Interact)
        {
            Interactuar();
        }

        //Pausar
        if (Menu && !enpausa)
        {
            enpausa = true;
            MenuPausa.SetActive(true);
        }
        else if (Menu && enpausa)
        {
            enpausa = false;
            MenuPausa.SetActive(false);
        }

    }

    /*==========================================================-  Funciones  -==================================================*/

    void Pausar()
    {
        Time.timeScale = 0f;
    }
    void Despausar()
    {
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        //Se mueve con rigidbody
        Rb.MovePosition(Rb.position + movim * Time.deltaTime);
    }

    //Toy tocando el piso?
    bool EnSuelo()
    {
        return (Physics.Raycast(Tra.position, Vector3.down, 1f));
    }

    void Interactuar()
    {
        RaycastHit hit;

        if (Physics.Raycast(tracam.position, tracam.forward, out hit, 4f)){
            print(hit.collider.name);
            if (hit.collider.gameObject.CompareTag("ObjClave"))
            {
                hit.collider.GetComponent<Chino_Pickup>().ItemsClave();
            }
            Debug.DrawLine(tracam.position,hit.point , Color.red, 1f);
        }
    }
        
        

    IEnumerator movercamara()
    {
        for (float valorT = 0.0f; valorT < 1.0f; valorT += factMovim )
        {
            PuntoA = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
            PuntoB = new Vector3(transform.position.x, transform.position.y + 0f, transform.position.z);
            if (valorT >= 1.0f)//Seguridad de no ir mas haya del B
            {
                valorT = 1.0f;
            }
            if (estagachado) tracam.position = Vector3.Lerp(PuntoA, PuntoB, valorT);
            if (!estagachado) tracam.position = Vector3.Lerp(PuntoB, PuntoA, valorT);
            yield return new WaitForSeconds(.01f);
           
        }
        
    }

    IEnumerator cambiartamaño()
    {

            if (estagachado)
            {
                while (colai.height > 1.0f)
                {
                    colai.height -= .1f;
                    yield return new WaitForSeconds(.01f);
                }
                if (colai.height != 1.0f) colai.height = 1.0f;
            }
            else if(!estagachado) {
                    while (colai.height < 2.0f)
                    {
                        colai.height += .1f;
                        yield return new WaitForSeconds(.01f);
                    }
                if (colai.height != 2.0f) colai.height = 2.0f;
            }       
    }

}
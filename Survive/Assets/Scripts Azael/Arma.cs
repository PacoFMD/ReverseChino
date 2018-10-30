using UnityEngine;

public class Arma : MonoBehaviour {

    public float dano = 10.0f;
    public float rango = 100.0f;
    public float fuerzaimpacto = 30.0f;
    public float fireRate = 10.0f;

    public Camera fpsCam;

    public GameObject muzzleflash;
    public GameObject impacteffect;

    private float nextTimeToFire = 0.0f;

    Transform FirePoint;
    Quaternion Rota;
    public float Cargador;
    public float CargadorMaximo = 30.0f;
    bool Recargar = false;
    public int TiempoRecarga = 2;
    public bool puedesdisparar = false;

    int proyectiles = 8;

    void Start()
    {
        Cargador = CargadorMaximo;
    }

    void Update ()
    {
        FirePoint = this.GetComponent<Transform>().Find("FirePoint");
        Rota = this.FirePoint.rotation;

        if (Input.GetAxis("R_trigger_1") > 0.0f && Time.time >= nextTimeToFire)
        {
            if (this.CompareTag("Escopeta") && this.puedesdisparar == true)
            {
                nextTimeToFire = Time.time + 1.0f / fireRate;
                GameObject.FindObjectOfType<Sonidos>().reproduce(3);
                for (int i = 0; i < proyectiles; i++)
                {
                    DispararEscopeta();
                }
                GameObject.FindObjectOfType<Sonidos>().reproduce(2);
                Cargador -= 1.0f;
            }
            else
            {
                nextTimeToFire = Time.time + 1.0f / fireRate;
                Disparar();
            }
        }

        if (Input.GetButtonDown("B_btn_1") && Cargador != CargadorMaximo)
        {
            Recargar = true;
            GameObject.FindObjectOfType<Sonidos>().reproduce(2);
            Invoke("Recarga", TiempoRecarga);
            return;
        }
	}

    void Disparar()
    {
        if (Recargar == false && puedesdisparar == true)
        {
            if (Cargador == 0.0f)
            {
                Recargar = true;
                GameObject.FindObjectOfType<Sonidos>().reproduce(2);
                Invoke("Recarga", TiempoRecarga);
                return;
            }

            Cargador -= 1.0f;

            GameObject muzzleGO = Instantiate(muzzleflash, FirePoint.position, Rota);
            Destroy(muzzleGO, 0.2f);

            if (this.CompareTag("REVOLVER"))
            {
                GameObject.FindObjectOfType<Sonidos>().reproduce(4);
            }
            else if (this.CompareTag("UMP"))
            {
                GameObject.FindObjectOfType<Sonidos>().reproduce(5);
            }
            else
            {
                GameObject.FindObjectOfType<Sonidos>().reproduce(1);
            }

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, rango))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.ReciveDano(dano);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal * fuerzaimpacto);
                }

                GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2.0f);
            }
        }
    }

    void DispararEscopeta()
    {
        if (Recargar == false && puedesdisparar == true)
        {
            if (Cargador == 0.0f)
            {
                GameObject.FindObjectOfType<Sonidos>().reproduce(2);
                Recargar = true;
                Invoke("Recarga", TiempoRecarga);
                return;
            }

            GameObject muzzleGO = Instantiate(muzzleflash, FirePoint.position, Rota);
            Destroy(muzzleGO, 0.2f);

            RaycastHit hit;

            Vector3 direction = fpsCam.transform.forward;
            Vector3 spread = fpsCam.transform.position;
            spread += fpsCam.transform.up * Random.Range(-1f, 1f);
            spread += fpsCam.transform.right * Random.Range(-1f, 1f);
            direction += spread.normalized * Random.Range(0f, 0.2f);

            if (Physics.Raycast(fpsCam.transform.position, direction, out hit, rango))
            {
                Debug.DrawLine(fpsCam.transform.position, hit.point, Color.red, 1f);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.ReciveDano(dano);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal * fuerzaimpacto);
                }

                GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2.0f);
            }
        }
    }

    void Recarga()
    {
        Recargar = false;
        Cargador = CargadorMaximo;
    }
}

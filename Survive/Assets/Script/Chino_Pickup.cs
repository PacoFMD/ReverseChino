using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chino_Pickup : MonoBehaviour {

    [Header("NombreDelItem")]
    public string nombreItem;

	void Start () {
		
	}
	
    public void ItemsClave()
    {
        switch (nombreItem)
        {
            case "Piston":
                FindObjectOfType<Chino_FuncionesMenu>().ActivarBoton(0);
                break;
            case "Cubo":
                FindObjectOfType<Chino_FuncionesMenu>().ActivarBoton(1);
                break;
            case "Esfera":
                FindObjectOfType<Chino_FuncionesMenu>().ActivarBoton(2);
                break;
        }
        
        Destroy(gameObject);
    }


}

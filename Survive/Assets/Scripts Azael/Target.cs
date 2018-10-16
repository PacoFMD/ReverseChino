using UnityEngine;

public class Target : MonoBehaviour {

    public float Salud = 50.0f;

    private void Start()
    {
    }

    public void ReciveDano(float dano)
    {
        Salud -= dano;
        if (Salud <= 0.0f)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        Destroy(gameObject);
    }

}

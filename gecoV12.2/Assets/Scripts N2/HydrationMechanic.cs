using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HydrationMechanic : MonoBehaviour
{
    [SerializeField] private float hidratacion;

    [SerializeField] private float hidratacionMax;

    [SerializeField] private BarControl bar;


    // Start is called before the first frame update
    void Start()
    {
        hidratacion = hidratacionMax;
        bar.IniciarrBarra(hidratacion);
    }

    // Update is called once per frame
    void Update()
    {
        hidratacion -= Time.deltaTime;
        bar.CambiarActual(hidratacion);
        if(hidratacion <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Hidratacion(float cantidad){
        hidratacion += (cantidad + Time.deltaTime);
        bar.CambiarActual(hidratacion);
    }
}

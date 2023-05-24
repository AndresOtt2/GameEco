using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarMaxima(float cantidad){
        slider.maxValue = cantidad;
    }

    public void CambiarActual(float cantidad){
        slider.value = cantidad;
    }

    public void IniciarrBarra(float cantidad){
        CambiarMaxima(cantidad);
        CambiarActual(cantidad);
    }

}

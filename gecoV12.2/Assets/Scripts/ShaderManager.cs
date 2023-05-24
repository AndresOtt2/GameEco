using UnityEngine;

public class ShaderManager : MonoBehaviour {
    public GameObject objetoParaOscurecer;
    
    public float oscurecerFactor = 0.0f;
    private Material materialOscurecido;

    void Start() {
        materialOscurecido = objetoParaOscurecer.GetComponent<Renderer>().material;
    }

    void Update() {
        oscurecerFactor = Mathf.Clamp(oscurecerFactor, 0, 1);
        materialOscurecido.SetFloat("_OscurecerFactor", oscurecerFactor);
    }
}
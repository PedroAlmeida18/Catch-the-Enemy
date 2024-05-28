using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public static BarraVida Instance;
   public  Slider sliderVida;

    void Awake(){
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlteraVida(float vida){
        sliderVida.value = vida;
    }

} 

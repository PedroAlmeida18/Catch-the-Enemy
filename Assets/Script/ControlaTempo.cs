using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaTempo : MonoBehaviour
{
    public  Text texto ;
    public float tempo = 100f;
    public Button botao;
    private bool poderodarContador = false;
    public GameObject PainelGameover;
    void Start()
    {
        poderodarContador = true;
    }

    // Update is called once per frame
    void Update()
    {
        Conta_tempo();
    }
    
    private  void Conta_tempo(){
        if(poderodarContador){
             int tempoInteiro;
            texto.gameObject.SetActive(true);
             if(tempo>0){
                tempo = tempo - Time.deltaTime;
                tempoInteiro = (int) tempo;
                texto.text = "Tempo é : " + tempoInteiro.ToString("0");
                if(tempoInteiro==0){
                PainelGameover.gameObject.SetActive(true);
                
            }
            }
            
        
    }
}
}

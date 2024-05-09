using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PainelGameOver : MonoBehaviour

{
    public GameObject Poder ; 
    public  Text texto ;
    public GameObject PainelGaMEOVER;
    public UnityEngine.UI.Button botao;
    public float tempo = 100f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Conta_tempo();
    }

  private  void Conta_tempo(){

        if(Poder.activeSelf){
             int tempoInteiro;
            texto.gameObject.SetActive(true);
             if(tempo>0){
                tempo = tempo - Time.deltaTime;
                tempoInteiro = (int) tempo;
                texto.text = "Tempo é : " + tempoInteiro.ToString("0");
                if(tempoInteiro==0){
                PainelGaMEOVER.gameObject.SetActive(true);
                Poder.SetActive(false);
                
                

            }
            }
            

 
}
}
  
}

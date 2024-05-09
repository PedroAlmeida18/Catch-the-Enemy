using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Controla_interface : MonoBehaviour
{
    public GameObject Poder ;
    public UnityEngine.UI.Button botao;
    public float tempo = 100f;
    public Text texto ;
    public GameObject Painel ;
   
     public  static int tempoInteiro;

    void Awake(){
         
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
       // Conta_tempo();
    }
    public void OnButtonClick(){
         if(!Poder.activeSelf){
            Poder.SetActive(true);
        
        } 
        if(Poder.activeSelf){
            Painel.gameObject.SetActive(false);
        }
        
               
        
        
    }
    private void  destativaPoder( ){
        if(tempo == 0){
            Poder.SetActive(false);
        }

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
                Poder.SetActive(false);
                
                

            }
            }
            

 
}
}
}
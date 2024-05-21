using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Controla_interface : MonoBehaviour
{
    public GameObject Poder ; 
    public  Text texto ;
    public GameObject PainelGaMEOVER;
    public GameObject PainelVitoria;
  [SerializeField] private string NomeDoLevalDeJogo;
    public float tempo = 100f;
     public static Controla_interface Instance;


    void Start()
    {
       Instance = this;
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
    public void Reiniciar(){
        SceneManager.LoadScene(NomeDoLevalDeJogo);
    }
    public void proximaFase(){
        print("Você venceu ");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBox : MonoBehaviour
{
    [SerializeField] private Controla_Jogador Jogador;
    [SerializeField] private GameObject Caixa;
    private int vidaBox = 30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GanhaVida(){
        

    }
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.CompareTag("Poder")){
            if(vidaBox>0){
                 vidaBox-=10;
            }
            
            if(vidaBox==0){
                Destroy(Caixa);
                Jogador.vida+=30;
            }
        }

    }
}

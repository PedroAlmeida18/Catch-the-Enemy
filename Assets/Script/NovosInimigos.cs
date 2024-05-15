using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;

public class NovosInimigos : MonoBehaviour
{
    public Controla_Inimigo Inimigos ;
    private float TempoEmcriacao;
     private int quantidadeInimigos;
    void Start()
    {
        TempoEmcriacao = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
      criacoInimigos();
            
            
      //criacoInimigos();
    }
    private void criacoInimigos(){
        TempoEmcriacao+=Time.deltaTime;
        if(TempoEmcriacao>=2.0f){
            TempoEmcriacao=0;
             float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(-4,4);
            UnityEngine.Vector2 psocaoInimigo = new  UnityEngine.Vector2(eixox,eixoy);
            while (quantidadeInimigos<5)
            {
                Instantiate(Inimigos, psocaoInimigo, Quaternion.identity);
                quantidadeInimigos++;
            }
                quantidadeInimigos=5;
                Debug.Log("Unatidade de Inimgos criados foi :"+ quantidadeInimigos);
            
            
            
            
        }
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class NovosInimigos : MonoBehaviour
{
    public Controla_Inimigo Inimigos ;
    private float TempoEmcriacao;
    public static int quantidadeInimigos;

   
    
    void Awake(){
        
       
    }

    void Start()
    {
        TempoEmcriacao = 0;
    }

    // Update is called once per frame
    void Update()
    {
      criacoInimigos();   
    }
    private void criacoInimigos(){
        TempoEmcriacao+=Time.deltaTime;
        if(TempoEmcriacao>=2.0f){
            TempoEmcriacao=0;
             float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(3,3.17f);
            UnityEngine.Vector2 psocaoInimigo = new  UnityEngine.Vector2(eixox,eixoy);
            while (quantidadeInimigos<1)
            {
                Instantiate(Inimigos, psocaoInimigo, Quaternion.identity);
                quantidadeInimigos++;
                Debug.Log("quantidade de Inimgos criados foi :"+ quantidadeInimigos);
            }
                
        }
        
    }
     
}

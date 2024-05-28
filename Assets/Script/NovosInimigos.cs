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
    public  int quantidadeInimigosFase1;
    [SerializeField] private int duvida;
    public int SalvarQuantidadeInimigos ;
    public static NovosInimigos Instance;
    [SerializeField] private List <ConfigNivelScriptableObject> configNivelScriptableObjects;
   
    
    void Awake(){
        
       Instance = this;
    }

    void Start()
    {
       StartCoroutine(criacaoInimigoCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
      //criacoInimigos();   
    }

    private IEnumerator criacaoInimigoCoroutine(){
        for(int x = 0; x < configNivelScriptableObjects[0].QuantidadeInimigos; x++){
                
                float eixox = Random.Range(-9,9);
                float eixoy = Random.Range(3,3.17f);
                UnityEngine.Vector2 psocaoInimigo = new  UnityEngine.Vector2(eixox,eixoy);
                
                yield return new WaitForSeconds(configNivelScriptableObjects[0].PegarInimigo.PropriedadesInimigo.TempoDecriacao);
                

                
                Controla_Inimigo _Inimigo = Instantiate(configNivelScriptableObjects[0].PegarInimigo.InimigoPrefab, psocaoInimigo, Quaternion.identity);
                _Inimigo.novosInimigos = this;
                _Inimigo.propriedadesInimigo = configNivelScriptableObjects[0].PegarInimigo.PropriedadesInimigo;
                quantidadeInimigosFase1++;
                SalvarQuantidadeInimigos = quantidadeInimigosFase1;

                Debug.Log("quantidade de Inimgos criados foi :"+ quantidadeInimigosFase1);

        }
        
    }

    private void criacoInimigos(){
        TempoEmcriacao+=Time.deltaTime;
        if(TempoEmcriacao>=2.0f){
            Debug.Log("CRIOU");
            TempoEmcriacao=0;
            float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(3,3.17f);
            UnityEngine.Vector2 psocaoInimigo = new  UnityEngine.Vector2(eixox,eixoy);
            for(int x = 0; x < configNivelScriptableObjects[0].QuantidadeInimigos; x++){
                Instantiate(configNivelScriptableObjects[0].PegarInimigo.InimigoPrefab, psocaoInimigo, Quaternion.identity);
                quantidadeInimigosFase1++;
                SalvarQuantidadeInimigos = quantidadeInimigosFase1;
                Debug.Log("quantidade de Inimgos criados foi :"+ quantidadeInimigosFase1);
        }
      
        }
      
    }

     
}

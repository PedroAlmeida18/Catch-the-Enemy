using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Controla_Inimigo : MonoBehaviour

{

    Rigidbody2D rigidbody2D_inimigo;
    Transform transformInimigo;
    public static int  zumbimorto = 0;
    public int ZumbiVivos = 5;
    public GameObject prefabDoObjeto;
    
    public GameObject PainelVitoria ;
  
    int vidaInimigo = 100;
    void Start()
    {
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
       
      
  }
        

    void Update()
    {
        MovimentaInimigo();
        AtivaVitoria();
       
    }
    
       private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Poder"))
        {
            float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(-4,4);
            gameObject.SetActive(false);
            zumbimorto++;
            print(zumbimorto);
            
        } 
        AtivaVitoria();


        }

    private void MovimentaInimigo(){
        float  velocidade = 2.0f;
        float x = Random.Range(-9,9);
        float y = Random.Range(-4,4);
         Vector3 novaposicao = new Vector3(x,y,0);
        transformInimigo.Translate(novaposicao*Time.deltaTime*velocidade);
    }
    private void AtivaVitoria(){
        print(zumbimorto);
        if(zumbimorto == ZumbiVivos){
            PainelVitoria.gameObject.SetActive(true);

        }
    }
   

}

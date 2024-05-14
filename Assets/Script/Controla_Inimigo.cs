using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Controla_Inimigo : MonoBehaviour

{
   public  Rigidbody2D rigidbody2D_inimigo;
   public float VelocidadeMinimia = 1 ;
   public float velocidadeMaxima = 10;
   private float VelocidadeY;
    Transform transformInimigo;
    public static int  zumbimorto = 0;
    public int ZumbiVivos = 5;
    public GameObject PainelVitoria ;
    int vidaInimigo = 20;
    void Start()
    {
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        VelocidadeY = Random.Range(VelocidadeMinimia, velocidadeMaxima);
       
      
  }
        

    void Update()
    {
        rigidbody2D_inimigo.velocity = new UnityEngine.Vector2(0,-VelocidadeY);
       MovimentaInimigo();
       
      
       
    }
    
       private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Poder"))
        {
           vidaInimigo = vidaInimigo-10;;
           print(vidaInimigo);

            if(vidaInimigo==0){
                 gameObject.SetActive(false);
                  
                zumbimorto++;
            }
            print(zumbimorto);
            
        } 
      //  AtivaVitoria();
      


        }

    private void MovimentaInimigo(){
        float  velocidade = 2.0f;
        float x = Random.Range(-9,9);
        float y = Random.Range(-4,4);
         Vector3 novaposicao = new Vector3(x,y,0);
        transformInimigo.Translate(novaposicao*Time.deltaTime*velocidade);
    }
  /*  private void AtivaVitoria(){
        if(zumbimorto == ZumbiVivos){
            PainelVitoria.gameObject.SetActive(true);

        }
    }*/
}
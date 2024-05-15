using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
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
   private float distancia;
   public GameObject Jogador;
    private float distanciaMin;
    private Camera camera;
    [SerializeField]
    private PoderInimigo prefabPoder;
    private float TempoEmcriacao;


    void Start()
    {
        TempoEmcriacao=0;
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        VelocidadeY = Random.Range(VelocidadeMinimia, velocidadeMaxima);
       
      
  }
        

    void Update()
    {
        rigidbody2D_inimigo.velocity = new UnityEngine.Vector2(0,-VelocidadeY);
       MovimentaInimigo();
       TiroCompoder();
       
      
       
    }
    
       private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Poder"))
        {
           vidaInimigo = vidaInimigo-10;;
           //print(vidaInimigo);

            if(vidaInimigo==0){
                 gameObject.SetActive(false);
                  
                zumbimorto++;
            }
           // print(zumbimorto);
            
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
    public void TiroCompoder(){
        // calcular distancia 
        distanciaMin = 2.0f;
        distancia = Vector2.Distance( transformInimigo.position, Jogador.transform.position);
        if(distancia >= distanciaMin){
         Vector3 direcaoPoder =   Jogador.transform.position -transformInimigo.position;
         direcaoPoder = direcaoPoder.normalized;
        TempoEmcriacao+=Time.deltaTime;
        if(TempoEmcriacao>=2.0f){
             Debug.Log("Pode atirar");
            TempoEmcriacao=0;
            PoderInimigo NovoPoder= Instantiate(prefabPoder,transformInimigo.position, Quaternion.identity);
            NovoPoder.MoverPoder(direcaoPoder);
        }

            // Realizar o tiro na direção do Jogador 
            /* O que eu preciso:
            Saber Posição do Jogador,
            Criar o poder do Inimigo, 
            Fazer ele atirar na direção do Usuario
            Causar dano no usuario   

      */  }
 }
 }

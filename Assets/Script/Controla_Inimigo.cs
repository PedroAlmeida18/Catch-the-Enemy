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
    public Rigidbody2D PoderRigidbody2d;
    public Controla_Jogador Jogador;
    public GameObject PoderJogador;
    public GameObject poderInimigoPrefab;
    public float velocidadePoder = 5.0f;
    public float cooldownDisparo = 2.0f; // Tempo de espera entre os disparos
    private float ultimoDisparoTempo;
    
   
    int vidaInimigo = 20;
    void Start()
    {
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
       
      
  }
        

    void Update()
    {
        MovimentaInimigo();
         if (Time.time > ultimoDisparoTempo + cooldownDisparo)
        {
            DispararPoder();
            ultimoDisparoTempo = Time.time;
        }
      
       
    }
    
       private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Poder"))
        {
           vidaInimigo = vidaInimigo-10;;
           print(vidaInimigo);
           
            float eixox = Random.Range(-9,9);
            float eixoy = Random.Range(-4,4);
            if(vidaInimigo==0){
                 gameObject.SetActive(false);
                  
                zumbimorto++;
            }
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
        if(zumbimorto == ZumbiVivos){
            PainelVitoria.gameObject.SetActive(true);

        }
    }
  private void DispararPoder()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Jogador");
        if (jogador != null)
        {
            Vector3 direcao = jogador.transform.position - transform.position;
            direcao.Normalize();
            GameObject poderInimigo = Instantiate(poderInimigoPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbPoderInimigo = poderInimigo.GetComponent<Rigidbody2D>();
            rbPoderInimigo.velocity = direcao * velocidadePoder;
        }
    }
    
   

}

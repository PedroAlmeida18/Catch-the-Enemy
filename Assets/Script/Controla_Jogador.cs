using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controla_Jogador : MonoBehaviour
{
    Rigidbody2D rigidbody2D_Jogador;
   public  Transform transformjogador ;
    public float velocidade ;
    public GameObject Poder ;
    public bool Vivo = true;
    public bool Andando = false;
    public GameObject Jogador ;
    private Animator animatorJogador ; 
    public int vida = 100;
    public GameObject PainelGamerover;
     private Camera camera;
     [SerializeField]
     private Controla_Poder prefabPoder;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main;
        rigidbody2D_Jogador = GetComponent<Rigidbody2D>();
        transformjogador = GetComponent<Transform>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {   
        TiroCompoder();
        MovimentaJogador();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        { 
            if(vida>0){
                vida = vida-5;
            }
           // print(vida);
            if(vida==0){
                Poder.SetActive(false);
                animatorJogador.SetBool("Vivo", false);
                PainelGamerover.gameObject.SetActive(true);
                //print(vida );
            }
            
        } 
}
 private void MovimentaJogador (){
        
        velocidade = 5.0f;
        float eixoX = Input.GetAxis("Horizontal");
        float eixoy = Input.GetAxis("Vertical");
        Vector3 novaposicao = new Vector3(eixoX,eixoy,0);
        transformjogador.Translate(novaposicao * velocidade*Time.deltaTime);
        if(novaposicao != Vector3.zero){
            animatorJogador.SetBool("Movimenta", true);
        }
        else{
            animatorJogador.SetBool("Movimenta", false);
        }
        

 }
 public void TiroCompoder(){
    if(Input.GetMouseButtonDown(0)){
        Vector2 posicaomouse = Input.mousePosition;
        Vector3 posicaomouseNoMundo = this.camera.ScreenToWorldPoint(posicaomouse);
        posicaomouseNoMundo.z=0;

         Vector3 direcaoPoder = (posicaomouseNoMundo - transformjogador.position );
         direcaoPoder = direcaoPoder.normalized;
        

         Controla_Poder NovoPoder= Instantiate(prefabPoder,posicaomouseNoMundo, Quaternion.identity);
         NovoPoder.MoverPoder(direcaoPoder);
         

    }

 }
}

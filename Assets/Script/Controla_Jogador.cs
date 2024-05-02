using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Jogador : MonoBehaviour
{
    Rigidbody2D rigidbody2D_Jogador;
    Transform transformjogador ;
    public float velocidade ;
    public GameObject Poder ;
    public bool Vivo = true;
    public bool Andando = false;
    public GameObject Jogador ;
    private Animator animatorJogador ;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D_Jogador = GetComponent<Rigidbody2D>();

        transformjogador = GetComponent<Transform>();
        animatorJogador = GetComponent<Animator>();
    

    }

    // Update is called once per frame
    void Update()

    {   
        MovimentaJogador();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o collider que colidiu tem a tag "Inimigo"
        if (collision.gameObject.CompareTag("Inimigo"))
        { 
            Poder.SetActive(false);
            animatorJogador.SetBool("Vivo", false);
            
        } 
}
 private void MovimentaJogador (){
        
        velocidade = 5.0f;
        float eixoX = Input.GetAxis("Horizontal");
        Vector3 novaposicao = new Vector3(eixoX,0,0);
        transformjogador.Translate(novaposicao * velocidade*Time.deltaTime);
        if(novaposicao != Vector3.zero){
            animatorJogador.SetBool("Movimenta", true);
        }
        else{
            animatorJogador.SetBool("Movimenta", false);
        }
        

 }


}

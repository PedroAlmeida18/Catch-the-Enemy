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
    public Rigidbody2D rigidbody2D_inimigo;
    public float VelocidadeMinimia = 1;
    public float velocidadeMaxima = 10;
    private float VelocidadeY;
    Transform transformInimigo;
    public static int zumbimorto = 0;
    int vidaInimigo = 100;
    private float distancia;

    public Controla_Jogador Jogador;

    private float distanciaMin;
    private Camera camera;
    [SerializeField]
    private PoderInimigo prefabPoder;
    private float TempoEmcriacao;
    public BarraVida BarravaidaInimigo;
    public Controla_interface controlaInterface;
    public NovosInimigos novosInimigos;

    void Start()
    {
        TempoEmcriacao = 0;
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        VelocidadeY = Random.Range(VelocidadeMinimia, velocidadeMaxima);
        Jogador = Controla_Jogador.Instance;
        BarravaidaInimigo = BarraVida.Instance;
        controlaInterface = Controla_interface.Instance;
        novosInimigos = NovosInimigos.Instance;
    }


    void Update()
    {
        rigidbody2D_inimigo.velocity = new UnityEngine.Vector2(0, -VelocidadeY);
        MovimentaInimigo();
        TiroInimigor();
        VerficaVitoria();
    }

   
   private void OnTriggerEnter2D(Collider2D collider2D){
    if (collider2D.gameObject.CompareTag("Poder"))
        {
            vidaInimigo = vidaInimigo - 10;
            BarravaidaInimigo.AlteraVida(vidaInimigo);
            Destroy(collider2D.gameObject);
            if (vidaInimigo == 0)
            {
                gameObject.SetActive(false);

                zumbimorto++;
            }
           

        }
        VerficaVitoria();

   }

   
 

    private void MovimentaInimigo()
    {
        Vector3 direcaoPSeguir = Jogador.transform.position - transformInimigo.position;
        float velocidade = 2.0f;
        float x = Random.Range(-9, 9);
        float y = Random.Range(-4, 4);
        Vector3 novaposicao = new Vector3(x, y, 0);
        transformInimigo.Translate(direcaoPSeguir* Time.deltaTime * velocidade);

    }

   

    public void TiroInimigor()
    {
        // calcular distancia
        distanciaMin = 2.0f;
        distancia = Vector2.Distance(transformInimigo.position, Jogador.transform.position);

        if (distancia >= distanciaMin)
        {
            Vector3 direcaoPoder = Jogador.transform.position - transformInimigo.position;
            direcaoPoder = direcaoPoder.normalized;
            TempoEmcriacao += Time.deltaTime;

            if (TempoEmcriacao >= 2.0f)
            {
                Debug.Log("Pode atirar");
                TempoEmcriacao = 0;

                int ajustarDistanciaDoTiroDoInimigo = 1;

                PoderInimigo NovoPoder = Instantiate(prefabPoder, transformInimigo.position + (direcaoPoder * ajustarDistanciaDoTiroDoInimigo), Quaternion.identity);
                NovoPoder.MoverPoder(direcaoPoder);
            }
        }
    }
    private void VerficaVitoria(){
        if(zumbimorto == novosInimigos.SalvarQuantidadeInimigos){
            controlaInterface.PainelVitoria.gameObject.SetActive(true);
            if(controlaInterface.PainelVitoria.activeSelf){
                Jogador.MovimentaControle.gameObject.SetActive(false);
            
            }
           
            zumbimorto = 0;
            
    }
} 

}
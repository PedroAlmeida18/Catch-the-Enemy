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
   
    private float VelocidadeY;
    Transform transformInimigo;
    public static int zumbimorto = 0;
   
    private float distancia;

    public Controla_Jogador Jogador;

    int vidaInimigo = 150;

    private Camera camera;
    [SerializeField]
    private PoderInimigo prefabPoder;
    private float TempoEmcriacao;
    public BarraVida BarravaidaInimigo;
    public Controla_interface controlaInterface;
    public NovosInimigos novosInimigos;
    public  Propriedades propriedadesInimigo;
    public int ZumbiMortossave;
    public static Controla_Inimigo Instance;
    private ConfigNivelScriptableObject atualConfigNivelScriptableObject;
    private GameController gameController;
    [SerializeField] private List<ConfigNivelScriptableObject> configNivelScriptableObjects;

    void Awake(){
        Instance = this;
    }
    void Start()
    {
        TempoEmcriacao = 0;
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
        VelocidadeY = Random.Range(this.propriedadesInimigo.VelocidadeMinimia, this.propriedadesInimigo.Velocidademax);
        Jogador = Controla_Jogador.Instance;
        BarravaidaInimigo = BarraVida.Instance;
        controlaInterface = Controla_interface.Instance;
        novosInimigos = NovosInimigos.Instance;
        gameController = GameController.Instance;
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
                ZumbiMortossave = zumbimorto;
            }
           

        }
        VerficaVitoria();

   }

   
 

    private void MovimentaInimigo()
    {
        Vector3 direcaoPSeguir = Jogador.transform.position - transformInimigo.position;
        float velocidade = 1.2f;
        float x = Random.Range(-9, 9);
        float y = Random.Range(-4, 4);
        Vector3 novaposicao = new Vector3(x, y, 0);
        transformInimigo.Translate(direcaoPSeguir* Time.deltaTime * velocidade);

    }

   

    public void TiroInimigor()
    {
        // calcular distancia
        distancia = Vector2.Distance(transformInimigo.position, Jogador.transform.position);

        if (distancia >= this.propriedadesInimigo.distanciaMinima)
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
        atualConfigNivelScriptableObject = configNivelScriptableObjects[gameController.NivelSelecionado];
        if(zumbimorto == atualConfigNivelScriptableObject.QuantidadeInimigos){
            controlaInterface.PainelVitoria.gameObject.SetActive(true);
           
            if(controlaInterface.PainelVitoria.activeSelf){
                Jogador.MovimentaControle.gameObject.SetActive(false);
            
            }
           
            zumbimorto = 0;
            
    }
} 

}
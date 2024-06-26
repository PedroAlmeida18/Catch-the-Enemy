using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Controla_Jogador : MonoBehaviour
{
    [SerializeField] private AudioSource MusicaDerrota;
    public FixedJoystick MovimentaControle;
    Rigidbody2D rigidbody2D_Jogador;
    public Transform transformjogador;
    public float velocidade;
    public GameObject Poder;
    public bool Vivo = true;
    public bool Andando = false;
    public GameObject Jogador;
    private Animator animatorJogador;
    public float vida = 100.0f;
    
    private Camera camera;
    [SerializeField]
    private Controla_Poder prefabPoder;

    public static Controla_Jogador Instance;
    [SerializeField] private Slider sliderVida;
    public Controla_interface controlaInteface;
    public SaveData SaveJogador;
    [SerializeField] private AudioSource Musicatiro;
    [SerializeField] private AudioSource Somdano;
    [SerializeField] private AudioSource MusicaVitoria;
    private ConfigNivelScriptableObject atualConfigNivelScriptableObject;
    private GameController gameController;
    [SerializeField] private List<ConfigNivelScriptableObject> configNivelScriptableObjects;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main;
        rigidbody2D_Jogador = GetComponent<Rigidbody2D>();
        transformjogador = GetComponent<Transform>();
        animatorJogador = GetComponent<Animator>();
        controlaInteface = Controla_interface.Instance;
        SaveJogador = SaveData.instance;
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentaJogador();
        #if !UNITY_EDITOR
        TiroCompoderAndroid();
        #else 
        TiroCompoderPc();
        #endif
        Ativasom();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("Covas"))
        {
            if (vida > 0)
            {

                atualConfigNivelScriptableObject = configNivelScriptableObjects[gameController.NivelSelecionado];
                vida = vida - 15;
                AlteraVida(vida);
                if (vida <= 0)
                {
                    AlteraVida(vida);
                    animatorJogador.SetBool("Vivo", false);
                    controlaInteface.PainelGaMEOVER.gameObject.SetActive(true);
                    MusicaDerrota.Play();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("BolaSangue"))
        {
            if (vida > 0)
            {
                atualConfigNivelScriptableObject = configNivelScriptableObjects[gameController.NivelSelecionado];
                vida = vida - atualConfigNivelScriptableObject.DanoInimihoFases;;
                AlteraVida(vida);
                Somdano.Play();
                Destroy(collider2D.gameObject);
                if (vida <= 0)
                {
                    AlteraVida(vida);
                    animatorJogador.SetBool("Vivo", false);
                    controlaInteface.PainelGaMEOVER.gameObject.SetActive(true);
                    MusicaDerrota.Play();
                }
            }
        }
    }

    private void MovimentaJogador()
    {
        float eixoX = MovimentaControle.Horizontal;
        float eixoy = MovimentaControle.Vertical;
        Vector3 novaposicao = new Vector3(eixoX, eixoy, 0);
        transformjogador.Translate(novaposicao * velocidade * Time.deltaTime);
        animatorJogador.SetBool("Movimenta", novaposicao != Vector3.zero);
    }

    public void TiroCompoderAndroid()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 posicaomouse = touch.position;
                    Vector3 posicaomouseNoMundo = this.camera.ScreenToWorldPoint(posicaomouse);
                    posicaomouseNoMundo.z = 0;

                    Vector3 direcaoPoder = (posicaomouseNoMundo - transformjogador.position).normalized;

                    int ajustarDistanciaDoTiroDoInimigo = 1;
                    Controla_Poder NovoPoder = Instantiate(prefabPoder, transformjogador.position + (direcaoPoder * ajustarDistanciaDoTiroDoInimigo), Quaternion.identity);
                    NovoPoder.MoverPoder(direcaoPoder);
                    Musicatiro.Play();
                }
            }
        }
    }

    public void TiroCompoderPc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicaomouse = Input.mousePosition;
            Vector3 posicaomouseNoMundo = this.camera.ScreenToWorldPoint(posicaomouse);
            posicaomouseNoMundo.z = 0;

            Vector3 direcaoPoder = (posicaomouseNoMundo - transformjogador.position).normalized;

            int ajustarDistanciaDoTiroDoInimigo = 1;
            Controla_Poder NovoPoder = Instantiate(prefabPoder, transformjogador.position + (direcaoPoder * ajustarDistanciaDoTiroDoInimigo), Quaternion.identity);
            NovoPoder.MoverPoder(direcaoPoder);
            Musicatiro.Play();
        }
    }

    public void AlteraVida(float vida)
    {
        sliderVida.value = vida;
    }

    private void Ativasom()
    {
        if (controlaInteface.PainelVitoria.activeSelf)
        {
            MusicaVitoria.Play();
        }
    }
}

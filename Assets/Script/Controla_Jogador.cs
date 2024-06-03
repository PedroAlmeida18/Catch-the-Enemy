using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Controla_Jogador : MonoBehaviour
{
    [SerializeField] private AudioSource MusicaDerrota;
    public FixedJoystick MovimentaControle ;
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
        SaveJogador = SaveData.Instance;
    }

    // Update is called once per frame
    void Update()

    {
        #if !UNITY_EDITOR
        TiroCompoderAndroid();
        #else 
        TiroCompoderPc();
        #endif

        MovimentaJogador();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            if (vida > 0)
            {
                vida = vida - 5;
                AlteraVida(vida);
            }
            if (vida == 0)
            {
                AlteraVida(vida);
               // Poder.SetActive(false);
                animatorJogador.SetBool("Vivo", false);
                
                
            }
        if(collision.gameObject.CompareTag("Covas")){
            if (vida > 0)
            {
                vida = vida - 5;
                AlteraVida(vida);
            }
            if (vida == 0)
            {
                AlteraVida(vida);
               // Poder.SetActive(false);
                animatorJogador.SetBool("Vivo", false);
                
                
            }

        }


        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.gameObject.CompareTag("BolaSangue"))
        {
            if (vida > 0)
            {
                vida = vida - 10;
                AlteraVida(vida);
                Destroy(collider2D.gameObject);
                
            }
            if (vida == 0)
            {
                AlteraVida(vida);
                animatorJogador.SetBool("Vivo", false);
                 Destroy(collider2D.gameObject);
                controlaInteface.PainelGaMEOVER.gameObject.SetActive(true);
                MusicaDerrota.gameObject.SetActive(true);

               //  Poder.SetActive(false);

            }
        }
    }
    private void MovimentaJogador()
    {

        velocidade = 5.0f;
       // float eixoX = Input.GetAxis("Horizontal");
        //float eixoy = Input.GetAxis("Vertical");
        float eixoX = MovimentaControle.Horizontal;
        float eixoy = MovimentaControle.Vertical;
        Vector3 novaposicao = new Vector3(eixoX, eixoy, 0);
        transformjogador.Translate(novaposicao * velocidade * Time.deltaTime);
        if (novaposicao != Vector3.zero)
        {
            animatorJogador.SetBool("Movimenta", true);
        }
        else
        {
            animatorJogador.SetBool("Movimenta", false);
        }


    }
    public void TiroCompoderAndroid()
    {
        if (Input.touchCount>0)
        {
            Touch toqueTiro = Input.GetTouch(1);
            Vector2 posicaomouse = toqueTiro.position;
            Vector3 posicaomouseNoMundo = this.camera.ScreenToWorldPoint(posicaomouse);
            posicaomouseNoMundo.z = 0;

            Vector3 direcaoPoder = (posicaomouseNoMundo - transformjogador.position);
            direcaoPoder = direcaoPoder.normalized;

           
           
            int ajustarDistanciaDoTiroDoInimigo = 1;
            Controla_Poder NovoPoder = Instantiate(prefabPoder, transformjogador.position + (direcaoPoder * ajustarDistanciaDoTiroDoInimigo), Quaternion.identity);
            NovoPoder.MoverPoder(direcaoPoder);


        }

    }
    public void TiroCompoderPc(){
         
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicaomouse = Input.mousePosition;
            Vector3 posicaomouseNoMundo = this.camera.ScreenToWorldPoint(posicaomouse);
            posicaomouseNoMundo.z = 0;

            Vector3 direcaoPoder = (posicaomouseNoMundo - transformjogador.position);
            direcaoPoder = direcaoPoder.normalized;



            int ajustarDistanciaDoTiroDoInimigo = 1;
            Controla_Poder NovoPoder = Instantiate(prefabPoder, transformjogador.position + (direcaoPoder * ajustarDistanciaDoTiroDoInimigo), Quaternion.identity);
            NovoPoder.MoverPoder(direcaoPoder);


        }

    }
      private void AlteraVida(float vida){
        sliderVida.value = vida;
    }
    }
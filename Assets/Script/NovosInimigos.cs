using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;

public class NovosInimigos : MonoBehaviour
{
    public Controla_Inimigo Inimigos;
    private float TempoEmcriacao;
    public int quantidadeInimigosFase1;
    [SerializeField] private int duvida;
    public int SalvarQuantidadeInimigos;
    public static NovosInimigos Instance;
    [SerializeField] private List<ConfigNivelScriptableObject> configNivelScriptableObjects;
    private ConfigNivelScriptableObject atualConfigNivelScriptableObject;
    private GameController gameController;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameController = GameController.Instance;

        StartCoroutine(criacaoInimigoCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //criacoInimigos();
    }

    private IEnumerator criacaoInimigoCoroutine()
    {
        atualConfigNivelScriptableObject = configNivelScriptableObjects[gameController.NivelSelecionado];

        Debug.Log("NIVEL ATUAL: " + gameController.NivelSelecionado + 1); // Coloquei o numero um s� para ajuste do numero da fase

        for (int x = 0; x < atualConfigNivelScriptableObject.QuantidadeInimigos; x++)
        {
            float eixox = Random.Range(-6, 8);
            float eixoy = Random.Range(-3.7f,3.7f);
            Vector2 psocaoInimigo = new Vector2(eixox, eixoy);

            yield return new WaitForSeconds(atualConfigNivelScriptableObject.PegarInimigo.PropriedadesInimigo.TempoDecriacao);

            Controla_Inimigo _Inimigo = Instantiate(atualConfigNivelScriptableObject.PegarInimigo.InimigoPrefab, psocaoInimigo, Quaternion.identity);
            _Inimigo.novosInimigos = this;
            _Inimigo.propriedadesInimigo = atualConfigNivelScriptableObject.PegarInimigo.PropriedadesInimigo;
            quantidadeInimigosFase1++;
            SalvarQuantidadeInimigos = quantidadeInimigosFase1;

            Debug.Log("quantidade de Inimgos criados foi :" + quantidadeInimigosFase1);
        }
    }



}

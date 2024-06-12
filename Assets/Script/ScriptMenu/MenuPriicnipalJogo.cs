using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuPriicnipalJogo : MonoBehaviour
{

[SerializeField] private GameObject PainelMneuInicial;
[SerializeField] private GameObject PainelOpções;
[SerializeField] public AudioSource MusicaFundo;
[SerializeField] private AudioSource FaseSelecionada;
public SceneField sceneField;
public static MenuPriicnipalJogo Instance;
    void Awake(){
        Instance=this;
        DontDestroyOnLoad(MusicaFundo.gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Jogar(){
        SceneManager.LoadScene(sceneField.SceneName);
    }
    public void Opcoes(){
        FaseSelecionada.Play();
        PainelMneuInicial.SetActive(false);
        PainelOpções.SetActive(true);
    }
    public void SairOpcoes(){
        FaseSelecionada.Play();
        PainelOpções.SetActive(false);
        PainelMneuInicial.SetActive(true);

    }
    public void Sair(){
        FaseSelecionada.Play();
        Debug.Log("Saindo do Jogo");
        Application.Quit();

    }
    public void ControleVolume(float valor){
        MusicaFundo.volume = valor;
    }

}

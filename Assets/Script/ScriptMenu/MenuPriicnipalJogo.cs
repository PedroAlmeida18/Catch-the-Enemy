using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPriicnipalJogo : MonoBehaviour
{

[SerializeField] private GameObject PainelMneuInicial;
[SerializeField] private GameObject PainelOpções;
[SerializeField] private AudioSource MusicaFundo;
public SceneField sceneField;
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
        PainelMneuInicial.SetActive(false);
        PainelOpções.SetActive(true);


    }
    public void SairOpcoes(){
        PainelOpções.SetActive(false);
        PainelMneuInicial.SetActive(true);

    }
    public void Sair(){
        Debug.Log("Saindo do Jogo");
        Application.Quit();

    }
    public void ControleVolume(float valor){
        MusicaFundo.volume = valor;

    }
}

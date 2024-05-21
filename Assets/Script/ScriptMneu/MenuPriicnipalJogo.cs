using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPriicnipalJogo : MonoBehaviour
{
 [SerializeField] private string NomeDoLevalDeJogo;
  [SerializeField] private GameObject PainelMneuInicial;
 [SerializeField] private GameObject PainelOpções;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Jogar(){
        SceneManager.LoadScene(NomeDoLevalDeJogo);
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
}

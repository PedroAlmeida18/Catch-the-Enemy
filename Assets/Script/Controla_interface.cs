using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class Controla_interface : MonoBehaviour
{
    public GameObject PainelGaMEOVER;
    public GameObject PainelVitoria;
    public GameObject PainelPause;
    public SceneField sceneField;
    public SceneField Fase;
    public SceneField TelaFases;
    public float tempo = 100f;
    public static Controla_interface Instance;
    private GameController _gameController;

    void Awake(){
         Instance = this;
    }
    void Start()
    {
      _gameController = GameController.Instance;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void Reiniciar(){

        SceneManager.LoadScene(_gameController.NivelSelecionado);
    }
    public void proximaFase(){
        _gameController.SetarNivelSelecionado(_gameController.NivelSelecionado+1);
         SaveData.instance.Save();
        SceneManager.LoadScene(Fase.SceneName);
        PainelVitoria.SetActive(false);
        if(_gameController.NivelSelecionado == 5){
            SaveData.instance.Save();
            SceneManager.LoadScene(TelaFases.SceneName);
            PainelVitoria.SetActive(false);
        }
   
       
    }
    
    public void ativarPause(){
        Time.timeScale = 0;
        PainelPause.gameObject.SetActive(true);

    }
    public void desativarPause(){
        Time.timeScale=1;
        PainelPause.gameObject.SetActive(false);
    }
    public void VoltaTelaFases(){
        SceneManager.LoadScene(TelaFases);
    }
    public void VoltarFase(){
        _gameController.SetarNivelSelecionado(_gameController.NivelSelecionado);
        SceneManager.LoadScene(Fase.SceneName);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Controla_interface : MonoBehaviour
{
    
    
    public GameObject PainelGaMEOVER;
    public GameObject PainelVitoria;
    public GameObject PainelPause;
    public SceneField sceneField;
    public SceneField Fase2;
    public float tempo = 100f;
    public static Controla_interface Instance;


    void Awake(){
         Instance = this;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
            
    }
 
    public void Reiniciar(){
        SceneManager.LoadScene(sceneField.SceneName);
    }
    public void proximaFase(){
        SceneManager.LoadScene(Fase2.SceneName);
        PainelVitoria.SetActive(false);
    }
    
    public void ativarPause(){
        Time.timeScale = 0;
        PainelPause.gameObject.SetActive(true);

    }
    public void desativarPause(){
        Time.timeScale=1;
        PainelPause.gameObject.SetActive(false);
    }

}
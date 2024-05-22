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
  
  public SceneField sceneField;
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
        print("Você venceu ");
    }
}
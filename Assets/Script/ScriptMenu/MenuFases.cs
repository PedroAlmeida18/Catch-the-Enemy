using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFases : MonoBehaviour
{
    public SceneField fase1;
    public SceneField fase2;
    public SceneField fase3;
    public SceneField fase4;
    public SceneField fase5;
    public SceneField voltar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fase1(){
        SceneManager.LoadScene(fase1.SceneName);
    }
    public void Fase2(){
         SceneManager.LoadScene(fase2.SceneName);
    }
     public void Fase3(){
        SceneManager.LoadScene(fase3.SceneName);
    }
     public void Fase4(){
         SceneManager.LoadScene(fase4.SceneName);
    }
     public void Fase5(){
         SceneManager.LoadScene(fase5.SceneName);
    }
    public void voltarEntrada(){
    SceneManager.LoadScene(voltar.SceneName);
    }

}

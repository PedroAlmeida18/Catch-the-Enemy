using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFases : MonoBehaviour
{
    public SceneField fase1;
    public SceneField voltar;
    private GameController _gameController;
    [SerializeField] private AudioSource Faseselecionada;
     public List<Button> faseButtons;
     public MenuPriicnipalJogo audio;

    private void Start()
    {
        _gameController = GameController.Instance;
        Faseselecionada.Play();
         AtualizarMenuFases();
         audio=MenuPriicnipalJogo.Instance;
    }

    private void AtualizarMenuFases()
    {
        int nivelDesbloqueado = SaveData.instance.GetNivelDesbloqueado();

        for (int i = 0; i < faseButtons.Count; i++)
        {
            faseButtons[i].interactable = i <= nivelDesbloqueado;
        }
    }


    public void Fase1()
    {
        _gameController.SetarNivelSelecionado(0);
        SceneManager.LoadScene(fase1.SceneName);
         Faseselecionada.Play();
    }

    public void Fase2()
    {
        _gameController.SetarNivelSelecionado(1);
        SceneManager.LoadScene(fase1.SceneName);
         Faseselecionada.Play();
    }

    public void Fase3()
    {
        _gameController.SetarNivelSelecionado(2);
        SceneManager.LoadScene(fase1.SceneName);
         Faseselecionada.Play();
    }

    public void Fase4()
    {
        _gameController.SetarNivelSelecionado(3);
        SceneManager.LoadScene(fase1.SceneName);
         Faseselecionada.Play();
    }

    public void Fase5()
    {
        _gameController.SetarNivelSelecionado(4);
        SceneManager.LoadScene(fase1.SceneName);
         Faseselecionada.Play();
    }

    public void voltarEntrada()
    {
        SceneManager.LoadScene(voltar.SceneName);
        Faseselecionada.Play();
        Destroy(audio.MusicaFundo.gameObject);
         
    }
    public void Load(){
        SaveData.instance.LoadPrefs();
    }
     public void DeletarProgresso()
    {
        SaveData.instance.Delete();
        AtualizarMenuFases(); 
    }
}

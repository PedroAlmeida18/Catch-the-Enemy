using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFases : MonoBehaviour
{
    public SceneField fase1;
    public SceneField voltar;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.Instance;
    }

    public void Fase1()
    {
        _gameController.SetarNivelSelecionado(0);
        SceneManager.LoadScene(fase1.SceneName);
    }

    public void Fase2()
    {
        _gameController.SetarNivelSelecionado(1);
        SceneManager.LoadScene(fase1.SceneName);
    }

    public void Fase3()
    {
        _gameController.SetarNivelSelecionado(2);
        SceneManager.LoadScene(fase1.SceneName);
    }

    public void Fase4()
    {
        _gameController.SetarNivelSelecionado(3);
        SceneManager.LoadScene(fase1.SceneName);
    }

    public void Fase5()
    {
        _gameController.SetarNivelSelecionado(4);
        SceneManager.LoadScene(fase1.SceneName);
    }

    public void voltarEntrada()
    {
        SceneManager.LoadScene(voltar.SceneName);
    }
}

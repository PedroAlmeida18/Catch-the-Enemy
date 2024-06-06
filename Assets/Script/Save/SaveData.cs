using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int Nivel;

    public static SaveData instance;
    private GameController _gameController;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        _gameController = GameController.Instance;
        
    }

    void Update()
    {
        Nivel = _gameController.NivelSelecionado;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("NivelAtualDesbloqueado", Nivel);
        Debug.Log("Salvou o nivel atual do Jogador: " + Nivel);
    }

    public void LoadPrefs()
    {
        Nivel = PlayerPrefs.GetInt("NivelAtualDesbloqueado", 0); // Padrão para 0 se não estiver definido
        Debug.Log("Nivel que está desbloqueado é: " + Nivel);
    }

    public int GetNivelDesbloqueado()
    {
        return PlayerPrefs.GetInt("NivelAtualDesbloqueado", 0); // Padrão para 0 se não estiver definido
    }
     public void Delete()
    {
        PlayerPrefs.DeleteKey("NivelAtualDesbloqueado");
        Debug.Log("Progresso deletado.");
    }
}

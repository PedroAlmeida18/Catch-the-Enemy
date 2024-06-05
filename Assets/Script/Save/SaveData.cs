using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int Nível;
    public float vidaJogador;
    public int ZumbiMortos;
    public static SaveData instance;
    private Controla_Inimigo DadosInimigo;
    private Controla_Jogador DaddosJogador;
    private GameController _gameController;

    void Awake()
    {
            instance = this;
    }

   public  void Load()
    {
        DadosInimigo = Controla_Inimigo.Instance;
        DaddosJogador = Controla_Jogador.Instance;
        _gameController = GameController.Instance;
        print("Vida do Jogador é : " + DaddosJogador);
        print("Nivel é :" + Nível + 1 );
    }

    void Update()
    {
        vidaJogador = DaddosJogador.vida;
        Nível = _gameController.NivelSelecionado;
    }
}

using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _nivelSelecionado;

    public int NivelSelecionado { get { return _nivelSelecionado; } set { _nivelSelecionado = value; } }

    public static GameController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetarNivelSelecionado(int nivelSelecionado)
    {
        NivelSelecionado = nivelSelecionado;
    }
}

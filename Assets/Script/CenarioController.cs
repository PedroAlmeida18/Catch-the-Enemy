using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cenarios;

   [SerializeField] private GameController gameController;

    private void Start()
    {
        gameController = GameController.Instance;

        // Desativa todos antes de ativar o atual
        foreach (GameObject cenarioAtual in cenarios)
        {
            cenarioAtual.gameObject.SetActive(false);
        }

        AtivarCenarioAtual(gameController.NivelSelecionado);
    }

    private void AtivarCenarioAtual(int index)
    {
        cenarios[index].gameObject.SetActive(true);
    }
}

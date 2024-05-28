using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigInimigo", menuName = "ScriptableObjects/ConfigInimigo", order = 1)]
public class ConfiguracaoInimigo : ScriptableObject
{

    [SerializeField] private Controla_Inimigo inimigo;
    [SerializeField] private Propriedades propriedadeinimigo;
    public Controla_Inimigo InimigoPrefab{
        get {
            return this.inimigo;
        }
    }
    public Propriedades PropriedadesInimigo{
        get {
            return this.propriedadeinimigo;
        }
    }
}

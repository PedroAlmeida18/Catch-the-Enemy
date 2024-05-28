using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = " ConfigNivelScriptableObject", menuName = "ScriptableObjects/ConfigNivelScriptableObject", order = 1)]
public class ConfigNivelScriptableObject : ScriptableObject

{
    [SerializeField] private ConfiguracaoInimigo inimigo;
    [SerializeField] private int quantidadeInimigosFase;

    public ConfiguracaoInimigo PegarInimigo{
        get {
            return this.inimigo;
        }
    }
    public int QuantidadeInimigos{
        get{
            return this.quantidadeInimigosFase;
        }
    }

}

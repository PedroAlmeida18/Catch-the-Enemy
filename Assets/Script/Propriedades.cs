using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Propriedades", menuName = "ScriptableObjects/Propriedades", order = 1)]

public class Propriedades : ScriptableObject
{
    
    [SerializeField] public float velocidadeMinimia ;
    [SerializeField] public float velocidadeMaxima ;
    [SerializeField] private float distanciaMin;
    [SerializeField] private float vidaInimigo_Propriedade;
    [SerializeField] private float Tempodecriacao;
    [SerializeField] private float DanoCausado;

    public float VelocidadeMinimia {
        get{
            return this.velocidadeMinimia;
        }
    }
     public float Velocidademax {
        get{
            return this.velocidadeMaxima;
        }
    }
    public float distanciaMinima{
        get{
            return this.distanciaMin;
        }
    }
    public float vidaInimigo_PROP{
        get{
            return this.vidaInimigo_Propriedade;
        }
    }
    public float TempoDecriacao{
        get{
            return this.Tempodecriacao;
        }
    }
    public float DanoCusadoPeloInimigo{
        get{
            return this.DanoCausado;
        }
    }
    
}

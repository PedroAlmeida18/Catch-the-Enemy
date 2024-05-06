using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Inimigo : MonoBehaviour
{
     Rigidbody2D rigidbody2D_inimigo;
    Transform transformInimigo;

    public GameObject prefabDoObjeto;
    void Start()
    {
        transformInimigo = GetComponent<Transform>();
        rigidbody2D_inimigo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentaInimigo();
    }
    private void MorteInimigo(){
        
    }
    private void MovimentaInimigo(){
        float  velocidade = 0.5f;
        float x = Random.Range(-9,9);
        float y = Random.Range(-4,4);
         Vector3 novaposicao = new Vector3(x,y,0);
        transformInimigo.Translate(novaposicao*Time.deltaTime*velocidade);
    }

}

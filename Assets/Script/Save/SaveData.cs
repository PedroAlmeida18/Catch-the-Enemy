using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public  static int Nivel ;
    public  static int vidaJoga;
    public string  name ;
    [SerializeField]private GameObject [] Datas ;
     public Controla_Jogador Salvarjogador;
     public static SaveData Instance;
    void Awake (){
        Instance= this;
        Datas = GameObject.FindGameObjectsWithTag("Data");
        if(Datas.Length>=2){
            Salvarjogador.vida = vidaJoga;
            Destroy (Datas[0]);

            
        }
        if(Input.GetKeyDown("w")){
            PlayerPrefs.SetInt("Vida", vidaJoga);
        }
        DontDestroyOnLoad(transform.gameObject);


    }
    
    void Start()
    {
        Salvarjogador = Controla_Jogador.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

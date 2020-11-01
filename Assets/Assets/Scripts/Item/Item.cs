using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item",menuName ="Item")]
public class Item : ScriptableObject
{
    public string textItem;
    
    public Sprite imagemItem;
    
    
    public ItemName nomeItem=ItemName.N_Interative;
    public AudioClip clipSom;
    public bool pegou;
    
     
    public  virtual void UsarItem(VariavelGames vargeral)
    {

    }

  

   
   
}

public enum ItemName
{
    Camera,
    Chave,
    N_Interative,
    Cartao,
    Foto1,
    Foto2,
    Foto3,
    Foto4,
    FotoMetade,
    FotoInteira,
    Medalhao1,
    Medalhao2,
    Medalhao3,
    Medalhao4,
    Pagina
}

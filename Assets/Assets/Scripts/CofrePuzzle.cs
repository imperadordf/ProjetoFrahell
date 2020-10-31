using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CofrePuzzle : MonoBehaviour
{
    public List<int> listadeNumeroCertos;
    public int[] listaNumeroBotao = new int[4]
    {
        0,0,0,0
    };
    public TextMeshProUGUI TextCofre;
    string textNumeros;
    bool tentou;
    public Item itemGanha;
    private PuzzleRei puzzleScript;
    public AudioSource audiosource;
    public AudioClip somConcluir;
    public AudioClip somApertou;
    public AudioClip somErrou;
    private void Start()
    {
        TextCofre.text = "Digite";
        TextCofre.alignment = TextAlignmentOptions.Center;
        TextCofre.characterSpacing = 0;
    }

    public void PegarPuzzle(PuzzleRei script)
    {
        puzzleScript = script;
    }
    public void RecebeNumero(int numero)
    {
        TextCofre.characterSpacing = 120;
        TextCofre.alignment = TextAlignmentOptions.Left;
        if (tentou)
        {
            Cancelar();
            tentou = false;
           
        }
       
        for(int i = 0; i<listaNumeroBotao.Length;i++)
        {
            if (listaNumeroBotao[i] == 0)
            {
                listaNumeroBotao[i] = numero;
                textNumeros += listaNumeroBotao[i];
                break;
            }

        }

        TextCofre.text = textNumeros;
        audiosource.PlayOneShot(somApertou);
        audiosource.volume = 1;
    }

    public void Cancelar()
    {

        for (int i = 0; i < listaNumeroBotao.Length; i++)
        {

            listaNumeroBotao[i] = 0;

        }
        textNumeros = "";
        TextCofre.text = textNumeros;
      
    }


    public void Confirmar()
    {
        int cont = 0;
        for (int i = 0; i < listaNumeroBotao.Length; i++)
        {
            if (listaNumeroBotao[i] == listadeNumeroCertos[i])
            {
                cont++;
            }
        
        }
        if (cont == 4)
        {
            TextCofre.alignment = TextAlignmentOptions.Center;
            TextCofre.text = "Correto";
            TextCofre.characterSpacing = 0;
            GerenciadorItem.instacie.ReceberItem(itemGanha);
            audiosource.PlayOneShot(somConcluir);
            audiosource.volume = 0.4f;
            StartCoroutine(Concluiur());
          
        }
        else
        {
            TextCofre.text = "Incorreto";
            TextCofre.characterSpacing = 0;
            tentou = true;
            cont = 0;
            TextCofre.alignment = TextAlignmentOptions.Center;
            audiosource.PlayOneShot(somErrou);
            audiosource.volume = 0.4f;
        }

    }

   IEnumerator Concluiur()
    {      
        yield return new WaitForSecondsRealtime(1.2f);
        puzzleScript.Concluiu();
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScriptLoading : MonoBehaviour
{
    public static ScriptLoading instancie;
    public bool carregou;
    public GameObject textLoading;
    public GameObject loading;


    [Header("Referencia sobre a dica")]
    public Image imagemItem;
    public TextMeshProUGUI textItem;

    public TextMeshProUGUI textItemName;

    [Header("Lista de Dica")]
    public List<DicasGame> dicaslist = new List<DicasGame>();
    private void Awake()
    {
        if (!instancie)
        {
            instancie = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    

    private void Start()
    {
        gameObject.SetActive(false);
       DicaAleatoria();
    }

    private void DicaAleatoria()
    {
      int i =  Random.Range(0,dicaslist.Count);
      textItem.text = dicaslist[i]?.dicaText;
      imagemItem.sprite = dicaslist[i]?.imageItem;
      textItemName.text = dicaslist[i]?.nameItem;
    }

    private void Update()
    {
        if (Input.anyKeyDown && carregou)
        {
            FecharLoading();
        }
    }
    

    public void AtivarLoad(string NomeDaFase)
    {
        textLoading.SetActive(false);
        gameObject.SetActive(true);
        loading.SetActive(true);
        StartCoroutine(CarregarFase(NomeDaFase));
    }

   IEnumerator CarregarFase(string NomeDaFase)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(NomeDaFase);
        while (!carregamento.isDone)
        {
            carregou = false;
            yield return null;
        }
        GameManager.instancie.ativarloading = true;
        loading.SetActive(false);
        carregou = true;
        textLoading.SetActive(true);
    }

    private void FecharLoading()
    {
        gameObject.SetActive(false);
        GameManager.instancie.ativarloading = false;
    }

}

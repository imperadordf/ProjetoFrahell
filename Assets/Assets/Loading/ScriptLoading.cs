using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptLoading : MonoBehaviour
{
    public static ScriptLoading instancie;
    public bool carregou;
    public GameObject textLoading;
    public GameObject loading;
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
        Time.timeScale = 0;
        loading.SetActive(false);
        carregou = true;
        textLoading.SetActive(true);
    }

    private void FecharLoading()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Image damageUi;
    public Image itemImagem;
    public Animator animeItem;

    public Sprite maozinhaCurso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InterfaceDano()
    {
        damageUi.enabled = true;
        yield return new WaitForSeconds(0.5f);
        damageUi.enabled = false;
    }

    public void ApareceuItem(Item item)
    {
        itemImagem.sprite=item.imagemItem;
        animeItem.gameObject.SetActive(true);
        animeItem.enabled = true;
        animeItem.Play("Painel_aparece", 0);
    }

}

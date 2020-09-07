using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorItem : MonoBehaviour
{
    public static GerenciadorItem instacie;
    public  TextMeshProUGUI textItem;
    public Image imageItem;
    public GameObject inventarioCanvas;
    private void Awake()
    {
        if (!instacie)
        {
            instacie = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    public List<ButtonItem> listButtonitens;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instancie.ativarInventario = !GameManager.instancie.ativarInventario;
            
            inventarioCanvas.SetActive(GameManager.instancie.ativarInventario);
        }
    }
    public void ReceberItem(Item item)
    {
        StartCoroutine(RecebeitemConstratine(item));
    }

    IEnumerator RecebeitemConstratine(Item item)
    {
        foreach(ButtonItem itens in listButtonitens)
        {
            if (itens.RetornItem() == null)
            {
                itens.RecebeItem(item);
                break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void ClicouItem(Item item)
    {
        textItem.text = item.textItem;
        imageItem.sprite = item.imagemItem;
    }
}

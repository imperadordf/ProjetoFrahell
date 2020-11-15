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
    Item itemSelecionado;
    public RawImage itemExpandir;
    GameObject itemObjectInstancie;
    public GameObject itemExpadirObject;
   public TelaExpadir itensExpadinScript;
    public GameObject PanelExpadir;
    // Verificador se esta dentro da area para usar o Item
    public bool useritemArea = false;
    public VariavelGames variaveGeral = new VariavelGames();
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
            FecharTela();
        }

    }

    public void FecharTela()
    {
        GameManager.instancie.ativarInventario = !GameManager.instancie.ativarInventario;
        inventarioCanvas.SetActive(GameManager.instancie.ativarInventario);
        ExpandirItemSair();
    }
    public void ReceberItem(Item item)
    {
        StartCoroutine(RecebeitemConstratine(item));
    }

    IEnumerator RecebeitemConstratine(Item item)
    {
        foreach(ButtonItem itens in listButtonitens)
        {
            if (itens.RetornItem()==null)
            {
                itens.RecebeItem(item);
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ClicouItem(Item item)
    {
        itemSelecionado = item;
        textItem.text = item.textItem;
        imageItem.sprite = item.imagemItem;
        itemSelecionado = item;
    }

    public void UsarItem()
    {
        switch (itemSelecionado.nomeItem)
        {
            case ItemName.N_Interative:
                break;
            case ItemName.Camera:
                FecharTela();
                break;
            case ItemName.Chave:
                if (useritemArea)
                {
                    variaveGeral.scriptPorta.locked = false;
                    FecharTela();
                }
                break;
            case ItemName.Cartao:
                if (useritemArea)
                {
                    variaveGeral.cofre.locked = false;
                    FecharTela();
                }
                break;
            default:
                break;

        }

    }

    public void ExpandirItem()
    {
       
        itensExpadinScript.ExpadirItem(itemSelecionado.nomeItem);
        itemObjectInstancie = Instantiate(itemExpadirObject, GameManager.instancie.playerscript.SpawnItem.transform.position, Quaternion.identity);
        inventarioCanvas.SetActive(false);
        itemExpandir.texture = itensExpadinScript.textureItem;
        PanelExpadir.SetActive(true);
        
    }

    public void ExpandirItemSair()
    {
        inventarioCanvas.SetActive(GameManager.instancie.ativarInventario);
        PanelExpadir.SetActive(false);
        itensExpadinScript.Fechartelas();
        Destroy(itemObjectInstancie);
       // itensExpadinScript = null;

    }

   
}

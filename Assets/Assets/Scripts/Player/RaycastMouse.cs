﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastMouse : MonoBehaviour
{
    public LayerMask layer;
    public Image mouseImagem;
    public Camera cam;

    [Header("Sprite do Cursor")]
    public Sprite mouseMao;
    public Sprite spritePorta;
    public Sprite PadraoSprite;
    public Sprite spritePuzzle;

    GetItem itemGet;
    Item item;
    GameObject itemObject;
    public float tamanhaRaycast;
    private MateriaInterative itemselecionado;
    public Player scriptPlayer;
    private void FixedUpdate()
    {
        RaycastHit hit;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if ((Physics.Raycast(ray, out hit, tamanhaRaycast, layer)))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (hit.collider.tag)
                {
                    case "Item":
                        scriptPlayer.animator_Player.SetTrigger("PegouItem");
                        itemGet = hit.collider.GetComponent<GetItem>();
                        itemGet.gameObject.layer = 1;
                        item = itemGet.item;
                        itemObject = itemGet.gameObject;
                        break;
                    case "Porta":
                        PortaScript portascript = hit.collider.GetComponent<PortaScript>();
                        GerenciadorItem.instacie.useritemArea = true;
                        if (portascript.locked)
                        {
                            GerenciadorItem.instacie.variaveGeral.scriptPorta = portascript;
                            hit.collider.GetComponent<PortaScript>().OpenTheDoorOurClose();
                        }
                        else
                        {
                            hit.collider.GetComponent<PortaScript>().OpenTheDoorOurClose();

                        }
                        break;
                    case "Turnel":
                        hit.collider.GetComponent<CarregaFase>().PlayAnimation();
                        break;
                    case "TurnelTurnel":
                        hit.collider.GetComponent<CarregaFaseTurnel>().CarregaFase();
                        break;
                    case "Puzzle":
                        hit.collider.GetComponent<PuzzleRei>().PuzzleGo();
                        break;
                    case "Armario":
                        hit.collider.GetComponent<Armario>().AbrirPorta();
                        break;
                    case "Roupa":
                        if (hit.collider.GetComponent<GetItem>())
                        {
                            scriptPlayer.animator_Player.SetTrigger("PegouItem");
                            itemGet = hit.collider.GetComponent<GetItem>();
                            item = itemGet.item;
                            hit.collider.gameObject.layer = 0;
                        }

                        break;
                }
            }
            MudarCurso(hit);
        }
        else
        {
            mouseImagem.sprite = PadraoSprite;
            mouseImagem.transform.localScale = new Vector3(0.1570803f, 0.1570803f, 0.1570803f);
            if (itemselecionado)
            {
                itemselecionado.RaycastFora();
                itemselecionado = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            GerenciadorItem.instacie.variaveGeral.scriptPorta = other.GetComponent<PortaScript>();
            GerenciadorItem.instacie.useritemArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Porta"))
        {
            GerenciadorItem.instacie.useritemArea = false;
        }
    }

    public void PegarItem()
    {
        GerenciadorItem.instacie.ReceberItem(item);
        if(itemObject!=null)
        Destroy(itemObject.gameObject);
    }

    private void MudarCurso(RaycastHit hit)
    {
        switch (hit.collider.tag)
        {
            case "Item":
                mouseImagem.sprite = mouseMao;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                itemselecionado = hit.collider.GetComponent<MateriaInterative>();
                itemselecionado.RaycastEmcima();
                break;
            case "Porta":
                mouseImagem.sprite = spritePorta;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                break;
            case "Turnel":
                mouseImagem.sprite = spritePorta;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                break;
            case "TurnelTurnel":
                mouseImagem.sprite = spritePorta;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                break;
            case "Puzzle":
                mouseImagem.sprite = spritePuzzle;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                break;
            case "Armario":
                mouseImagem.sprite = mouseMao;
                mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                break;
            case "Roupa":
                if (hit.collider.GetComponent<GetItem>())
                {
                    mouseImagem.sprite = mouseMao;
                    mouseImagem.transform.localScale = new Vector3(0.3761445f, 0.3761445f, 0.3761445f);
                    itemselecionado = hit.collider.GetComponent<MateriaInterative>();
                    itemselecionado.RaycastEmcima();
                }
                else
                { 
                    mouseImagem.sprite = PadraoSprite;
                    mouseImagem.transform.localScale = new Vector3(0.1570803f, 0.1570803f, 0.1570803f);
                }
                break;
        }
    }
}

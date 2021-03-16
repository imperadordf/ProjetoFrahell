using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuConfig : MonoBehaviour
{
    //Resolução variavels
    Resolution[] resolutions;
    List<string> optionResolution = new List<string>();
    public TMP_Dropdown dropResolution;

    private void Start()
    {
        Inicialize();
    }

    public void Inicialize()
    {
        
        ConfigPadrao();
        ResolutionGame();
    }


    public void ConfigPadrao()
    {
        
        //PlayerPrefs.SetString("Config","Padrao");
        //Screen.resolutions.Length;
        
    }

    private void ResolutionGame()
    {
        dropResolution.ClearOptions();
        resolutions = Screen.resolutions;
        for (int i =0; i<resolutions.Length;i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            optionResolution.Add(options);
        }

        dropResolution.AddOptions(optionResolution);

    }

    private  void GraphicsGame()
    {

    }
}

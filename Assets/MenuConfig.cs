using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class MenuConfig : MonoBehaviour
{
   
    public void Inicialize()
    {
        ConfigurationUsuario config = (ConfigurationUsuario)SaveDataGame.LoadGame("Configuracao");
        if (config!=null)
        {
            LoadConfig(config);
            isloading = true;
        }
        GraphicsGame();
        ResolutionGame();
        GeneralConfiguration();
        ActionList();
        RefreshShown();      
    }

    //Carregando Informações
    private void LoadConfig(ConfigurationUsuario config)
    {
        isFullScreen = config.graphics.fullscreen;
        currentQuallity = config.graphics.qualidade;
        currentlookSensity = config.general.LookSensitivy;
        InvertUpAxis = config.general.InvertUpAxis;
        currentVolume = config.general.Volume;
        resolutionMy = config.graphics.RetornResolution();
        ConfigAlterada(resolutionMy);
        Debug.Log(config.graphics.resolution_height + "+" + config.graphics.resolution_widht);
    }

    //Pegando todas as resolutions e colocando na lista
    private void ResolutionGame()
    {
        dropResolution.ClearOptions();
        resolutions = Screen.resolutions;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            optionResolution.Add(options);
            if (isloading)
            {
                if (resolutions[i].width == resolutionMy.width &&
             resolutions[i].height == resolutionMy.height)
                {
                    currentResolution = i;
                }
            }
            else
            {
                if (resolutions[i].width == Screen.currentResolution.width &&
              resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolution = i;
                }
            }
         
        }

        dropResolution.AddOptions(optionResolution);
 
    }

    //Pegando todas os graficos  e colocando na lista
    private void GraphicsGame()
    {
        dropQuallity.ClearOptions();
        qualidadeString.Clear();
        for (int i = 0; i<renderesAssets.Length;i++ )
        {
            string renderName = renderesAssets[i].name;
            qualidadeString.Add(renderName);
            if (QualitySettings.GetQualityLevel() == i)
            {
                currentQuallity = i;
            }
        }
        dropQuallity.AddOptions(qualidadeString);
    }

    //Metodo para mostrar os valores no Unity
    private void RefreshShown()
    {
        //Resolução Drop
        dropResolution.value = currentResolution;
        dropResolution.RefreshShownValue();
        //Qualidade Drop
        dropQuallity.value = currentQuallity;
        dropQuallity.RefreshShownValue();
        //Toggle tela cheia
        toggleFullScreen.isOn = isFullScreen;
    }

    private void GeneralConfiguration()
    {
        toggleInvertUpAxis.isOn = InvertUpAxis;
        sliderLookSensity.value=currentlookSensity;
        sliderVolume.value = currentVolume;
    }

    //Add Action em cada botão na Unity usando Lambda Expression
    private void ActionList()
    {
        //Actions Graphics
        dropQuallity.onValueChanged.AddListener(index => currentQuallity = index);
        dropResolution.onValueChanged.AddListener(index =>currentResolution=index);
        toggleFullScreen.onValueChanged.AddListener(value=>isFullScreen=value);

        //Actions General
        sliderLookSensity.onValueChanged.AddListener(index=>currentlookSensity=index);
        sliderVolume.onValueChanged.AddListener(index=>currentVolume=index);
        toggleInvertUpAxis.onValueChanged.AddListener(value=>InvertUpAxis=value);

        //Action Button
        bt_Apply.onClick.AddListener(ApplicationConfig);

        bt_back.onClick.AddListener(()=> this.gameObject.SetActive(false));

        bt_Default.onClick.AddListener(()=> {
            currentResolution = 0;
            isFullScreen = true;
            currentQuallity = 0;
            currentVolume = 1;
            currentlookSensity = 1;
            InvertUpAxis = false;
            ApplicationConfig();
        });

        bt_General.onClick.AddListener(()=> {
            gameObject_General.SetActive(true);
            gameObject_Graphics.SetActive(false);
        });

        bt_Graphics.onClick.AddListener(()=> {
            gameObject_General.SetActive(false);
            gameObject_Graphics.SetActive(true);
        });
    }

    private void ApplicationConfig()
    {
        ConfigAlterada(resolutions[currentResolution]);
        ConfigurationGraphics configGraphicsData = new ConfigurationGraphics(resolution: resolutions[currentResolution], fullscreen: isFullScreen, quality: currentQuallity);
        ConfigurationGeneral configGeneralData = new ConfigurationGeneral(invertUpAxis:InvertUpAxis,lookSensitivy:currentlookSensity,volume:currentVolume);
        ConfigurationUsuario configData = new ConfigurationUsuario(configGraphicsData, configGeneralData);
        SaveDataGame.SaveGame("Configuracao",configData);
    }

    private void ConfigAlterada(Resolution resolution)
    {
        QualitySettings.SetQualityLevel(currentQuallity);
        resolutionMy = resolution;
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);
        PlayerData.InvertUpAxis = InvertUpAxis;
        PlayerData.LookSensitiy = currentlookSensity;
        AudioListener.volume = currentVolume;     
    }


    [Header("Referencias de Objetos")]
    [SerializeField] private GameObject gameObject_General;
    [SerializeField] private GameObject gameObject_Graphics;
   
    //Resolução variavels
    [Header("Graficos")]
    [Header("Resolução")]
    Resolution[] resolutions;
    List<string> optionResolution = new List<string>();
    [SerializeField]
    private TMP_Dropdown dropResolution;
    [SerializeField]
    private Toggle toggleFullScreen;

    //Qualidade 
    [Header("Qualidade")]
    [SerializeField] private TMP_Dropdown dropQuallity;
    [SerializeField] RenderPipelineAsset[] renderesAssets;
    List<string> qualidadeString = new List<string>();

    [Space]
    [Header("General")]
    [SerializeField] private Toggle toggleInvertUpAxis;
    [SerializeField] private Slider sliderLookSensity;
    [SerializeField] private Slider sliderVolume;

    [Space]
    [Header("Botão Confirmar")]
    [SerializeField] private Button bt_General;
    [SerializeField] private Button bt_Graphics;
    [SerializeField] private Button bt_Apply;
    [SerializeField] private Button bt_Default;
    [SerializeField] private Button bt_back;


    //Config minhas configuraçãos
    int currentResolution = 0;
    bool isFullScreen = true;
    int currentQuallity = 0;
    float currentVolume = 1;
    float currentlookSensity = 1;
    bool InvertUpAxis;
    Resolution resolutionMy;
    bool isloading;
}

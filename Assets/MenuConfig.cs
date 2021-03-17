using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class MenuConfig : MonoBehaviour
{
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
    [SerializeField] RenderPipelineAsset [] renderesAssets;
    List<string> qualidadeString = new List<string>();


    [Space]
    [Header("General")]
    [SerializeField] private Toggle toggleInvertUpAxis;
    [SerializeField] private Slider sliderLookSensity;
    [SerializeField] private Slider sliderVolume;

    //Config minhas configuraçãos
    int currentResolution = 0;
    bool isFullScreen=true;
    int currentQuallity = 0;
    float currentVolume = 1;
    float currentlookSensity = 50;
    bool InvertUpAxis;

    private void Start()
    {
        Inicialize();
    }

    public void Inicialize()
    {
        ConfigurationUsuario config = (ConfigurationUsuario)SaveDataGame.LoadGame("Configuracao");
        if (config!=null)
        {
            LoadConfig(config);
        }
        GraphicsGame();
        ResolutionGame();
        GeneralConfiguration();
        ActionList();
        toggleFullScreen.isOn= isFullScreen;
    }

    //Carregando Informações
    private void LoadConfig(ConfigurationUsuario config)
    {
        isFullScreen = config.graphics.fullscreen;
        currentQuallity = config.graphics.qualidade;
        ConfigAlterada(config.graphics.RetornResolution());
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
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        dropResolution.AddOptions(optionResolution);
        dropResolution.value = currentResolution;
        dropResolution.RefreshShownValue();
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
        dropQuallity.value = currentQuallity;
        dropQuallity.RefreshShownValue();
    }

    private void GeneralConfiguration()
    {
        toggleInvertUpAxis.isOn = InvertUpAxis;
        sliderLookSensity.value=currentlookSensity;
        sliderVolume.value = currentVolume;
    }

    //Add Action em cada botão na Unity
    private void ActionList()
    {
        //Actions Graphics
        dropQuallity.onValueChanged.AddListener(SetConfigQuallity);
        dropResolution.onValueChanged.AddListener(SetConfigScreen);
        toggleFullScreen.onValueChanged.AddListener(SetFullScreen);

        //Actions General
        sliderLookSensity.onValueChanged.AddListener(SetConfigLookSensitivy);
        sliderVolume.onValueChanged.AddListener(SetConfigVolume);
        toggleInvertUpAxis.onValueChanged.AddListener(SetConfigInvertAxis);
        
    }


    public void SetFullScreen(bool isfull)
    {
        isFullScreen = isfull;
    }

    public void SetConfigQuallity(int index)
    {
        currentQuallity = index;
    }

    public void SetConfigScreen(int index)
    {
        currentResolution = index;
    }

    public void SetConfigLookSensitivy(float index)
    {
        currentlookSensity = index;
    }
    public void SetConfigVolume(float index)
    {
        currentlookSensity = index;
    }
    public void SetConfigInvertAxis(bool value)
    {
        InvertUpAxis = value;
    }

    public void ApplicationConfig()
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
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);

        var KeyboardMouseY = Input.GetAxis("Mouse Y");
        
    }
}

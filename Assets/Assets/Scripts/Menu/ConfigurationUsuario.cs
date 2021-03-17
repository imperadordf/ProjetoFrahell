using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ConfigurationUsuario
{
    public ConfigurationGraphics graphics;
    public ConfigurationGeneral general;

    public ConfigurationUsuario(ConfigurationGraphics graphics,ConfigurationGeneral general)
    {
        this.graphics = graphics;
        this.general = general;
    }
}

[System.Serializable]
public class ConfigurationGraphics
{
    public int resolution_widht;
    public int resolution_height;
    public bool fullscreen;
    public int qualidade;
    public ConfigurationGraphics(Resolution resolution,bool fullscreen,int quality)
    {
        this.resolution_widht = resolution.width;
        this.resolution_height = resolution.height;
        this.fullscreen = fullscreen;
        this.qualidade = quality;
    }

    public Resolution RetornResolution()
    {
        Resolution resolution = new Resolution();
        resolution.height = resolution_height;
        resolution.width = resolution_widht;
        return resolution;
    }
}

[System.Serializable]
public class ConfigurationGeneral
{
    public bool InvertUpAxis;
    public float LookSensitivy;
    public float Volume;
    public ConfigurationGeneral(bool invertUpAxis,float lookSensitivy,float volume)
    {
        InvertUpAxis = invertUpAxis;
        LookSensitivy = lookSensitivy;
        Volume = volume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class LegendaBasica : PlayableBehaviour
{
    public string legendaTexto;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = legendaTexto;
        text.color = new Color(1, 1, 1, info.weight);
    }
}

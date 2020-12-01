using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LegendaClip : PlayableAsset
{
    public string legendaText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<LegendaBasica>.Create(graph);

        LegendaBasica legendabasica = playable.GetBehaviour();
        legendabasica.legendaTexto = legendaText;

        return playable;
    }
}

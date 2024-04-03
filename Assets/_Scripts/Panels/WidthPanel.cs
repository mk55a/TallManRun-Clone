using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthPanel : TransformPanel
{
    [SerializeField] float widthMultiplier = 0.01f;

    protected override void ApplyPanelEffect(Player player)
    {
        if (transformState == TransformCharacter.Width)
        {
            if (scaleState == ScaleState.Increase)
            {
                player.GetBody().IncreaseWidth(size * widthMultiplier);
            }
            else
            {
                player.gameObject.GetComponent<Player>().GetBody().DecreaseWidth(size * widthMultiplier);
            }
        }
    }

}

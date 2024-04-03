
using UnityEngine;

public class HeightPanel : TransformPanel
{
    [SerializeField] float heightMultiplier = 0.005f;

    protected override void ApplyPanelEffect(Player player)
    {
        if (transformState == TransformCharacter.Height)
        {
            if (scaleState == ScaleState.Increase)
            {
                player.GetBody().IncreaseHeight(size * heightMultiplier);
            }
            else
            {
                player.GetBody().DecreaseHeight(size * heightMultiplier);
            }
        }
    }
}

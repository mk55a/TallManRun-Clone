using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    public TextMeshProUGUI sizeText;
    public GameObject gateParticle;

    public Material yellow;
    public Material green;
    public Color textGreenColor;
    public Color textYellowColor;

    /*public abstract void ActivatePanel(Collider other);*/

    /*protected abstract void ApplyPanelEffect(Player player);*/

    
}
public enum TransformCharacter
{
    Width,
    Height
}
public enum ScaleState
{
    Increase,
    Decrease
}
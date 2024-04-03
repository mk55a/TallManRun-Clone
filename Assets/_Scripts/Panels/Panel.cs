using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Panel : MonoBehaviour
{ 
    public TextMeshProUGUI sizeText;
    public GameObject gateParticle;

    public Material yellow;
    public Material green;
    public Color textGreenColor;
    public Color textYellowColor;

    private float heightMultiplier = 0.005f;
    private float widthMultiplier = 0.01f;

    [Header("Panel Settings")]
    [Space(10)]
    public TransformCharacter transformState;
    public ScaleState scaleState;
    public int size;


    private void Start()
    {
        switch (scaleState)
        {

            case ScaleState.Increase:
                GetComponent<MeshRenderer>().material = green;
                sizeText.color = textGreenColor;
                
                break;

            case ScaleState.Decrease:
                GetComponent<MeshRenderer>().material = yellow;
                sizeText.color = textYellowColor;
                break;

        }
        switch (transformState)
        {

            case TransformCharacter.Width:
                if(scaleState == ScaleState.Increase)
                {
                    sizeText.text = "+" + size.ToString();
                }
                else
                {
                    sizeText.text = "-" + size.ToString();
                }
                break;

            case TransformCharacter.Height:
                if(scaleState == ScaleState.Increase)
                {
                    sizeText.text = "x" + size.ToString();
                }
                else
                {
                    sizeText.text = "/" + size.ToString();
                }
                break;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (transformState)
        {
            case TransformCharacter.Height:


                if (scaleState == ScaleState.Increase)
                {
                    other.gameObject.GetComponent<Player>().GetBody().IncreaseHeight(size * heightMultiplier);
                }
                else
                {
                    other.gameObject.GetComponent<Player>().GetBody().DecreaseHeight(size * heightMultiplier);
                }
                /*body.Height(size * heightMultiplier);*/
                Instantiate(gateParticle, transform.position, Quaternion.identity);
                break;
            case TransformCharacter.Width:
                if (scaleState == ScaleState.Increase)
                {
                    other.gameObject.GetComponent<Player>().GetBody().IncreaseWidth(size * widthMultiplier);
                }
                else
                {
                    other.gameObject.GetComponent<Player>().GetBody().DecreaseWidth(size * widthMultiplier);
                }
                
                /*body.Thicknes(size * thicknesMultiplier);*/
                Instantiate(gateParticle, transform.position, Quaternion.identity);
                break;
        }

        gameObject.SetActive(false);
    }
}


/*public enum TransformCharacter
{
    Width,
    Height
}
public enum ScaleState
{
    Increase, 
    Decrease
}*/
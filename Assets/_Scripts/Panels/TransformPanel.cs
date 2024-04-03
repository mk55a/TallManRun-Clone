
using UnityEngine;

public abstract class TransformPanel : BasePanel
{
    [Header("Panel Settings")]
    [Space(10)]
    public TransformCharacter transformState;
    public ScaleState scaleState;
    public int size;

    protected void Awake()
    {
        SetMaterialAndTextColor();
        SetSizeText();
    }
    protected void SetMaterialAndTextColor()
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
    }

    protected void SetSizeText()
    {
        switch (transformState)
        {

            case TransformCharacter.Width:
                if (scaleState == ScaleState.Increase)
                {
                    sizeText.text = "+" + size.ToString();
                }
                else
                {
                    sizeText.text = "-" + size.ToString();
                }
                break;

            case TransformCharacter.Height:
                if (scaleState == ScaleState.Increase)
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

    protected abstract void ApplyPanelEffect(Player player);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPanelEffect(other.GetComponent<Player>());
            //Instantiate(gateParticle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Debug.Log("Panel Destroyed");
        }
    }
   
}

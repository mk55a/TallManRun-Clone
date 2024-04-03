using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> playerBodyParts = new List<GameObject>();
    [SerializeField] private GameObject pivot;
    [SerializeField] private GameObject hips;
    [SerializeField] private GameObject upperBody;
    [SerializeField]
    private GameObject headObject;

    public void IncreaseHeight(float value)
    {
        pivot.transform.localScale += new Vector3(0, value, 0);
        upperBody.transform.position += new Vector3(0, value * 2, 0);
    }

    public void IncreaseWidth(float value)
    {
        Player.instance.GetPlayerBody().transform.localScale += new Vector3(value, 0, value);

        foreach (GameObject part in playerBodyParts)
        {
            part.transform.localScale += new Vector3(value, 0, value);
        }

        hips.transform.localScale += new Vector3(value, value * 0.5f, value);
    }

    public void DecreaseHeight(float value)
    {
        Vector3 initialScale = pivot.transform.localScale;  
        pivot.transform.localScale = new Vector3(initialScale.x, initialScale.y - value, initialScale.z);
        Debug.Log("Initial Scale: " + initialScale);
        Debug.Log("Current Scale: " + pivot.transform.localScale);
        upperBody.transform.position = new Vector3(
            upperBody.transform.position.x,
            pivot.transform.position.y + pivot.transform.localScale.y,
            upperBody.transform.position.z
        );
        //upperBody.transform.position -= new Vector3(0, value*2, 0);
    }

    public void DecreaseWidth(float value)
    {
        Player.instance.GetPlayerBody().transform.localScale -= new Vector3(value, 0, value);

        foreach (GameObject part in playerBodyParts)
        {
            part.transform.localScale -= new Vector3(value, 0, value);
        }

        hips.transform.localScale -= new Vector3(value, value * 0.5f, value);
    }

    public bool IsBodyThere()
    {
        if (transform.GetChild(1).transform.localScale.x < 0.05f)
        {
            Debug.LogWarning(transform.GetChild(1).gameObject.name);
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Death()
    {
        GameObject head = Instantiate(headObject, headObject.transform.position, Quaternion.identity);
        head.AddComponent<SphereCollider>();
        Rigidbody headCloneRb = head.AddComponent<Rigidbody>();
        headCloneRb.AddForce(0, 2, 5, ForceMode.Impulse);

        gameObject.SetActive(false);
    }
}

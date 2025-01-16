using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SpatialSys.UnitySDK;

public class ObtainMaster : MonoBehaviour
{
    public GameObject inputFieldGameObject;
    public GameObject panelPoints;
    [SerializeField] private TMP_InputField placeHolderText;
    public string code = "1234";

    public void EnterCode()
    {
        if (placeHolderText.text == code)
        {
            placeHolderText.text = "";
            ExitInputField();
            Pasapalabra.instance.GiveControl();
            panelPoints.SetActive(true);
            
        }
        else
        {
            placeHolderText.text = "";
        }
    }

    public void ExitInputField()
    {
        inputFieldGameObject.SetActive(false);
    }
}

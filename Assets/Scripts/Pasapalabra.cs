using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SpatialSys.UnitySDK;

public class Pasapalabra : SpatialNetworkBehaviour, IVariablesChanged
{
    public static Pasapalabra instance;
    private NetworkVariable<int> scoreTeam1 = new(initialValue: 0);
    private NetworkVariable<int> scoreTeam2 = new(initialValue: 0);
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void GivePointTeam1()
    {
        scoreTeam1.value++;
        UpdateText();
    }
    public void GivePointTeam2()
    {
        scoreTeam2.value++;
        UpdateText();
    }

    public void RestPointTeam1()
    {
        if (scoreTeam1 > 0)
        {
            scoreTeam1.value--;
            UpdateText();
        }
    }
    public void RestPointTeam2()
    {
        if (scoreTeam2 > 0)
        {
            scoreTeam2.value--;
            UpdateText();
        }
    }
    private void UpdateText()
    {
        text.text = $"Equipo 1:{scoreTeam1.value} / Equipo 2:{scoreTeam2.value}";
    }
    public void GiveControl()
    {
        if (!hasControl)
        {
            SpatialNetworkObject obj = GetComponent<SpatialNetworkObject>();
            obj.RequestOwnership();
        }

    }
    public void OnVariablesChanged(NetworkObjectVariablesChangedEventArgs args)
    {
        if (args.changedVariables.ContainsKey(scoreTeam1.id))
        {
            UpdateText();
        }
        if (args.changedVariables.ContainsKey(scoreTeam2.id))
        {
            UpdateText();
        }
    }
}

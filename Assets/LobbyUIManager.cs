using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private LobbyPanelBase[] lobbyPanels;
    [SerializeField] private LoadingCanvasController loadingCanvasControllerPrefab;

    private void Start()
    {
        foreach (var lobby in lobbyPanels)
        {
            lobby.InitPanel(this);
        }

        Instantiate(loadingCanvasControllerPrefab);
    }

    public void ShowPanel(LobbyPanelBase.LobbyType type)
    {
        foreach (var lobby in lobbyPanels)
        {
            if (lobby.panelType == type)
            {
                lobby.ShowPanel();
                break;
            }
        }
    }
}

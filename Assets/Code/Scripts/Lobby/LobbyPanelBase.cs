using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("Inherited variables")]
    public LobbyType panelType { get; private set; }

    [SerializeField] private Animator panelAnimator;

    protected LobbyUIManager lobbyUIManager;

    public enum LobbyType
    {
        None,
        CreateNicknamePanel,
        MiddleSectionPanel
    }

    public virtual void InitPanel(LobbyUIManager uiManager)
    {
        lobbyUIManager = uiManager;
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string POP_IN_CLIP_NAME = "In";
        panelAnimator.Play(POP_IN_CLIP_NAME);
    }

    protected void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
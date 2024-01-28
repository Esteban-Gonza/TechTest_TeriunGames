using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator loadingAnimator;
    [SerializeField] Button cancelBtn;

    private NetworkRunnerController networkRunnerController;

    private void Start()
    {
        networkRunnerController = GlobalManagers.Instance.networkRunnerController;
        networkRunnerController.OnStartedRunnerConnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSucessfully += OnPlayerJoinedSucessfully;

        cancelBtn.onClick.AddListener(networkRunnerController.ShutDownRunner);
        this.gameObject.SetActive(false);
    }

    private void OnPlayerJoinedSucessfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimAndSetState(gameObject, loadingAnimator, CLIP_NAME, false));
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimAndSetState(gameObject, loadingAnimator, CLIP_NAME));
    }

    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnerConnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSucessfully -= OnPlayerJoinedSucessfully;
    }
}
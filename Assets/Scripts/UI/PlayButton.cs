using UnityEngine;

public class MyButtonScript : MonoBehaviour
{
    public void OnClickAction()
    {
        Debug.Log("Botão clicado diretamente!");
        var matchmakingClient = WebSocketClient.MatchmakingClient;
        matchmakingClient.Connect();
    }
}

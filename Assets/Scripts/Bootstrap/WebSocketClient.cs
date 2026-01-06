
using UnityEngine;


public class WebSocketClient : MonoBehaviour
{
    public static ConnectionClient connectionClient { get; private set; }


    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        string connectionUrl = AppEnvManager.Settings.connectionConsumerUrl;
        connectionClient = new ConnectionClient(connectionUrl);
    }
  
}

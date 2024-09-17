using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestConnect : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text connectButtonText;
    [SerializeField] private TMP_Text disconnectButtonText;

    private void Start()
    {
        // Asignar listeners para los botones TMP
        connectButtonText.GetComponentInParent<UnityEngine.UI.Button>().onClick.AddListener(ConnectToServer);
        disconnectButtonText.GetComponentInParent<UnityEngine.UI.Button>().onClick.AddListener(DisconnectFromServer);
    }

    // Función para conectar al servidor
    public void ConnectToServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            print("Connecting to server...");
            PhotonNetwork.GameVersion = "0.0.1";
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            print("Already connected to the server.");
        }
    }

    // Función para desconectar del servidor
    public void DisconnectFromServer()
    {
        if (PhotonNetwork.IsConnected)
        {
            print("Disconnecting from server...");
            PhotonNetwork.Disconnect();
        }
        else
        {
            print("Not connected to the server.");
        }
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print($"Disconnected from server: {cause}");
    }
}

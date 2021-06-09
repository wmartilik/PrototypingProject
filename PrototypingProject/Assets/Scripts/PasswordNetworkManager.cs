using MLAPI;
using System.Text;
using TMPro;
using UnityEngine;

namespace HelloWorld
{
    public class PasswordNetworkManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private GameObject passwordEntryUI;
        [SerializeField] private GameObject leaveButton;

        private void Start()
        {
            NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;
        }

        private void OnDestroy()
        {
            if (NetworkManager.Singleton == null) return;

            NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
        }
        public void Host()
        {
            NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
            NetworkManager.Singleton.StartHost(new Vector3(2f,0f,0f), Quaternion.Euler(0f,-55f,0f));
        }
        public void Client()
        {
            NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding.ASCII.GetBytes(passwordInputField.text);
            NetworkManager.Singleton.StartClient();
        }
        public void Leave()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.StopHost();
                NetworkManager.Singleton.ConnectionApprovalCallback -= ApprovalCheck;
            }
            else if (NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StopClient();
            }

            passwordEntryUI.SetActive(true);
            leaveButton.SetActive(false);
        }

        private void HandleServerStarted()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                HandleClientConnected(NetworkManager.Singleton.LocalClientId);
            }
        }

        private void HandleClientConnected(ulong clientId)
        {
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                passwordEntryUI.SetActive(false);
                leaveButton.SetActive(true);
            }
        }

        private void HandleClientDisconnect(ulong clientId)
        {
            passwordEntryUI.SetActive(true);
            leaveButton.SetActive(false);
        }

        private void ApprovalCheck(byte[] connectionData, ulong clientId, NetworkManager.ConnectionApprovedDelegate callback)
        {
            string password = Encoding.ASCII.GetString(connectionData);

            bool approveConnection = password == passwordInputField.text;

            Vector3 spawnPos = Vector3.zero;
            Quaternion spawnRot = Quaternion.identity;

            switch (NetworkManager.Singleton.ConnectedClients.Count)
            {
                case 1:
                    spawnPos = new Vector3(0f, 0f, 0f);
                    spawnRot = Quaternion.Euler(0f, 0f, 0f);
                    break;
                case 2:
                    spawnPos = new Vector3(-2f, 0f, 0f);
                    spawnRot = Quaternion.Euler(0f, 55f, 0f);
                    break;
            }

            callback(true, null, approveConnection, spawnPos, spawnRot);
        }
    }
}
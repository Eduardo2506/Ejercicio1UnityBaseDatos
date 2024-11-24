using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game1
{
    public class UploadScoreView : MonoBehaviour
    {
        [SerializeField] private Button sendSocreButton;
        [SerializeField] private UploadScoreController uploadScoreController;
        private void Awake()
        {
            sendSocreButton.onClick.AddListener(Onclicked);
        }
        private void Onclicked()
        {
            uploadScoreController.Execute(GameData.nombre_usuario, GameData.puntaje, OnCallback);
        }
        private void OnCallback(MessageController data)
        {
            if (data.message == "success")
            {
                GetComponent<GetRankingView>().Execute();
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}


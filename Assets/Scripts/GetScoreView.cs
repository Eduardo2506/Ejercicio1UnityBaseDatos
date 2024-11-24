using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game1
{
    public class GetScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI oldscoreText;
        [SerializeField] private TextMeshProUGUI newScoreText;
        [SerializeField] private TextMeshProUGUI userNameText;
        private GetScoreController getScoreController;

        private void Awake()
        {
            getScoreController = GetComponent<GetScoreController>();
            getScoreController.Execute(GameData.nombre_usuario, OnCallback);
        }
        private void OnCallback(GetScoreModel data)
        {
            if (data.message == "success")
            {
                oldscoreText.text = $"Puntaje antiguo: {data.score}";
            }
            else
            {
                oldscoreText.text = $"Puntaje antiguo: -";
            }

            newScoreText.text = $"Puntaje nuevo: {GameData.puntaje}";
            userNameText.text = $"Usuario: {GameData.nombre_usuario}";
        }
    }
}


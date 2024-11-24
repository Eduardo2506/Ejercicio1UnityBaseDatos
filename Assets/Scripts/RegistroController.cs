using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game1
{ 
    public class RegistroController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nombreInput;
        [SerializeField] private Button empezarButton;
        [SerializeField] ScoreManager scoreManager;

        private void Awake()
        {
            empezarButton.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            if (nombreInput.text.Length > 0)
            {
                scoreManager.StartGame();
                GameData.nombre_usuario = nombreInput.text;
            }
        }
    }
}

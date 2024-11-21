using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("TEXTS")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    [Header("SETTINGS")]
    [SerializeField] private float gameDuration;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private GameObject registerPanel;
    [SerializeField] private Button clickButton;
    [SerializeField] private Button reintentarButton;
    [SerializeField] private Button mostrarPuntaje;

    [Header("CUBE")]
    [SerializeField] private MeshRenderer cubeMeshRender;

    private int currentScore = 0;
    private float currentTime;
    private bool isGameActive;
    private Material cubeMaterial;

    private void Start()
    {
        reintentarButton.onClick.AddListener(ResetGame);
        clickButton.onClick.AddListener(OnButtonClick);
        mostrarPuntaje.onClick.AddListener(ShowResults);
        gameOverPanel.SetActive(false);
        cubeMaterial = cubeMeshRender.material;
        //StartGame();
    }

    private void Update()
    {
        if (!isGameActive) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateTimer();
    }

    public void StartGame()
    {
        currentScore = 0;
        currentTime = gameDuration;
        isGameActive = true;

        UpdateScore();
        UpdateTimer();

        gameOverPanel.SetActive(false);
        registerPanel.SetActive(false);
        clickButton.interactable = true;

        cubeMaterial.color = Color.white;

    }
    private void UpdateScore()
    {
        scoreText.text = $"Puntos: {currentScore}";
    }
    private void UpdateTimer()
    {
        int segundos = (int)currentTime;
        timeText.text = "Tiempo: " + segundos + "s";
    }
    private void OnButtonClick()
    {
        if (!isGameActive) return;
        currentScore++;
        UpdateScore();

        Color newColor = new Color(Random.value, Random.value, Random.value);

        cubeMaterial.color = newColor;

    }
    private void GameOver()
    {
        isGameActive = false;
        clickButton.interactable = false;
        gameOverPanel.SetActive(true);
    }
    private void ShowResults()
    {
        resultsPanel.SetActive(true);
        isGameActive = false;
        gameOverPanel.SetActive(false);
        clickButton.interactable = false;
    }
    private void ResetGame()
    {
        StartGame();
    }
}

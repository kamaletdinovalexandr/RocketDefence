using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public int StartLives;
    public Text LivesText;
    public Text SecondsText;
    public GameObject _gameOver;
    public bool IsGamOver;
    private float _gameTimer = 0;
    static string LIVES = "Lives: ";
    static string TIMER = "Survived: ";
    public Button Restart;
    private int _currentLives;

    private void Start() {
        _instance = this;
        Restart.onClick.AddListener(OnRestart);
        Init();
    }

    private void Init() {
        _currentLives = StartLives;
        _gameTimer = 0f;
        _gameOver.SetActive(false);
        IsGamOver = false;
    }

    private void Update() {
        if(!IsGamOver)
            _gameTimer += Time.deltaTime;

        UpdateUI();

        if (IsGamOver)
            return;

        if (_currentLives == 0) {
            _gameOver.SetActive(true);
            IsGamOver = true;
        }
    }

    public void Damage() {
        _currentLives--;
        if (_currentLives <= 0) {
            IsGamOver = true;
            _gameOver.SetActive(true);
        }
    }

    private void UpdateUI() {
        LivesText.text = LIVES + _currentLives;
        SecondsText.text = TIMER + (int)_gameTimer;
    }

    private void OnRestart() {
        Init();
        SceneManager.LoadScene(0);
    }

    private void OnDestroy() {
        Restart.onClick.RemoveAllListeners();
    }
}

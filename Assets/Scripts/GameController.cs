using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public float PortalLives;
    public Text LivesText;
    public Text SecondsText;
    public GameObject _gameOver;
    public bool IsGamOver;
    private float _gameTimer = 0;
    static string LIVES = "Lives: ";
    static string TIMER = "Survived: ";

    private void Start() {
        _instance = this;
        _gameOver.SetActive(false);
    }

    private void Update() {
        if(!IsGamOver)
            _gameTimer += Time.deltaTime;

        UpdateUI();

        if (IsGamOver)
            return;

        if (PortalLives <= 0) {
            _gameOver.SetActive(true);
            IsGamOver = true;
        }
    }

    public void Damage() {
        PortalLives--;
        if (PortalLives <=0) {
            IsGamOver = true;
            _gameOver.SetActive(true);
        }
    }

    private void UpdateUI() {
        LivesText.text = LIVES + PortalLives;
        SecondsText.text = TIMER + (int)_gameTimer;
    }
}

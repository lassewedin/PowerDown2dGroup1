using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public TMP_Text waveLabel;
    public HealthBar healthBar;

    public PowerDownSelect powerDownSelection;

    private static HUD _instance;

	private void Awake() {
        _instance = this;
	}

	void Start()
    {
        SetScore(0);
        SetWave(1);
        SetHealth(100);
    }

    public static void SetScore(int score) {
        if (_instance == null) return;
        _instance.scoreLabel.text = score.ToString("D7");
	}

    public static void SetWave(int wave) {
        if (_instance == null) return;
        _instance.waveLabel.text = string.Format("Wave: {0}", wave);
	}

    public static void SetHealth(int healthPoints) {
        if (_instance == null) return;
        _instance.healthBar.value = Mathf.Clamp01(healthPoints / 100.0f);
	}

    public static void ShowPowerDownSelection(bool show) {
        if (_instance == null) return;
        _instance.powerDownSelection.Show(show);
	}
}

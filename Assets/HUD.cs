using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public TMP_Text waveLabel;
    public HealthBar healthBar;

    private static HUD _instance;

	private void Awake() {
        _instance = this;
	}

	void Start()
    {
        SetScore(0);
        SetWave(0);
        SetHealth(100);
    }

    public static void SetScore(int score) {
        _instance.scoreLabel.text = score.ToString("D7");
	}

    public static void SetWave(int wave) {
        _instance.waveLabel.text = string.Format("Wave: {0}", wave);
	}

    public static void SetHealth(int healthPoints) {
        _instance.healthBar.value = Mathf.Clamp01(healthPoints / 100.0f);
	}
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CarnivalScores : MonoBehaviour {

	[SerializeField]
	private int TeddyBearPointsMin = 2000;

	[SerializeField]
	private GameObject TeddyBear;

	[SerializeField]
	private TextMeshPro plinkoScore;
	[SerializeField]
	private TextMeshPro wheelScore;
	[SerializeField]
	private TextMeshPro coinScore;
	[SerializeField]
	private short _gameTime;

	public static CarnivalScores Instance;

	private const short LOOP_TIMEOUT = 5;
	private const String SCENE_NAME = "MainMenu";

	private int plinkoPoints;
	private int wheelPoints;
	private int coinPoints;
	private float _timer;
	private bool _canReset;

	void Awake() {
		if (Instance == null)
			Instance = this;

		TeddyBear.SetActive(false);
		ResetGameTime();
	}

	void OnDestroy() {
		if (Instance = this)
			Instance = null;
	}

	// Update is called once per frame
	void Update () {
		plinkoScore.text = "Plinko: " + plinkoPoints.ToString("0000");
		wheelScore.text = "Wheel: " + wheelPoints.ToString("0000");
		coinScore.text = "Coins: " + coinPoints.ToString("0000");

		if (plinkoPoints + wheelPoints + coinPoints >= TeddyBearPointsMin) {
			TeddyBear.SetActive(true);
		}

		_timer -= Time.deltaTime;
		if (_timer <= 0)
		{
			TimeOut();
		}
	}

	public void IncrementPlinkoScore(float points) {
		plinkoPoints += (int) points;
	}

	public void IncrementWheelScore(float points) {
		wheelPoints += (int) points;
	}

	public void IncrementCoinScore() {
		coinPoints += 1000;
	}
	private void ResetGameTime()
	{
		_timer = _gameTime;
		_canReset = false;
	}

	private void TimeOut()
	{
		if (_canReset)
		{
			SceneManager.LoadScene(SCENE_NAME);
		}

		Debug.Log("TIMEOUT !!!");
		_timer = LOOP_TIMEOUT;
		_canReset = true;
	}
}

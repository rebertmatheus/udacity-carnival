using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private int _timeToAction;
	[SerializeField]
	private Material _reticlePointer;
	private const string carnivalScene = "Carnival";

	private float _timer;
	private bool _canCount = false;

	void Start () {
		ResetTimer();
	}

	void Update()
	{
		if (_canCount)
		{
			_timer -= Time.deltaTime;
			if (_timer <= 0)
			{
				LoadScene();
			}
		}
	}

	private void ResetTimer()
	{
		_timer = _timeToAction;
	}

	public void OnPointerEnter()
	{
		_canCount = true;
	}

	public void OnPointerExit()
	{
		_canCount = false;
		ResetTimer();
	}

	private void LoadScene()
	{
		SceneManager.LoadScene(carnivalScene);
	}
}

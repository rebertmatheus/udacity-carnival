using UnityEngine;

public class TimerRockets : MonoBehaviour {

	[SerializeField]
	private GameObject _rockets;
	[SerializeField]
	private short _rocketsDelay;

	private float _timeout;

	void Start () {
		ResetTimeout();
	}

	void Update () {
		_timeout -= Time.deltaTime;
		if (_timeout <= 0)
		{
			EmitRockets();
		}
	}

	void ResetTimeout()
	{
		_timeout = _rocketsDelay;
	}

	void EmitRockets()
	{
		_timeout = _rocketsDelay;
		_rockets.GetComponent<ParticleSystem>().Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManholeBehaviour : MonoBehaviour
{
	public TextMeshProUGUI manholeText;
	public GameObject player;
	public float playerDistance;
	public float minDistance = 2.5f;

	private void Start()
	{
		manholeText.enabled = false;
	}

	private void Update()
	{
		playerDistance = Vector3.Distance(transform.position, player.transform.position);
		Debug.DrawLine(transform.position, player.transform.position, Color.green);

		if (playerDistance > minDistance)
		{
			manholeText.enabled = false;
		}
		else
		{
			manholeText.enabled = true;
		}
	}
}
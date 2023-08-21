using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManholeBehaviour : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private TextMeshProUGUI instructionUI;
	public string manholeText = "[E] Enter manhole";
	public GameObject player;

	[Header("Variables")]
	public float playerDistance;
	public float minDistance = 2.5f;
	public bool inRange = false;

	private void Update()
	{
		playerDistance = Vector3.Distance(transform.position, player.transform.position);
		Debug.DrawLine(transform.position, player.transform.position, Color.green);

		if (playerDistance > minDistance && inRange == true)
		{
			UIManager.Instance.UpdateUI(instructionUI, "");
			inRange = false;
		}
		else if (playerDistance <= minDistance && inRange == false)
		{
			UIManager.Instance.UpdateUI(instructionUI, manholeText);
			inRange = true;
		}

		if (Input.GetKey(KeyCode.E) && inRange)
		{
			SceneManager.LoadScene("Sewer");
		}
	}
}
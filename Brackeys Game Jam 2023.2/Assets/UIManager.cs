using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI instructionText;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

	private void Start()
	{
        UpdateUI(instructionText, "");

		if (SceneManager.GetActiveScene().name == "Main")
		{
            StartCoroutine(Tutorial());
		}
	}

	public void UpdateUI (TextMeshProUGUI textUI, string textToAdd)
	{
        textUI.text = textToAdd;
	}

    IEnumerator Tutorial()
	{
        yield return new WaitForSeconds(1);
        UpdateUI(instructionText, "[WASD] to move around \n Move your mouse to look around");
        yield return new WaitForSeconds(5);
        UpdateUI(instructionText, "");
	}
}

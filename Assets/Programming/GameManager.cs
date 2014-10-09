using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[Range(0, 200)]
	public float time = 100f;
	private float timeRemaining;

	private int numObjectiveAnts = 1;

	// Use this for initialization
	void Start()
	{
		timeRemaining = time;
		InvokeRepeating("UpdateAntCount", 0, 1f);
	}
	
	// Update is called once per frame
	void Update()
	{
		timeRemaining -= Time.deltaTime;
		UpdateText();

		if (timeRemaining <= 0)
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKey(KeyCode.Escape))
	    {
			Application.Quit();
		}
	}

	void UpdateText()
	{
		if (GetComponent<GUIText>())
		{
			GetComponent<GUIText>().text = Mathf.FloorToInt(timeRemaining).ToString();
		}
	}

	public void ResetGame()
	{
		Application.LoadLevel(0);
	}

	public void UpdateAntCount()
	{
		int num = FindObjectsOfType<ObjectiveAnt>().Length;
		numObjectiveAnts = num;
		if (numObjectiveAnts <= 0)
		{
			WinLevel();
		}
	}

	public void WinLevel()
	{
		Debug.Log("Completed level!");
		int l = (int)Mathf.Repeat(Application.loadedLevel + 1, Application.levelCount);
		Debug.Log("Loading level " + l.ToString());
		Application.LoadLevel(l);
	}
}

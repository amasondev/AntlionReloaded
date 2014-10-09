using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private int numObjectiveAnts = 1;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("UpdateAntCount", 0, 1f);
	}
	
	// Update is called once per frame
	void Update()
	{
	
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

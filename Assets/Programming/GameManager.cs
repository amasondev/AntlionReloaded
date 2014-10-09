using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private int numObjectiveAnts = 1;

	// Use this for initialization
	void Start()
	{
		UpdateAntCount();
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
		int l = Application.loadedLevel;
		l++;
		Application.LoadLevel(l);
	}
}

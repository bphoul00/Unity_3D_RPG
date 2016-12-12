using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject gameObject;
	private static GameManager m_Instance;
	public static GameManager Instance{
		get{
			if(m_Instance == null)
			{
				m_Instance = new GameManager ();
				m_Instance.gameObject = new GameObject ("_gameManager");
			}
			return m_Instance;
		}
	}
		
}

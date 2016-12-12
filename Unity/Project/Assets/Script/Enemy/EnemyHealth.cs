using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float maxHealth = 100;
	public float curHealth = 100;
	public float healthBarLength;

	// Use this for initialization
	void Start () {
		
		healthBarLength = Screen.width / 2;

	
	}

	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0);
		if (curHealth == 0) {
			Death ();
		}
	
	}

	void OnGUI()
	{
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Box(new Rect(targetPos.x, targetPos.y/10, healthBarLength, 20), curHealth + "/" + maxHealth);


	}

	public void AddjustCurrentHealth(float adj) {
		curHealth += adj;

		if (curHealth < 0) {
			curHealth = 0;
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (maxHealth < 1) {
			maxHealth = 1;
		}
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	private void Death(){
		Destroy (this.gameObject);
	}



}

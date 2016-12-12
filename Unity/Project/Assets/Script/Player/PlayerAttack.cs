using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

	public float attackDistance = 2;
	public float attackDirection =  0;
	public float attackTimer;
	public float coolDown = 2;
	public float attackDamage = -10;


	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0) {
			attackTimer -= Time.deltaTime;
		}

		if (attackTimer < 0) {
			attackTimer = 0;
		}

		if (Input.GetKeyUp (KeyCode.F)) {
			if (attackTimer == 0) {
				Attack ();
				attackTimer = coolDown;
			}
		}
	
	}

	private void Attack(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in go) {
			float distance = Vector3.Distance (enemy.transform.position, transform.position);

			Vector3 dir = (enemy.transform.position - transform.position).normalized;

			float direction = Vector3.Dot (dir, transform.forward);


			if (distance <= attackDistance && direction >= attackDirection) {
				EnemyHealth enemyHealth = (EnemyHealth)enemy.GetComponent ("EnemyHealth");
				enemyHealth.AddjustCurrentHealth (attackDamage);
			}
		}
			
	}
		
		
}

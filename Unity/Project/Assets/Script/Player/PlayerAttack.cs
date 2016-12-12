using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject target;
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
		float distance = Vector3.Distance (target.transform.position, transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot (dir, transform.forward);

		Debug.Log (direction);

		if (distance <= attackDistance && direction >= attackDirection) {
			EnemyHealth enemyHealth = (EnemyHealth)target.GetComponent ("EnemyHealth");
			enemyHealth.AddjustCurrentHealth (attackDamage);

			if (enemyHealth.curHealth <= 0) {
				Targetting ta = (Targetting)this.GetComponent ("Targetting");
				Kill ();
				ta.ClearTargetsAfterDeath ();
				
			}


		}

	}

	public void Kill(){
		Destroy (target);
	}
		
}

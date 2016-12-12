using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float attackDistance = 2;
	public float attackDirection =  0;
	public float attackTimer;
	public float attackDamage = -10;
	public float coolDown;


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
			
			if (attackTimer == 0) {
				Attack ();
				attackTimer = coolDown;
			}


	}

	private void Attack(){
		float distance = Vector3.Distance (target.transform.position, transform.position);

		Vector3 dir = (target.transform.position - transform.position).normalized;

		float direction = Vector3.Dot (dir, transform.forward);


		if (distance <= attackDistance && direction >= attackDirection) {
			PlayerVital playerHealth = (PlayerVital)target.GetComponent ("PlayerVital");
			playerHealth.AddjustCurrentHealth (attackDamage);

		}
	}
}

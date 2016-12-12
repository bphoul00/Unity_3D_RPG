using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	public float attackDamage = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if(col.gameObject.tag == "Enemy")
		{
			EnemyHealth enemyHealth = (EnemyHealth)col.gameObject.GetComponent ("EnemyHealth");
			enemyHealth.AddjustCurrentHealth (attackDamage);
			//Destroy(col.gameObject);
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);
		}


}
}

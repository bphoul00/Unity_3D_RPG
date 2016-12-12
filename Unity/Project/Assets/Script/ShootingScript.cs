using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;
	public bool applyForce = true;
	public LineRenderer line;
	public int speed;
	public float manaCost = - 10;
	public Vector3 shootFromHere;
	public Text text;
	public GameObject player;

	// Use this for initialization
	void Start () {
		line = gameObject.AddComponent<LineRenderer> ();
		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		shootFromHere = new Vector3 (
			
			this.transform.position.x,
			this.transform.position.y + 2,
			this.transform.position.z );
		//text.text = "Ammo: " + ammo;
		if (Input.GetMouseButtonDown (0)) {

			PlayerVital pv = (PlayerVital)player.GetComponent ("PlayerVital");
			if(pv.manaSlider.value > -(manaCost)){
			SpawnBulletPrefab ();
			pv.AddjustCurrentMana (manaCost);
			}
			//SpawnBulletRaycast();

		}
	
	}

	void SpawnBulletPrefab()
	{
		GameObject bulletCloned;
		bulletCloned = Instantiate (bullet, shootFromHere, Quaternion.identity) as GameObject;

		//bulletCloned.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * speed);
		bulletCloned.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;

		Destroy (bulletCloned, 1);

	}

	void SpawnBulletRaycast(){
		RaycastHit hit;
		Ray myRay = new Ray (shootFromHere, Camera.main.transform.forward);
		if (Physics.Raycast (myRay, out hit, Mathf.Infinity)) {
			Debug.Log ("Hit");
			line.SetPosition (0, transform.position);
			line.SetPosition (1, hit.point);
		}
	}
}

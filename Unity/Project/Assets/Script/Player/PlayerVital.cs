using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class PlayerVital : MonoBehaviour {

	public Slider healthSlider;
	public int maxHealth;
	public int healthFallRate;
	public int healthRegenationRate;

	public Slider manaSlider;
	public int maxMana;
	public int manaRegenationRate;

	public Slider expSlider;
	public int maxExp;

	void Start()
	{
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;

		manaSlider.maxValue = maxMana;
		manaSlider.value = maxMana;

		expSlider.maxValue = maxExp;
		expSlider.value = 0;
	}
		
	void Update()
	{
		if (healthSlider.value <= 0) 
		{
			CharacterDeath();
		}

		//Heatlh Controller

		//SelfHealing

		if(healthSlider.value > 0 && healthSlider.value < maxHealth)
		{
			healthSlider.value += (Time.deltaTime/10000)*healthRegenationRate;
		}


		//Damage overtime
		if(healthSlider.value > 0 )
		{
			healthSlider.value -= (Time.deltaTime/10000)+healthFallRate ;

		}

		//Prevent suplus of health
		if(healthSlider.value > maxHealth)
		{
			healthSlider.value = maxHealth;
		}

		//Mana Controller
		if(manaSlider.value < 0)
		{
			manaSlider.value = 0;
		}

		if(manaSlider.value >= 0 && manaSlider.value < maxMana)
		{
			manaSlider.value += (Time.deltaTime/10000)*manaRegenationRate ;
		}

		//Prevent suplus of mana
		if(manaSlider.value > maxMana)
		{
			manaSlider.value = maxMana;
		}

		//Exp Controller
		if(expSlider.value < 0)
		{
			expSlider.value = 0;
		}
			

		//Prevent suplus of mana
		if(expSlider.value > maxExp)
		{
			expSlider.value = 0;
		}



	}





	public void AddjustCurrentHealth(float adj) {
		healthSlider.value += adj;

		if (healthSlider.value < 0) {
			healthSlider.value = 0;
		}

		if (healthSlider.value > maxHealth) {
			healthSlider.value = maxHealth;
		}
			
	}

	public void AddjustCurrentMana(float adj) {
		manaSlider.value += adj;

		if (manaSlider.value < 0) {
			manaSlider.value = 0;
		}

		if (manaSlider.value > maxMana) {
			manaSlider.value = maxMana;
		}
			
	}

	public void AddjustCurrentExp(float adj) {
		manaSlider.value += adj;

		if (expSlider.value < 0) {
			expSlider.value = 0;
		}

		if (expSlider.value > maxMana) {
			expSlider.value = 0;
		}

	}

	public void CharacterDeath (){
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		Time.timeScale = 1;
	}

}
 
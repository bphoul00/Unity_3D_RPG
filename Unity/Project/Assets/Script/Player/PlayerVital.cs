using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerVital : MonoBehaviour {

	public Slider healthSlider;
	public int maxHealth;
	public int healthFallRate;
	public int healthRegenationRate;

	public Slider manaSlider;
	public int maxMana;
	public int manaRegenationRate;

	void Start()
	{
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;

		manaSlider.maxValue = maxMana;
		manaSlider.value = maxMana;
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



	}



	void CharacterDeath()
	{
		//Death
	}

	public void AddjustCurrentHealth(float adj) {
		healthSlider.value += adj;

		if (healthSlider.value < 0) {
			healthSlider.value = 0;
		}

		if (healthSlider.value > maxHealth) {
			healthSlider.value = maxHealth;
		}

		if (healthSlider.value < 1) {
			healthSlider.value = 1;
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

		if (manaSlider.value < 1) {
			manaSlider.value = 1;
		}
	}

}

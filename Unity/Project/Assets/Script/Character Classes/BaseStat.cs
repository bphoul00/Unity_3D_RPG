using UnityEngine;
using System.Collections;

public class BaseStat : MonoBehaviour {

	private int _baseValue;	//the base vule of this stat
	private int _buffValue; //the amount of the buff to this stat
	private int _expToLevel; 	//tht tomal amount of the exp need to raise this skill
	private float _levelModifier;	 //the modifier applied top the exp neede Touch raise the skill


public BaseStat(){
	_baseValue = 0;
	_buffValue = 0;
	_expToLevel = 1;
	_levelModifier = 100;
}
	public int get_baseValue(){
		return _baseValue;
	}

	public int get_buffValue(){
		return _buffValue;
	}

	public int get_expToLevel(){
		return _expToLevel;
	}

	public float get_levelModifier(){
		return _levelModifier;
	}

	public void set_baseValue(int value){
		 _baseValue = value;
	}

	public void set_buffValue(int value){
		 _buffValue = value;
	}

	public void set_expToLevel(int value){
		 _expToLevel = value;
	}

	public void  set_levelModifier(float value ){
		_levelModifier = value;
	}

	private int CalculateExpToLevel() {
		return (int)_expToLevel * (int)_levelModifier;
	}

	public void LevelUp() {
		_expToLevel = CalculateExpToLevel ();
		_baseValue++;
	}

	public int AdjustedValue(){
		return _baseValue + _buffValue;
	}


}
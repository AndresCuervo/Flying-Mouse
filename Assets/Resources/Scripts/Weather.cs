﻿using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour
{
	// This should be the name of the texture the type uses in its model, for clarity
	public string type;
	WeatherModel model;

	public void init ()
	{
		init ("tileBlank");
	}

	public WeatherModel init (string weather_type)
	{
		this.type = weather_type;
		return initWeatherModel ();
	}

	public WeatherModel initWeatherModel ()
	{
		GameObject modelObject = GameObject.CreatePrimitive (PrimitiveType.Quad);	// Create a quad object for holding the bird texture.
		model = modelObject.AddComponent<WeatherModel> ();						// Add a bird_model script to control visuals of the bird.
		model.init (this);

		return model;
	}
}
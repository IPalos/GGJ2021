/*
			AudioManager
			Creado por Ignacio Palos Reynoso
			abril 2019
			Para Trimino v 1
			Controla el audio del juego
*/

using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;


///<summary>Controla el audio del juego, funciona como componente de un GameObject
///Preferentemente llamado AudioManager</summary>
public class AudioManager : MonoBehaviour {

	[SerializeField]
	public Sound[] sounds;


	public static AudioManager audioManager;

	void Awake () {

		#region Singleton
			if (audioManager == null){
				audioManager = this;
			}
			else{
				Destroy(gameObject);
				return;
			}
			DontDestroyOnLoad(gameObject);			
		#endregion

		//Hace ajustes iniciales para cada Sound del array
		foreach (Sound s in sounds){
			audioManager.sounds=sounds;
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			if (s.category == "sound"){
				s.source.volume = 1;
			}
			else if (s.category == "music"){
				s.source.volume = 1;
			}
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.playOnAwake = false;
		}
	}

	//Empieza a tocar el tema MenuTheme
	void Start(){
            ChangeMVolume(1);
            ChangeSVolume(1);
			Play("MainTheme");			
	}

	///<summary>Reproduce el audio con el nombre "name"</summary>	
	public void Play(string name){

		//Busca en sounds el sound tal que su nombre = name
		Sound s = Array.Find(audioManager.sounds, sound => sound.name == name);
		if (s== null){
			Debug.LogWarning("El sonido: "+name+" no se encontró");
			return;
		}
		s.source.Play();
	}

	///<summary>Sustitute la canción nameOut por nameIn, e indica si se hace con fade o no</summary>	
	public void ChangeTrack(string nameOut, string nameIn, bool fade, float overTime=0.5f){
        float MusicVolume =1;
        
		Sound sOut = Array.Find(sounds,sound => sound.name == nameOut);
		Sound sIn = Array.Find(sounds,sound => sound.name == nameIn);
		if (fade){
			StartCoroutine(Fade(overTime,sOut.source,sIn.source));
		}
		//Que haga fadeOut, y que entre de golpe
		else{
			sOut.source.Stop();
			sIn.source.volume = MusicVolume;
			sIn.source.Play();
		}

	}

	//Aumenta el volumen de forma lineal en un tiempo overTime
	public IEnumerator FadeIn(float overTime, AudioSource s){
		float musicVol = 1;
		float startTime = Time.time;
		s.volume = 0;
		s.Play();
		while (Time.time < startTime + overTime + .1f){
			s.volume = (musicVol*(Time.time-startTime))/overTime;
			yield return null;
		}
	}

	//hace fadeOut de sOut y fadeIn de sIn en un tiempo overTime
	IEnumerator Fade(float overTime, AudioSource sOut, AudioSource sIn){
		float musicVol = 1;
		float startTime = Time.time;
		sOut.volume = 1;
		while (Time.time < startTime + overTime + .1f){
			sOut.volume = musicVol-((Time.time-startTime)/overTime);
			yield return null;
		}
		sOut.Stop();
		yield return new WaitForSeconds(overTime);
		StartCoroutine(FadeIn(overTime*2,sIn));
	}

	public void ChangeSVolume(float vol){
		foreach (Sound s in audioManager.sounds){
			if (s.category == "sound"){
				s.source.volume = vol;
                s.source.pitch=1;
			}
		}
	}

	public void ChangeMVolume(float vol){
		foreach (Sound s in audioManager.sounds){
			if (s.category == "music"){
				s.source.volume = vol;
                s.source.pitch=1;
			}
		}
	}

}
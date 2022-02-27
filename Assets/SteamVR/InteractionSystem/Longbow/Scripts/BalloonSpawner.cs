//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Spawns balloons
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class BalloonSpawner : MonoBehaviour
	{
		public float minSpawnTime = 5f;
		public float maxSpawnTime = 15f;
		private float nextSpawnTime;
		public GameObject balloonPrefab;

		public bool autoSpawn = true;
		public bool spawnAtStartup = true;

		public bool playSounds = true;
		public SoundPlayOneshot inflateSound;
		public SoundPlayOneshot stretchSound;

		public bool sendSpawnMessageToParent = false;

		public float scale = 1f;

		public Transform spawnDirectionTransform;
		public float spawnForce;

		public bool attachBalloon = false;

		public Balloon.BalloonColor color = Balloon.BalloonColor.Random;


		//-------------------------------------------------
		void Start()
		{
			if ( balloonPrefab == null )
			{
				return;
			}

			if ( autoSpawn && spawnAtStartup )
			{
				SpawnBalloon( Vector3.zero, color );
				nextSpawnTime = Random.Range( minSpawnTime, maxSpawnTime ) + Time.time;
			}
		}


		//-------------------------------------------------
		void Update()
		{
			if ( balloonPrefab == null )
			{
				return;
			}

			if ( ( Time.time > nextSpawnTime ) && autoSpawn )
			{
				SpawnBalloon( Vector3.zero, color );
				nextSpawnTime = Random.Range( minSpawnTime, maxSpawnTime ) + Time.time;
			}
		}


		//-------------------------------------------------
		public GameObject SpawnBalloon(Vector3 offset, Balloon.BalloonColor color = Balloon.BalloonColor.Red)
		{
			if ( balloonPrefab == null )
			{
				return null;
			}
			GameObject balloon = Instantiate( balloonPrefab, transform.position + offset, transform.rotation ) as GameObject;
			balloon.transform.localScale = new Vector3( scale, scale, scale );
			if ( attachBalloon )
			{
				balloon.transform.parent = transform;
			}

			if ( sendSpawnMessageToParent )
			{
				if ( transform.parent != null )
				{
					transform.parent.SendMessage( "OnBalloonSpawned", balloon, SendMessageOptions.DontRequireReceiver );
				}
			}

			if ( playSounds )
			{
				if ( inflateSound != null )
				{
					inflateSound.Play();
				}
				if ( stretchSound != null )
				{
					stretchSound.Play();
				}
			}
			balloon.GetComponentInChildren<Balloon>().SetColor( color );
			if ( spawnDirectionTransform != null )
			{
				balloon.GetComponentInChildren<Rigidbody>().AddForce( spawnDirectionTransform.forward * spawnForce );
			}

			return balloon;
		}

		//-------------------------------------------------
		public void SpawnBalloonFromEvent( int color )
		{
			// Copy of SpawnBalloon using int because we can't pass in enums through the event system
			SpawnBalloon( Vector3.zero, (Balloon.BalloonColor)color );
		}

		public void SpawnThreeRandomBalloons()
		{
			// Copy of SpawnBalloon using int because we can't pass in enums through the event system
			SpawnBalloon(Vector3.zero, Balloon.BalloonColor.Random);
			SpawnBalloon(new Vector3(Random.Range(0.35f, .85f), Random.Range(-.75f, .75f), 0));
			SpawnBalloon(new Vector3(-Random.Range(0.35f, .85f), Random.Range(-.75f, .75f), 0));
		}
	}
}

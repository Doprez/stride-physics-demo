using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Games;
using System;

namespace PhysicsPerfDemo;
public class SpawnPrefab : SyncScript
{
	public Prefab PrefabToSpawn { get; set; }

	private int _instanceCount = 0;
	private float _elapsedtime = 0;
	private bool _keepSpawning = false;
	private Random _random = new();

	public override void Start()
	{
		SpawnInstance();
	}

	public override void Update()
	{
		DebugText.Print($"Instances {_instanceCount}", new Int2(50, 50));
		if(Input.IsKeyPressed(Stride.Input.Keys.I))
		{
			SpawnInstance();
		}
		if(Input.IsKeyPressed(Stride.Input.Keys.O))
		{
			SpawnMultiple();
		}
		if(Input.IsKeyPressed(Stride.Input.Keys.P))
		{
			_keepSpawning = !_keepSpawning;
		}

		if(_keepSpawning)
		{
			SpawnUntilDead();
		}
	}

	/// <summary>
	/// Spawns 100 instances per call
	/// </summary>
	private void SpawnMultiple()
	{
		for(int i = 0; i < 100;  i++)
		{
			SpawnInstance();
		}
	}

	/// <summary>
	/// Will spawn instances until FPS hits 10
	/// </summary>
	private void SpawnUntilDead()
	{
		_elapsedtime += (float)Game.UpdateTime.Elapsed.TotalSeconds;

		if (_elapsedtime >= .1f)
		{
			SpawnInstance();
			_elapsedtime = 0;
		} 
	}

	/// <summary>
	/// Spawns one instance per call
	/// </summary>
	private void SpawnInstance()
	{
		var instance = PrefabToSpawn.Instantiate();
		instance[0].Transform.Position = new Vector3(_random.Next(-5, 5), _random.Next(5, 10), _random.Next(-5, 5));
		SceneSystem.SceneInstance.RootScene.Entities.Add(instance[0]);
		_instanceCount++;
	}
}

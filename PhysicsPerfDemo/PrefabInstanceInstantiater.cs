using Stride.Engine;
using System;
using System.Linq;

namespace PhysicsPerfDemo;
public class PrefabInstanceInstantiater : StartupScript
{
	public InstanceComponent InstanceComponent { get; set; }

	public override void Start()
	{
		if (InstanceComponent == null)
			InstanceComponent = Entity.Get<InstanceComponent>();
		if (InstanceComponent == null)
			throw new Exception("InstanceComponent is null");

		AddInstanceModel();
	}

	private void AddInstanceModel()
	{
		var scene = SceneSystem.SceneInstance.RootScene;
		var instancingComponent = scene.Entities.Where(x => x.Name == "InstanceModel").FirstOrDefault().Get<InstancingComponent>();

		InstanceComponent.Master = instancingComponent;
	}
}

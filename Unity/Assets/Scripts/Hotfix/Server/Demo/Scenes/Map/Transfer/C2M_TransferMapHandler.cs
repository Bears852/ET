﻿using System;

namespace ET.Server
{
	[ActorMessageLocationHandler(SceneType.Map)]
	public class C2M_TransferMapHandler : ActorMessageLocationHandler<Unit, C2M_TransferMap, M2C_TransferMap>
	{
		protected override async ETTask Run(Unit unit, C2M_TransferMap request, M2C_TransferMap response)
		{
			await ETTask.CompletedTask;

			string currentMap = unit.Scene().Name;
			string toMap = null;
			if (currentMap == "Map1")
			{
				toMap = "Map2";
			}
			else
			{
				toMap = "Map1";
			}

			StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.Scene().Zone, toMap);
			
			TransferHelper.TransferAtFrameFinish(unit, startSceneConfig.InstanceId, toMap).Coroutine();
		}
	}
}
﻿namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class M2C_RemoveUnitsHandler : MessageHandler<M2C_RemoveUnits>
	{
		protected override async ETTask Run(Session session, M2C_RemoveUnits message)
		{	
			UnitComponent unitComponent = session.Root().CurrentScene()?.GetComponent<UnitComponent>();
			if (unitComponent == null)
			{
				return;
			}
			foreach (long unitId in message.Units)
			{
				unitComponent.Remove(unitId);
			}

			await ETTask.CompletedTask;
		}
	}
}

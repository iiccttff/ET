﻿using System;
using System.Collections.Generic;

namespace ET.Client
{
	/// <summary>
	/// 管理所有UI GameObject
	/// </summary>
	public class UIEventComponent: Singleton<UIEventComponent>, ISingletonLoad, ISingletonAwake
	{
		public Dictionary<string, AUIEvent> UIEvents { get; } = new();
		
        public void Awake()
        {
            var uiEvents = EventSystem.Instance.GetTypes(typeof (UIEventAttribute));
            foreach (Type type in uiEvents)
            {
                object[] attrs = type.GetCustomAttributes(typeof (UIEventAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                UIEventAttribute uiEventAttribute = attrs[0] as UIEventAttribute;
                AUIEvent aUIEvent = Activator.CreateInstance(type) as AUIEvent;
                this.UIEvents.Add(uiEventAttribute.UIType, aUIEvent);
            }
        }
        
        public void Load()
        {
	        World.Instance.AddSingleton<UIEventComponent>(true);
        }
	}
}
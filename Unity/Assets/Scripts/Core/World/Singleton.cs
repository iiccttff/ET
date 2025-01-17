﻿namespace ET
{
    public abstract class ASingleton: DisposeObject
    {
        public abstract void Register();
    }
    
    public abstract class Singleton<T>: ASingleton where T: Singleton<T>, new()
    {
        private bool isDisposed;
        
        [StaticField]
        private static T instance;
        
        public static T Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public override void Register()
        {
            Instance = (T)this;
        }

        public bool IsDisposed()
        {
            return this.isDisposed;
        }

        protected virtual void Destroy()
        {
            
        }

        public override void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }
            
            this.isDisposed = true;
            
            this.Destroy();
        }
    }
}
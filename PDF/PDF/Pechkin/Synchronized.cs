using System;

namespace Pechkin
{
    internal class Synchronized
    {
        private GlobalConfig globalConfig;

        public Synchronized(GlobalConfig globalConfig)
        {
            this.globalConfig = globalConfig;
        }

        internal class SynchronizedPechkin
        {
            private GlobalConfig pechkinGlobalConfig;

            public SynchronizedPechkin(GlobalConfig pechkinGlobalConfig)
            {
                this.pechkinGlobalConfig = pechkinGlobalConfig;
            }
        }

        internal object Convert(ObjectConfig objectConfig)
        {
            throw new NotImplementedException();
        }
    }
}
using System;

namespace Common
{
    public abstract class Model<TConfig> : Model
        where TConfig : Config
    {
        public TConfig Config { get; }
        
        protected Model(TConfig config)
        {
            Config = config;
        }
    }
    
    public abstract class Model
    {
    }
}
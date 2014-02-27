namespace WorldOfNinja
{
    using System;
    using Interfaces;

    public abstract class WorldObject : IGameObject
    {
        private string name;

        public WorldObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("{0} name can not be null or epmty", this.GetType().Name));
                }

                this.name = value;
            }
        }
    }
}
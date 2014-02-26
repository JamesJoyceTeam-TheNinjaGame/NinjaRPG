namespace WorldOfNinja
{
    using System;
    using System.Text.RegularExpressions;
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
                if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                {
                    throw new ArgumentException(string.Format("{0} name must be at least 3 symbols and could contain only latin letters", this.GetType().Name));
                }

                this.name = value;
            }
        }
    }
}

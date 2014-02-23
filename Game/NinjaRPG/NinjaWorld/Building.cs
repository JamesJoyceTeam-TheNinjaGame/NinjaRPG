namespace NinjaWorld
{
    using System.Text.RegularExpressions;

    public abstract class Building
    {
        private string name;

        public Building(string name)
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
                    throw new ImproperlyDefinedBuildingException(string.Format("{0} name must be at least 3 symbols and could contain only latin letters", this.GetType().Name));
                }

                this.name = value;
            }
        }
    }
}
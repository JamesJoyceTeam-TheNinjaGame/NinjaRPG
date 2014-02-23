namespace NinjaWorld
{
    using System.Text.RegularExpressions;

    public abstract class Item : IItem
    {
        private string name;        
        
        public Item(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == null)
                {
                    if (!Regex.IsMatch(value, @"\b[A-Za-z][A-Za-z][A-Za-z]+\b"))
                    {
                        throw new ImproperlyDefinedItemException(string.Format("{0} name must be at least 3 symbols and could contain only latin letters", this.ItemType));
                    }

                    this.name = value;
                }
            }
        }

        public string ItemType 
        {
            get { return this.GetType().Name; }
        }
    }
}
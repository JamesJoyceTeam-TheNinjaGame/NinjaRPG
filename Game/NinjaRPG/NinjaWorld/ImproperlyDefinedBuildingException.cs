namespace NinjaWorld
{
    using System;

    public class ImproperlyDefinedBuildingException : ApplicationException
    {
        public ImproperlyDefinedBuildingException(string msg)
            : base(msg)
        {
        }

        public ImproperlyDefinedBuildingException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}

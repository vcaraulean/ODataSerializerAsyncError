namespace TheApp.WebApi
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExposedAttribute(string controllerName) : Attribute
    {
        public string ControllerName { get; private set; } = controllerName;
    }
}
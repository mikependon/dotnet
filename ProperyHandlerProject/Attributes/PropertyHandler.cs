using System;

namespace ProperyHandlerProject.Attributes
{
    public class PropertyHandler : Attribute
    {
        public PropertyHandler(Type handlerType)
        {
            HandlerType = handlerType;
        }

        public Type HandlerType { get; }
    }
}

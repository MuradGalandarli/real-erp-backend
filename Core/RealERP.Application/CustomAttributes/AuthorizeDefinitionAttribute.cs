

using RealERP.Application.Enums;

namespace RealERP.Application.CustomAttrubutes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType  { get; set; }
    }
}

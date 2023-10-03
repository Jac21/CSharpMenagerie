using System.Reflection;

namespace Cataloging.Models;

public class CatalogingInfoModel
{
    public Type Type { get; set; }

    public IEnumerable<MethodInfo> Actions { get; set; }

    public ConstructorInfo Constructor { get; set; }
}
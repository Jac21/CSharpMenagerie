namespace SimpleReflectionMapper.Core;

public static class Mapper
{
    public static TResult Map<TIn, TResult>(TIn obj) where TResult : new()
    {
        var result = new TResult();

        var inputProperties = typeof(TIn).GetProperties();
        var resultProperties = typeof(TResult).GetProperties();

        foreach (var inputProperty in inputProperties)
        {
            // find matching property by name and type
            var resultProperty = resultProperties
                .FirstOrDefault(prop =>
                    string.Equals(prop.Name, inputProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                    prop.PropertyType == inputProperty.PropertyType);

            if (resultProperty != null && resultProperty.CanWrite)
            {
                resultProperty.SetValue(result, inputProperty.GetValue(obj));
            }
        }

        return result;
    }
}
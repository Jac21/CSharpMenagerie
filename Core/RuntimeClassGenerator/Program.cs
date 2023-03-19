using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace RuntimeClassGenerator
{
    internal class Program
    {
        public static Type GeneratedType { private set; get; }

        // Keep track of my properties
        private static readonly Dictionary<string, Type> Properties = new Dictionary<string, Type>(new[]
        {
            new KeyValuePair<string, Type>("FTSE100", typeof(decimal)),
            new KeyValuePair<string, Type>("CAC40", typeof(decimal))
        });

        private static void Main()
        {
            Console.WriteLine("Hello, classes!");

            //// explicitly create a new List with the generated type
            //var listGenericType = typeof(List<>);
            //var list = listGenericType.MakeGenericType(GeneratedType);
            //var constructor = list.GetConstructor(new Type[] { });
            //var newList = (IList) constructor.Invoke(new object[] { });

            //foreach (var value in values)
            //{
            //    newList.Add(value);
            //}

            Initialize();

            Console.WriteLine(GeneratedType.AssemblyQualifiedName);
        }

        private static void Initialize()
        {
            var newTypeName = Guid.NewGuid().ToString();
            var assemblyName = new AssemblyName(newTypeName);
            var dynamicAssembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var dynamicModule = dynamicAssembly.DefineDynamicModule("Main");

            var dynamicType = dynamicModule.DefineType(newTypeName,
                TypeAttributes.Public |
                TypeAttributes.Class |
                TypeAttributes.AutoClass |
                TypeAttributes.AnsiClass |
                TypeAttributes.BeforeFieldInit |
                TypeAttributes.AutoLayout,
                typeof(PriceHolderModel)); // This is the type of class to derive from. Use null if there isn't one

            dynamicType.DefineDefaultConstructor(MethodAttributes.Public |
                                                 MethodAttributes.SpecialName |
                                                 MethodAttributes.RTSpecialName);

            foreach (var property in Properties)
            {
                AddProperty(dynamicType, property.Key, property.Value);
            }

            GeneratedType = dynamicType.CreateType();
        }

        private static void AddProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            var fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            var propertyBuilder =
                typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            var getMethod = typeBuilder.DefineMethod("get_" + propertyName,
                MethodAttributes.Public |
                MethodAttributes.SpecialName |
                MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);

            var getMethodIl = getMethod.GetILGenerator();

            getMethodIl.Emit(OpCodes.Ldarg_0);
            getMethodIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getMethodIl.Emit(OpCodes.Ret);

            var setMethod = typeBuilder.DefineMethod("set_" + propertyName,
                MethodAttributes.Public |
                MethodAttributes.SpecialName |
                MethodAttributes.HideBySig,
                null, new[] {propertyType});

            var setMethodIl = setMethod.GetILGenerator();
            Label modifyProperty = setMethodIl.DefineLabel();
            Label exitSet = setMethodIl.DefineLabel();

            setMethodIl.MarkLabel(modifyProperty);
            setMethodIl.Emit(OpCodes.Ldarg_0);
            setMethodIl.Emit(OpCodes.Ldarg_1);
            setMethodIl.Emit(OpCodes.Stfld, fieldBuilder);
            setMethodIl.Emit(OpCodes.Nop);
            setMethodIl.MarkLabel(exitSet);
            setMethodIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethod);
            propertyBuilder.SetSetMethod(setMethod);
        }
    }
}
using System.Reflection;
using System.Reflection.Emit;

var assemblyName = new AssemblyName("MyAssembly");
var builder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

var module = builder.DefineDynamicModule(assemblyName.Name!);

// Create class
var myClass = module.DefineType("Hello", TypeAttributes.Public);

// Create method 
var myMethod = myClass.DefineMethod("Say", MethodAttributes.Public | MethodAttributes.Static, typeof(void),
    Type.EmptyTypes);
    
// Generate de IL 
var generator = myMethod.GetILGenerator();

// Opcodes 
generator.Emit(OpCodes.Ldstr, "Hello :)");
generator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", [typeof(string)])!);
generator.Emit(OpCodes.Ret);

var helloTypeClass = myClass.CreateType();
helloTypeClass.GetMethod("Say")?.Invoke(null, null);




    
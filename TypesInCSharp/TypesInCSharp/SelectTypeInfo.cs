using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypesInCSharp
{
    public class TypeInfo
    {
        public string TypeName { get; private set; }
        public bool IsValueType { get; private set; }
        public string Namespace { get; private set; }
        public string Assembly { get; private set; }
        public int ElementsCount { get; private set; }
        public int FieldsCount { get; private set; }
        public int PropertiesCount { get; private set; }
        public int MethodsCount { get; private set; }
        public string[] FieldsInType { get; private set; }
        public string[] PropertiesInType { get; private set; }
        public Dictionary<string, int[]> DictMethodsInType { get; private set; }

        public TypeInfo(Type t)
        {
            TypeName = GetTypeName(t);
            IsValueType = GetIsValueType(t);
            Namespace = GetNamespace(t);
            Assembly = GetAssembly(t);
            FieldsCount = GetFieldsCount(t);
            PropertiesCount = GetPropertiesCount(t);
            MethodsCount = GetMethodsCount(t);
            ElementsCount = GetElementsCount(t);
            FieldsInType = GetFieldsInThisType(t);
            PropertiesInType = GetPropertiesInThisType(t);
            DictMethodsInType = GetDictMethodsInType(t);
        }

        #region PropertiesHandlers
        private string GetTypeName(Type t)
        {
            return t.ToString();
        }

        private bool GetIsValueType(Type t)
        {
            return t.IsValueType;
        }

        private string GetNamespace(Type t)
        {
            return t.Namespace;
        }

        private string GetAssembly(Type t)
        {
            return t.Assembly.GetName().Name;
        }

        private int GetElementsCount(Type t)
        {
            return t.GetFields().Length +
                   t.GetProperties().Length +
                   t.GetMethods().Length;
        }

        private int GetFieldsCount(Type t)
        {
            return t.GetFields().Length;
        }

        private int GetPropertiesCount(Type t)
        {
            return t.GetProperties().Length;
        }

        private int GetMethodsCount(Type t)
        {
            return t.GetMethods().Length;
        }

        private string[] GetFieldsInThisType(Type t)
        {
            var arr = t.GetFields();
            string[] res = new string[arr.Length];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = arr[i].Name;
            }

            return res;
        }

        private string[] GetPropertiesInThisType(Type t)
        {
            var arr = t.GetProperties();
            string[] res = new string[arr.Length];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = arr[i].Name;
            }

            return res;
        }

        private Dictionary<string, int[]> GetDictMethodsInType(Type t)
        {
            MethodInfo[] methodsArray = t.GetMethods();
            Dictionary<string, int[]> DictResult = new Dictionary<string, int[]>();

            for (int i = 0; i < methodsArray.Length; i++)
            {
                string methodName = methodsArray[i].Name;

                if (DictResult.ContainsKey(methodName))
                {
                    DictResult[methodName][0]++;  // overloadsCount
                    if (methodsArray[i].GetParameters().Length >= DictResult[methodName][2])
                    {
                        DictResult[methodName][2] = methodsArray[i].GetParameters().Length; // maxParameters
                    }
                }
                else
                {
                    DictResult.Add(methodName, new int[3]);
                    DictResult[methodName][0]++;
                    DictResult[methodName][1] = methodsArray[i].GetParameters().Length; // minParameters
                    DictResult[methodName][2] = methodsArray[i].GetParameters().Length; // maxParameters
                }
            }

            return DictResult;
        }

        #endregion

    }

    public class SelectTypeInfo
    {
        #region START Methods
        public void StartSelectTypeInfo()
        {
            Type[] arr =
            {                           //MENU SLECTORS
                typeof(int),		    //[1]
                typeof(long),		    //[2]
                typeof(float),		    //[3]
                typeof(double),		    //[4]
                typeof(char),		    //[5]
                typeof(string),		    //[6]
				typeof(ConsoleColor),	//[7]
                typeof(Nullable),	    //[8]
                typeof(Nullable),	    //[9]
            };

            DisplayMenuSelectTypeInfo();

            while (true)
            {
                char c = Handlers.InPutHandler();

                if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5'
                    || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    int num = Convert.ToInt32(c.ToString()) - 1;
                    TypeInfo t = new TypeInfo(arr[num]);
                    StartDisplayTypeFullInfo(t);
                    break;
                }

                else if (c == '0')
                {
                    MainMenu m = new MainMenu();
                    m.StartMainMenu();
                    break;
                }
            }
        }

        private void StartDisplayTypeFullInfo(TypeInfo t)
        {
            DisplayTypeFullInfo(t);

            while (true)
            {
                char c = char.ToLower(Console.ReadKey(true).KeyChar);
                if (c == '8')
                {
                    StartDisplayMethodsInfo(t);
                    break;
                }
                else if (c == '9')
                {
                    StartSelectTypeInfo();
                }
                else if (c == '0')
                {
                    MainMenu m = new MainMenu();
                    m.StartMainMenu();
                    break;
                }
            }
        }

        private void StartDisplayMethodsInfo(TypeInfo t)
        {
            DisplayMethodsInfo(t);

            while (true)
            {
                char c = char.ToLower(Console.ReadKey(true).KeyChar);
                if (c == '9')
                {
                    StartDisplayTypeFullInfo(t);
                }
                else if (c == '0')
                {
                    MainMenu m = new MainMenu();
                    m.StartMainMenu();
                    break;
                }
            }
        }
        #endregion

        #region DISPLAY methods
        private void DisplayMenuSelectTypeInfo()
        {
            Console.Clear();
            Console.WriteLine($"Select type info:\n" +
                              $"================\n" +
                              $"[1] - [ INT ]\n" +
                              $"[2] - [ LONG ]\n" +
                              $"[3] - [ FLOAT ]\n" +
                              $"[4] - [ DOUBLE ]\n" +
                              $"[5] - [ CHAR ]\n" +
                              $"[6] - [ STRING ]\n" +
                              $"[7] - [ ConsoleColor ]\n" +
                              $"[8] - [ nullable ]\n" +
                              $"[9] - [ nullable ]\n" +
                              $"================\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }

        private void DisplayTypeFullInfo(TypeInfo t)
        {
            Console.Clear();
            Console.WriteLine($"TYPE: {t.TypeName}\n" +
                              $"================\n" +
                              $"Is value type: {(t.IsValueType == true ? "+" : "-")}\n" +
                              $"Namespace: {t.Namespace}\n" +
                              $"Assembly: {t.Assembly}\n" +
                              $"Element count: {t.ElementsCount}\n" +
                              $"- fields: {t.FieldsCount}\n" +
                              $"- properties: {t.PropertiesCount}\n" +
                              $"- methods: {t.MethodsCount}\n" +
                              $"Fields list: {string.Join(", ", t.FieldsInType)}\n" +
                              $"Properties list: {string.Join(", ", t.PropertiesInType)}\n" +
                              $"================\n" +
                              $"[8] - [ METHODS INFO ]\n" +
                              $"================\n" +
                              $"[9] - [ BACK ]\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }

        private void DisplayMethodsInfo(TypeInfo t)
        {
            Console.Clear();
            Console.WriteLine($"TYPE`s METHODS: {t.TypeName}\n" +
                              $"================\n" +
                              $"{"Method`s name", -30}" +
                              $"{"Overloads count", -18}" +
                              $"{"Parameters count", -16}\n");
            
            foreach (KeyValuePair<string, int[]> item in t.DictMethodsInType)
            {
                Console.WriteLine($"{item.Key,-30}" + 
                                  $"{item.Value[0],-18}" + 
                                  $"{item.Value[1],1}" + $".." +
                                  $"{item.Value[2],-2}"
                                  );
            }

            Console.WriteLine($"================\n" +
                              $"[9] - [ BACK ]\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }
        #endregion
    }
}


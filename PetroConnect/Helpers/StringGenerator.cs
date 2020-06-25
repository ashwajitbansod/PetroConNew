using System;

namespace PetroConnect.API.Helpers
{
    public static class StringGenerator
    {
        public static string GetProcedureParameter<T>(T obj , string spName) where T: class
        {
            var attributeCount = 0;
            System.Text.StringBuilder param = new System.Text.StringBuilder();
            Type type = typeof(T);

            attributeCount = type.GetProperties().Length;
            for (var i = 0; i < attributeCount; i++)
            {
                param.Append("{" + i + "} , ");
            }
            
            return " exec " + spName  + " " + ( param.ToString().Length > 2 ?  param.ToString().Substring(0, param.Length - 2) : param.ToString());
        }
        public static string GetProcedureParameter(int parameterCount, string spName) 
        {
            System.Text.StringBuilder param = new System.Text.StringBuilder();
            for (var i = 0; i < parameterCount; i++)
            {
                param.Append("{" + i + "} , ");
            }

            return " exec " + spName + " " + (param.ToString().Length > 2 ? param.ToString().Substring(0, param.Length - 2) : param.ToString());
        }


        public static string GetProcedureParameter(string spName)
        {
            return " exec " + spName + " ";
        }
    }
}

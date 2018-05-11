using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.MAPPER
{
    public abstract class EntityMapper
    {
        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (val == DBNull.Value) return null;
            if (result && dic.ContainsKey(attName) && val is string)
                return (string)val;
            
            return "";
        }

        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (result && dic.ContainsKey(attName) && (val is int || val is decimal))
                return (int)dic[attName];

            return -1;
        }

        protected float GetFloatValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (result && dic.ContainsKey(attName) && val is float || val is double)
                return Convert.ToSingle(dic[attName]);

            return -1;
        }

        protected double GetDoubleValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (result && dic.ContainsKey(attName) && val is double)
                return (double)dic[attName];

            return -1;
        }

        protected bool GetBooleanValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (result && dic.ContainsKey(attName) && val is bool)
                return (bool)dic[attName];

            return false;
        }

        protected DateTime GetDateValue(Dictionary<string, object> dic, string attName)
        {
            // >> Try to get the value from the dictionary, if it fails then return default
            var result = dic.TryGetValue(attName, out var val);
            if (result && dic.ContainsKey(attName) && val is DateTime)
                return (DateTime)dic[attName];

            return DateTime.Now;
        }
    }
}

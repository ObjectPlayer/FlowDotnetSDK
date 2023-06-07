using System;
using System.Dynamic;
using Flow.Net.Sdk.Core;
using Flow.Net.Sdk.Core.Cadence;
using Flow.Net.Sdk.Core.Models;

namespace Decoding
{
    public class CadenceDecoding
    {
        string[] numberTypes = { "Int", "UInt", "Int8", "UInt8", "Int16", "UInt16", "Int32", "UInt32", "Int64", "UInt64", "Int128", "UInt128", "Int256", "UInt256", "Word8", "Word16", "Word32", "Word64", "Fix64", "UFix64" };

        string[] compositeTypes = { "Struct", "Resource" };

        public dynamic decode(ICadence value)
        {

            //Current Limitation 
            //Never, Type, Capability, Path, 
            string type = getType(value);

            //Boolean Type
            if (type == "Bool")
                return resolveBoolean(value);

            //Number Type
            else if (Array.IndexOf(numberTypes, type) > -1)
                return resolveNumber(value);

            //Address Type
            else if (type == "Address")
                return resolveAddress(value);

            //String Type
            else if (type == "String")
                return resolveString(value);

            //Array Type
            else if (type == "Array")
                return resolveArray(value);

            //Dictionary Type
            else if (type == "Dictionary")
                return resolveDictionary(value);

            //Dictionary Type
            else if (type == "Optional")
                return resolveOptional(value);

            //Link Type
            else if (type == "Link")
                return resolveLink(value);

            //Path Type
            else if (type == "Path")
                return resolvePath(value);

            //Type-value Type
            else if (type == "Type")
                return resolveTypeValue(value);


            //Composite Type
            else if (Array.IndexOf(compositeTypes, type) > -1)
                return resolveCompositeType(value);

            //Void Type
            else if (type == "Void")
                return null;


            return null;

        }

        public string getType(ICadence value)
        {
            return value.Type;
        }

        public bool resolveBoolean(ICadence value)
        {
            return value.As<CadenceBool>().Value;
        }
        public dynamic resolveNumber(ICadence value)
        {
            return value.As<CadenceNumber>().Value;
        }

        public string resolveAddress(ICadence value)
        {
            return value.As<CadenceAddress>().Value;
        }

        public string resolveString(ICadence value)
        {
            return value.As<CadenceString>().Value;
        }

        public dynamic resolveArray(ICadence value)
        {
            IList<ICadence> values = value.As<CadenceArray>().Value;
            dynamic result = new dynamic[values.Count];

            for (int i = 0; i < values.Count; i++)
            {
                result[i] = decode(values[i]);
            }

            return result;
        }

        public dynamic resolveDictionary(ICadence cadenceObject)
        {
            IList<CadenceDictionaryKeyValue> values = cadenceObject.As<CadenceDictionary>().Value;

            Dictionary<object, object> result = new Dictionary<object, object>();


            for (int i = 0; i < values.Count; i++)
            {
                CadenceDictionaryKeyValue keyValue = values[i];

                dynamic key = decode(keyValue.Key);
                dynamic value = decode(keyValue.Value);

                result[key] = value;
            }

            return result;
        }

        public dynamic resolveOptional(ICadence cadenceObject)
        {
            ICadence optionalValue = cadenceObject.As<CadenceOptional>().Value;
            return optionalValue == null ? null : decode(optionalValue);
        }
        public dynamic resolveLink(ICadence cadenceObject)
        {
            CadenceLinkValue linkValue = cadenceObject.As<CadenceLink>().Value;
            Dictionary<object, object> result = new Dictionary<object, object>();
            result["targetPath"] = linkValue.TargetPath;
            result["borrowType"] = linkValue.BorrowType;
            return result;
        }

        public dynamic resolvePath(ICadence cadenceObject)
        {
            CadencePathValue pathValue = cadenceObject.As<CadencePath>().Value;
            Dictionary<object, object> result = new Dictionary<object, object>();
            result["domain"] = pathValue.Domain;
            result["identifier"] = pathValue.Identifier;
            return result;
        }

        public dynamic resolveTypeValue(ICadence cadenceObject)
        {
            CadenceTypeValueValue typeValue = cadenceObject.As<CadenceTypeValue>().Value;
            Dictionary<object, object> result = new Dictionary<object, object>();
            result["staticType"] = typeValue.StaticType;
            return result;
        }

        public dynamic resolveCompositeType(ICadence cadenceObject)
        {
            IEnumerable<CadenceCompositeItemValue> values = cadenceObject.As<CadenceComposite>().Value.Fields;

            Dictionary<object, object> result = new Dictionary<object, object>();


            foreach (var item in values)
            {
                dynamic key = item.Name;
                dynamic value = decode(item.Value);

                result[key] = value;
            }

            return result;
        }

    }
}
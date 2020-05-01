using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RaspberryDashboard_Backend.JsonContractResolver
{
    public class LongNameContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var list = base.CreateProperties(type, memberSerialization);

            foreach (var prop in list) prop.PropertyName = prop.UnderlyingName;

            return list;
        }
    }
}
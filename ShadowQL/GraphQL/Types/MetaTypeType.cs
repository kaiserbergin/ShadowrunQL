using GraphQL.Types;
using ShadowQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.GraphQL.Types
{
    public class MetaTypeType: ObjectGraphType<Metatype>
    {
        public MetaTypeType()
        {
            Field(t => t.Id);
            Field(t => t.Type).Description("Your metatype");
        }
    }
}

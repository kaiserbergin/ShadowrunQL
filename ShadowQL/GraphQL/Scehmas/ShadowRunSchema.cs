using GraphQL;
using GraphQL.Types;
using ShadowQL.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.GraphQL.Scehmas
{
    public class ShadowRunSchema: Schema
    {
        public ShadowRunSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<ShadowRunQuery>();
        }
    }
}

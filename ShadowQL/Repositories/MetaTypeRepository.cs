using Microsoft.EntityFrameworkCore;
using ShadowQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowQL.Repositories
{
    public class MetaTypeRepository
    {
        private readonly ShadowRunContext shadowRunContext;

        public MetaTypeRepository(ShadowRunContext shadowRunContext)
        {
            this.shadowRunContext = shadowRunContext;
        }

        public async Task<IEnumerable<Metatype>> GetAll() => await shadowRunContext.Metatypes.ToListAsync();

        public async Task<Metatype> GetById(int? id) => await shadowRunContext.Metatypes.Where(m => m.Id == id).FirstOrDefaultAsync();

        public async Task<string> GetMetaTypeAsString(int? id)
        {
            var type = await shadowRunContext.Metatypes.Where(m => m.Id == id).FirstOrDefaultAsync();
            return type.Type;
        }

        public async Task<ILookup<int, Metatype>> GetByIds(IEnumerable<int?> ids)
        {
            var metaTypes = await shadowRunContext.Metatypes.Where(m => ids.Contains(m.Id)).ToListAsync();
            return metaTypes.ToLookup(x => x.Id);
        }

        public async Task<ILookup<int, string>> GetMetatypesAsStrings(IEnumerable<int> ids)
        {
            var metaTypes = await shadowRunContext.Metatypes.Where(m => ids.Contains(m.Id)).ToListAsync();
            return metaTypes.ToLookup(x => x.Id, x => x.Type);
        }

    }
}

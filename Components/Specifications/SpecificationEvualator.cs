using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Specifications
{
    public class SpecificationEvaluator <Tentity> where Tentity : BaseEntity
    {
        public static IQueryable <Tentity> GetQuery(IQueryable<Tentity> input , ISpecification<Tentity> spec){
            var query = input;
            if (spec.Criteria != null)
            {
                query= query.Where(spec.Criteria);
            }
            query=spec.Includes.Aggregate(query,(current,include) => current.Include(include));

            return query;
        }
        
    }
}
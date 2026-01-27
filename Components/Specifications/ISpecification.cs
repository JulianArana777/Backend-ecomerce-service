using System.Linq.Expressions;

namespace API.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria {get;}
        List<Expression<Func<T,object>>> Includes {get;}
        Expression<Func<T,object>> OrderBy{get;set;}
         Expression<Func<T,object>> OrderByDesc{get;set;}
    }
}
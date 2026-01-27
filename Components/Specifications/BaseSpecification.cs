using System.Linq.Expressions;

namespace API.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria )
        {
            Criteria=criteria;
            
        }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
           new List<Expression<Func<T, object>>>();
       
        protected void  AddInclude(Expression<Func<T, object>> IncludedExpression)
        {
            Includes.Add(IncludedExpression);
        }  

        public Expression<Func<T, object>> OrderBy { get ;  set ; }
        public Expression<Func<T, object>> OrderByDesc { get ;  set ; }

        protected void  AddOrderBy(Expression<Func<T,object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }
            protected void  AddOrderByDesc(Expression<Func<T,object>> OrderByExpression)
        {
            OrderByDesc = OrderByExpression;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.Utils
{
    //使 EntityFrameWork 自动 去除字符串 末尾 空格
    public class StringTrimmerInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if(interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                if(interceptionContext.Result is DbQueryCommandTree queryCommand)
                {
                    var newQuery = queryCommand.Query.Accept(new StringTrimmerQueryVisitor());
                    interceptionContext.Result = new DbQueryCommandTree(
                        queryCommand.MetadataWorkspace,
                        queryCommand.DataSpace,
                        newQuery);


                }
            }
        }
    }

     class StringTrimmerQueryVisitor : DefaultExpressionVisitor
    {
        private static readonly string[] _typeToTrim = { "nvarchar", "varchar", "char", "nchar" };
        public override DbExpression Visit(DbNewInstanceExpression expression)
        {
            var argments = expression.Arguments.Select(t =>
            {
                if (t is DbPropertyExpression propertyArg && _typeToTrim.Contains(propertyArg.Property.TypeUsage.EdmType.Name))
                {
                    return EdmFunctions.Trim(t);
                }
                return t;
            });

            return DbExpressionBuilder.New(expression.ResultType, argments);
        }
    }


}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.EFLog
{
    //自定义EF Log格式
    public class SingleLineFormmatter:DatabaseLogFormatter
    {
        public SingleLineFormmatter(DbContext context,Action<string> writeAction):base(context,writeAction)
        {

        }

        public override void LogCommand<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            // base.LogCommand(command, interceptionContext);
            Write(string.Format("Context '{0}' is excuting command '{1}'{2}", Context.GetType().Name, command.CommandText.Replace(Environment.NewLine, ""), Environment.NewLine));
        }

        public override void LogResult<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
      
        }
    }
}

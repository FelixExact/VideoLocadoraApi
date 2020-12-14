using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}

using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public interface ICursoDAL : IDALGenerico<Curso> 
    {
        IEnumerable<Curso> GetByPlan(int IdPlan);


    }
}

using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class MatriculaDALImpl : IMatriculaDAL
    {
        SISTEMA_ACADEMICOContext context;

        public MatriculaDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }
        public bool Add(Matricula entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Matricula> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matricula> Find(Expression<Func<Matricula, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Matricula Get(int ID_MATRICULA)
        {
            try
            {
                Matricula matricula;
                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    matricula = unidad.genericDAL.Get(ID_MATRICULA);
                }
                return matricula;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Matricula> Get()
        {
            try
            {
                IEnumerable<Matricula> matricula;
                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    matricula = unidad.genericDAL.GetAll();
                }
                return matricula.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Matricula> GetAll()
        {
            try
            {
                IEnumerable<Matricula> matricula;
                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    matricula = unidad.genericDAL.GetAll();
                }
                return matricula;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Matricula entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Matricula> entities)
        {
            throw new NotImplementedException();
        }

        public Matricula SingleOrDefault(Expression<Func<Matricula, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Matricula matricula)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Matricula> unidad = new UnidadDeTrabajo<Matricula>(context))
                {
                    unidad.genericDAL.Update(matricula);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
}

    

using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CursoDALImpl : ICursoDAL
    {
        SISTEMA_ACADEMICOContext context;

        public CursoDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }

        public bool Add(Curso entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
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

        public void AddRange(IEnumerable<Curso> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Curso> Find(Expression<Func<Curso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Curso Get(int IdCurso)
        {
            try
            {
                Curso curso;
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
                {
                    curso = unidad.genericDAL.Get(IdCurso);
                }
                return curso;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Curso> Get()
        {
            try
            {
                IEnumerable<Curso> cursos;
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
                {
                    cursos = unidad.genericDAL.GetAll();
                }
                return cursos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Curso> GetAll()
        {
            try
            {
                IEnumerable<Curso> cursos;
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
                {
                    cursos = unidad.genericDAL.GetAll();
                }
                return cursos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Curso entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
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

        public void RemoveRange(IEnumerable<Curso> entities)
        {
            throw new NotImplementedException();
        }

        public Curso SingleOrDefault(Expression<Func<Curso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Curso curso)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Curso> unidad = new UnidadDeTrabajo<Curso>(context))
                {
                    unidad.genericDAL.Update(curso);
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

using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class EstudianteDALImpl : IEstudianteDAL
    {
        SISTEMA_ACADEMICOContext context;

        public EstudianteDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }

        public bool Add(Estudiante entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
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

        public void AddRange(IEnumerable<Estudiante> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estudiante> Find(Expression<Func<Estudiante, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Estudiante Get(int IdEstudiante)
        {
            try
            {
                Estudiante estudiante;
                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
                {
                    estudiante = unidad.genericDAL.Get(IdEstudiante);
                }
                return estudiante;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Estudiante> Get()
        {
            try
            {
                IEnumerable<Estudiante> estudiantes;
                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
                {
                    estudiantes = unidad.genericDAL.GetAll();
                }
                return estudiantes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Estudiante> GetAll()
        {
            try
            {
                IEnumerable<Estudiante> estudiantes;
                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
                {
                    estudiantes = unidad.genericDAL.GetAll();
                }
                return estudiantes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Estudiante entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
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

        public void RemoveRange(IEnumerable<Estudiante> entities)
        {
            throw new NotImplementedException();
        }

        public Estudiante SingleOrDefault(Expression<Func<Estudiante, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Estudiante estudiante)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Estudiante> unidad = new UnidadDeTrabajo<Estudiante>(context))
                {
                    unidad.genericDAL.Update(estudiante);
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

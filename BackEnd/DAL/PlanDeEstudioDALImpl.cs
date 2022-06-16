using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PlanDeEstudioDALImpl : IPlanDeEstudioDAL
    {
        SISTEMA_ACADEMICOContext context;

        public PlanDeEstudioDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }

        public bool Add(PlanEstudio entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
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

        public void AddRange(IEnumerable<PlanEstudio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanEstudio> Find(Expression<Func<PlanEstudio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public PlanEstudio Get(int ID_PLAN_ESTUDIO)
        {
            try
            {
                PlanEstudio planEstudio;
                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
                {
                    planEstudio = unidad.genericDAL.Get(ID_PLAN_ESTUDIO);
                }
                return planEstudio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PlanEstudio> Get()
        {
            try
            {
                IEnumerable<PlanEstudio> planesDeEstudio;
                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
                {
                    planesDeEstudio = unidad.genericDAL.GetAll();
                }
                return planesDeEstudio.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PlanEstudio> GetAll()
        {
            try
            {
                IEnumerable<PlanEstudio> planesDeEstudio;
                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
                {
                    planesDeEstudio = unidad.genericDAL.GetAll();
                }
                return planesDeEstudio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(PlanEstudio entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
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

        public void RemoveRange(IEnumerable<PlanEstudio> entities)
        {
            throw new NotImplementedException();
        }

        public PlanEstudio SingleOrDefault(Expression<Func<PlanEstudio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(PlanEstudio planEstudio)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<PlanEstudio> unidad = new UnidadDeTrabajo<PlanEstudio>(context))
                {
                    unidad.genericDAL.Update(planEstudio);
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

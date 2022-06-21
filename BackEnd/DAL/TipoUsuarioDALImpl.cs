using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public  class TipoUsuarioDALImpl : ITipoUsuarioDAL
    {
        SISTEMA_ACADEMICOContext context;

        public TipoUsuarioDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }

        public bool Add(TipoUsuario entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
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

        public void AddRange(IEnumerable<TipoUsuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoUsuario> Find(Expression<Func<TipoUsuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario Get(int ID_TIPO_USUARIO)
        {
            try
            {
                TipoUsuario tipoUsuario;
                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
                {
                    tipoUsuario = unidad.genericDAL.Get(ID_TIPO_USUARIO);
                }
                return tipoUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Get()
        {
            try
            {
                IEnumerable<TipoUsuario> tipoUsuarios;
                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
                {
                    tipoUsuarios = unidad.genericDAL.GetAll();
                }
                return tipoUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TipoUsuario> GetAll()
        {
            try
            {
                IEnumerable<TipoUsuario> tipoUsuarios;
                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
                {
                    tipoUsuarios = unidad.genericDAL.GetAll();
                }
                return tipoUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TipoUsuario entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
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

        public void RemoveRange(IEnumerable<TipoUsuario> entities)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario SingleOrDefault(Expression<Func<TipoUsuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoUsuario tipoUsuario)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TipoUsuario> unidad = new UnidadDeTrabajo<TipoUsuario>(context))
                {
                    unidad.genericDAL.Update(tipoUsuario);
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

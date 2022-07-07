using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {
        SISTEMA_ACADEMICOContext context;

        public UsuarioDALImpl()
        {
            context = new SISTEMA_ACADEMICOContext();

        }

        public bool Add(Usuario entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int IdUsuario)
        {
            try
            {
                Usuario usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.Get(IdUsuario);
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Get()
        {
            try
            {
                IEnumerable<Usuario> usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.GetAll();
                }
                return usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                IEnumerable<Usuario> usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.GetAll();
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return GetAll().Where(item => item.Email == _correo && item.Contrasena == _clave).FirstOrDefault();
        }

        public bool Remove(Usuario entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Curso SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario usuario)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    unidad.genericDAL.Update(usuario);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        Usuario IDALGenerico<Usuario>.SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

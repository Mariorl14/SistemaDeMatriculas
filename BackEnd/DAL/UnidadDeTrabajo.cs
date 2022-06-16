using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly SISTEMA_ACADEMICOContext context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenerico<T> genericDAL;


        public UnidadDeTrabajo(SISTEMA_ACADEMICOContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
          
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}

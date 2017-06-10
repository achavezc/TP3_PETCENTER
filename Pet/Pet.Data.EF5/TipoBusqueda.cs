﻿using Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
    public static class TipoBusqueda
    {
        public static List<BETipoBusqueda> ListaTipoBusqueda()
        {
            List<BETipoBusqueda> lista = new List<BETipoBusqueda>();

            using (var db = new EFData.PETCENTEREntities1())
            {
                foreach (var item in db.TipoBusquedas.ToList())
                {
                    BETipoBusqueda it = new BETipoBusqueda();
                    it.Codigo = item.Codigo;
                    it.Descripcion = item.Descripcion;
                    it.EstadoRegistro = item.EstadoRegistro;
                    lista.Add(it);
                }

                return lista;
            }
        }
    }
}

﻿// Librerias
using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_aplicaciones.Implementaciones
{
    public class LocalizacionesAplicacion : ILocalizacionesAplicacion
    {
        // Variable para interactuar con el repositorio
        private ILocalizacionesRepositorio? iRepositorio = null;
        // Constructor
        public LocalizacionesAplicacion(ILocalizacionesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        // Metodos
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Localizaciones Borrar(Localizaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Localizaciones Guardar(Localizaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Localizaciones> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Localizaciones> Buscar(Localizaciones entidad, string tipo)
        {
            Expression<Func<Localizaciones, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.test!.Contains(entidad.test!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Localizaciones Modificar(Localizaciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        /* Metodo vacio
        private Localizaciones Calcular(Localizaciones entidad)
        {
        }
        */
    }
}
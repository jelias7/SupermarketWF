using BLL;
using DAL;
using Entidades;
using SupermarketRosario.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupermarketRosario.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                id.Text = "0";

                int idx = Utils.ToInt(Request.QueryString["id"]);
                if (idx > 0)
                {
                    BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
                    var us = repositorio.Buscar(idx);

                    if (us == null)
                    {
                        MostrarMensaje(TiposMensaje.Error, "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampo(us);
                    }
                }
            }
        }
        private void Limpiar()
        {
            id.Text = "0";
            nombres.Text = string.Empty;
            usuario.Text = string.Empty;
            clave.Text = string.Empty;
            confirmar.Text = string.Empty;
            email.Text = string.Empty;
            fecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            id.Text = Convert.ToString(usuarios.UsuarioId);
            nombres.Text = usuarios.Nombres;
            usuario.Text = usuarios.Usuario;
            clave.Text = Eramake.eCryptography.Decrypt(usuarios.Clave);
            confirmar.Text = Eramake.eCryptography.Decrypt(usuarios.Clave);
            email.Text = usuarios.Email;
            fecha.Text = usuarios.FechaCreacion.ToString("yyyy-MM-dd");
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar(Convert.ToInt32(id.Text));
            return (usuarios != null);
        }
        void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            Error.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                Error.CssClass = "alert-success";
            else if (tipo == TiposMensaje.Error)
                Error.CssClass = "alert-danger";
            else
                Error.CssClass = "alert-warning";
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = Utils.ToInt(id.Text);
            usuarios.Nombres = nombres.Text;
            usuarios.Usuario = usuario.Text;
            usuarios.Clave = Eramake.eCryptography.Encrypt(clave.Text);
            usuarios.Email = email.Text;
            usuarios.FechaCreacion = Utils.ToDateTime(fecha.Text);

            return usuarios;
        }
        private bool ClavesCoinciden()
        {
            bool paso = true;

            if (clave.Text != confirmar.Text) { MostrarMensaje(TiposMensaje.Warning, "Las claves no coinciden."); paso = false; }

            return paso;
        }
        public static bool RepetirUser(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuario.Any(p => p.Usuario.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool RepetirEmail(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuario.Any(p => p.Email.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool ValidarRepetir()
        {
            bool paso = true;

            if (RepetirUser(usuario.Text) || RepetirEmail(email.Text))
            {
                MostrarMensaje(TiposMensaje.Warning, "Ya existe ese!");
                paso = false;
            }
            return paso;
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();

            bool paso = false;

            if (!ClavesCoinciden())
                return;

            usuarios = LlenaClase();
            if (Utils.ToInt(id.Text) == 0)
            {
                if (!ValidarRepetir())
                    return;

                paso = Repositorio.Guardar(usuarios);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {

                    MostrarMensaje(TiposMensaje.Error, "No existe ese usuario");
                    return;
                }
                paso = Repositorio.Modificar(usuarios);
                Limpiar();
            }

            if (paso)
            {
                MostrarMensaje(TiposMensaje.Success, "Se ha guardado");
                return;
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Problema al guardar");

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();

            var usuario = Repositorio.Buscar(Utils.ToInt(id.Text));
            if (usuario != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(id.Text)))
                {
                    MostrarMensaje(TiposMensaje.Success, "Exito!");
                    Limpiar();
                }
                else
                    MostrarMensaje(TiposMensaje.Error, "Error!");
            }
            else
                MostrarMensaje(TiposMensaje.Error, "Error!");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();

            usuarios = Repositorio.Buscar(Utils.ToInt(id.Text));
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                MostrarMensaje(TiposMensaje.Warning, "Problemas inesperados al buscar!");
        }
    }
}
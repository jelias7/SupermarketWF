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
                FechaTextBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
                IDTextBox.Text = "0";

                int ID = Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
                    var us = repositorio.Buscar(ID);

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
            IDTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            IDTextBox.Text = Convert.ToString(usuarios.UsuarioId);
            NombresTextBox.Text = usuarios.Nombres;
            UsuarioTextBox.Text = usuarios.Usuario;
            ClaveTextBox.Text = Eramake.eCryptography.Decrypt(usuarios.Clave);
            ConfirmarTextBox.Text = Eramake.eCryptography.Decrypt(usuarios.Clave);
            EmailTextBox.Text = usuarios.Email;
            FechaTextBox.Text = usuarios.FechaCreacion.ToString("yyyy-MM-dd");
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar(Convert.ToInt32(IDTextBox.Text));
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
            usuarios.UsuarioId = Utils.ToInt(IDTextBox.Text);
            usuarios.Nombres = NombresTextBox.Text;
            usuarios.Usuario = UsuarioTextBox.Text;
            usuarios.Clave = Eramake.eCryptography.Encrypt(ClaveTextBox.Text);
            usuarios.Email = EmailTextBox.Text;
            usuarios.FechaCreacion = Utils.ToDateTime(FechaTextBox.Text);

            return usuarios;
        }
        private bool ClavesCoinciden()
        {
            bool paso = true;

            if (ClaveTextBox.Text != ConfirmarTextBox.Text) { MostrarMensaje(TiposMensaje.Warning, "Las claves no coinciden."); paso = false; }

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

            if (RepetirUser(UsuarioTextBox.Text) || RepetirEmail(EmailTextBox.Text))
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
            if (Utils.ToInt(IDTextBox.Text) == 0)
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

            var usuario = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            if (usuario != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
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

            usuarios = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                MostrarMensaje(TiposMensaje.Warning, "Problemas inesperados al buscar!");
        }
    }
}
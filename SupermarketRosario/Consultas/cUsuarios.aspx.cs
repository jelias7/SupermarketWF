using BLL;
using Entidades;
using SupermarketRosario.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupermarketRosario.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
                HastaFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtros = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();

            DateTime Desde = Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utils.ToDateTime(HastaFecha.Text);

            int id;
            id = Utils.ToInt(CriterioTextBox.Text);
            switch (FiltroDropDown.SelectedIndex)
            {
                case 0: //ID                  
                    filtros = c => c.UsuarioId == id && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 1: //Usuario
                    filtros = c => c.Usuario.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 2: //Nombres
                    filtros = c => c.Nombres.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 3: //Email
                    filtros = c => c.Email.Contains(CriterioTextBox.Text) && c.FechaCreacion >= Desde && c.FechaCreacion <= Hasta;
                    break;
                case 4: //Todo
                    break;
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }

    }
}
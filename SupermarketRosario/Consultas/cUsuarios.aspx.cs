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

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> filtros = x => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();


            int id;
            id = Utils.ToInt(criterio.Text);
            switch (filtro.SelectedIndex)
            {
                case 0: //ID                  
                    filtros = c => c.UsuarioId == id;
                    break;
                case 1: //Usuario
                    filtros = c => c.Usuario.Contains(criterio.Text);
                    break;
                case 2: //Nombres
                    filtros = c => c.Nombres.Contains(criterio.Text);
                    break;
                case 3: //Email
                    filtros = c => c.Email.Contains(criterio.Text);
                    break;
                case 4: //Todo
                    break;
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }

    }
}
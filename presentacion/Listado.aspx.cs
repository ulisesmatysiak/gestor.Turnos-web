using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnos.DataSource = negocio.listar();
            dgvTurnos.DataBind();
        }
        protected void btnHoy_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnos.DataSource = negocio.listarHoy();
            dgvTurnos.DataBind();
        }

        protected void btnSemana_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnos.DataSource = negocio.listarSemana();
            dgvTurnos.DataBind();
        }
    }
}
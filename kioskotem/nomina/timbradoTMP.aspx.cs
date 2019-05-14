﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using kioskotem.wcfoperadora;


namespace kioskotem.nomina
{
    public partial class timbradoTMP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dtpinicio.SelectedDate = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                dtpfinal.SelectedDate = DateTime.Parse(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);


            }

        }

        protected void dtgnominas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dtgnominas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int id = Convert.ToInt32(e.CommandArgument);


                    DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
                    string carpetab = ((Label)dtgnominas.Rows[id].FindControl("lblbe")).Text;
                    string path;

                    if (carpetab != "")
                    {

                        Session["ruta"] = "recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.pdf";
                        Session["ruta2"] = "recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.xml";
                        path = Server.MapPath("../recibostOPERADORAMX/" + carpetab) + "\\" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.pdf";
                        String path2 = "../recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";
                    }
                    else
                    {
                        Session["ruta"] = "recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.pdf";
                        Session["ruta2"] = "recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.xml";
                        path = Server.MapPath("../recibostOPERADORAMX/") + "\\" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.pdf";
                        String path2 = "../recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.xml";
                    }

                    Session["archivo"] = fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.xml";
                    Session["archivoxml"] = fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "T.xml";
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    if (toDownload.Exists)
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2 + "','_blank')", true);
                        Response.Redirect("../descargar.aspx", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('No se encuentra el archivo ');", true);

                    }
                    
                }
                if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);

                    //Session["xml"] = "1";

                    DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
                    string carpetab = ((Label)dtgnominas.Rows[id].FindControl("lblb2")).Text;
                    string path;

                    if (carpetab != "")
                    {
                        Session["ruta"] = "recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.pdf";
                        Session["ruta2"] = "recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";
                        path = Server.MapPath("../recibostOPERADORAMX/" + carpetab) + "\\" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.pdf";
                        String path2 = "../recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";

                    }
                    else
                    {
                        Session["ruta"] = "recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.pdf";
                        Session["ruta2"] = "recibostOPERADORAMX/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";
                        path = Server.MapPath("../recibostOPERADORAMX/") + "\\" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.pdf";
                        String path2 = "../recibostOPERADORAMX/" + carpetab + "/" + fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";

                    }

                    Session["archivo"] = fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";
                    Session["archivoxml"] = fecha.Month.ToString("00") + fecha.Year.ToString() + Session["idcodigo"].ToString() + "TD.xml";
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    if (toDownload.Exists)
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2 + "','_blank')", true);
                        Response.Redirect("../descargar.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('No se encuentra el archivo ');", true);

                    }
                }
            }
            catch (Exception EX)
            {
                //clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
            }
        }


        
        protected void dtgnominas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgnominas.DataSource = (DataSet)Session["dsPagos"];
            dtgnominas.PageIndex = e.NewPageIndex;
            dtgnominas.DataBind();
        }

        protected void cmdbuscar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = "";

            cargar_grid();
        }


        private void cargar_grid()
        {
            IsvcOperadoraMxClient Manejador = new IsvcOperadoraMxClient(); 


            DataSet dsEmpresas = new DataSet();
            dsEmpresas.Tables.Add("Tabla");
            dsEmpresas.Tables[0].Columns.Add("iIdPago");
            //dsEmpresas.Tables[0].Columns.Add("pagob");
            dsEmpresas.Tables[0].Columns.Add("Fecha");
            dsEmpresas.Tables[0].Columns.Add("importesa");
            dsEmpresas.Tables[0].Columns.Add("nombrenomina");

            DateTime inicio = DateTime.Parse(dtpinicio.SelectedDate.ToString());
            DateTime final = DateTime.Parse(dtpfinal.SelectedDate.ToString());
            string inicial = inicio.Year.ToString() + inicio.Month.ToString("00") + inicio.Day.ToString("00");
            string fin = final.Year.ToString() + final.Month.ToString("00") + final.Day.ToString("00");



            try
            {
                Tabla tbEmpresas = Manejador.getEjecutaStoredProcedure1("getpagosnomina", "1|" + Session["idusuario"].ToString() + "|" + inicial + "|" + fin);
                if (tbEmpresas != null)
                {
                    DataTable dtEmpresas = clFunciones.convertToDatatable(tbEmpresas);
                    for (int x = 0; x < dtEmpresas.Rows.Count; x++)
                    {
                        dsEmpresas.Tables[0].Rows.Add(dtEmpresas.Rows[x]["iIdPago"],
                                                        //dtEmpresas.Rows[x]["pagob"],
                                                        DateTime.Parse(dtEmpresas.Rows[x]["Fecha"].ToString().Remove(18)),
                                                        //DateTime.Parse(dtEmpresas.Rows[x]["Fecha"].ToString()).ToShortDateString(),
                                                        dtEmpresas.Rows[x]["importesa"],
                                                        dtEmpresas.Rows[x]["nombrenomina"]);



                    }

                    Session["dsPagos"] = dsEmpresas;
                    dtgnominas.DataSource = dsEmpresas;

                }
                else
                {
                    Session["dsPagos"] = null;
                    dtgnominas.DataSource = null;
                    lblmensaje.Text = "Sin Pagos Recientes";

                }
                dtgnominas.DataBind();

            }
            catch (Exception EX)
            {
                clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
            }

        }
    }
}
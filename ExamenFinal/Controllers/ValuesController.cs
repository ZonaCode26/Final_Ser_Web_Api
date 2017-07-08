using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ExamenFinal.Models;

using System.Data.SqlClient;
using System.Data;

namespace ExamenFinal.Controllers
{
    public class ValuesController : ApiController
    {

        SqlConnection cn = new SqlConnection("server=.;database=negocios2017;uid=sa;pwd=sql");
        
        public List<Clientes> GetListado1()
        {
            List<Clientes> lista = new List<Clientes>() ;

            SqlCommand cmd = new SqlCommand("USP_LISTACLIENTEF", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Clientes reg = new Clientes();

                reg.idcliente = dr.GetString(0).ToString();
                reg.nombrecia = dr.GetString(1).ToString();
                reg.direccion = dr.GetString(2).ToString();
                reg.nombrepais = dr.GetString(3).ToString();
                reg.telefono = dr.GetString(4).ToString();
                lista.Add(reg);

            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public List<Paises> GetListaPais()
        {
            List<Paises> lista = new List<Paises>();

            SqlCommand cmd = new SqlCommand("USP_LISTAPAISESF", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Paises reg = new Paises();

                reg.idpais = dr.GetString(0).ToString();
                reg.nombrepais = dr.GetString(1).ToString();
               
                lista.Add(reg);

            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public List<Clientes> GetListadoCliente()
        {
            List<Clientes> lista = new List<Clientes>(); ;

            SqlCommand cmd = new SqlCommand("Select * from tb_clientes", cn);
          
            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Clientes reg = new Clientes();

                reg.idcliente = dr.GetString(0).ToString();
                reg.nombrecia = dr.GetString(1).ToString();
                reg.direccion = dr.GetString(2).ToString();
                reg.idpais = dr.GetString(3).ToString();
                reg.telefono = dr.GetString(4).ToString();
                lista.Add(reg);

            }
            dr.Close();
            cn.Close();
            return lista;
        }


        public string AgregarCliente(Clientes reg)
        {
            string msg = "";

            try
            {


                SqlCommand cmd = new SqlCommand("USP_AGREGARCLIENTEF", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", reg.idcliente);
                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@idp", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);
                cn.Open();
                cmd.ExecuteNonQuery();

                msg = "Agregado";
            }
            catch (Exception)
            {

                msg = "No Agregado";
            }
            finally {
                cn.Close();
            }

            return msg;
        }



        public string ActualizarCliente(Clientes reg)
        {
            string msg = "";

            try
            {


                SqlCommand cmd = new SqlCommand("USP_ACTUALIZARCLIENTEF", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", reg.idcliente);

                cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                cmd.Parameters.AddWithValue("@dir", reg.direccion);
                cmd.Parameters.AddWithValue("@idp", reg.idpais);
                cmd.Parameters.AddWithValue("@tel", reg.telefono);
                cn.Open();
                cmd.ExecuteNonQuery();

                msg = "Actualizado";
            }
            catch (Exception)
            {

                msg = "No Actualizado";
            }
            finally {

                cn.Close();
            }

            return msg;
        }






        Negocios2017Entities bd = new Negocios2017Entities();
        // GET api/values


        public IEnumerable<USP_LISTACLIENTEF_Result> GetListado()
        {
            return bd.USP_LISTACLIENTEF();
        }

        public IEnumerable<USP_LISTAPAISESF_Result> GetPaises()
        {
            return bd.USP_LISTAPAISESF();
        }


        public tb_clientes GetCliente(string id) {

            return bd.tb_clientes.ToList().Where(x=>x.IdCliente==id).FirstOrDefault();
        }


        public string Agregar(tb_clientes reg)
        {
            string msg = "";

            try {

                bd.USP_AGREGARCLIENTEF(reg.IdCliente,reg.NombreCia,reg.Direccion,reg.idpais,reg.Telefono);

                bd.SaveChanges();

                msg = "Agregado";
            }
            catch (Exception ) {

                msg = "No Agregado";
            }

            return msg;
        }

        public string Actualizar(tb_clientes reg)
        {
            string msg = "";

            try
            {

                bd.USP_ACTUALIZARCLIENTEF(reg.IdCliente, reg.NombreCia, reg.Direccion, reg.idpais, reg.Telefono);

                bd.SaveChanges();

                msg = "Actualizado";
            }
            catch (Exception)
            {
                msg = "No actualizado";
            }

            return msg;
        }
        /*
        public string Eliminar(string id)
        {
            string msg = "";
            bd.USP_ELIMINARF(id);
            bd.SaveChanges();
            msg

        }*/
      }
}

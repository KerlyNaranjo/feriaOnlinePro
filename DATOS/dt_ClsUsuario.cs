/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dt_ClsUsuario
/// </summary>
public class dt_ClsUsuario
{
    public dt_ClsUsuario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data;
using PryFeriaOnline.COMUN;
using System.Web.UI.WebControls;

namespace PryFeriaOnline.DATOS
{
    public class dt_ClsUsuario
    {
        public dt_ClsUsuario()
        {

        }

        public static string constr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            }
        }

        public static string provider
        {
            get { return ConfigurationManager.ConnectionStrings["Conn"].ProviderName; }
        }

        public static DbProviderFactory dpf
        {
            get
            {
                return DbProviderFactories.GetFactory(provider);
            }

        }

        //-------------------------------------------------

        private static int ejecuteNonQuery(string StoredProcedure, List<DbParameter> parametros)
        {
            int id = 0;
            try
            {
                using (DbConnection con = dpf.CreateConnection())
                {
                    con.ConnectionString = constr;
                    using (DbCommand cmd = dpf.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (DbParameter param in parametros)
                        {
                            cmd.Parameters.Add(param);
                        }
                        con.Open();
                        id = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return id;
        }

        //Insertar usuarios
        public int ingresarUsuarios (string nombre, string apellido, string tipoDocumento,
            string numeroDocumento, string correo, string usuario, string clave, int idRol)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = dpf.CreateParameter();
            param.Value = nombre;
            param.ParameterName = "Nombre";
            parametros.Add(param);

            DbParameter param1 = dpf.CreateParameter();
            param1.Value = apellido;
            param1.ParameterName = "Apellido";
            parametros.Add(param1);

            DbParameter param2 = dpf.CreateParameter();
            param2.Value = tipoDocumento;
            param2.ParameterName = "TipoDocumento";
            parametros.Add(param2);

            DbParameter param3 = dpf.CreateParameter();
            param3.Value = numeroDocumento;
            param3.ParameterName = "NumeroDocumento";
            parametros.Add(param3);

            DbParameter param4 = dpf.CreateParameter();
            param4.Value = correo;
            param4.ParameterName = "Correo";
            parametros.Add(param4);

            DbParameter param5 = dpf.CreateParameter();
            param5.Value = usuario;
            param5.ParameterName = "Usuario ";
            parametros.Add(param5);

            DbParameter param6 = dpf.CreateParameter();
            param6.Value = clave;
            param6.ParameterName = "Clave";
            parametros.Add(param6);

            DbParameter param7 = dpf.CreateParameter();
            param7.Value = idRol;
            param7.ParameterName = "IdRol";
            parametros.Add(param7);

        }

        //Listar usuario por ID
        public cm_ClsUsuario listarUsuarioPorId(string idUsuario)
        {
            cm_ClsUsuario obj_user = new cm_ClsUsuario();

            string storeProcedure = "obtenerUsuarioId";
            using (DbConnection con = dpf.CreateConnection())
            {
                con.ConnectionString = constr;
                using (DbCommand cmd = dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = storeProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "idUsuario";
                    param.Value = idUsuario;

                    cmd.Parameters.Add(param);
                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj_user = new cm_ClsUsuario(
                                     (string)dr["ced_User"], (string)dr["nom_User"],
                                    (string)dr["ape_User"], (string)dr["edad_User"],
                                    (string)dr["tlf_User"], (decimal)dr["pesoI_User"],
                                    (decimal)dr["alturaI_User"], (int)dr["cod_TipoFK"],
                                    (int)dr["cod_ActFK"]);
                        }
                    }


                }
            }
            return obj_user;
        }

        //actualizar usuario
        public int actualizarUsuario(string ced_User, string nom_User, string ape_User, string edad_User, string tlf_User, decimal pesoI_User
                                   , decimal alturaI_User, int act_Usu)
        {
            List<DbParameter> parametros = new List<DbParameter>();
            DbParameter param = dpf.CreateParameter();
            param.Value = ced_User;
            param.ParameterName = "ced_User";
            parametros.Add(param);

            DbParameter param1 = dpf.CreateParameter();
            param1.Value = nom_User;
            param1.ParameterName = "nom_User ";
            parametros.Add(param1);

            DbParameter param2 = dpf.CreateParameter();
            param2.Value = ape_User;
            param2.ParameterName = "ape_User  ";
            parametros.Add(param2);

            DbParameter param3 = dpf.CreateParameter();
            param3.Value = edad_User;
            param3.ParameterName = "edad_User";
            parametros.Add(param3);

            DbParameter param4 = dpf.CreateParameter();
            param4.Value = tlf_User;
            param4.ParameterName = "tlf_User";
            parametros.Add(param4);

            DbParameter param5 = dpf.CreateParameter();
            param5.Value = pesoI_User;
            param5.ParameterName = "pesoI_User ";
            parametros.Add(param5);

            DbParameter param6 = dpf.CreateParameter();
            param6.Value = alturaI_User;
            param6.ParameterName = "alturaI_User ";
            parametros.Add(param6);

            DbParameter param8 = dpf.CreateParameter();
            param8.Value = act_Usu;
            param8.ParameterName = "cod_ActFK ";
            parametros.Add(param8);


            return ejecuteNonQuery("modificarUsuario", parametros);
        }

        //listar todos los usuario
        public List<cm_ClsUsuario> listarUsuarios()
        {

            List<cm_ClsUsuario> ListaUsuario = new List<cm_ClsUsuario>();

            string storeProcedure = "obtenerUsuarios";
            using (DbConnection con = dpf.CreateConnection())
            {
                con.ConnectionString = constr;
                using (DbCommand cmd = dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = storeProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListaUsuario.Add(new cm_ClsUsuario(
                                 (string)dr["ced_User"], (string)dr["nom_User"],
                                (string)dr["ape_User"], (string)dr["edad_User"],
                                (string)dr["tlf_User"], (decimal)dr["pesoI_User"],
                                (decimal)dr["alturaI_User"], (int)dr["cod_TipoFK"],
                                (int)dr["cod_ActFK"]));
                        }
                    }
                }
            }
            return ListaUsuario;
        }

        //LISTAR USUARIOS POR ID  PARA VERIFICAR LOGIN 
        public cm_ClsUsuario listarUsuarioPorIdLogin(string iduser)
        {
            cm_ClsUsuario obj_user = new cm_ClsUsuario();

            string storeProcedure = "obtenerUsuarioId";
            using (DbConnection con = dpf.CreateConnection())
            {
                con.ConnectionString = constr;
                using (DbCommand cmd = dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = storeProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "ced_User";
                    param.Value = iduser;

                    cmd.Parameters.Add(param);
                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj_user = new cm_ClsUsuario((string)dr["ced_User"], (string)dr["nom_User"], (int)dr["cod_TipoFK"], (int)dr["cod_ActFK"]);

                        }
                    }
                }
            }
            return obj_user;
        }

        //DAR DE BAJA USUARIOS ------------------------------
        public int darBajaUsuario(string ced_User, int act_Usu)
        {
            List<DbParameter> parametros = new List<DbParameter>();
            DbParameter param = dpf.CreateParameter();
            param.Value = ced_User;
            param.ParameterName = "ced_User";
            parametros.Add(param);

            DbParameter param1 = dpf.CreateParameter();
            param1.Value = act_Usu;
            param1.ParameterName = "cod_ActFK";
            parametros.Add(param1);

            return ejecuteNonQuery("darBajaUser", parametros);
        }

        // Dar de baja usuario si se acaba los dias------------
        public int darBaja(string ced_User)
        {
            List<DbParameter> parametros = new List<DbParameter>();
            DbParameter param = dpf.CreateParameter();
            param.Value = ced_User;
            param.ParameterName = "ced_User";
            parametros.Add(param);
            return ejecuteNonQuery("darBaja", parametros);
        }


    }
}
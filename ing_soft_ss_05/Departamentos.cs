using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ing_soft_ss_07
{
    public partial class Departamentos : Form
    {
        public Departamentos()
        {
            InitializeComponent();
            mensaje_bd();
        }
        static string R_departamento;
        static string R_carreras;
        static string C_departamento;
        static string D_departamento;
        static int operacion;
        static string tabla;
        string query;
        static int registros;
        static int columnas = 2;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        static bool est = false;
        static string X = "";
        public static bool probarConexion()
        {
            MySqlConnection con;
            //Cadena de conexion
            //     cadenaConexion = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, database);

            con = new MySqlConnection(cs);

            con.Open();//se abre la conexion
            if (con.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void mensaje_bd()
        {
            if (probarConexion())
            {
                //            MessageBox.Show("si se pudo conectar a una base de datos");
            }
            else
            {
                MessageBox.Show("Error no se pudo conectar a una base de datos");
            }

        }
        public static void conexion_b(string sql, int ope, string tabla)
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                Consulta_b(conn, sql, ope, tabla);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        private static void Consulta_b(MySqlConnection conn, string sql, int ope, string tabla)
        {

            R_departamento = "";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            /*cmd.CommandText = "Select e.Fname, e.Lname, e.Ssn, e.Bdate, e.Address, " +
                " d.Dname from EMPLOYEE as e INNER JOIN DEPARTMENT as d on e.Dno = d.Dnumber " +
                " order by e.Lname, e.Fname";
            */
            try
            {
                MySqlDataReader MyReader = cmd.ExecuteReader();
                





                if (tabla.Equals("departamento"))
                {
                    
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                /* Console.WriteLine(MyReader.GetString("Fname") + " "
                                     + MyReader.GetString("Lname").ToString() + " "
                                     + MyReader.GetString("Ssn").ToString() + " "
                                     + MyReader.GetDateTime("Bdate").ToString() + " "
                                     + MyReader.GetString("address").ToString() + " "
                                     + MyReader.GetString("Dname").ToString());*/
                                //  MessageBox.Show(MyReader.GetString("Nombre").ToString());
                                R_departamento = MyReader.GetString("Nombre_departamento").ToString();
                                //        MessageBox.Show("Resultado: "+R_materias);


                            }

                            break;
                        case 2://Agregar

                            MessageBox.Show("Se ha registrado una nuevo Departamento");



                            break;
                        case 3://Modificar
                           

                   //         while (MyReader.Read())
                   //         {

                   //             R_departamento = MyReader.GetString("Nombre_departamento").ToString();
                               
                            MessageBox.Show("Se ha actualizado la base de datos");
                            est = true;
                            /*  if (R_departamento!="")
                              {
                                  MessageBox.Show("Se ha actualizado la base de datos");
                                  est = true;
                                  return;



                              }
                              else
                              {
                                  MessageBox.Show("ERROR al Actulizar, La Clave No Existe");
                                  return;

                              }
                              */

                            //        }
                            //        MessageBox.Show("Mensaje 2 " + R_departamento);


                            break;
                        case 4://Borrar
                            MessageBox.Show("Registro Eliminado de " + tabla);
                            break;
                    }


                }
                else if (tabla.Equals("Carreras"))
                {

                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                /* Console.WriteLine(MyReader.GetString("Fname") + " "
                                     + MyReader.GetString("Lname").ToString() + " "
                                     + MyReader.GetString("Ssn").ToString() + " "
                                     + MyReader.GetDateTime("Bdate").ToString() + " "
                                     + MyReader.GetString("address").ToString() + " "
                                     + MyReader.GetString("Dname").ToString());*/
                                //  MessageBox.Show(MyReader.GetString("Nombre").ToString());
                                R_carreras = MyReader.GetString("Nombre").ToString();


                            }

                            break;
                        case 2://Agregar
                            MessageBox.Show("Se ha registrado una nueva carrera");
                            break;
                        case 3://Modificar
                       //     while (MyReader.Read())
                      //      {

                       //         R_carreras = MyReader.GetString("Nombre").ToString();
                                MessageBox.Show("Se ha actualizado la base de datos");
                       //     }


                            break;
                        case 4://Borrar
                            MessageBox.Show("Registro Eliminado de " + tabla);
                            break;
                    }

                }
                else if (tabla.Equals("Chcar_R"))
                {
                    while (MyReader.Read())
                    {
                        R_departamento = MyReader.GetString("conteo").ToString();
                        MessageBox.Show("Conteo: " + R_departamento);
                        registros = int.Parse(R_departamento);


                    }

                }
                else if (tabla.Equals("Existe_clv"))
                {
                    while (MyReader.Read())
                    {
                       
                        R_departamento= MyReader.GetString(X).ToString();


                    }
                }
                /*    else if (tabla.Equals("llenado_matriz"))
                    {
                        int i = 0;
                        while (MyReader.Read())
                        {
                            if (i<registros)
                            {
                                matriz[i, 0] = MyReader.GetString("clave").ToString();
                                matriz[i, 1] = MyReader.GetString("nombre").ToString();
                                i++;
                            }
                            else
                            {
                            }

                        }

               */



            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1062:
                        // Aquí gestiona la Excepción..
                        MessageBox.Show("Error Datos duplicados");
                        break;
                    case 1046:
                        //busca un id que no existe
                        MessageBox.Show("No Existe ese Registro");
                        break;
                }
            }

        }
        //metodo comprobar si existe
        public Boolean esNuevo(string id, string des)
        {

            return true;
        }
        public  bool existe(string n,string x)
        {
            X = x;
          //  tabla = "departamento";
            query = "Select * from departamento where Clv_departamento =" + n;
            conexion_b(query, operacion, "Existe_clv");
            if (R_departamento==n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        private void btn_agragar_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
           


        }

        private void Departamentos_Load(object sender, EventArgs e)
        {

        }

        private void txt_clave_Leave(object sender, EventArgs e)
        {
            operacion = 1;
            tabla = "departamento";
            C_departamento = txt_clave.Text;
            if (!C_departamento.Equals("") )
            {
                query = "Select * from departamento where Clv_departamento =" + C_departamento;
                conexion_b(query, operacion, tabla);
                txt_descripcion.Text = R_departamento;
              
            }

            else
            {
                MessageBox.Show("Debes de Introducir Una clave del Departamento");
            }
        }

        private void txt_clave_TextChanged(object sender, EventArgs e)
        {
            string clv = txt_clave.Text;
            if (clv.Equals(""))
            {
                btn_modificar.Enabled = false;
                btn_borrar.Enabled = false;
                btn_agregar.Enabled = false;
            }
            else
            {
                btn_modificar.Enabled = true;
                btn_borrar.Enabled = true;
                if (existe(clv, "Nombre_departamento"))
                {
                    btn_agregar.Enabled = false;
                }
                else
                {
                    btn_agregar.Enabled = true;
                }
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            operacion = 2;
            tabla = "departamento";
            C_departamento = txt_clave.Text;
            D_departamento = txt_descripcion.Text;
            if (D_departamento != "")
            {
                if (C_departamento != "")
                {

                    query = "INSERT INTO " + tabla + "(Clv_departamento, Nombre_departamento) VALUES (" + C_departamento + "," + "'" + D_departamento + "'" + ");";
                    conexion_b(query, operacion, tabla);
                    txt_clave.Text = "";
                    txt_descripcion.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave del Departamento");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una Descripcion del Departamento");
            }
        }

        private void btn_modificar_Click_1(object sender, EventArgs e)
        {
            operacion = 3;
            tabla = "departamento";
            C_departamento = txt_clave.Text;
            D_departamento = txt_descripcion.Text;
            if (D_departamento != "")
            {
                if (C_departamento != "")
                {
                    if (existe(C_departamento, "Clv_" + tabla))
                    {

                        //    UPDATE materias SET nombre = 'Ingenieria de Software2222'WHERE ClvMateria = 001;
                        query = "UPDATE " + tabla + " SET nombre_departamento = " + "'" + D_departamento + "'" + " Where Clv_departamento = " + C_departamento + ";";

                        conexion_b(query, operacion, tabla);

                        // txt_descripcion.Text = R_departamento;
                        if (est == true)
                        {
                            txt_clave.Text = "";
                            txt_descripcion.Text = "";
                            est = false;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Registro no existe");
                    }


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave del Departamento");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una Descripcion del Departamento");
            }
        }

        private void btn_borrar_Click_1(object sender, EventArgs e)
        {
            operacion = 4;
            tabla = "departamento";
            C_departamento = txt_clave.Text;
            D_departamento = txt_descripcion.Text;
            if (D_departamento != "")
            {
                if (C_departamento != "")
                {
                    // DELETE FROM carreras WHERE ClvCarrera = 100012;
                    query = "DELETE FROM " + tabla + " WHERE Clv_departamento = " + C_departamento + ";";
                    conexion_b(query, operacion, tabla);
                    //    txt_descripcion_carreras.Text = R_carreras;
                    txt_clave.Text = "";
                    txt_descripcion.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave del Departamento");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave del Departamento");
            }
        }
    }
}
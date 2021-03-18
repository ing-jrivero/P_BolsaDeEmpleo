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
    public partial class Escolaridad : Form
    {
        public Escolaridad()
        {
            InitializeComponent();
            mensaje_bd();
        }
        static string R_escolaridad;
        static string R_carreras;
        static string C_escolaridad;
        static string D_escolaridad;
        static int operacion;
        static string tabla = "escolaridad";
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

            R_escolaridad = "";
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



            if (tabla.Equals("escolaridad"))
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
                            R_escolaridad = MyReader.GetString("Nombre_" + tabla).ToString();
                            //        MessageBox.Show("Resultado: "+R_materias);


                        }

                        break;
                    case 2://Agregar
                        MessageBox.Show("Se ha registrado una nueva Escolaridad");
                        break;
                    case 3://Modificar
                        /*
                            while (MyReader.Read())
                            {

                                R_escolaridad = MyReader.GetString("Nombre_" + tabla).ToString();

                            }
                            if (R_escolaridad != "")
                            {*/
                                MessageBox.Show("Se ha actualizado la base de datos");
                                est = true;
                            /*
                            }
                            else
                            {
                                MessageBox.Show("ERROR al Actulizar, La Clave No Existe");
                            }
                    */
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
                        while (MyReader.Read())
                        {

                            R_carreras = MyReader.GetString("Nombre").ToString();
                            MessageBox.Show("Se ha actualizado la base de datos");
                        }


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
                    R_escolaridad = MyReader.GetString("conteo").ToString();
                    MessageBox.Show("Conteo: " + R_escolaridad);
                    registros = int.Parse(R_escolaridad);


                }

            }

                else if (tabla.Equals("Existe_clv"))
                {

                    while (MyReader.Read())
                    {

                        R_escolaridad = MyReader.GetString(X).ToString();


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
                        MessageBox.Show("ERROR: Datos duplicados");
                        break;
                    case 1046:
                        //busca un id que no existe
                        MessageBox.Show("No Existe ese Registro");
                        break;
                    case 1136:
                        MessageBox.Show("ERROR: Consulta SQL inconrrecta");
                        break;
                    case 1406:
                        MessageBox.Show("ERROR: Tamaño de Datos Fuera de limite de la base de datos");
                        break;
                }
            }


        }
        //metodo comprobar si existe

        public bool existe(string n, string x)
        {
            X = x;
            //  MessageBox.Show(X);
            query = "Select * from " + tabla + " where Clv_" + tabla + " =" + n;
            conexion_b(query, operacion, "Existe_clv");
            if (R_escolaridad == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        private void btn_buscar_Click(object sender, EventArgs e)
        {
           
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

        private void Escolaridad_Load(object sender, EventArgs e)
        {

        }

        private void txt_clave_Leave(object sender, EventArgs e)
        {
            operacion = 1;
              tabla = "escolaridad";
            C_escolaridad = txt_clave.Text;
            if (C_escolaridad != "")
            {
                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + C_escolaridad;
                conexion_b(query, operacion, tabla);
                txt_descripcion.Text = R_escolaridad;
              
            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave de la Escolaridad");
            }
        }

        private void txt_clave_TextChanged(object sender, EventArgs e)
        {
            string clv = txt_clave.Text;
            if (clv.Equals(""))
            {
                btn_modificar.Enabled = false;
                btn_borrar.Enabled = false;
                btn_agragar.Enabled = false;
            }
            else
            {
                btn_modificar.Enabled = true;
                btn_borrar.Enabled = true;
                if (existe(clv, "Clv_" + tabla))
                {
                    btn_agragar.Enabled = false;
                }
                else
                {
                    btn_agragar.Enabled = true;
                }
            }
        }

        private void btn_agragar_Click_1(object sender, EventArgs e)
        {
            operacion = 2;
            //   tabla = "perfil";
            C_escolaridad = txt_clave.Text;
            D_escolaridad = txt_descripcion.Text;
            if (D_escolaridad != "")
            {
                if (C_escolaridad != "")
                {

                    query = "INSERT INTO " + tabla + "(Clv_" + tabla + ", Nombre_" + tabla + ") VALUES (" + C_escolaridad + "," + "'" + D_escolaridad + "'" + ");";
                    conexion_b(query, operacion, tabla);
                    txt_clave.Text = "";
                    txt_descripcion.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave de la Escolaridad");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una Descripcion de la Escolaridad");
            }
        }

        private void btn_modificar_Click_1(object sender, EventArgs e)
        {
            operacion = 3;
            // tabla = "perfil";
            C_escolaridad = txt_clave.Text;
            D_escolaridad = txt_descripcion.Text;
            if (D_escolaridad != "")
            {
                if (C_escolaridad != "")
                {
                    if (existe(C_escolaridad, "Clv_" + tabla))
                    {
                        //    UPDATE materias SET nombre = 'Ingenieria de Software2222'WHERE ClvMateria = 001;
                        query = "UPDATE " + tabla + " SET nombre_" + tabla + " = " + "'" + D_escolaridad + "'" + " Where Clv_" + tabla + " = " + C_escolaridad + ";";
                        conexion_b(query, operacion, tabla);
                        // txt_descripcion.Text = R_escolaridad;
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
                    MessageBox.Show("Debes de Introducir Una clave de la Escolaridad");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una Descripcion de la Escolaridad");
            }

        }

        private void btn_borrar_Click_1(object sender, EventArgs e)
        {
            operacion = 4;
            // tabla = "perfil";
            C_escolaridad = txt_clave.Text;
            D_escolaridad = txt_descripcion.Text;
            if (D_escolaridad != "")
            {
                if (C_escolaridad != "")
                {
                    // DELETE FROM carreras WHERE ClvCarrera = 100012;
                    query = "DELETE FROM " + tabla + " WHERE Clv_" + tabla + " = " + C_escolaridad + ";";
                    conexion_b(query, operacion, tabla);
                    //    txt_descripcion_carreras.Text = R_carreras;
                    txt_clave.Text = "";
                    txt_descripcion.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave de la Escolaridad");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave de la Escolaridad");
            }
        }
    }
}



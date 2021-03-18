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
    public partial class Horarios : Form
    {
        public Horarios()
        {
            InitializeComponent();
            mensaje_bd();
        }


        static string hr_E;
        static string hr_S;
        static string hr_Semanas;
        static string dias_Semanas;

        static string R_horario_C;
        static string R_carreras;
        static string C_horario;


        static string Des_hr_e;
        static string Des_hr_s;
        static string Des_hr_sem;
        static string Des_dias_sem;
        static int operacion;
        static string tabla = "horario";
        string query;
        static int registros;
        static int columnas = 2;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        static SqlConnection sqlcc ;
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

            R_horario_C = "";
            hr_E = "";
            hr_S = "";
            hr_Semanas ="";
            dias_Semanas ="";


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
             //   MessageBox.Show("Se ejecuta la query");



                if (tabla.Equals("horario"))
            {
                switch (ope)
                {
                    case 1://Buscar
                           
                        while (MyReader.Read())
                        {
                            R_horario_C = MyReader.GetString("Clv_" + tabla).ToString();
                            

                        }
                     //       MessageBox.Show("R_horario_C ="+R_horario_C);
                            // sqlcc = cs;
                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);
                            if (R_horario_C!="")
                            {
                     //           MessageBox.Show("Se va a llenar los campos virtuales");
                                R_horario_C = datos.Rows[0]["Clv_horario"].ToString();
                                hr_E = datos.Rows[0]["Hora_Entrada"].ToString();
                                hr_S = datos.Rows[0]["Hora_Salida"].ToString();
                                hr_Semanas = datos.Rows[0]["Horas_Semana"].ToString();
                                dias_Semanas = datos.Rows[0]["Dias_Semanas"].ToString();

                            }
                            else
                            {
                                
                            //    est = true;
                            //    MessageBox.Show("No Se Encontro Registro");
                            }



                            break;
                    case 2://Agregar
                            
                            
                                MessageBox.Show("Se ha registrado un nuevo Horario");
                           
                           
                        break;
                    case 3://Modificar
                    /*    while (MyReader.Read())
                        {

                            R_horario_C = MyReader.GetString("Nombre_" + tabla).ToString();
                            
                        }
                            if (R_horario_C != "")
                            {
                            */
                                MessageBox.Show("Se ha actualizado la base de datos");
                                est = true;
                          /*  }
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
                            
                        }
                            MessageBox.Show("Se ha actualizado la base de datos");

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
                    R_horario_C = MyReader.GetString("conteo").ToString();
                    MessageBox.Show("Conteo: " + R_horario_C);
                    registros = int.Parse(R_horario_C);


                }

            }

                else if (tabla.Equals("Existe_clv"))
                {

                    while (MyReader.Read())
                    {

                        R_horario_C = MyReader.GetString(X).ToString();


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
            if (R_horario_C == n)
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

        private void Horarios_Load(object sender, EventArgs e)
        {

        }

        private void txt_clave_Leave(object sender, EventArgs e)
        {
            operacion = 1;
            tabla = "horario";
            C_horario = txt_clave.Text;

        //    txt_clave.Text = "";
                     
            if (C_horario != "")
            {
                //       MessageBox.Show("Se va a hacer la query");
                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + C_horario;
                //      MessageBox.Show("Se mando la query");
                conexion_b(query, operacion, tabla);
                //     MessageBox.Show("regresamos de la query");
                txt_hr_E.Text = hr_E;
                txt_hr_S.Text = hr_S;
                txt_hr_sem.Text = hr_Semanas;
                txt_dias_sem.Text = dias_Semanas;
      //          if (est == true)
     //           {
                    //     MessageBox.Show("limpiando campos");
     //               txt_clave.Text = "";
     //               txt_hr_E.Text = "";
     //               txt_hr_S.Text = "";
     //               txt_hr_sem.Text = "";
    //                txt_dias_sem.Text = "";
    //                est = false;

        //        }
            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave del Horario");
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
            C_horario = txt_clave.Text;
            Des_hr_e = txt_hr_E.Text;
            Des_hr_s = txt_hr_S.Text;
            Des_hr_sem = txt_hr_sem.Text;
            Des_dias_sem = txt_dias_sem.Text;
            if (Des_hr_e != "" || Des_hr_s != "" || Des_hr_sem != "" || Des_dias_sem != "")
            {
                if (C_horario != "")
                {
                    //insert into `horario` values(99,12,8,40,5);

                    query = "INSERT INTO " + tabla + " VALUES (" + C_horario + "," + Des_hr_e + "," + Des_hr_s + "," + Des_hr_sem + "," + Des_dias_sem + ");";
                    conexion_b(query, operacion, tabla);
                    txt_clave.Text = "";
                    txt_hr_E.Text = "";
                    txt_hr_S.Text = "";
                    txt_hr_sem.Text = "";
                    txt_dias_sem.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave del Horario");
                }

            }
            else
            {
                MessageBox.Show("Debes llenar toda la Descripcion del Horario");
            }
        }

        private void btn_modificar_Click_1(object sender, EventArgs e)
        {
            operacion = 3;
            // tabla = "perfil";
            C_horario = txt_clave.Text;
            Des_hr_e = txt_hr_E.Text;
            Des_hr_s = txt_hr_S.Text;
            Des_hr_sem = txt_hr_sem.Text;
            Des_dias_sem = txt_dias_sem.Text;
            if (Des_hr_e != "" || Des_hr_s != "" || Des_hr_sem != "" || Des_dias_sem != "")
            {
                if (C_horario != "")
                {
                    if (existe(C_horario, "Clv_" + tabla))
                    {
                        //   Update `horario` set Hora_Entrada=10,Hora_Salida=6,Horas_Semana=40,Dias_Semanas=5 where Clv_horario=99;

                        query = "UPDATE " + tabla + " SET Hora_Entrada =" + Des_hr_e + ",Hora_Salida = " + Des_hr_s + ",Horas_Semana =" + Des_hr_sem + ",Dias_Semanas =" + Des_dias_sem + " Where Clv_" + tabla + " = " + C_horario + ";";
                        conexion_b(query, operacion, tabla);
                        if (est == true)
                        {
                            txt_clave.Text = "";
                            txt_hr_E.Text = "";
                            txt_hr_S.Text = "";
                            txt_hr_sem.Text = "";
                            txt_dias_sem.Text = "";
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
                    MessageBox.Show("Debes de Introducir Una clave del Horario");
                }

            }
            else
            {
                MessageBox.Show("Debes llenar toda la Descripcion del Horario");
            }
        }

        private void btn_borrar_Click_1(object sender, EventArgs e)
        {
            operacion = 4;
            // tabla = "perfil";
            C_horario = txt_clave.Text;
            Des_hr_e = txt_hr_E.Text;
            if (Des_hr_e != "")
            {
                if (C_horario != "")
                {
                    // DELETE FROM carreras WHERE ClvCarrera = 100012;
                    query = "DELETE FROM " + tabla + " WHERE Clv_" + tabla + " = " + C_horario + ";";
                    conexion_b(query, operacion, tabla);
                    //    txt_descripcion_carreras.Text = R_carreras;

                    txt_clave.Text = "";
                    txt_hr_E.Text = "";
                    txt_hr_S.Text = "";
                    txt_hr_sem.Text = "";
                    txt_dias_sem.Text = "";


                }
                else
                {
                    MessageBox.Show("Debes de Introducir Una clave del Horario");
                }

            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave del Horario");
            }
        }
    }
}



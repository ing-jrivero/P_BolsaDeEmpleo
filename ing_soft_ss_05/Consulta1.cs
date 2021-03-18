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
    public partial class Consulta1 : Form
    {
        string query;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        static SqlConnection sqlcc;
        public static string registro = "";
        static int operacion;
        static string X = "";
        public static string tabla = "";
        public static string nregistro = "";
        public static string documentos="";
        public static string[] documento;
        public static string[] numdoc=new string [5];
        public static string[] namedoc = new string[5];
        public static string[,] matriz_res=new string [5,2];
        public Consulta1()
        {
            InitializeComponent();
            mensaje_bd();
        }
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

            nregistro = "";

            //         R_cursos = "";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            /*cmd.CommandText = "Select e.Fname, e.Lname, e.Ssn, e.Bdate, e.Address, " +
                " d.Dname from EMPLOYEE as e INNER JOIN DEPARTMENT as d on e.Dno = d.Dnumber " +
                " order by e.Lname, e.Fname";
            */
        //    cerrar_ventana = true;
            try
            {
                MySqlDataReader MyReader = cmd.ExecuteReader();


                //buscar datos
                if (tabla.Equals("registro_bolsa"))
                {
                    //   MessageBox.Show("entramos al if de la tabla ope="+ope);
                    switch (ope)
                    {

                        case 1:
                            while (MyReader.Read())
                            {

                                //                       MessageBox.Show("Conteo: " + R_cursos);
                                //                       registros = int.Parse(R_cursos);


                            }
                            nregistro = MyReader.GetString("N_control").ToString();
                            if (nregistro == "")
                            {
                                //       est_bolsa = false;
                            }
                            else
                            {
                                //       est_bolsa = true;
                            }
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                                nregistro = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (nregistro != "")
                            {
                                //   A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                //    A_materno = datos.Rows[0]["A_Materno"].ToString();
                                //     nombre = datos.Rows[0]["Nombre"].ToString();
                                //     sexo = datos.Rows[0]["Sexo"].ToString();
                                //    f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                //    calle = datos.Rows[0]["Calle"].ToString();
                                //     numero = datos.Rows[0]["Numero"].ToString();
                                //     colonia = datos.Rows[0]["Colonia"].ToString();
                                //      telefono = datos.Rows[0]["Telefono"].ToString();
                                //      curp = datos.Rows[0]["Curp"].ToString();
                                //      F_ingreso = datos.Rows[0]["F_Ingreso"].ToString();
                                //        perfil = datos.Rows[0]["Perfil"].ToString();
                                //         experiencia = datos.Rows[0]["Experiencia"].ToString();
                                //          escolaridad = datos.Rows[0]["Escolaridad"].ToString();
                                documentos = datos.Rows[0]["Documentos"].ToString();
                                //         estatus = datos.Rows[0]["Estatus"].ToString();
                                //         observaciones = datos.Rows[0]["Observaciones"].ToString();



                            }
                            else
                            {

                                //   est = true;
                                MessageBox.Show("No Se Encontro Registro");
                            }



                            break;
                        case 3:
                            MessageBox.Show("Registro Guardado");
                            break;
                        case 4:
                            MessageBox.Show("Se ha eliminado el registro");
                            break;
                        case 5:
                            ///se utiliza para borrar los datos en el proceso de actualizacion
                            break;

                    }




                }
                else if (tabla.Equals("documento"))
                {
                    switch (ope)
                    {

                        case 1:
                            while (MyReader.Read())
                            {

                                //                       MessageBox.Show("Conteo: " + R_cursos);
                                //                       registros = int.Parse(R_cursos);


                            }
                            nregistro = MyReader.GetString("N_control").ToString();
                            if (nregistro == "")
                            {
                                //       est_bolsa = false;
                            }
                            else
                            {
                                //       est_bolsa = true;
                            }
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                                nregistro = MyReader.GetString("Clv_documento").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (nregistro != "")
                            {
                               
                                numdoc[0] = datos.Rows[0]["Clv_documento"].ToString();
                                numdoc[1] = datos.Rows[1]["Clv_documento"].ToString();
                                numdoc[2] = datos.Rows[2]["Clv_documento"].ToString();
                                numdoc[3] = datos.Rows[3]["Clv_documento"].ToString();
                                numdoc[4] = datos.Rows[4]["Clv_documento"].ToString();

                                namedoc[0] = datos.Rows[0]["Nombre_documento"].ToString();
                                namedoc[1] = datos.Rows[1]["Nombre_documento"].ToString();
                                namedoc[2] = datos.Rows[2]["Nombre_documento"].ToString();
                                namedoc[3] = datos.Rows[3]["Nombre_documento"].ToString();
                                namedoc[4] = datos.Rows[4]["Nombre_documento"].ToString();




                            }
                            else
                            {

                                //   est = true;
                                MessageBox.Show("No Se Encontro Registro");
                            }



                            break;
                        case 3:
                            MessageBox.Show("Registro Guardado");
                            break;
                        case 4:
                            MessageBox.Show("Se ha eliminado el registro");
                            break;
                        case 5:
                            ///se utiliza para borrar los datos en el proceso de actualizacion
                            break;

                    }
                }


                else if (tabla.Equals("Existe_clv"))
                {

                    while (MyReader.Read())
                    {

                        nregistro = MyReader.GetString(X).ToString();


                    }
                }
           

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
            query = "Select * from " + tabla + " Where N_control" + " =" + n;
            conexion_b(query, operacion, "Existe_clv");
            if (nregistro == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void limpiar_matriz()
        {
            for (int i=0;i<5;i++)
            {
                for (int j=0;j<2;j++)
                {
                    matriz_res[i, j] = "";
                }
            }
            
        }

        public static bool Esta_en(string registro, string[] docs)
        {
            bool esta = false;
            for (int i = 0; i < docs.Length; i++)
            {
                    if (docs[i].Equals( registro))
                    {
                    esta = true;
                    return esta;
                    }
                    else
                    {

                    }
            }
            esta = false;
            return esta;

        }
        
        public static void comp_doc(string[] docs,string[] registro)
        {
            int nmat = 0;
            limpiar_matriz();
            for (int i=0;i<registro.Length;i++)
            {
                if (Esta_en(registro[i], docs))
                {
                    //no se hace nada
                }
                else
                {
                    matriz_res[nmat, 0] = numdoc[i];
                    matriz_res[nmat, 1] = namedoc[i];
                    nmat++;
                }
                
            }
        
        }


        public  void pasar_a_dgv(string[,]datos)
        {
            int Llimite = 5;
            int Climite = 2;
            /*
            for (int Lindex = 0; Lindex < Llimite; ++Lindex)
            {
                var row = new DataGridViewRow();

                for (int Cindex = 0; Cindex < Climite; ++Cindex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = datos[Lindex, Cindex]
                    });
                }

                dgv_01.Rows.Add(row);
            }*/
            for (int i = 0; i < 5; i++)
            {
                dgv_01.Rows.Add(new object[] { datos[i,0], datos[i, 1] });
            }
        } 



        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_01.Rows.Clear();
            registro = txt_registro.Text;
          //  operacion = 1;
            tabla = "registro_bolsa";
            
           // query = "Select " + "N_control" + " from " + tabla + " where N_control" + " =" + registro;
           // conexion_b(query, operacion, tabla);

            if (existe(registro, "N_control"))
            {
                //      MessageBox.Show("Mandamos a una funcion");
                //   select* from persona where Id_persona = (select persona from registro_bolsa where N_control = 1);
                operacion = 2;
                tabla = "registro_bolsa";
                registro = txt_registro.Text;
                

                //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                query = "Select *" + " from " + tabla + " where N_control" + " =" + registro;
                conexion_b(query, operacion, tabla);

                string[] d = documentos.Split(',');
                //    txt_a_paterno.Text = A_paterno;
                //   txt_a_materno.Text = A_materno;
                //   txt_nombre.Text = nombre;
                //   txt_sexo.Text = sexo;
                //   dtp_f_naciemiento.Text = f_nacimiento;
                //fecha nacimoento = f_nacimiento;
                //    txt_calle.Text = calle;
                //      txt_numero.Text = numero;
                //      txt_colonia.Text = colonia;
                //     txt_telefono.Text = telefono;
                //     txt_curp.Text = curp;
                //fecha_ingreso = F_ingreso;
                //     dtp_f_ingreso.Text = F_ingreso;
                //      txt_c_perfil.Text = perfil;
                //      txt_c_experiencia.Text = experiencia;
                //      txt_c_escolaridad.Text = escolaridad;
                //       txt_c_documento1.Text = d[0];
                //      txt_c_docuemnto2.Text = d[1];
                //      txt_c_documento3.Text = d[2];
                //       txt_c_documento4.Text = d[3];
                //       txt_c_documento5.Text = d[4];
                //      txt_estatus.Text = estatus;
                //        txt_observaciones.Text = observaciones;

                operacion = 2;
                tabla = "documento";
              //registro = txt_registro.Text;

                query = "Select *" + " from " + tabla;
                conexion_b(query, operacion, tabla);

                comp_doc(d,numdoc);
                pasar_a_dgv(matriz_res);


            }
            else
            {
                MessageBox.Show("Debes de Introducir Una clave del Horario");
            }
        }

    }
}

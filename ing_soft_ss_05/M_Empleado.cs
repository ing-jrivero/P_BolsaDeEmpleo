using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ing_soft_ss_07
{
    public partial class M_Empleado : Form
    {
        public static DateTime today = DateTime.Today;

        //Variables de conexion
        static int operacion;
        static string tabla = "curso";
        string  query;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        ////////////////////////
        //variables 
        static bool est_empleado = false;
        static string R_empleado;
        static string ncontrol;
        //datos persona
        static string A_paterno;
        static string A_materno;
        static string nombre;
        static string sexo;
        static string f_nacimiento;
        static string telefono;
        //datos registro
        static string F_ingreso;
        static string estatus;
        static string observaciones;
        static bool cerrar_ventana = true;
        //datos empleado
        static string nss;
        static string puesto;
        static string departamento;
        static string curso;
        static string c_horario;
        static string horario_he;
        static string horario_hs;
        static string horario_dsem;
        static string horario_hsem;
        static string X = "";
        static bool leave = true;
        public M_Empleado()
        {
            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();
            R_empleado = "";
            ncontrol = "@";
            leave = true;
        }

        public M_Empleado(string data)
        {

            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();

            llenar_ventana(data);
            R_empleado = "";
            leave = false;
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
                //                MessageBox.Show("si se pudo conectar a una base de datos");
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

            //         R_cursos = "";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            /*cmd.CommandText = "Select e.Fname, e.Lname, e.Ssn, e.Bdate, e.Address, " +
                " c.Dname from EMPLOYEE as e INNER JOIN DEPARTMENT as c on e.Dno = c.Dnumber " +
                " order by e.Lname, e.Fname";
            */
            cerrar_ventana = true;
            try
            {
                MySqlDataReader MyReader = cmd.ExecuteReader();


                //buscar datos
                if (tabla.Equals("empleado"))
                {
                    //               MessageBox.Show("entramos al if de la tabla ope="+ope);
                    switch (ope)
                    {

                        case 1:
                            while (MyReader.Read())
                            {

                                //                       MessageBox.Show("Conteo: " + R_cursos);
                                //                       registros = int.Parse(R_cursos);


                            }
                            R_empleado = MyReader.GetString("N_control").ToString();
                            if (R_empleado == "")
                            {
                                est_empleado = false;
                            }
                            else
                            {
                                est_empleado = true;
                            }
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                                R_empleado = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (R_empleado != "")
                            {
                                A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                A_materno = datos.Rows[0]["A_Materno"].ToString();
                                nombre = datos.Rows[0]["Nombre"].ToString();
                                sexo = datos.Rows[0]["Sexo"].ToString();
                                f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                nss = datos.Rows[0]["Nss"].ToString();
                                telefono = datos.Rows[0]["Telefono"].ToString();
                                F_ingreso = datos.Rows[0]["F_Ingreso"].ToString();
                                c_horario = datos.Rows[0]["Horario"].ToString();

                                puesto = datos.Rows[0]["Puesto"].ToString();
                                departamento = datos.Rows[0]["Departamento"].ToString();
                                curso = datos.Rows[0]["Curso"].ToString();
                                estatus = datos.Rows[0]["Estatus"].ToString();
                                observaciones = datos.Rows[0]["Observaciones"].ToString();


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
                            //        MessageBox.Show("Se ha eliminado el registro kkkkk");
                            break;

                    }

                }


                else if (tabla.Equals("Existe_clv"))
                {

                    while (MyReader.Read())
                    {

                        R_empleado = MyReader.GetString(X).ToString();


                    }
                }
                else if (tabla.Equals("puesto"))
                {
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                puesto = MyReader.GetString("Nombre_puesto").ToString();


                            }

                            break;

                    }
                }
                else if (tabla.Equals("departamento"))
                {
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                departamento = MyReader.GetString("Nombre_departamento").ToString();


                            }

                            break;

                    }
                }
                else if (tabla.Equals("curso"))
                {
                    curso = "";
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                curso = MyReader.GetString("Nombre_curso").ToString();


                            }

                            break;

                    }
                }
                else if (tabla.Equals("horario"))
                {
                    switch (ope)
                    {
                        case 1://Buscar
                               //    string[] hs;
                               //       string horariop;
                            while (MyReader.Read())
                            {
                                c_horario = MyReader.GetString("Clv_" + tabla).ToString();


                            }
                            //       MessageBox.Show("R_horario_C ="+R_horario_C);
                            // sqlcc = cs;
                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);
                            if (!c_horario.Equals(""))
                            {
                                //           MessageBox.Show("Se va a llenar los campos virtuales");
                                c_horario = datos.Rows[0]["Clv_horario"].ToString();
                                horario_he = datos.Rows[0]["Hora_Entrada"].ToString();
                                horario_hs = datos.Rows[0]["Hora_Salida"].ToString();
                                horario_hsem = datos.Rows[0]["Horas_Semana"].ToString();
                                horario_dsem = datos.Rows[0]["Dias_Semanas"].ToString();

                            }
                            else
                            {

                                //    est = true;
                                //    MessageBox.Show("No Se Encontro Registro");
                            }

                            break;

                    }
                }

                else if (tabla.Equals("registro_bolsa"))
                {

                    MessageBox.Show("Se actualizo el registro bolsa");


                }
            }
            catch (MySqlException ex)
            {
                cerrar_ventana = false;
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

        public void llenar_ventana(string data)
        {
            string[] d = data.Split(',');
            txt_ncontrol.Text = d[0];
            txt_a_paterno.Text = d[1];
            txt_a_materno.Text = d[2];
            txt_nombre.Text = d[3];
            txt_sexo.Text = d[4];
            dtp_f_naciemiento.Text = d[5];
            txt_telefono.Text = d[6];

            txt_ncontrol.Enabled=false;
            txt_a_paterno.Enabled = false;
            txt_a_materno.Enabled = false;
            txt_nombre.Enabled = false;
            txt_sexo.Enabled = false;
            dtp_f_naciemiento.Enabled = false;
            txt_telefono.Enabled = false;
        }




        //metodo comprobar si existe

        public bool existe(string n, string x)
        {
            X = x;
            query = "Select " + x + " from " + tabla + " where " + x + "  =" + n;
            conexion_b(query, operacion, "Existe_clv");
            if (R_empleado == n)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void imprimir_fecha()
        {
            txt_fecha.Text = today.ToString("dd/MM/yyyy");
            txt_hora.Text = today.ToString("hh:mm");

        }


        ////////////////////////////////////////////////////////
        private void M_Empleado_Load(object sender, EventArgs e)
        {

        }

        private void label_EObserv_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label_Clave_Click(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////


        private void btn_aceptar1_Click(object sender, EventArgs e)
        {
            A_paterno = txt_a_paterno.Text;
            A_materno = txt_a_materno.Text;
            nombre = txt_nombre.Text;
            sexo = txt_sexo.Text;
            f_nacimiento = dtp_f_naciemiento.Text;
            telefono = txt_telefono.Text;
            nss = txt_nseguro.Text;
            F_ingreso = dtp_f_ingreso.Text;
            c_horario = txt_c_horario.Text;
            puesto = txt_c_puesto.Text;
            departamento = txt_c_departamento.Text;
            curso = txt_c_curso1.Text + "," + txt_c_curso2.Text + "," + txt_c_curso3.Text + "," + txt_c_curso4.Text + "," + txt_c_curso5.Text + ",";
            estatus = txt_estatus.Text;
            observaciones = txt_observaciones.Text;
       
            tabla = "empleado";
            ncontrol = txt_ncontrol.Text;

            if (existe(ncontrol, "N_control"))
            {
                //     MessageBox.Show("si existe");
                string s = txt_estatus.Text;
                char[] c = s.ToCharArray();
                if (c[0]=='V')
                { 
          //              MessageBox.Show("entramos en V");
                    tabla = "registro_bolsa";
                    operacion = 0;
                    //update registro_bolsa set Estatus = 'B' where N_control = '6';
                    query = "UPDATE registro_bolsa SET Estatus = " + "'V'" + " WHERE N_control =" + ncontrol;
                    conexion_b(query, operacion, tabla);
                    tabla = "empleado";
                    operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                    conexion_b(query, operacion, tabla);

                }
                else if (c[0] == 'B')
                {

         //               MessageBox.Show("entramos en B");
                    tabla = "empleado";
                    operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                    conexion_b(query, operacion, tabla);
                    //       MessageBox.Show("ya borramos");
                    operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    query = "INSERT INTO `bolsa`.`empleado` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + nss + "'" + "," + "'" + telefono + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + c_horario + "'" + "," + "'" + puesto + "'" + "," + "'" + departamento + "'" + "," + "'" + curso + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    conexion_b(query, operacion, tabla);


                    tabla = "registro_bolsa";
                    operacion = 0;
                    query = "UPDATE registro_bolsa SET Estatus = " + "'B'" + " WHERE N_control =" + ncontrol;
                    conexion_b(query, operacion, tabla);


                }
                else if (c[0] == 'M')
                {
                    
            //            MessageBox.Show("entramos en M");
                    //      tabla = "registro_bolsa";
                    //     operacion = 0;
                    //update registro_bolsa set Estatus = 'B' where N_control = '6';
                    //       query = "UPDATE registro_bolsa SET Estatus = " + "'M'" + " WHERE N_control =" + ncontrol;
                    //       conexion_b(query, operacion, tabla);
                    //       tabla = "empleado";
                    //     operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    //    query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                    //    conexion_b(query, operacion, tabla);
                    //         MessageBox.Show("abrimos ventana Muerto");
                    //        string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + nss + "," + telefono + "," + F_ingreso + "," + c_horario + "," + puesto + "," + departamento + "," + curso + "," + estatus + "," + observaciones;
                    string data = ncontrol;
                    Archivo_Muerto AM = new Archivo_Muerto(data);
                    AM.Show();

                }
                else 
                {
                    cerrar_ventana = false;
                    MessageBox.Show("Estatus Invalido");
                }               
             
            }
            else
            {
                string s = txt_estatus.Text;
                char[] c = s.ToCharArray();
                if (c[0] == 'V')
                {
          //          MessageBox.Show("entramos en V");
                    tabla = "registro_bolsa";
                    operacion = 0;
                    //update registro_bolsa set Estatus = 'B' where N_control = '6';
                    query = "UPDATE registro_bolsa SET Estatus = " + "'V'" + " WHERE N_control =" + ncontrol;
                    conexion_b(query, operacion, tabla);
                    tabla = "empleado";
                    operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                    conexion_b(query, operacion, tabla);

                }
                else if (c[0] == 'B')
                {

               //     MessageBox.Show("entramos en B");
                    tabla = "empleado";
                  
                    operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    query = "INSERT INTO `bolsa`.`empleado` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + nss + "'" + "," + "'" + telefono + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + c_horario + "'" + "," + "'" + puesto + "'" + "," + "'" + departamento + "'" + "," + "'" + curso + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    conexion_b(query, operacion, tabla);


                    tabla = "registro_bolsa";
                    operacion = 0;
                    query = "UPDATE registro_bolsa SET Estatus = " + "'B'" + " WHERE N_control =" + ncontrol;
                    conexion_b(query, operacion, tabla);


                }
                else if (c[0] == 'M')
                {

                    MessageBox.Show("entramos en M");
                    tabla = "registro_bolsa";
                    operacion = 0;
                    //update registro_bolsa set Estatus = 'B' where N_control = '6';
       //             query = "UPDATE registro_bolsa SET Estatus = " + "'M'" + " WHERE N_control =" + ncontrol;
         //           conexion_b(query, operacion, tabla);

      //              tabla = "empleado";
       //             operacion = 5;
       //             //  MessageBox.Show("vamos a insertar");
        //            query = "INSERT INTO `bolsa`.`empleado` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + nss + "'" + "," + "'" + telefono + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + c_horario + "'" + "," + "'" + puesto + "'" + "," + "'" + departamento + "'" + "," + "'" + curso + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
        //            conexion_b(query, operacion, tabla);

                    //  MessageBox.Show("abrimos ventana Muerto");
                    // string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + nss + "," + telefono + "," + F_ingreso + "," + c_horario + "," + puesto + "," + departamento + "," + curso + "," + estatus + "," + observaciones;
                    string data = txt_ncontrol.Text;
           //         MessageBox.Show(data);
                    Archivo_Muerto AM = new Archivo_Muerto(data);
                    AM.Show();

                }
                else
                {
                    cerrar_ventana = false;
                    MessageBox.Show("Estatus Invalido");
                }


            }


            if (cerrar_ventana)
            {
                this.Dispose();

            }

            // MessageBox.Show(ncontrol, A_paterno, A_materno, nombre, sexo, calle, numero, colonia, telefono, curp, F_ingreso, perfil, experiencia, escolaridad, documentos, estatus, observaciones);

        }

        private void txt_ncontrol_Leave(object sender, EventArgs e)
        {
            if (leave)
            {
                //   MessageBox.Show("Buscando");
                operacion = 1;
                tabla = "empleado";
                ncontrol = txt_ncontrol.Text;

                query = "Select " + "N_control" + " from " + tabla + " where N_control" + " =" + ncontrol;
                conexion_b(query, operacion, tabla);
                //   if () { }

                if (existe(ncontrol, "N_control"))
                {
                    //      MessageBox.Show("Mandamos a una funcion");
                    //   select* from persona where Id_persona = (select persona from registro_bolsa where N_control = 1);
                    operacion = 2;
                    tabla = "empleado";
                    ncontrol = txt_ncontrol.Text;
                    btn_eliminar.Enabled = true;

                    //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                    query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                    conexion_b(query, operacion, tabla);

                    string[] c = curso.Split(',');
                    txt_a_paterno.Text = A_paterno;
                    txt_a_materno.Text = A_materno;
                    txt_nombre.Text = nombre;
                    txt_sexo.Text = sexo;
                    dtp_f_naciemiento.Text = f_nacimiento;
                    txt_nseguro.Text = nss;
                    txt_telefono.Text = telefono;

                    dtp_f_ingreso.Text = F_ingreso;
                    txt_c_horario.Text = c_horario;
                    txt_c_puesto.Text = puesto;
                    txt_c_departamento.Text = departamento;
                    txt_c_curso1.Text = c[0];
                    txt_c_curso2.Text = c[1];
                    txt_c_curso3.Text = c[2];
                    txt_c_curso4.Text = c[3];
                    txt_c_curso5.Text = c[4];
                    txt_estatus.Text = estatus;
                    txt_observaciones.Text = observaciones;


                  //  txt_ncontrol.Enabled = false;
                    txt_a_paterno.Enabled = false;
                    txt_a_materno.Enabled = false;
                    txt_nombre.Enabled = false;
                    txt_sexo.Enabled = false;
                    dtp_f_naciemiento.Enabled = false;
                    txt_telefono.Enabled = false;



                }
                else
                {
                    //    MessageBox.Show("No se encontro registro");
                    txt_a_paterno.Text = "";
                    txt_a_materno.Text = "";
                    txt_nombre.Text = "";
                    txt_sexo.Text = "";
                    dtp_f_naciemiento.Text = today.ToString();
                    txt_nseguro.Text = "";
                    txt_telefono.Text = "";


                    dtp_f_ingreso.Text = today.ToString();
                    txt_c_horario.Text = "";
                    txt_c_puesto.Text = "";
                    txt_c_departamento.Text = "";
                    txt_c_curso1.Text = "";
                    txt_c_curso2.Text = "";
                    txt_c_curso3.Text = "";
                    txt_c_curso4.Text = "";
                    txt_c_curso5.Text = "";
                    txt_estatus.Text = "";
                    txt_observaciones.Text = "";
                    btn_eliminar.Enabled = false;

                //    txt_ncontrol.Enabled = true;
                    txt_a_paterno.Enabled = true;
                    txt_a_materno.Enabled = true;
                    txt_nombre.Enabled = true;
                    txt_sexo.Enabled = true;
                    dtp_f_naciemiento.Enabled = true;
                    txt_telefono.Enabled = true;

                }
            }
            else
            {
            }
        }


        private void txt_c_horario_TextChanged(object sender, EventArgs e)
        {
            string c_h = txt_c_horario.Text;
            tabla = "horario";
            if (!c_h.Equals(""))
            {
                if (existe(c_h,"Clv_horario"))
                {
                    operacion = 1;
               //     tabla = "horario";

                    query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_h;
                    conexion_b(query, operacion, tabla);
                    txt_display_horario1.Text = "";
                    txt_display_horario2.Text = "";
                    txt_display_horario3.Text = "";
                    txt_display_horario4.Text = "";
                    txt_display_horario1.Text = horario_he;
                    txt_display_horario2.Text = horario_hs;
                    txt_display_horario3.Text = horario_dsem;
                    txt_display_horario4.Text = horario_hsem;
                    horario_he = "";
                    horario_hs = "";
                    horario_dsem = "";
                    horario_hsem = "";
                }
                else
                {
                    txt_display_horario1.Text = "";
                    txt_display_horario2.Text = "";
                    txt_display_horario3.Text = "";
                    txt_display_horario4.Text = "";
                }






            }
            else
            {
                txt_display_horario1.Text = "";
                txt_display_horario2.Text = "";
                txt_display_horario3.Text = "";
                txt_display_horario4.Text = "";
            }
        }

        private void txt_c_puesto_TextChanged(object sender, EventArgs e)
        {
            string c_p = txt_c_puesto.Text;
            if (!c_p.Equals(""))
            {



                operacion = 1;
                tabla = "puesto";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_p;
                conexion_b(query, operacion, tabla);
                txt_display_puesto.Text = "";
                txt_display_puesto.Text = puesto;
                puesto = "";
            }
            else
            {
                txt_display_puesto.Text = "";
            }
        }

        private void txt_c_departamento_TextChanged(object sender, EventArgs e)
        {
            string c_d = txt_c_departamento.Text;
            if (!c_d.Equals(""))
            {



                operacion = 1;
                tabla = "departamento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_d;
                conexion_b(query, operacion, tabla);
                txt_display_departamento.Text = "";
                txt_display_departamento.Text = departamento;
                departamento = "";
            }
            else
            {
                txt_display_departamento.Text = "";
            }
        }

        private void txt_c_curso1_TextChanged(object sender, EventArgs e)
        {
            string c_c1 = txt_c_curso1.Text;
            if (!c_c1.Equals(""))
            {



                operacion = 1;
                tabla = "curso";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_c1;
                conexion_b(query, operacion, tabla);
                txt_display_curso1.Text = "";
                txt_display_curso1.Text = curso;
                curso = "";
            }
            else
            {
                txt_display_curso1.Text = "";
            }
        }

        private void txt_c_curso2_TextChanged(object sender, EventArgs e)
        {
            string c_c2 = txt_c_curso2.Text;
            if (!c_c2.Equals(""))
            {



                operacion = 1;
                tabla = "curso";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_c2;
                conexion_b(query, operacion, tabla);
                txt_display_curso2.Text = "";
                txt_display_curso2.Text = curso;
                curso = "";
            }
            else
            {
                txt_display_curso2.Text = "";
            }
        }

        private void txt_c_curso3_TextChanged(object sender, EventArgs e)
        {
            string c_c3 = txt_c_curso3.Text;
            if (!c_c3.Equals(""))
            {



                operacion = 1;
                tabla = "curso";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_c3;
                conexion_b(query, operacion, tabla);
                txt_display_curso3.Text = "";
                txt_display_curso3.Text = curso;
                curso = "";
            }
            else
            {
                txt_display_curso3.Text = "";
            }
        }

        private void txt_c_curso4_TextChanged(object sender, EventArgs e)
        {
            string c_c4 = txt_c_curso4.Text;
            if (!c_c4.Equals(""))
            {



                operacion = 1;
                tabla = "curso";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_c4;
                conexion_b(query, operacion, tabla);
                txt_display_curso4.Text = "";
                txt_display_curso4.Text = curso;
                curso = "";
            }
            else
            {
                txt_display_curso4.Text = "";
            }
        }

        private void txt_c_curso5_TextChanged(object sender, EventArgs e)
        {
            string c_c5 = txt_c_curso5.Text;
            if (!c_c5.Equals(""))
            {



                operacion = 1;
                tabla = "curso";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_c5;
                conexion_b(query, operacion, tabla);
                txt_display_curso5.Text = "";
                txt_display_curso5.Text = curso;
                curso = "";
            }
            else
            {
                txt_display_curso5.Text = "";
            }
        }

        private void txt_ncontrol_TextChanged(object sender, EventArgs e)
        {
            string n = txt_ncontrol.Text;
            if (!n.Equals(""))
            {
                btn_aceptar1.Enabled = true;
            }
            else
            {
                btn_aceptar1.Enabled = false;
            }
        }

        private void txt_sexo_TextChanged(object sender, EventArgs e)
        {
            string s = txt_sexo.Text;
            if (s.Equals(""))
            {
                txt_sexo.Text = "M/F";
            }
            else
            {
            }

        }

        private void txt_estatus_TextChanged(object sender, EventArgs e)
        {
            string q = txt_estatus.Text;
            if (q.Equals(""))
            {
                txt_estatus.Text = "B";
            }
            else
            {
            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            string ncon = txt_ncontrol.Text;
            operacion = 4;
            tabla = "empleado";

            query = "DELETE FROM " + tabla + " WHERE N_control = " + ncon;
            conexion_b(query, operacion, tabla);
            this.Dispose();
        }
    }
}
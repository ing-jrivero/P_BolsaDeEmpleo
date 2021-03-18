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
    public partial class Archivo_Muerto : Form
    {
        public static DateTime today = DateTime.Today;

        //Variables de conexion
        static int operacion;
        static string tabla = "muerto";
        string query;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        ////////////////////////
        //variables 
        static bool est_muerto = false;
        static string R_muerto;
        static string ncontrol;
        static string documento;
        //datos persona
        static string A_paterno;
        static string A_materno;
        static string nombre;
        static string sexo;
        static string f_nacimiento;
        static string telefono;
        //datos registro
        static string F_ingreso_b;
        static string F_ingreso_e;
        static string F_ingreso_m;
        static string perfil;
        static string documentos = "";
        static string observaciones;
        static bool cerrar_ventana = true;
        //datos empleado

        static string puesto;
        static string departamento;
        static string X = "";
        //datos muerto
        static string motivo;
        bool leave=true;

        public Archivo_Muerto()
        {
            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();
            //   llenar_ventana(data);
            R_muerto = "@";
            leave = true;
            dtp_FM.Enabled = false;
            txt_motivo.Enabled = false;
        }
        public Archivo_Muerto(string d)
        {
            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();
            //   llenar_ventana(data);
            ncontrol = "";
            ncontrol = d;
            txt_ncontrol.Text = d;
            R_muerto = "@";
            dtp_FM.Enabled = true;
            txt_motivo.Enabled = true;
            leave = false;
            consultar_bolsa();
            consultar_empleado();
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
                if (tabla.Equals("muerto"))
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
                            R_muerto = MyReader.GetString("N_control").ToString();
                            if (R_muerto == "")
                            {
                                est_muerto = false;
                            }
                            else
                            {
                                est_muerto = true;
                            }
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                                R_muerto = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (R_muerto != "")
                            {
                                A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                A_materno = datos.Rows[0]["A_Materno"].ToString();
                                nombre = datos.Rows[0]["Nombre"].ToString();
                                sexo = datos.Rows[0]["Sexo"].ToString();
                                f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                telefono = datos.Rows[0]["Telefono"].ToString();
                                F_ingreso_b = datos.Rows[0]["F_Ingreso_bolsa"].ToString();
                                F_ingreso_m = datos.Rows[0]["F_Ingreso_muerto"].ToString();
                                F_ingreso_e = datos.Rows[0]["F_Ingreso_empleado"].ToString();
                                perfil = datos.Rows[0]["Perfil"].ToString();
                                puesto = datos.Rows[0]["Puesto"].ToString();
                                departamento = datos.Rows[0]["Departamento"].ToString();
                                documentos = datos.Rows[0]["Documentos"].ToString();
                                motivo = datos.Rows[0]["Motivo"].ToString();
                                observaciones = datos.Rows[0]["Observaciones_bolsa"].ToString();


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

                        R_muerto = MyReader.GetString(X).ToString();


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
                else if (tabla.Equals("perfil"))
                {
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                perfil = MyReader.GetString("Nombre_perfil").ToString();


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
                else if (tabla.Equals("documento"))
                {
                    documento = "";
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                documento = MyReader.GetString("Nombre_documento").ToString();


                            }

                            break;

                    }
                }

                else if (tabla.Equals("registro_bolsa"))
                {
                    switch (ope)
                    {
                        case 0:
                            break;
                        case 3:
                            while (MyReader.Read())
                            {
                                R_muerto = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (R_muerto != "")
                            {
                                A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                A_materno = datos.Rows[0]["A_Materno"].ToString();
                                nombre = datos.Rows[0]["Nombre"].ToString();
                                sexo = datos.Rows[0]["Sexo"].ToString();
                                f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                telefono = datos.Rows[0]["Telefono"].ToString();
                                F_ingreso_b = datos.Rows[0]["F_Ingreso"].ToString();
                                perfil = datos.Rows[0]["Perfil"].ToString();
                                documentos = datos.Rows[0]["Documentos"].ToString();
                                observaciones = datos.Rows[0]["Observaciones"].ToString();


                            }
                            else
                            {

                                //   est = true;
                                MessageBox.Show("No Se Encontro Registro");
                            }
                            break;

                    }


                }
                else if (tabla.Equals("empleado"))
                {
                    switch (ope)
                    {
                        case 3:
                            while (MyReader.Read())
                            {
                                R_muerto = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);

                            if (R_muerto != "")
                            {



                                F_ingreso_e = datos.Rows[0]["F_Ingreso"].ToString();
                                puesto = datos.Rows[0]["Puesto"].ToString();
                                departamento = datos.Rows[0]["Departamento"].ToString();




                            }
                            else
                            {

                                //   est = true;
                                MessageBox.Show("No Se Encontro Registro");
                            }
                            break;
                        case 5:
                            break; 
                    }


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
    

        /*
        public  void llenar_ventana(string data)
        {
            string[] d = data.Split(',');
            txt_ncontrol.Text = d[0];
            txt_a_paterno.Text = d[1];
            txt_a_materno.Text = d[2];
            txt_nombre.Text = d[3];
            txt_sexo.Text = d[4];
            dtp_f_naciemiento.Text = d[5];
        }
        */
        public void consultar_bolsa()
        {
            //  ncontrol = txt_ncontrol.Text;
            if (leave)
            {
           //     MessageBox.Show(ncontrol);
                tabla = "registro_bolsa";
                if (existe(ncontrol, "N_control"))
                {
                    operacion = 0;
                    tabla = "registro_bolsa";
                    //   ncontrol = txt_ncontrol.Text;
                    //   btn_eliminar.Enabled = true;

                    //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                    query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                    conexion_b(query, operacion, tabla);



                    string[] doc = documentos.Split(',');
                    txt_ncontrol.Text = ncontrol;
                    txt_a_paterno.Text = A_paterno;
                    txt_a_materno.Text = A_materno;
                    txt_nombre.Text = nombre;
                    txt_sexo.Text = sexo;
                    txt_telefono.Text = telefono;
                    dtp_f_naciemiento.Text = f_nacimiento;
                    dtp_FB.Text = F_ingreso_b;
                    txt_c_perfil.Text = perfil;
                    txt_c_documento1.Text = doc[0];
                    txt_c_docuemnto2.Text = doc[1];
                    txt_c_documento3.Text = doc[2];
                    txt_c_documento4.Text = doc[3];
                    txt_c_documento5.Text = doc[4];
                    txt_motivo.Text = motivo;
                    txt_observaciones.Text = observaciones;
                }
                else
                {
                    MessageBox.Show("No se encontro registro bolsa");
                    txt_a_paterno.Text = "";
                    txt_a_materno.Text = "";
                    txt_nombre.Text = "";
                    txt_sexo.Text = "";
                    txt_telefono.Text = "";
                    dtp_f_naciemiento.Text = "";
                    dtp_FB.Text = "";
                    txt_c_perfil.Text = "";
                    txt_c_documento1.Text = "";
                    txt_c_docuemnto2.Text = "";
                    txt_c_documento3.Text = "";
                    txt_c_documento4.Text = "";
                    txt_c_documento5.Text = "";
                    txt_motivo.Text = "";
                }




            }
            else
            {
             //   MessageBox.Show(ncontrol);
                ncontrol = txt_ncontrol.Text;
            //    MessageBox.Show(ncontrol);
                operacion = 3;
                tabla = "registro_bolsa";
                //   ncontrol = txt_ncontrol.Text;
                //   btn_eliminar.Enabled = true;

                //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
             //   MessageBox.Show(query);
                conexion_b(query, operacion, tabla);



                string[] doc = documentos.Split(',');
                txt_ncontrol.Text = ncontrol;
                txt_a_paterno.Text = A_paterno;
                txt_a_materno.Text = A_materno;
                txt_nombre.Text = nombre;
                txt_sexo.Text = sexo;
                txt_telefono.Text = telefono;
                dtp_f_naciemiento.Text = f_nacimiento;
                dtp_FB.Text = F_ingreso_b;
                txt_c_perfil.Text = perfil;
                txt_c_documento1.Text = doc[0];
                txt_c_docuemnto2.Text = doc[1];
                txt_c_documento3.Text = doc[2];
                txt_c_documento4.Text = doc[3];
                txt_c_documento5.Text = doc[4];
                txt_motivo.Text = motivo;
                txt_observaciones.Text = observaciones;

            }
        }



        public void consultar_empleado()
        {
            if (leave)
            {
                ncontrol = txt_ncontrol.Text;
          //      MessageBox.Show(ncontrol);
                tabla = "empleado";
                if (existe(ncontrol, "N_control"))
                {
                    operacion = 0;
                    tabla = "empleado";
                    //   ncontrol = txt_ncontrol.Text;
                    //   btn_eliminar.Enabled = true;

                    //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                    query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                    conexion_b(query, operacion, tabla);



                    dtp_FE.Text = F_ingreso_e;
                    txt_c_puesto.Text = puesto;
                    txt_c_departamento.Text = departamento;


                }
                else
                {
                    MessageBox.Show("No se encontro empleado");
                    dtp_FE.Text = "";
                    txt_c_puesto.Text = "";
                    txt_c_departamento.Text = "";
                }
            }
            else
            {
                tabla = "empleado";
                if (existe(ncontrol,"N_control"))
                {
                    operacion = 0;
                    tabla = "empleado";
                    //   ncontrol = txt_ncontrol.Text;
                    //   btn_eliminar.Enabled = true;

                    //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                    query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                    conexion_b(query, operacion, tabla);

                    dtp_FE.Text = F_ingreso_e;
                    txt_c_puesto.Text = puesto;
                    txt_c_departamento.Text = departamento;
                }
                else
                {
                    dtp_FE.Text = "";
                    txt_c_puesto.Text = "";
                    txt_c_departamento.Text = "";
                }
            }




        }


        //metodo comprobar si existe

        public bool existe(string n, string x)
        {
            X = x;
            query = "Select " + x + " from " + tabla + " where " + x + "  =" + n;
            conexion_b(query, operacion, "Existe_clv");
            if (R_muerto == n)
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

        public void activar_mod_fecha_m()
        {
            string ncon = txt_ncontrol.Text;
            if (!ncon.Equals(""))
            {
                tabla = "muerto";
                if (existe(ncon,"Ncontrol"))
                {
                    dtp_FM.Enabled = false;
                }
                else
                {
                    dtp_FM.Enabled = true;
                }
            }
            else
            {
            }
        }

        //////////////////////////////////////////////////////////////
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txbox_MBobserv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //////////////////////////////////////////////////////////////////

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            A_paterno = txt_a_paterno.Text;
            A_materno = txt_a_materno.Text;
            nombre = txt_nombre.Text;
            sexo = txt_sexo.Text;
            f_nacimiento = dtp_f_naciemiento.Text;
            telefono = txt_telefono.Text;
            F_ingreso_m = dtp_FM.Text;
            F_ingreso_b = dtp_FB.Text;
            F_ingreso_e = dtp_FE.Text;
            puesto = txt_c_puesto.Text;
            departamento = txt_c_departamento.Text;
            perfil = txt_c_perfil.Text;
            documento = txt_c_documento1.Text + "," + txt_c_docuemnto2.Text + "," + txt_c_documento3.Text + "," + txt_c_documento4.Text + "," + txt_c_documento5.Text + ",";
            //  estatus = txt_estatus.Text;
            motivo = txt_motivo.Text;
            observaciones = txt_motivo.Text;

            tabla = "empleado";
            ncontrol = txt_ncontrol.Text;

            if (existe(ncontrol, "N_control"))
            {

                tabla = "registro_bolsa";
                operacion = 0;
                //update registro_bolsa set Estatus = 'B' where N_control = '6';
                query = "UPDATE registro_bolsa SET Estatus = " + "'M'" + " WHERE N_control =" + ncontrol;
                conexion_b(query, operacion, tabla);
                //     MessageBox.Show("si existe");
                tabla = "empleado";
                operacion = 5;
                //DELETE FROM registro_bolsa WHERE N_control = 33;
                query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                conexion_b(query, operacion, tabla);
          //              MessageBox.Show("ya borramos");
               
            }
            else
            {
                //          MessageBox.Show("no existe existe");
                tabla = "registro_bolsa";
                operacion = 0;
                //update registro_bolsa set Estatus = 'B' where N_control = '6';
                query = "UPDATE registro_bolsa SET Estatus = " + "'M'" + " WHERE N_control =" + ncontrol;
                conexion_b(query, operacion, tabla);

            }
            if (leave)
            {
            }
            else
            {

                tabla = "muerto";
                operacion = 3;
                //  MessageBox.Show("vamos a insertar");

                query = "INSERT INTO `bolsa`.`muerto` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + departamento + "'" + "," + "'" + telefono + "'" + "," + "'" + F_ingreso_m + "'" + "," + "'" + F_ingreso_b + "'" + "," + "'" + puesto + "'" + "," + "'" + perfil + "'" + "," + "'" + F_ingreso_e + "'" + "," + "'" + documento + "'" + "," + "'" + motivo + "'" + "," + "'" + observaciones + "'" + ");";
                conexion_b(query, operacion, tabla);
           //     MessageBox.Show("Registro Guardado");
            }

            if (cerrar_ventana)
            {
                this.Dispose();

            }

            // MessageBox.Show(ncontrol, A_paterno, A_materno, nombre, sexo, calle, numero, colonia, telefono, curp, F_ingreso, perfil, experiencia, escolaridad, documentos, estatus, observaciones);

        }

        private void txt_ncontrol_Leave(object sender, EventArgs e)
        {
        //    activar_mod_fecha_m();
            if (leave)
            {
                //   MessageBox.Show("Buscando");
                operacion = 1;
                tabla = "muerto";
                ncontrol = txt_ncontrol.Text;

                query = "Select " + "N_control" + " from " + tabla + " where N_control" + " =" + ncontrol;
                conexion_b(query, operacion, tabla);
                //   if () { }

                if (existe(ncontrol, "N_control"))
                {
                    //      MessageBox.Show("Mandamos a una funcion");
                    //   select* from persona where Id_persona = (select persona from registro_bolsa where N_control = 1);
                    operacion = 2;
                    tabla = "muerto";
                    ncontrol = txt_ncontrol.Text;
                    btn_borrar.Enabled = true;
                    //   btn_eliminar.Enabled = true;

                    //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                    query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                    conexion_b(query, operacion, tabla);
                //    MessageBox.Show(documentos);
                    string[] d = documentos.Split(',');
                    txt_a_paterno.Text = A_paterno;
                    txt_a_materno.Text = A_materno;
                    txt_nombre.Text = nombre;
                    txt_sexo.Text = sexo;
                    dtp_f_naciemiento.Text = f_nacimiento;
                    txt_telefono.Text = telefono;

                    dtp_FM.Text = F_ingreso_m;
                    dtp_FB.Text = F_ingreso_b;
                    dtp_FE.Text = F_ingreso_e;
                    txt_c_puesto.Text = puesto;
                    txt_c_departamento.Text = departamento;
                    txt_c_perfil.Text = perfil;
                    txt_c_documento1.Text = d[0];
                    txt_c_docuemnto2.Text = d[1];
                    txt_c_documento3.Text = d[2];
                    txt_c_documento4.Text = d[3];
                    txt_c_documento5.Text = d[4];
                    txt_motivo.Text = motivo;
                    txt_observaciones.Text = observaciones;




                }
                else
                {
                    btn_borrar.Enabled = false;
                    MessageBox.Show("No se encontro registro");

                    //    btn_eliminar.Enabled = false;
                }
            }
            else
            {

            }
        }

        private void txt_ncontrol_TextChanged(object sender, EventArgs e)
        {
            string n = txt_ncontrol.Text;
            if (!n.Equals(""))
            {
                btn_Aceptar.Enabled = true;
            }
            else
            {
                btn_Aceptar.Enabled = false;
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

        private void txt_c_perfil_TextChanged(object sender, EventArgs e)
        {
            string c_perfil = txt_c_perfil.Text;
            operacion = 1;
            tabla = "perfil";
            if (!c_perfil.Equals(""))
            {

                if (existe(c_perfil, "Clv_" + tabla))
                {

                    query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_perfil;
                    conexion_b(query, operacion, tabla);
                    txt_display_perfil.Text = perfil;

                }
                else

                {

                    txt_display_perfil.Text = "";
                }

            }
            else
            {
                txt_display_perfil.Text = "";
            }

        }

        private void txt_c_documento1_TextChanged(object sender, EventArgs e)
        {
            string c_documento = txt_c_documento1.Text;

            if (!c_documento.Equals(""))
            {
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento1.Text = "";
                txt_display_documento1.Text = documento;
                documento = "";
            }
            else
            {
                txt_display_documento1.Text = "";
            }

        }

        private void txt_c_docuemnto2_TextChanged(object sender, EventArgs e)
        {
            string c_documento = txt_c_docuemnto2.Text;

            if (!c_documento.Equals(""))
            {
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento2.Text = "";
                txt_display_documento2.Text = documento;
                documento = "";
            }
            else
            {
                txt_display_documento2.Text = "";
            }
        }

        private void txt_c_documento3_TextChanged(object sender, EventArgs e)
        {
            string c_documento = txt_c_documento3.Text;

            if (!c_documento.Equals(""))
            {
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento3.Text = "";
                txt_display_documento3.Text = documento;
                documento = "";
            }
            else
            {
                txt_display_documento3.Text = "";
            }
        }

        private void txt_c_documento4_TextChanged(object sender, EventArgs e)
        {
            string c_documento = txt_c_documento4.Text;

            if (!c_documento.Equals(""))
            {
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento4.Text = "";
                txt_display_documento4.Text = documento;
                documento = "";
            }
            else
            {
                txt_display_documento4.Text = "";
            }
        }

        private void txt_c_documento5_TextChanged(object sender, EventArgs e)
        {
            string c_documento = txt_c_documento5.Text;

            if (!c_documento.Equals(""))
            {
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento5.Text = "";
                txt_display_documento5.Text = documento;
                documento = "";
            }
            else
            {
                txt_display_documento5.Text = "";
            }
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            string ncon = txt_ncontrol.Text;
            operacion = 4;
            tabla = "muerto";

            query = "DELETE FROM " + tabla + " WHERE N_control = " + ncon;
            conexion_b(query, operacion, tabla);
            this.Dispose();
        }
    }
}

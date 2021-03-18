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
    public partial class M_Bolsa : Form
    {
        public static DateTime today = DateTime.Today;

        static int operacion;
        static string tabla = "curso";
        string query;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        //variables 
        static bool est_bolsa = false;
        static string R_bolsa;
        static string ncontrol;
        static string documento;
        //datos persona
        static string A_paterno;
        static string A_materno;
        static string nombre;
        static string sexo;
        static string f_nacimiento;
        static string calle;
        static string numero;
        static string colonia;
        static string telefono;
        static string curp;
        //datos registro
        static string F_ingreso;
        static string perfil;
        static string experiencia;
        static string escolaridad;
        static string documentos="";
        static string estatus;
        static string observaciones;
        static bool cerrar_ventana=true;
        //  static string[] datos_persona;
        //  static string[] datos_empleado;
      //  static string[] d=new string[5];
      static string X="";

        public M_Bolsa()
        {
            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();
            R_bolsa="";
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
                " d.Dname from EMPLOYEE as e INNER JOIN DEPARTMENT as d on e.Dno = d.Dnumber " +
                " order by e.Lname, e.Fname";
            */
            cerrar_ventana = true;
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
                            R_bolsa = MyReader.GetString("N_control").ToString();
                            if (R_bolsa == "")
                            {
                                est_bolsa = false;
                            }
                            else
                            {
                                est_bolsa = true;
                            }
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                                R_bolsa = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);
                            
                            if (R_bolsa != "")
                            {
                                A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                A_materno = datos.Rows[0]["A_Materno"].ToString();
                                nombre = datos.Rows[0]["Nombre"].ToString();
                                sexo = datos.Rows[0]["Sexo"].ToString();
                                f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                calle = datos.Rows[0]["Calle"].ToString();
                                numero = datos.Rows[0]["Numero"].ToString();
                                colonia = datos.Rows[0]["Colonia"].ToString();
                                telefono = datos.Rows[0]["Telefono"].ToString();
                                curp = datos.Rows[0]["Curp"].ToString();
                                F_ingreso = datos.Rows[0]["F_Ingreso"].ToString();
                                perfil = datos.Rows[0]["Perfil"].ToString();
                                experiencia = datos.Rows[0]["Experiencia"].ToString();
                                escolaridad = datos.Rows[0]["Escolaridad"].ToString();
                                documentos = datos.Rows[0]["Documentos"].ToString();
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
                            ///se utiliza para borrar los datos en el proceso de actualizacion
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
                                //                              R_carreras = MyReader.GetString("Nombre").ToString();


                            }

                            break;
                        case 2://Agregar
                            MessageBox.Show("Se ha registrado una nueva carrera");
                            break;
                        case 3://Modificar
                            while (MyReader.Read())
                            {

                                //                              R_carreras = MyReader.GetString("Nombre").ToString();
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
                        //                        R_cursos = MyReader.GetString("conteo").ToString();
                        //                       MessageBox.Show("Conteo: " + R_cursos);
                        //                       registros = int.Parse(R_cursos);


                    }

                }
               /* else if (tabla.Equals("registro_bolsa"))
                {
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
                                R_muerto= MyReader.GetString("N_control").ToString();


                            }
                           
                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);
                          //  string[] d;
                            if (R_muerto != "")
                            {
                                //           MessageBox.Show("Se va a llenar los campos virtuales");
                                //   R_horario_C = datos.Rows[0]["Clv_horario"].ToString();
                                A_paterno = datos.Rows[0]["A_Paterno"].ToString();
                                A_materno = datos.Rows[0]["A_Materno"].ToString();
                                nombre = datos.Rows[0]["Nombre"].ToString();
                                sexo = datos.Rows[0]["Sexo"].ToString();
                                f_nacimiento = datos.Rows[0]["F_Nacimiento"].ToString();
                                calle = datos.Rows[0]["Calle"].ToString();
                                numero = datos.Rows[0]["Numero"].ToString();
                                colonia = datos.Rows[0]["Colonia"].ToString();
                                telefono = datos.Rows[0]["Telefono"].ToString();
                                curp = datos.Rows[0]["Curp"].ToString();
                                F_ingreso = datos.Rows[0]["F_Ingreso"].ToString();
                                perfil = datos.Rows[0]["Perfil"].ToString();
                                experiencia = datos.Rows[0]["Experiencia"].ToString();
                                escolaridad = datos.Rows[0]["Escolaridad"].ToString();
                                documentos = datos.Rows[0]["Documentos"].ToString();
                                estatus = datos.Rows[0]["Estatus"].ToString();
                                observaciones = datos.Rows[0]["Observaciones"].ToString();
                                MessageBox.Show(A_paterno);
                                MessageBox.Show(A_materno);
                                MessageBox.Show(perfil);
                                MessageBox.Show(observaciones);


                            }
                            else
                            {

                             //   est = true;
                                MessageBox.Show("No Se Encontro Registro");
                            }



                            break;

                    }

                }*/


                else if (tabla.Equals("Existe_clv"))
                {

                    while (MyReader.Read())
                    {

                        R_bolsa = MyReader.GetString(X).ToString();


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
                else if (tabla.Equals("experiencia"))
                {
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                experiencia = MyReader.GetString("Nombre_experiencia").ToString();


                            }

                            break;

                    }
                }
                else if (tabla.Equals("escolaridad"))
                {
                    switch (ope)
                    {
                        case 1://Buscar

                            while (MyReader.Read())
                            {
                                escolaridad = MyReader.GetString("Nombre_escolaridad").ToString();


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
        //metodo comprobar si existe

        public bool existe(string n,string x)
        {
            X = x;
            query = "Select "+x+ " from " + tabla + " where "+x+"  =" + n;
            conexion_b(query, operacion, "Existe_clv");
                     if (R_bolsa == n)
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

        private void M_Bolsa_Load(object sender, EventArgs e)
        { }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {

            A_paterno = txt_a_paterno.Text;
            A_materno = txt_a_materno.Text;
            nombre = txt_nombre.Text;
            sexo = txt_sexo.Text;
            f_nacimiento = dtp_f_naciemiento.Text;
            //fecha nacimoento = f_nacimiento;
            calle = txt_calle.Text;
            numero = txt_numero.Text;
            colonia = txt_colonia.Text;
            telefono = txt_telefono.Text;
            curp = txt_curp.Text;
            //fecha_ingreso = F_ingreso;
            F_ingreso = dtp_f_ingreso.Text;
            perfil = txt_c_perfil.Text;
            experiencia = txt_c_experiencia.Text;
            escolaridad = txt_c_escolaridad.Text;
            string documentos = txt_c_documento1.Text + "," + txt_c_docuemnto2.Text + "," + txt_c_documento3.Text + "," + txt_c_documento4.Text + "," + txt_c_documento5.Text + ",";
            estatus = txt_estatus.Text;
            observaciones = txt_observaciones.Text;
            //   operacion = 3;
            tabla = "registro_bolsa";
            ncontrol = txt_ncontrol.Text;
            R_bolsa = "@";
            if (existe(ncontrol, "N_control"))
            {
                //     MessageBox.Show("si existe");
                string s = txt_estatus.Text;
                char[] c = s.ToCharArray();
                if (c[0] == 'V')
                {

                    //      MessageBox.Show("entramos en V");
                    tabla = "registro_bolsa";
                    operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    query = "DELETE FROM registro_bolsa WHERE N_control = " + ncontrol;
                    conexion_b(query, operacion, tabla);
                    //       MessageBox.Show("ya borramos");
                    operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    query = "INSERT INTO `bolsa`.`registro_bolsa` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + calle + "'" + "," + "'" + numero + "'" + "," + "'" + colonia + "'" + "," + "'" + telefono + "'" + "," + "'" + curp + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + perfil + "'" + "," + "'" + experiencia + "'" + "," + "'" + escolaridad + "'" + "," + "'" + documentos + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    conexion_b(query, operacion, tabla);





                }
                else if (c[0] == 'B')
                {
                    string n = txt_ncontrol.Text;
                    tabla = "registro_bolsa";

                    //      MessageBox.Show("entramos en B");

                    //actualizamos datos
                    //         operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    //       query = "DELETE FROM registro_bolsa WHERE N_control = " + ncontrol;
                    //        conexion_b(query, operacion, tabla);
                    //       MessageBox.Show("ya borramos");
                    //         operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    //        query = "INSERT INTO `bolsa`.`registro_bolsa` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + calle + "'" + "," + "'" + numero + "'" + "," + "'" + colonia + "'" + "," + "'" + telefono + "'" + "," + "'" + curp + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + perfil + "'" + "," + "'" + experiencia + "'" + "," + "'" + escolaridad + "'" + "," + "'" + documentos + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    //          conexion_b(query, operacion, tabla);


                    //////////////////////////////////////////
                    /*     operacion = 0;
                         //update registro_bolsa set Estatus = 'B' where N_control = '6';
                         query = "UPDATE registro_bolsa SET Estatus = " + "'V'" + " WHERE N_control =" + ncontrol;
                         conexion_b(query, operacion, tabla);
                         tabla = "empleado";
                       */
                    //     MessageBox.Show("abrimos ventana Empleado");
                    string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + telefono + "," + estatus;
                    M_Empleado EM = new M_Empleado(data);
                    EM.Show();

                }
                else if (c[0] == 'M')
                {
                    R_bolsa = "@";
                    tabla = "registro_bolsa";
                    ncontrol = txt_ncontrol.Text;
                    if (existe(ncontrol, "N_control"))
                    {
                        R_bolsa = "@";
                        tabla = "muerto";
                        ncontrol = txt_ncontrol.Text;

                        if (!existe(ncontrol, "N_control"))
                        {
                            R_bolsa = "@";
                            //       MessageBox.Show("entramos en M");
                            string nulo = "";

                            tabla = "empleado";
                            operacion = 5;
                            //DELETE FROM registro_bolsa WHERE N_control = 33;
                            query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                            conexion_b(query, operacion, tabla);
                            //        MessageBox.Show("abrimos ventana Muerto");
                            //        string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + nulo + "," + telefono + "," + F_ingreso + "," + nulo + "," + nulo + "," + nulo + "," + nulo + "," + estatus + "," + observaciones;
                            cerrar_ventana = true;
                            string data = ncontrol;
                            Archivo_Muerto AM = new Archivo_Muerto(data);
                            AM.Show();

                        
                    }
                    else
                    {
                    }
                }
                else
                {
           //         MessageBox.Show("metodo 2");
                    MessageBox.Show("Antes de mandar a archivo muerto se debe registrar en bolsa de trabajo");
                    cerrar_ventana = false;

                }
                   
                }
                else
                {
                    cerrar_ventana = false;
                    MessageBox.Show("Estatus Invalido");
                }

            } 

            else
            {
                //          MessageBox.Show("no existe existe");
                string s = txt_estatus.Text;
                char[] c = s.ToCharArray();
                if (c[0] == 'V')
                {

            //        MessageBox.Show("entramos en V");
                    tabla = "registro_bolsa";
                
                    operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    query = "INSERT INTO `bolsa`.`registro_bolsa` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + calle + "'" + "," + "'" + numero + "'" + "," + "'" + colonia + "'" + "," + "'" + telefono + "'" + "," + "'" + curp + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + perfil + "'" + "," + "'" + experiencia + "'" + "," + "'" + escolaridad + "'" + "," + "'" + documentos + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    conexion_b(query, operacion, tabla);





                }
                else if (c[0] == 'B')
                {
                    string n = txt_ncontrol.Text;
                    tabla = "registro_bolsa";

            //        MessageBox.Show("entramos en B");

                    //actualizamos datos
                    operacion = 5;
                    //DELETE FROM registro_bolsa WHERE N_control = 33;
                    query = "DELETE FROM registro_bolsa WHERE N_control = " + ncontrol;
                    conexion_b(query, operacion, tabla);
                    //       MessageBox.Show("ya borramos");
                    operacion = 3;
                    //  MessageBox.Show("vamos a insertar");
                    query = "INSERT INTO `bolsa`.`registro_bolsa` VALUES(" + ncontrol + "," + "'" + A_paterno + "'" + "," + "'" + A_materno + "'" + "," + "'" + nombre + "'" + "," + "'" + sexo + "'" + "," + "'" + f_nacimiento + "'" + "," + "'" + calle + "'" + "," + "'" + numero + "'" + "," + "'" + colonia + "'" + "," + "'" + telefono + "'" + "," + "'" + curp + "'" + "," + "'" + F_ingreso + "'" + "," + "'" + perfil + "'" + "," + "'" + experiencia + "'" + "," + "'" + escolaridad + "'" + "," + "'" + documentos + "'" + "," + "'" + estatus + "'" + "," + "'" + observaciones + "'" + ");";
                    conexion_b(query, operacion, tabla);


                    //////////////////////////////////////////
                    /*     operacion = 0;
                         //update registro_bolsa set Estatus = 'B' where N_control = '6';
                         query = "UPDATE registro_bolsa SET Estatus = " + "'V'" + " WHERE N_control =" + ncontrol;
                         conexion_b(query, operacion, tabla);
                         tabla = "empleado";
                       */
                //    MessageBox.Show("abrimos ventana Empleado");
                    string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + telefono + "," + estatus;
                    M_Empleado EM = new M_Empleado(data);
                    EM.Show();

                }
                else if (c[0] == 'M')
                {
                    tabla = "registro_bolsa";
                    ncontrol = txt_ncontrol.Text;
                    if (existe(ncontrol, "N_control"))
                    {

                        tabla = "muerto";
                        ncontrol = txt_ncontrol.Text;

                        if (!existe(ncontrol, "N_control"))
                        {
                            //   MessageBox.Show("entramos en M");
                            string nulo = "";
                            tabla = "registro_bolsa";
                            operacion = 0;
                            //update registro_bolsa set Estatus = 'B' where N_control = '6';
                            query = "UPDATE registro_bolsa SET Estatus = " + "'M'" + " WHERE N_control =" + ncontrol;
                            conexion_b(query, operacion, tabla);
                            tabla = "empleado";
                            operacion = 5;
                            //DELETE FROM registro_bolsa WHERE N_control = 33;
                            query = "DELETE FROM empleado WHERE N_control = " + ncontrol;
                            conexion_b(query, operacion, tabla);
                            //  MessageBox.Show("abrimos ventana Muerto");
                            //    string data = ncontrol + "," + A_paterno + "," + A_materno + "," + nombre + "," + sexo + "," + f_nacimiento + "," + nulo + "," + telefono + "," + F_ingreso + "," + nulo + "," + nulo + "," + nulo + "," + nulo + "," + estatus + "," + observaciones;
                            ncontrol = "";
                            ncontrol = txt_ncontrol.Text;
                            string data = ncontrol;
                            Archivo_Muerto AM = new Archivo_Muerto(data);
                            AM.Show();

                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("metodo 1");
                        MessageBox.Show("Antes de mandar a archivo muerto se debe registrar en bolsa de trabajo");
                        cerrar_ventana = false;

                    }
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
         //   MessageBox.Show("Buscando");
            operacion = 1;
            tabla = "registro_bolsa";
            ncontrol = txt_ncontrol.Text;

            query = "Select "+"N_control"+" from " + tabla + " where N_control" + " =" + ncontrol;
            conexion_b(query, operacion, tabla);
         //   if () { }

            if (existe(ncontrol,"N_control"))
            {
                //      MessageBox.Show("Mandamos a una funcion");
             //   select* from persona where Id_persona = (select persona from registro_bolsa where N_control = 1);
                operacion = 2;
                tabla = "registro_bolsa";
                ncontrol = txt_ncontrol.Text;
                btn_eliminar.Enabled = true;

                //    query = "Select *" + " from persona where Id_persona =" + "(selesct persona from "+tabla+" where N_control = "+ncontrol+");";
                query = "Select *" + " from " + tabla + " where N_control" + " =" + ncontrol;
                conexion_b(query, operacion, tabla);

                string[] d=documentos.Split(',');
                txt_a_paterno.Text = A_paterno;
                txt_a_materno.Text = A_materno;
                txt_nombre.Text = nombre;
                txt_sexo.Text = sexo;
                dtp_f_naciemiento.Text = f_nacimiento;
                //fecha nacimoento = f_nacimiento;
                txt_calle.Text = calle;
                txt_numero.Text = numero;
                txt_colonia.Text = colonia;
                txt_telefono.Text = telefono;
                txt_curp.Text = curp;
                //fecha_ingreso = F_ingreso;
                dtp_f_ingreso.Text = F_ingreso;
                txt_c_perfil.Text = perfil;
                txt_c_experiencia.Text = experiencia;
                txt_c_escolaridad.Text = escolaridad;
                txt_c_documento1.Text =d[0];
                txt_c_docuemnto2.Text =d[1];
                txt_c_documento3.Text =d[2];
                txt_c_documento4.Text =d[3];
                txt_c_documento5.Text =d[4];
                txt_estatus.Text = estatus;
                txt_observaciones.Text = observaciones;

                if (estatus.Equals("M"))
                {
                    txt_estatus.Enabled = false;
                }
                else
                {
                    txt_estatus.Enabled = true;
                }




            }
            else
            {
                //    MessageBox.Show("No se encontro registro");
                txt_a_paterno.Text = "";
                txt_a_materno.Text = "";
                txt_nombre.Text = "";
                txt_sexo.Text = "";
                dtp_f_naciemiento.Text = today.ToString();
                //fecha nacimoento = f_nacimiento;
                txt_calle.Text = "";
                txt_numero.Text = "";
                txt_colonia.Text = "";
                txt_telefono.Text = "";
                txt_curp.Text = "";
                //fecha_ingreso = F_ingreso;
                dtp_f_ingreso.Text = today.ToString();
                txt_c_perfil.Text = "";
                txt_c_experiencia.Text = "";
                txt_c_escolaridad.Text = "";
                txt_c_documento1.Text = "";
                txt_c_docuemnto2.Text = "";
                txt_c_documento3.Text = "";
                txt_c_documento4.Text = "";
                txt_c_documento5.Text = "";
                txt_estatus.Text = "";
                txt_observaciones.Text = "";
                btn_eliminar.Enabled = false;


            }

            // MessageBox.Show("");
            //   txt_descripcion.Text = R_cursos;

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

        private void txt_c_experiencia_TextChanged(object sender, EventArgs e)
        {
            string c_experiencia = txt_c_experiencia.Text;

            operacion = 1;
            tabla = "experiencia";

            if (!c_experiencia.Equals(""))
            {

                if (existe(c_experiencia,"Clv_"+tabla))
                {
    
                    query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_experiencia;
                    conexion_b(query, operacion, tabla);
                    txt_display_experiencia.Text = experiencia;

                }
                else

                {
     
                   txt_display_experiencia.Text = "";
                }
          
                
            }
            else
            {
                txt_display_experiencia.Text = "";
            }


        }

        private void txt_c_escolaridad_TextChanged(object sender, EventArgs e)
        {
            string c_escolaridad = txt_c_escolaridad.Text;
            operacion = 1;
            tabla = "escolaridad";

            if (!c_escolaridad.Equals(""))
            {


                if (existe(c_escolaridad, "Clv_" + tabla))
                {

                    query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_escolaridad;
                    conexion_b(query, operacion, tabla);
                    txt_display_escolaridad.Text = escolaridad;

                }
                else

                {

                    txt_display_escolaridad.Text = "";
                }


               

                        
                

            }
            else
            {
                txt_display_escolaridad.Text = "";
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
          //  MessageBox.Show(c_documento);
            if (!c_documento.Equals(""))
            {


             
                operacion = 1;
                tabla = "documento";

                query = "Select * from " + tabla + " where Clv_" + tabla + " =" + c_documento;
                conexion_b(query, operacion, tabla);
                txt_display_documento5.Text = "";
          //      MessageBox.Show(documento);
                txt_display_documento5.Text = documento;
                documento = "";




            }
            else
            {
                txt_display_documento5.Text = "";
            }
        }

        private void txt_display_escolaridad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            string ncon = txt_ncontrol.Text;
            operacion = 4;
            tabla = "registro_bolsa";

            query = "DELETE FROM " + tabla + " WHERE N_control = " + ncon;
            conexion_b(query, operacion, tabla);
            this.Dispose();
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

        private void txt_calle_TextChanged(object sender, EventArgs e)
        {
            string cl = txt_calle.Text;
            if (cl.Equals(""))
            {
                txt_calle.Text = "Calle";
            }
            else
            {
            }

        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            string n = txt_numero.Text;
            if (n.Equals(""))
            {
                txt_numero.Text = "Numero #";
            }
            else
            {
            }

        }

        private void txt_colonia_TextChanged(object sender, EventArgs e)
        {
            string c = txt_colonia.Text;
            if (c.Equals(""))
            {
                txt_colonia.Text = "Colonia";
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
                txt_estatus.Text = "V";
            }
            else
            {
            }
        }
    }







}

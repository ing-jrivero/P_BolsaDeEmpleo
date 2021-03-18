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
    public partial class Reporte_1 : Form

    {
        public static DateTime today = DateTime.Today;
        static int operacion;
        static string tabla = "curso";
        string query;
        static string cs = @"server=localhost;userid=root;password=12345;database=bolsa";
        static MySqlConnection conn = null;
        //public Empleado[] empleados;
        public static int conteo;
        public static string nregistro;
        static string X = "";
        public Empleado[] emm;

        public Reporte_1()
        {
            InitializeComponent();
            imprimir_fecha();
            mensaje_bd();

            Buscar();
       //     empleados = new Empleado[conteo];
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
        public  void conexion_b(string sql, int ope, string tabla)
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
        private void Consulta_b(MySqlConnection conn, string sql, int ope, string tabla)
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
                if (tabla.Equals("empleado"))
                {
                    //   MessageBox.Show("entramos al if de la tabla ope="+ope);
                    switch (ope)
                    {

                        case 1:
                            while (MyReader.Read())
                            {
                                nregistro = MyReader.GetString("conteo").ToString();
                                //                      MessageBox.Show("Conteo: " + R_cursos);
                                //                      nregistro = int.Parse(R_cursos);


                            }
                         //   nregistro = MyReader.GetString("conteo").ToString();
                            
                            break;
                        case 2:

                            while (MyReader.Read())
                            {
                             //   nregistro = MyReader.GetString("N_control").ToString();


                            }

                            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, cs);
                            DataTable datos = new DataTable();
                            adapter.Fill(datos);
                            
                            Empleado[] empleados = new Empleado[contar()];
                            for (int i=0; i<conteo;i++)
                            {

                                Empleado emp1 = new Empleado();
                            //    empleados[i] = null;
                            //    empleados[i] = new Empleado();
                                emp1.setN_control(datos.Rows[i]["N_control"].ToString());
                                emp1.setA_Paterno(datos.Rows[i]["A_Paterno"].ToString());
                                emp1.setA_Materno(datos.Rows[i]["A_Materno"].ToString());
                                emp1.setNombre(datos.Rows[i]["Nombre"].ToString());
                                emp1.setSexo(datos.Rows[i]["Sexo"].ToString());
                                emp1.setF_Nacimiento(datos.Rows[i]["F_Nacimiento"].ToString());
                                emp1.setNss(datos.Rows[i]["Nss"].ToString());
                                emp1.setTelefono(datos.Rows[i]["Telefono"].ToString());
                                emp1.setF_Ingreso(datos.Rows[i]["F_Ingreso"].ToString());
                                emp1.setHorario(datos.Rows[i]["Horario"].ToString());
                                emp1.setPuesto(datos.Rows[i]["Puesto"].ToString());
                                emp1.setDepartamento(datos.Rows[i]["Departamento"].ToString());
                                emp1.setCurso(datos.Rows[i]["Curso"].ToString());
                                emp1.setEstatus(datos.Rows[i]["Estatus"].ToString());
                                emp1.setObservaciones(datos.Rows[i]["Observaciones"].ToString());

                                empleados[i] = emp1;
                            }

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
                            // documentos = datos.Rows[0]["Documentos"].ToString();
                            //         estatus = datos.Rows[0]["Estatus"].ToString();
                            //         observaciones = datos.Rows[0]["Observaciones"].ToString();




                            guardar_arreglo(empleados);

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

        public void imprimir_fecha()
        {
            txt_fecha.Text = today.ToString("dd/MM/yyyy");
            txt_hora.Text = today.ToString("hh:mm");

        }

        public void pasar_a_dgv(string[,] datos)
        {
            for (int i = 0; i < 5; i++)
            {
                dgv_01.Rows.Add(new object[] { datos[i, 0], datos[i, 1] });
            }
        }

        private void Reporte_1_Load(object sender, EventArgs e)
        {


            
        }

        public int contar()
        {
            //conteo
            tabla = "empleado";
            operacion = 1;
            //  select count(*) from empleado;
            query = "Select count(*) as conteo " + " from " + tabla;
            conexion_b(query, operacion, tabla);
         //   MessageBox.Show(nregistro);
            conteo = Int32.Parse(nregistro);
            //     MessageBox.Show(conteo + "");
            //    
            return conteo;
        }

         public void guardar_arreglo(Empleado[] e)
        {
            emm = e;
        }


        public void Buscar()
        {


            dgv_01.Rows.Clear();
            

            

            //buscar datos
            tabla = "empleado";
            operacion = 2;

            query = "Select *" + " from " + tabla;
            conexion_b(query, operacion, tabla);

            Empleado[] empleados = emm;
            //llenado del dgv
            for (int i=0;i<conteo;i++)
            {
            dgv_01.Rows.Add(new object[] {empleados[i].getN_control(),empleados[i].getA_Paterno(),empleados[i].getA_Materno(),empleados[i].getNombre(),
            empleados[i].getSexo(),empleados[i].getF_Nacimiento(),empleados[i].getNss(),empleados[i].getTelefono(),
            empleados[i].getF_Ingreso(),empleados[i].getHorario(),empleados[i].getPuesto(),empleados[i].getDepartamento(),
            empleados[i].getCurso(),empleados[i].getEstatus(),empleados[i].getObservaciones()});
            }





        }




    }
}

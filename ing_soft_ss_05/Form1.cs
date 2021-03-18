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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_despartamentos_Click(object sender, EventArgs e)
        {
            Departamentos d = new Departamentos();
            d.Show();
        }

        private void btn_perfiles_Click(object sender, EventArgs e)
        {
            Perfiles p = new Perfiles();
            p.Show();
        }

        private void btn_Puestos_Click(object sender, EventArgs e)
        {
            Puestos ps = new Puestos();
            ps.Show();
        }

        private void btn_Cursos_Click(object sender, EventArgs e)
        {
            Cursos c = new Cursos();
            c.Show();
        }

        private void btn_Escolaridad_Click(object sender, EventArgs e)
        {
            Escolaridad es = new Escolaridad();
            es.Show();
        }

        private void btn_Documentos_Click(object sender, EventArgs e)
        {
            Documentos dt = new Documentos();
            dt.Show();
        }

        private void btn_horarios_Click(object sender, EventArgs e)
        {
            Horarios h = new Horarios();
            h.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_bolsa_Click(object sender, EventArgs e)
        {
            M_Bolsa bolsa = new M_Bolsa();
            bolsa.Show();
        }

        private void btn_empleado_Click(object sender, EventArgs e)
        {
            M_Empleado Empleado = new M_Empleado();
            Empleado.Show();
        }

        private void btn_ArMuerto_Click(object sender, EventArgs e)
        {
            Archivo_Muerto AC = new Archivo_Muerto();
            AC.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Experiencia Ex = new Experiencia();
            Ex.Show();
        }

        private void btn_consulta1_Click(object sender, EventArgs e)
        {
            Consulta1 cs1 = new Consulta1();
            cs1.Show();
        }

        private void btn_reporte_1_Click(object sender, EventArgs e)
        {
            Reporte_1 r1 = new Reporte_1();
            r1.Show();
        }

        private void btn_reporte_2_Click(object sender, EventArgs e)
        {
            Reporte_2 r2 = new Reporte_2();
            r2.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ing_soft_ss_07
{
    public class Empleado
    {
        //atributos
        string N_control, A_Paterno, A_Materno, Nombre, Sexo, F_Nacimiento, Nss, Telefono, F_Ingreso, Horario, Puesto, Departamento, Curso, Estatus, Observaciones;

        public Empleado() { }

        public Empleado(string N_con, string A_Pat, string A_Mat, string Nom, string S, string F_Nac, string N, string Tel, string F_Ing, string Hor, string Ps, string Dep, string C, string Est, string Ob)
        {
            N_control = N_con;
            A_Paterno = A_Pat;
            A_Materno = A_Mat;
            Nombre = Nom;
            Sexo = S;
            F_Nacimiento = F_Nac;
            Nss = N;
            Telefono = Tel;
            F_Ingreso = F_Ing;
            Horario = Hor;
            Puesto = Ps;
            Departamento = Dep;
            Curso = C;
            Estatus = Est;
            Observaciones = Ob;
        }


        public string getN_control()
        {
            return N_control;
        }

        public void setN_control(string n_control)
        {
            N_control = n_control;
        }

        public string getA_Paterno()
        {
            return A_Paterno;
        }

        public void setA_Paterno(string a_Paterno)
        {
            A_Paterno = a_Paterno;
        }

        public string getA_Materno()
        {
            return A_Materno;
        }

        public void setA_Materno(string a_Materno)
        {
            A_Materno = a_Materno;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public void setNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string getSexo()
        {
            return Sexo;
        }

        public void setSexo(string sexo)
        {
            Sexo = sexo;
        }

        public string getF_Nacimiento()
        {
            return F_Nacimiento;
        }

        public void setF_Nacimiento(string f_Nacimiento)
        {
            F_Nacimiento = f_Nacimiento;
        }

        public string getNss()
        {
            return Nss;
        }

        public void setNss(string nss)
        {
            Nss = nss;
        }

        public string getTelefono()
        {
            return Telefono;
        }

        public void setTelefono(string telefono)
        {
            Telefono = telefono;
        }

        public string getF_Ingreso()
        {
            return F_Ingreso;
        }

        public void setF_Ingreso(string f_Ingreso)
        {
            F_Ingreso = f_Ingreso;
        }

        public string getHorario()
        {
            return Horario;
        }

        public void setHorario(string horario)
        {
            Horario = horario;
        }

        public string getPuesto()
        {
            return Puesto;
        }

        public void setPuesto(string puesto)
        {
            Puesto = puesto;
        }

        public string getDepartamento()
        {
            return Departamento;
        }

        public void setDepartamento(string departamento)
        {
            Departamento = departamento;
        }

        public string getCurso()
        {
            return Curso;
        }

        public void setCurso(string curso)
        {
            Curso = curso;
        }

        public string getEstatus()
        {
            return Estatus;
        }

        public void setEstatus(string estatus)
        {
            Estatus = estatus;
        }

        public string getObservaciones()
        {
            return Observaciones;
        }

        public void setObservaciones(string observaciones)
        {
            Observaciones = observaciones;
        }



    }
}

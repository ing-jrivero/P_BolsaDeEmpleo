using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ing_soft_ss_07
{
    public class Registro_Bolsa
    {
        string N_control, A_Paterno, A_Materno, Nombre, Sexo, F_Nacimiento, Calle, Numero, Colonia, Telefono, Curp, F_Ingreso, Perfil, Experiencia, Escolaridad, Documentos, Estatus, Observaciones;

        public Registro_Bolsa() { }
        public Registro_Bolsa(string n_control, string a_Paterno, string a_Materno, string nombre, string sexo,
                string f_Nacimiento, string calle, string numero, string colonia, string telefono, string curp,
                string f_Ingreso, string perfil, string experiencia, string escolaridad, string documentos, string estatus,
                string observaciones)
        {
            N_control = n_control;
            A_Paterno = a_Paterno;
            A_Materno = a_Materno;
            Nombre = nombre;
            Sexo = sexo;
            F_Nacimiento = f_Nacimiento;
            Calle = calle;
            Numero = numero;
            Colonia = colonia;
            Telefono = telefono;
            Curp = curp;
            F_Ingreso = f_Ingreso;
            Perfil = perfil;
            Experiencia = experiencia;
            Escolaridad = escolaridad;
            Documentos = documentos;
            Estatus = estatus;
            Observaciones = observaciones;
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

        public string getCalle()
        {
            return Calle;
        }

        public void setCalle(string calle)
        {
            Calle = calle;
        }

        public string getNumero()
        {
            return Numero;
        }

        public void setNumero(string numero)
        {
            Numero = numero;
        }

        public string getColonia()
        {
            return Colonia;
        }

        public void setColonia(string colonia)
        {
            Colonia = colonia;
        }

        public string getTelefono()
        {
            return Telefono;
        }

        public void setTelefono(string telefono)
        {
            Telefono = telefono;
        }

        public string getCurp()
        {
            return Curp;
        }

        public void setCurp(string curp)
        {
            Curp = curp;
        }

        public string getF_Ingreso()
        {
            return F_Ingreso;
        }

        public void setF_Ingreso(string f_Ingreso)
        {
            F_Ingreso = f_Ingreso;
        }

        public string getPerfil()
        {
            return Perfil;
        }

        public void setPerfil(string perfil)
        {
            Perfil = perfil;
        }

        public string getExperiencia()
        {
            return Experiencia;
        }

        public void setExperiencia(string experiencia)
        {
            Experiencia = experiencia;
        }

        public string getEscolaridad()
        {
            return Escolaridad;
        }

        public void setEscolaridad(string escolaridad)
        {
            Escolaridad = escolaridad;
        }

        public string getDocumentos()
        {
            return Documentos;
        }

        public void setDocumentos(string documentos)
        {
            Documentos = documentos;
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

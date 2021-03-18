using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoSIENA.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Insertar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into usuarios(id,documento,tipodoc,nombre,celular,email,genero,aprendiz,egresado,areaformacion,fechaegresado,direccion,barrio,ciudad,departamento,fecharegistro) values (@id,@documento,@tipodoc,@nombre,@celular,@email,@genero,@aprendiz,@egresado,@areaformacion,@fechaegresado,@direccion,@barrio,@ciudad,@departamento,@fecharegistro)", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);

            comando.Parameters["@id"].Value = usu.Id;
            comando.Parameters["@documento"].Value = usu.Documento;
            comando.Parameters["@tipodoc"].Value = usu.Tipodoc;
            comando.Parameters["@nombre"].Value = usu.Nombre;
            comando.Parameters["@celular"].Value = usu.Celular;
            comando.Parameters["@email"].Value = usu.Email;
            comando.Parameters["@genero"].Value = usu.Genero;
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;
            comando.Parameters["@egresado"].Value = usu.Egresado;
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;
            comando.Parameters["@direccion"].Value = usu.Direccion;
            comando.Parameters["@barrio"].Value = usu.Barrio;
            comando.Parameters["@ciudad"].Value = usu.Ciudad;
            comando.Parameters["@departamento"].Value = usu.Departamento;
            comando.Parameters["@fecharegistro"].Value = usu.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();

            return i;

        }
        public List<Usuario> RecuperarTodos()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();
            SqlCommand comando = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios order by id asc", con);
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();

            while(registros.Read())
            {
                Usuario usu = new Usuario
                {
                    Id = int.Parse(registros["id"].ToString()),
                    Documento = registros["documento"].ToString(),
                    Tipodoc = registros["tipodoc"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    Celular = registros["celular"].ToString(),
                    Email = registros["email"].ToString(),
                    Genero = registros["genero"].ToString(),
                    Aprendiz = registros["aprendiz"].ToString(),
                    Egresado = registros["egresado"].ToString(),
                    AreaFormacion = registros["areaformacion"].ToString(),
                    FechaEgresado = registros["fechaegresado"].ToString(),
                    Direccion = registros["direccion"].ToString(),
                    Barrio = registros["barrio"].ToString(),
                    Ciudad = registros["ciudad"].ToString(),
                    Departamento = registros["departamento"].ToString(),
                    FechaRegistro = registros["fecharegistro"].ToString()
                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }
        public Usuario RecuperarAreaFormacion(string areaformacion)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where areaformacion = @areaformacion", con);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = areaformacion;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();

            if(registros.Read())
            {
                usuario.Id = int.Parse(registros["id"].ToString());
                usuario.Documento = registros["documento"].ToString();
                usuario.Tipodoc = registros["tipodoc"].ToString();
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Celular = registros["celular"].ToString();
                usuario.Email = registros["email"].ToString();
                usuario.Genero = registros["genero"].ToString();
                usuario.Aprendiz = registros["aprendiz"].ToString();
                usuario.Egresado = registros["egresado"].ToString();
                usuario.AreaFormacion = registros["areaformacion"].ToString();
                usuario.FechaEgresado = registros["fechaegresado"].ToString();
                usuario.Direccion = registros["direccion"].ToString();
                usuario.Barrio = registros["barrio"].ToString();
                usuario.Ciudad = registros["ciudad"].ToString();
                usuario.Departamento = registros["departamento"].ToString();
                usuario.FechaRegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }
        public Usuario RecuperarPorGenero(string genero)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where genero = @genero", con);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = genero;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();

            if (registros.Read())
            {
                usuario.Id = int.Parse(registros["id"].ToString());
                usuario.Documento = registros["documento"].ToString();
                usuario.Tipodoc = registros["tipodoc"].ToString();
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Celular = registros["celular"].ToString();
                usuario.Email = registros["email"].ToString();
                usuario.Genero = registros["genero"].ToString();
                usuario.Aprendiz = registros["aprendiz"].ToString();
                usuario.Egresado = registros["egresado"].ToString();
                usuario.AreaFormacion = registros["areaformacion"].ToString();
                usuario.FechaEgresado = registros["fechaegresado"].ToString();
                usuario.Direccion = registros["direccion"].ToString();
                usuario.Barrio = registros["barrio"].ToString();
                usuario.Ciudad = registros["ciudad"].ToString();
                usuario.Departamento = registros["departamento"].ToString();
                usuario.FechaRegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }
        public Usuario RecuperarPorDocumento(string documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where documento = @documento", con);
            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters["@documento"].Value = documento;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuario = new Usuario();

            if (registros.Read())
            {
                usuario.Id = int.Parse(registros["id"].ToString());
                usuario.Documento = registros["documento"].ToString();
                usuario.Tipodoc = registros["tipodoc"].ToString();
                usuario.Nombre = registros["nombre"].ToString();
                usuario.Celular = registros["celular"].ToString();
                usuario.Email = registros["email"].ToString();
                usuario.Genero = registros["genero"].ToString();
                usuario.Aprendiz = registros["aprendiz"].ToString();
                usuario.Egresado = registros["egresado"].ToString();
                usuario.AreaFormacion = registros["areaformacion"].ToString();
                usuario.FechaEgresado = registros["fechaegresado"].ToString();
                usuario.Direccion = registros["direccion"].ToString();
                usuario.Barrio = registros["barrio"].ToString();
                usuario.Ciudad = registros["ciudad"].ToString();
                usuario.Departamento = registros["departamento"].ToString();
                usuario.FechaRegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }

        public int Modificar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update usuarios set tipodoc=@tipodoc, nombre=@nombre, celular=@celular, email=@email, genero=@genero, aprendiz=@aprendiz, egresado=@egresado, areaformacion=@areaformacion, fechaegresado=@fechaegresado, direccion=@direccion, barrio=@barrio, ciudad=@ciudad, departamento=@departamento, fecharegistro=@fecharegistro where documento=@documento", con);

            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.Tipodoc;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.Email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.Genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters["@egresado"].Value = usu.Egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.VarChar);
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.Direccion;

            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.Barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.Ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.Departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);
            comando.Parameters["@fecharegistro"].Value = usu.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(string documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from usuarios where documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters["@documento"].Value = documento;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
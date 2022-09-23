using BackendPeluqueria.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BackendPeluqueria.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private PostgreSQLConfiguration _connectionString;

        public UsuarioRepositorio(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"
                DELETE FROM public.usuario WHERE usuario_id=@Id
            ";

            var result = await db.ExecuteAsync(sql, new { Id = usuario.Usuario_id });
            return result > 0;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var db = dbConnection();

            var sql = @"
                SELECT usuario_id, usuario_nombre, usuario_apellido, usuario_nickname, usuario_password, 
                usuario_email, usuario_sexo, usuario_foto, fk_usuario_perfil_id, usuario_fecha_creacion, 
                usuario_fecha_nacimiento FROM public.usuario WHERE usuario_id=@Id
            ";

            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var db = dbConnection();

            var sql = @"
                SELECT usuario_id, usuario_nombre, usuario_apellido, usuario_nickname, usuario_password, 
                usuario_email, usuario_sexo, usuario_foto, fk_usuario_perfil_id, usuario_fecha_creacion, 
                usuario_fecha_nacimiento FROM public.usuario
            ";

            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"
                INSERT INTO public.usuario (usuario_id, usuario_nombre, usuario_apellido, usuario_nickname, usuario_password, 
                usuario_email, usuario_sexo, usuario_foto, fk_usuario_perfil_id, usuario_fecha_creacion, 
                usuario_fecha_nacimiento) VALUES (@Usuario_id, @Usuario_nombre, @Usuario_apellido, @Usuario_nickname, 
                @Usuario_password, @Usuario_email, @Usuario_sexo, @Usuario_foto, @Fk_usuario_perfil_id, 
                @Usuario_fecha_creacion, @Usuario_fecha_nacimiento)
            ";

            var result = await db.ExecuteAsync(sql, new { usuario.Usuario_id, usuario.Usuario_nombre, usuario.Usuario_apellido, 
                usuario.Usuario_nickname, usuario.Usuario_password, usuario.Usuario_email, usuario.Usuario_sexo, usuario.Usuario_foto, 
                usuario.Fk_usuario_perfil_id, usuario.Usuario_fecha_creacion, usuario.Usuario_fecha_nacimiento});
            return result > 0;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbConnection();

            var sql = @"
                UPDATE public.usuario SET usuario_nombre=@Usuario_nombre, usuario_apellido=@Usuario_apellido, 
                usuario_nickname=@Usuario_nickname, usuario_password=@Usuario_password, usuario_email=@Usuario_email, 
                usuario_sexo=@Usuario_sexo, usuario_foto=@Usuario_foto, fk_usuario_perfil_id=@Fk_usuario_perfil_id, 
                usuario_fecha_creacion=@Usuario_fecha_creacion, usuario_fecha_nacimiento=@Usuario_fecha_nacimiento WHERE usuario_id=@Usuario_id
            ";

            var result = await db.ExecuteAsync(sql, new {
                usuario.Usuario_nombre, usuario.Usuario_apellido, usuario.Usuario_nickname, usuario.Usuario_password,
                usuario.Usuario_email, usuario.Usuario_sexo, usuario.Usuario_foto, usuario.Fk_usuario_perfil_id,
                usuario.Usuario_fecha_creacion, usuario.Usuario_fecha_nacimiento, usuario.Usuario_id });
            return result > 0;
        }
    }
}

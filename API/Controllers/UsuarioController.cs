using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dados;
using System.Data.Entity;
namespace API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
        private static apirestEntities db = new apirestEntities();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public Retorno CadastrarUsuario(Usuario usuario)
        {
            Retorno ret = new Retorno();
            try
            {
                Usuario user = new Usuario();
                user = usuario;
                db.Usuario.AddObject(user);
                db.SaveChanges();

                ret.mensagem = "Usuário cadastrado com sucesso!";
                ret.success = true;

            }
            catch (Exception)
            {
                ret.mensagem = "Ocorreu um erro ao adicionar usuario!";
                ret.success = false;
            }




            return ret;
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public Retorno AlterarUsuario(Usuario usuario)
        {
            Retorno ret = new Retorno();
           
            Usuario user = db.Usuario.Where(r => r.Codigo == usuario.Codigo).FirstOrDefault();
            if (user==null)
            {
                ret.mensagem = "Usuário não encontrado";
                ret.success = false;
            }
            else
            {
                ret.mensagem = "Usuário alterado com sucesso!";
                ret.success = true;
                user.Nome = usuario.Nome;
                user.CPF = usuario.CPF;
                user.Login = usuario.Login;
                db.SaveChanges();

            }
                 
            return ret;
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public Retorno ExcluirUsuario(int codigo)
        {

            Usuario usuario = db.Usuario.Where(n => n.Codigo == codigo).FirstOrDefault();

            if (usuario==null)
            {
                return new Retorno()
                {
                    mensagem = "Usuário não encontrado",
                    success = false
                };

            }
            else
            {
                db.Usuario.DeleteObject(usuario);
                db.SaveChanges();
                return new Retorno()
                {
                    mensagem = "Usuário removido com sucesso",
                    success = true
                };
            }
         

            
        }


       
        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCPF/{cpf}")]
        public UsuarioModel ConsultarUsuarioPorCPF(string cpf)
        {

            UsuarioModel usrModel = new UsuarioModel();
            var usuario = db.Usuario.Where(n => n.CPF.Contains(cpf))
                                                .Select(n => n)
                                                .FirstOrDefault();


            if (usuario == null)
            {
              
            }
            else
            {
                usrModel.Codigo = usrModel.Codigo;
                usrModel.Nome = usrModel.Nome;
                usrModel.CPF = usrModel.CPF;
              
            }
            return usrModel;
        }

        [BasicAuthentication]
        [AcceptVerbs("GET")]
        [Route("ConsultarUsuariosAut")]
        public List<UsuarioModel> ConsultarUsuariosAut()
        {
            List<UsuarioModel> lstUserModel = new List<UsuarioModel>();
            foreach (var item in db.Usuario.ToList())
            {

                lstUserModel.Add(new UsuarioModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CPF = item.CPF,
                });
            }
            return lstUserModel;
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            List<UsuarioModel> lstUserModel = new List<UsuarioModel>();
            foreach (var item in db.Usuario.ToList())
            {

                lstUserModel.Add(new UsuarioModel()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CPF = item.CPF,
                });
            }
            return lstUserModel;
        }

    }
}

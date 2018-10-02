using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.ViewModels;
using System.Web.Http.Description;
using Projeto.Data.Contracts;
using Projeto.Services.Utils;
using AutoMapper;
using Projeto.Entities;

namespace Projeto.Services.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/estoque")]
    public class EstoqueController : ApiController
    {
        //atributo
        private readonly IEstoqueRepository repository;

        //construtor com entrada de argumentos (SimpleInjector)
        public EstoqueController(IEstoqueRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost] //requisições POST
        [Route("cadastrar")] //URL: /api/estoque/cadastrar
        public HttpResponseMessage Post(EstoqueCadastroViewModel viewModel)
        {
            //verificar se não há erros de validação na classe de modelo
            if(ModelState.IsValid)
            {
                try
                {
                    var estoque = Mapper.Map<Estoque>(viewModel);
                    repository.Add(estoque); //gravando..

                    //retornar para o cliente um status de sucesso 200
                    return Request.CreateResponse(HttpStatusCode.OK,
                                "Estoque cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    //retornar para o cliente um status de erro 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                            "Ocorreu um erro: " + e.Message);
                }
            }
            else
            {
                //retornar para o cliente um status de erro 400
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                            ValidationUtil.GetErrorMessages(ModelState));
            }
        }

        [HttpPut] //requisições PUT
        [Route("atualizar")] //URL: /api/estoque/atualizar
        public HttpResponseMessage Put(EstoqueEdicaoViewModel viewModel)
        {
            //verificar se não há erros de validação na classe de modelo
            if (ModelState.IsValid)
            {
                try
                {
                    var estoque = Mapper.Map<Estoque>(viewModel);
                    repository.Update(estoque); //atualizando..

                    //retornar para o cliente um status de sucesso 200
                    return Request.CreateResponse(HttpStatusCode.OK,
                                "Estoque atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    //retornar para o cliente um status de erro 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                            "Ocorreu um erro: " + e.Message);
                }
            }
            else
            {
                //retornar para o cliente um status de erro 400
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                            ValidationUtil.GetErrorMessages(ModelState));
            }
        }

        [HttpDelete] //requisições DELETE
        [Route("excluir")] //URL: /api/estoque/excluir?id={0}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //buscar o estoque pelo id
                var estoque = repository.FindById(id);

                //verificar se o Estoque foi encontrado
                if(estoque != null)
                {
                    repository.Remove(estoque); //excluindo..

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Estoque excluído com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Estoque não encontrado.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpGet] //requisições GET
        [Route("consultar")] //URL: /api/estoque/consultar
        [ResponseType(typeof(List<EstoqueConsultaViewModel>))]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lista = new List<EstoqueConsultaViewModel>();

                foreach(var estoque in repository.FindAll())
                {
                    lista.Add(Mapper.Map<EstoqueConsultaViewModel>(estoque));
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpGet] //requisições GET
        [Route("obter")] //URL: /api/estoque/obter?id={0}
        [ResponseType(typeof(EstoqueConsultaViewModel))]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                //buscar o estoque pelo id..
                var estoque = repository.FindById(id);

                if(estoque != null) //verificando se o estoque foi encontrado..
                {
                    var model = Mapper.Map<EstoqueConsultaViewModel>(estoque);

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Estoque não encontrado.");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Ocorreu um erro: " + e.Message);
            }
        }
    }
}

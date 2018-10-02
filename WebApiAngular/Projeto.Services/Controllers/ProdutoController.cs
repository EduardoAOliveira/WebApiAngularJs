using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Services.ViewModels;
using System.Web.Http.Description;
using Projeto.Data.Contracts;
using AutoMapper;
using Projeto.Entities;
using Projeto.Services.Utils;

namespace Projeto.Services.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        //atributo
        private readonly IProdutoRepository repository;

        //construtor com entrada de argumentos (SimpleInjector)
        public ProdutoController(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost] //requisições POST
        [Route("cadastrar")] //URL: /api/produto/cadastrar
        public HttpResponseMessage Post(ProdutoCadastroViewModel viewModel)
        {
            //verificar se não há erros de validação na classe de modelo
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(viewModel);
                    repository.Add(produto); //gravando..

                    //retornar para o cliente um status de sucesso 200
                    return Request.CreateResponse(HttpStatusCode.OK,
                                "Produto cadastrado com sucesso.");
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

        [HttpPut] //requisições PUT
        [Route("atualizar")] //URL: /api/produto/atualizar
        public HttpResponseMessage Put(ProdutoEdicaoViewModel viewModel)
        {
            //verificar se não há erros de validação na classe de modelo
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = Mapper.Map<Produto>(viewModel);
                    repository.Update(produto); //atualizando..

                    //retornar para o cliente um status de sucesso 200
                    return Request.CreateResponse(HttpStatusCode.OK,
                                "Produto atualizado com sucesso.");
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
        [Route("excluir")] //URL: /api/produto/excluir?id={0}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //buscar o Produto pelo id
                var produto = repository.FindById(id);

                //verificar se o Produto foi encontrado
                if (produto != null)
                {
                    repository.Remove(produto); //excluindo..

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Produto excluído com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Produto não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpGet] //requisições GET
        [Route("consultar")] //URL: /api/produto/consultar
        [ResponseType(typeof(List<ProdutoConsultaViewModel>))]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lista = new List<ProdutoConsultaViewModel>();

                foreach (var produto in repository.FindAll())
                {
                    lista.Add(Mapper.Map<ProdutoConsultaViewModel>(produto));
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Ocorreu um erro: " + e.Message);
            }
        }

        [HttpGet] //requisições GET
        [Route("obter")] //URL: /api/produto/obter?id={0}
        [ResponseType(typeof(ProdutoConsultaViewModel))]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                //buscar o Produto pelo id..
                var produto = repository.FindById(id);

                if (produto != null) //verificando se o Produto foi encontrado..
                {
                    var model = Mapper.Map<ProdutoConsultaViewModel>(produto);

                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Produto não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Ocorreu um erro: " + e.Message);
            }
        }
    }
}

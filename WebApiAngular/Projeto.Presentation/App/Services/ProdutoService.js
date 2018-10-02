app.service('$produtoService',
    function ($http) {

        //URL da api..
        var urlBase = "http://localhost:57010/api/produto";

        //variavel JSON para armazenar as funções que
        //irão acessar os serviços da API de estoque..
        var produtoService = {};

        //criando funções para acessar cada serviço da API..
        produtoService.cadastrar = function (model) {
            return $http.post(urlBase + "/cadastrar", model);
        };

        produtoService.atualizar = function (model) {
            return $http.put(urlBase + "/atualizar", model);
        };

        produtoService.excluir = function (id) {
            return $http.delete(urlBase + "/excluir?id=" + id);
        };

        produtoService.consultar = function () {
            return $http.get(urlBase + "/consultar");
        };

        produtoService.obter = function (id) {
            return $http.get(urlBase + "/obter?id=" + id);
        };

        //retornando..
        return produtoService;
    });
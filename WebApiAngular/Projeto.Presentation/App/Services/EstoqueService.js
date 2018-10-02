app.service('$estoqueService',
    function ($http) {

        //URL da api..
        var urlBase = "http://localhost:57010/api/estoque";

        //variavel JSON para armazenar as funções que
        //irão acessar os serviços da API de estoque..
        var estoqueService = {};

        //criando funções para acessar cada serviço da API..
        estoqueService.cadastrar = function (model) {
            return $http.post(urlBase + "/cadastrar", model);
        };

        estoqueService.atualizar = function (model) {
            return $http.put(urlBase + "/atualizar", model);
        };

        estoqueService.excluir = function (id) {
            return $http.delete(urlBase + "/excluir?id=" + id);
        };

        estoqueService.consultar = function () {
            return $http.get(urlBase + "/consultar");
        };

        estoqueService.obter = function (id) {
            return $http.get(urlBase + "/obter?id=" + id);
        };

        //retornando..
        return estoqueService;
    });
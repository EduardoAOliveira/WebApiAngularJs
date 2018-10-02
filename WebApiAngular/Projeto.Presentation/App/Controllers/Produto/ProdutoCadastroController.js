app.controller('produtoCadastroController',
    function ($scope, $produtoService, $estoqueService) {

        //objeto JSON para cadastro de produto
        $scope.produto = {
            Nome: '',
            Preco: '',
            Quantidade: '',
            IdEstoque: ''
        }

        //função para exibir os estoques..
        $scope.consultarEstoques = function () {

            $estoqueService.consultar()
                .then(function (result) {
                    //guardar o retorno da API..
                    $scope.estoques = result.data;
                })
                .catch(function (e) {
                    $scope.mensagem = e.data;
                });
        };

        //função executada para cadastrar produto..
        $scope.cadastrar = function () {

            //imprimir mensagem..
            $scope.mensagem = "Processando requisição...";

            //executar o serviço da API..
            $produtoService.cadastrar($scope.produto)
                .then(function (result) { //promisse

                    $scope.mensagem = result.data;

                    $scope.produto.Nome = '';
                    $scope.produto.Preco = '';
                    $scope.produto.Quantidade = '';
                    $scope.produto.IdEstoque = '';

                    $scope.erros = {};

                    $scope.consultarEstoques();
                })
                .catch(function (e) { //promisse

                    if (e.status == 400) { //BadRequest
                        $scope.erros = e.data;
                        $scope.mensagem = '';
                    }
                    else if (e.status == 500) { //InternalServerError
                        $scope.mensagem = e.data;
                    }
                })
                .finally(function () {

                });
        };

    });
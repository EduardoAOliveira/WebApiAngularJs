app.controller('estoqueCadastroController',
    function ($scope, $estoqueService) {
        
        //objeto JSON que será utilizado na requisição de 
        //cadastro de estoques da API..
        $scope.estoque = {
            Nome: ''
        };

        //função executada para cadastrar estoque..
        $scope.cadastrar = function () {

            //imprimir mensagem..
            $scope.mensagem = "Processando requisição...";

            //executar o serviço da API..
            $estoqueService.cadastrar($scope.estoque)
                .then(function (result) { //promisse
                    $scope.mensagem = result.data;
                    $scope.estoque.Nome = '';
                    $scope.erros = {};
                })
                .catch(function (e) { //promisse

                    if (e.status == 400){ //BadRequest
                        $scope.erros = e.data;
                        $scope.mensagem = '';
                    }
                    else if (e.status == 500){ //InternalServerError
                        $scope.mensagem = e.data;
                    }
                })
                .finally(function () {
                    
                });
        };
    });
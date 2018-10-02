app.controller('produtoConsultaController',
    function ($scope, $produtoService) {

        //criando uma função para executar o serviço
        //de consulta de produtos na API e retornar os dados..
        $scope.consultar = function () {

            //executar o serviço de consulta na API..
            $produtoService.consultar()
                .then(function (result) { //promisse
                    //guardar a lista de estoques..
                    $scope.produtos = result.data;
                })
                .catch(function (e) { //promisse
                    $scope.mensagem = e.data;
                })
                .finally(function () {

                });
        };

    });